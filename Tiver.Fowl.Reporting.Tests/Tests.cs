using NUnit.Framework;

namespace Tiver.Fowl.Reporting.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var test = Report.Build("./ReportTemplates/simple.hbs");
        }
    }
}