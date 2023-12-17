using System;
using System.Diagnostics;

namespace StartUp
{
    internal class Program
    {
        static string FormatTime(TimeSpan ts)
        {
            string elapsedTime;
            
            if (ts.Hours < 1)
            {
                elapsedTime = String.Format("{0:00}:{1:00}",
                ts.Minutes, ts.Seconds);
            }
            else
            {
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
            }

            return "Runtimie: " + elapsedTime;
        }
        static string SessionTime()
        {
            string command = Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Stopwatch started");

            while (command != "stop")
            {
                command = Console.ReadLine();
            }

            stopwatch.Stop();
            Console.WriteLine("Stopwatch stopped");

            TimeSpan stopwatchTime = stopwatch.Elapsed;
            
            return FormatTime(stopwatchTime) + "s";
        }

        static void ReadFile ()
        {
            var reader = new StreamReader("C:/Users/Asus/Desktop/Focus times.txt");
            using (reader)
            {
                int counter = 1;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    Console.WriteLine(counter++ + ". " + line);
                }
            }
        }

        static void WriteInFile (string text)
        {
            
            File.AppendAllText("C:/Users/Asus/Desktop/Focus times.txt", text + Environment.NewLine);

            
        }

        //static bool 


        static void Main(string[] args)
        {
            string elapsedTime = SessionTime();

            WriteInFile(elapsedTime);

            ReadFile();
            Console.WriteLine("Done reading");

            // To Do: function which compares the current session time with the record time

        }

    }
}
