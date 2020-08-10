using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aoria
{
    public sealed class Logger
    {
        private static readonly object padlock = new object();
        private static Logger instance = null;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }


        private Logger()
        {
            ConsoleColorList["Info"] = ConsoleColor.Green;
            ConsoleColorList["Warning"] = ConsoleColor.DarkYellow;
            ConsoleColorList["Error"] = ConsoleColor.Red;
            ConsoleColorList["Debug"] = ConsoleColor.Blue;

            Info(String.Format("Created Logger on {0}r.", DateTime.Today.ToString("dd.MM.yyyy")));
            Debug("Game running in DEBUG mode.");
        }
        public void Info(string _message) => LogOutput("Info", _message);
        public void Warning(string _message) => LogOutput("Warning", _message);
        [Conditional("DEBUG")]
        public void Debug(string _message) => LogOutput("Debug", _message);
        public void Error(string _message, int _exitCode = -1)
        {
            LogOutput("Error", _message);
            System.Environment.Exit(_exitCode);
        }

        private static Dictionary<string, ConsoleColor> ConsoleColorList = new Dictionary<string, ConsoleColor>();

        private void LogOutput(string _type, string _message)
        {
            Console.ForegroundColor = ConsoleColorList[_type];
            Console.Write($"{DateTime.Now:hh:mm:ss.ff tt} - " + _type + ": ");
            Console.ResetColor();
            Console.WriteLine(_message);
        }
    }
}
