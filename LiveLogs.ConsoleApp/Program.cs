using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace LiveLogs.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console sizing can cause exceptions if you are using a 
            // small monitor. Change as required.

            Console.SetWindowSize(152, 58);
            Console.BufferHeight = 1500;

            string filePath = ConfigurationManager.AppSettings["MonitoredTextFilePath"];

            Console.Title = string.Format("Live Logs {0}", filePath);

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            // Move to the end of the stream so we do not read in existing
            // log text, only watch for new text.

            fileStream.Position = fileStream.Length;

            StreamReader streamReader;

            // Commented lines are for duplicating the log output as it's written to 
            // allow verification via a diff that the contents are the same and all 
            // is being output.

            // var fsWrite = new FileStream(@"C:\DuplicateFile.txt", FileMode.Create);
            // var sw = new StreamWriter(fsWrite);

            int rowNum = 0;

            while (true)
            {
                streamReader = new StreamReader(fileStream);

                string line;
                string rowStr;

                while (streamReader.Peek() != -1)
                {
                    rowNum++;

                    line = streamReader.ReadLine();
                    rowStr = rowNum.ToString();

                    string output = String.Format("{0} {1}:\t{2}", rowStr.PadLeft(6, '0'), DateTime.Now.ToLongTimeString(), line);

                    Console.WriteLine(output);

                    // sw.WriteLine(output);
                }

                // sw.Flush();

                Thread.Sleep(500);
            }
        }
    }
}
