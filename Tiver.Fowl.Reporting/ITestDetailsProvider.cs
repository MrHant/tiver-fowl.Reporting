namespace Tiver.Fowl.Reporting
{
    public interface ITestDetailsProvider
    {
        string TestName { get; }
        string TestId { get; }
    }
}