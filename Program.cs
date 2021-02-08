using System;
using System.IO;
using NLog.Web;

namespace MovieLibrary_HutsonRyan
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program started");


             logger.Info("Program ended");
        }


    }
}
