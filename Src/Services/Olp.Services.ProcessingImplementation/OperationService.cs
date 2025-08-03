using EasyNetQ;

using Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;
using Olp.Core.ProcessingContracts.Commands;
using Olp.Core.ProcessingDomain.Entities;
using Olp.Core.ProcessingDomain.Enums;
using Olp.Infrastructure.EventBus.AuthContracts.EventMessages;
using Olp.Repositories.ProcessingAbstractions;
using Olp.Services.ProcessingAbstractions;
using Olp.Services.ProcessingAbstractions.Clients;


namespace Olp.ProcessingService.Services.Implementation;

public class OperationService(
    IBus bus,
    IProposalServiceClient proposalServiceClient,
    IUnitOfWork unitOfWork
) : IOperationService
{
    #region CreateProposal command

    private async Task<CreateProposalCommandResult> CreateProposalAsync(Guid userId, CommandBase command)
    {
        return await unitOfWork.ExecInTransactionAsync(async (uow) =>
        {
            var operation = await uow.OperationRepository.AddAsync(new Operation
            {
                UserId = userId,
                Name = "CreateProposal",
                Status = OperationStatus.Pending,
                StartedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            }) ?? throw new InvalidOperationException("Operation wasn't added.");
            var operationId = operation.Id ?? throw new InvalidOperationException("Unknown Id of Operation.");

            var prepareProposalOperationStep = await uow.OperationStepRepository.AddAsync(new OperationStep
            {
                OperationId = operationId,
                Name = "PrepareProposal",
                Status = OperationStepStatus.Pending,
                StartedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
            });

            var createProposalResponse = await proposalServiceClient.CreateProposalAsync(new CreateProposalRequest
            {
                Command = new(),
                OperationStepId = prepareProposalOperationStep.Id ?? throw new InvalidOperationException("Unknown Id of PrepareProposalOperationStep."),
            });

            prepareProposalOperationStep.Status = OperationStepStatus.Succeeded;
            uow.OperationStepRepository.Update(prepareProposalOperationStep);

            operation.Status = OperationStatus.Processing;
            uow.OperationRepository.Update(operation);

            var hasUserPermissionOperationStep = await uow.OperationStepRepository.AddAsync(new OperationStep
            {
                OperationId = operationId,
                Name = "HasUserPermission",
                Status = OperationStepStatus.Pending,
                StartedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
            });
            var hasUserPermissionOperationStepId = hasUserPermissionOperationStep.Id ?? throw new InvalidOperationException("Unknown Id of HasUserPermissionOperationStep.");

            bus.PubSub.Publish(new HasUserPermissionEvent
            {
                OperationStepId = hasUserPermissionOperationStepId,
                Action = "Command",
                Command = new()
                {
                    Params = new()
                    {
                        UserId = Guid.Parse("a3e3f3e7-3e3f-4e3f-8e3f-3e3f3e3f3e3f"),
                        PermissionName = "createProposal"
                    }
                }
            });

            hasUserPermissionOperationStep.Status = OperationStepStatus.Processing;
            uow.OperationStepRepository.Update(hasUserPermissionOperationStep);

            return new CreateProposalCommandResult
            {
                Operation = new()
                {
                    Id = operationId,
                    Name = operation.Name,
                    Status = operation.Status.ToString()
                },
                Proposal = new()
                {
                    Id = createProposalResponse.Result.Proposal.Id,
                    Status = createProposalResponse.Result.Proposal.Status
                }
            };
        });
        
    }

    #endregion

    #region IOperationService members

    public async Task<CommandBaseResult> ExecCommandAsync(Guid userId, CommandBase command)
    {
        var result = command.Name switch
        {
            string commandName when commandName == KnownCommands.CreateProposal.Name => 
                await CreateProposalAsync(userId, command),
            _ => throw new NotSupportedException()
        };

        return new()
        {
            Command = command,
            Result = result
        };
    }

    #endregion
}
