using NUnit.Framework.Internal;

namespace Tiver.Fowl.Reporting
{
    public class TestDetailsProviderNUnit : ITestDetailsProvider
    {
        public string TestName => TestExecutionContext.CurrentContext.CurrentTest.Name;

        public string TestId => TestExecutionContext.CurrentContext.CurrentTest.Id;
    }
}