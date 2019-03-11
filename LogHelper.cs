using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Commission
{
    class LogHelper
    {
        public static void WriteLog(Level level, string msg)
        {
            StackTrace trace = new StackTrace();
            string typeName = trace.GetFrame(1).GetMethod().DeclaringType.ToString();
            //trace.GetFrame(1).GetMethod().ToString();  //方法名
            log4net.ILog log = log4net.LogManager.GetLogger(typeName);

            switch (level)
            {
                case Level.FATAL:
                    log.Fatal(msg);
                    break;

                case Level.ERROR:
                    log.Error(msg);
                    break;

                case Level.WARN:
                    log.Warn(msg);
                    break;

                case Level.INFO:
                    log.Info(msg);
                    break;

                case Level.DEBUG:
                    log.Debug(msg);
                    break;

                default:
                    break;
            }
        }
    }

    enum Level
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}
