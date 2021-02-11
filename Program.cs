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

            string file = "ml-latest-small/movies.csv";

            Console.WriteLine("Enter 1 to view movie library.");
            Console.WriteLine("Enter 2 to add movie record.");
            Console.WriteLine("Enter anything else to quit.");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                if(File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {

                        //read movie file

                        string line = sr.ReadLine();
                        string[] arr = line.Split(",");

                        // display library

                        foreach (string s in arr)
                        {
                            Console.WriteLine(s);
                        }


                    }
                }

                else
                {
                    Console.WriteLine("File does not exist");
                }

            }

            else if (input == "2")
            {



            }

             logger.Info("Program ended");
        }


    }
}
