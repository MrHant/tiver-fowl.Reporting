using System.Collections.Generic;
using System.IO;
using System.Linq;
using HandlebarsDotNet;
using Newtonsoft.Json.Linq;

namespace Tiver.Fowl.Reporting
{
    public class Report
    {
        public static string Build(string logFilepath, string templateFilepath)
        {
            var template = Handlebars.Compile(File.ReadAllText(templateFilepath));

            var log = File.ReadAllLines(logFilepath).Select(JObject.Parse);
            var temp = log.GroupBy(l => l["Properties"]["TestId"].Value<string>());
            var data = temp.ToDictionary(l => l.Key);

            return template(new Dictionary<string,object>()
            {
                {"tests", data}
            });
        }
    }
}