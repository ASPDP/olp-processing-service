using Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient;
using Olp.ProcessingService.Core.Contracts.Commands;
using Olp.ProcessingService.Core.Contracts.Commands.CreateProposal;
using Olp.ProcessingService.Core.Domain.Entities;
using Olp.ProcessingService.Core.Domain.Enums;
using Olp.ProcessingService.Repositories.Abstractions;
using Olp.ProcessingService.Services.Abstractions;
using Olp.ProcessingService.Services.Abstractions.Clients;
using Olp.ProcessingService.WebApi.EventBus.Events;
using Olp.RabbitMqTools.Infrastructure.EventBus.Services;

namespace Olp.ProcessingService.Services.Implementation
{
    public class OperationService(
        IProposalServiceClient proposalServiceClient,
        IUnitOfWork unitOfWork,
        IEventBusService eventBusService
    ) : IOperationService
    {
        #region CreateProposal command

        private async Task<CreateProposalCommandResult> CreateProposalAsync(Guid userId, BaseCommand command)
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
                });
                var prepareProposalOperationStep = await uow.OperationStepRepository.AddAsync(new OperationStep
                {
                    OperationId = operation.Id,
                    Name = "PrepareProposal",
                    Status = OperationStepStatus.Pending,
                    StartedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                });

                var createProposalResponse = await proposalServiceClient.CreateProposalAsync(new CreateProposalRequest
                {
                    Command = new CreateProposalCommand { Name = command.Name },
                    OperationStepId = prepareProposalOperationStep.Id,
                });

                prepareProposalOperationStep.Status = OperationStepStatus.Succeeded;
                uow.OperationStepRepository.Update(prepareProposalOperationStep);

                operation.Status = OperationStatus.Processing;
                uow.OperationRepository.Update(operation);

                var hasUserPermissionOperationStep = await uow.OperationStepRepository.AddAsync(new OperationStep
                {
                    OperationId = operation.Id,
                    Name = "HasUserPermission",
                    Status = OperationStepStatus.Pending,
                    StartedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                });

                eventBusService.SendEvent(new HasUserPermissionEvent("HasUserPermission"));

                hasUserPermissionOperationStep.Status = OperationStepStatus.Processing;
                uow.OperationStepRepository.Update(hasUserPermissionOperationStep);

                return new CreateProposalCommandResult
                {
                    Operation = new()
                    {
                        Id = operation.Id,
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

        public async Task<BaseCommandResult> ExecCommandAsync(Guid userId, BaseCommand commandModel)
        {
            var result = commandModel.Name switch
            {
                string commandName when commandName == KnownCommands.CreateProposal.Name => 
                    await CreateProposalAsync(userId, commandModel),
                _ => throw new NotSupportedException()
            };

            return new()
            {
                Command = commandModel,
                Result = result
            };
        }

        #endregion
    }
}
