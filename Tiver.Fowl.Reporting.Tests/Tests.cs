using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Tiver.Fowl.Reporting.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ReportContentIsNotEmpty()
        {
            string GetFilepath(string f) =>
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", f);

            var reportContent = Report.Build(
                GetFilepath("./in/cockatiel_log.txt"),
                GetFilepath("./ReportTemplates/simple.hbs")
            );
            
            Assert.IsTrue(!string.IsNullOrEmpty(reportContent));
        }
    }
}