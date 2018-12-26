using Serilog.Core;
using Serilog.Events;

namespace Tiver.Fowl.Reporting
{
    public class TestDetailsEnricher : ILogEventEnricher
    {
        public TestDetailsEnricher(ITestDetailsProvider testDetailsProvider)
        {
            _testDetailsProvider = testDetailsProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty(
                    "TestName",
                    _testDetailsProvider.TestName));
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty(
                    "TestId",
                    _testDetailsProvider.TestId));
        }

        private readonly ITestDetailsProvider _testDetailsProvider;
    }
}