using System;
using System.Reflection;

namespace TeleNet.OpenClient
{
    public static class ConsoleLogger
    {
        static bool pausePrint = false;
        public enum LogType
        {
            Default = 0,
            Warning = 1,
            Error = 2,
            Info = 3,
            SupperInfo = 4,
        }

        public static void PausePrint(bool? forcePausePrint = null)
        {
            if (forcePausePrint.HasValue)
                pausePrint = forcePausePrint.Value;
            else
            {
                if (pausePrint)
                    pausePrint = false;
                else
                    pausePrint = true;
            }
        }

        public static void Log(string msg, LogType logType = LogType.Default, bool save = false, bool writeLine = true, bool removeTime = false)
        {
            if (!pausePrint)
            {
                Console.ForegroundColor = logType == LogType.Error ? ConsoleColor.Red :
                logType == LogType.Warning ? ConsoleColor.Yellow :
                logType == LogType.SupperInfo ? ConsoleColor.DarkYellow :
                logType == LogType.Info ? ConsoleColor.White : ConsoleColor.DarkGray;

                if (writeLine)
                    Console.WriteLine((removeTime ? "" : (DateTime.Now.ToString("T") + " ")) + msg);
                else
                    Console.Write(msg);

                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            //if (save)
            //    switch (logType)
            //    {
            //        case LogType.Default:
            //            Serilog.Log.Information(msg);
            //            break;
            //        case LogType.Warning:
            //            Serilog.Log.Warning(msg);
            //            break;
            //        case LogType.Error:
            //            Serilog.Log.Error(msg);
            //            break;
            //        case LogType.Info:
            //        case LogType.SupperInfo:
            //            Serilog.Log.Information(msg);
            //            break;
            //        default:
            //            Serilog.Log.Debug(msg);
            //            break;
            //    }
        }

        public static void Debug(string msg, LogType logType = LogType.Default, bool writeLine = true)
        {
#if DEBUG
            Log(msg, logType, false, writeLine);
#else
            if (saveAllLogs)
                Log(msg, logType, true, writeLine);
#endif
        }

        public static void Print(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Type t = obj.GetType(); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            Console.WriteLine("-----\t ObjectName:" + obj.GetType().Name + " \t--------");
            foreach (PropertyInfo p in pi)
            {
                Console.WriteLine(p.Name + " : " + p.GetValue(obj));
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
