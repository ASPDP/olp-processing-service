namespace Olp.Core.ProcessingDomain.Enums
{
    public enum OperationStepStatus : byte
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Compensated
    }
}
