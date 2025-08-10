using EasyNetQ;

using Olp.Core.ProcessingContracts.Commands;
using Olp.Core.ProcessingContracts.Models;
using Olp.Core.ProcessingDomain.Entities;
using Olp.Core.ProcessingDomain.Enums;
using Olp.Core.ProposalContracts.ProposalServiceClient;
using Olp.Infrastructure.EventBus.AuthContracts.EventMessages;
using Olp.Repositories.ProcessingAbstractions;
using Olp.Services.ProcessingAbstractions;
using Olp.Services.ProcessingAbstractions.Clients;


namespace Olp.ProcessingService.Services.Implementation;

public class ProposalOperationService(
    IBus bus,
    IProposalServiceClient proposalServiceClient,
    IUnitOfWork unitOfWork
) : IProposalOperationService
{
    #region CreateProposal command

    private async Task<CreateProposalCommandResult> ExecCreateProposalAsync(Guid userId, CreateProposalCommand command)
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

            var createProposalResponse = await proposalServiceClient.CreateProposalAsync(new PrepareProposalModel
            {
                Command = new()
                {
                    Params = new()
                    {
                        Title = command.Params.Title,
                        Description = command.Params.Description,
                    }
                },
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
                        UserId = userId,
                        PermissionName = "CreateProposal"
                    }
                }
            });

            hasUserPermissionOperationStep.Status = OperationStepStatus.Processing;
            uow.OperationStepRepository.Update(hasUserPermissionOperationStep);

            return new CreateProposalCommandResult
            {
                Success = true,
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

    #region IProposalOperationService implementation

    public async Task<CreateProposalResult> CreateProposalAsync(Guid userId, CreateProposalCommand command)
    {
        try
        {
            var commandResult = await ExecCreateProposalAsync(userId, command);
            return new()
            {
                CommandName = command.Name,
                CommandResult = commandResult
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                CommandName = command.Name,
                CommandResult = new()
                {
                    Success = false,
                    Error = ex.ToString()
                }
            };
        }
    }

    #endregion
}
