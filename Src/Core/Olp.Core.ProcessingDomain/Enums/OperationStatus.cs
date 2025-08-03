namespace Olp.Core.ProcessingDomain.Enums
{
    public enum OperationStatus : byte
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Compensated
    }
}
