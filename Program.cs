using System;
using System.IO;
using NLog.Web;
using System.Collections;

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
            string input;

            do{

            Console.WriteLine("Enter 1 to view movie library.");
            Console.WriteLine("Enter 2 to add movie record.");
            Console.WriteLine("Enter anything else to quit.");

            input = Console.ReadLine();

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
                if(File.Exists(file))
                {

                StreamWriter sw = new StreamWriter(file, append: true);

                // ask questions to fill out movie record
                Console.WriteLine("Please enter a movie ID.");
                string id = Console.ReadLine();

                Console.WriteLine("Please enter a movie title.");
                string title = Console.ReadLine();

                Console.WriteLine("Would you like to add a genre? (Y/N");
                string resp = Console.ReadLine().ToUpper();

                if(resp == "Y")
                {

                Console.WriteLine("Please enter a genre");

                ArrayList genre = new ArrayList();
                int i;
                for(i=0; i < 3; i++)
                {
                    string gen = Console.ReadLine();
                    genre.Add(gen);
                    Console.WriteLine("Would you like to add another genre? Y/N");
                    string res = Console.ReadLine().ToUpper();
                    if (res != "Y") {break;}
                }

                sw.Write($"{id},{title},");
                foreach(var d in genre)
                {
                    sw.Write("{0}|", d);
                }
                sw.WriteLine();
                sw.Close();

                }

                if(resp == "N")
                {

                    string ge = "(No genre listed)";
                    sw.WriteLine($"{id},{title},{ge}");
                    sw.Close();

                }

                //TO DO: handle execption if resp does not equal Y or N


                }

                else
                {
                    Console.WriteLine("File does not exist");
                }



                
                

            }
            }while(input == "1" | input == "2");

            Console.Clear();
             logger.Info("Program ended");
        }


    }
}
