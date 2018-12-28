using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HandlebarsDotNet;
using Newtonsoft.Json.Linq;

namespace Tiver.Fowl.Reporting
{
    public class Report
    {
        public static string Build(string logFilepath, string templateFilepath)
        {
            var template = Handlebars.Compile(File.ReadAllText(templateFilepath));

            var rawLog = ReadLogFile(logFilepath);
            var testsData = rawLog
                .GroupBy(l => Tuple.Create(
                    l["Properties"]["TestId"].Value<string>(),
                    l["Properties"]["TestName"].Value<string>()
                ))
                .ToDictionary(l => l.Key);

            return template(new Dictionary<string,object>()
            {
                {"tests", testsData}
            });
        }

        private static IEnumerable<JObject> ReadLogFile(string logFileFilepath)
        {
            var lines = new List<JObject>();
            using (var fileStream = new FileStream(logFileFilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lines.Add(JObject.Parse(line));
                }
            }

            return lines;
        }
    }
}