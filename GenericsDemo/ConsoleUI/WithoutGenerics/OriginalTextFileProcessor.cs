using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();
            Person person;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            // Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                person = new Person();

                person.FirstName = vals[0];
                person.IsAlive = bool.Parse(vals[1]);
                person.LastName = vals[2];

                output.Add(person);
            }
            return output;
        }

        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry log;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            // Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                log = new LogEntry();

                log.ErrorCode = int.Parse(vals[0]);
                log.Message = vals[1];
                log.TimOfEvent = DateTime.Parse(vals[2]);

                output.Add(log);
            }
            return output;
        }

        public static void SavePeople(List<Person> people, string filePath)
        {
            List<string> lines = new List<string>();

            // Add a header row
            lines.Add("FirstName,IsAlive,LastName");

            foreach (var person in people)
            {
                lines.Add($"{ person.FirstName }, { person.IsAlive }, { person.LastName }");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }

        public static void SaveLogs(List<LogEntry> logs, string filePath)
        {
            List<string> lines = new List<string>();

            // Add a header row
            lines.Add("ErrorCode,Message,TimeOfEvent");

            foreach (var log in logs)
            {
                lines.Add($"{ log.ErrorCode }, { log.Message }, { log.TimOfEvent }");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
