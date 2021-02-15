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

            string file = "movies.csv";
            string input;

            do{

            Console.WriteLine("Enter 1 to view movie library.");
            Console.WriteLine("Enter 2 to add movie record.");
            Console.WriteLine("Enter anything else to quit.");

            input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();

                //Catch and handle FileNotFoundExecption

                try{
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {

                        //read movie file

                        string line = sr.ReadLine();

                        // display library

                        Console.WriteLine(line);


                    }
                    sr.Close();
                }

                catch(FileNotFoundException)
                {
                    Console.WriteLine("File not Found");
                }

                }
            

            else if (input == "2")
            {

                //Catch and handle FileNotFoundExecption

                //TO DO: Check for Duplicate entries

                try
                {

                StreamWriter sw = new StreamWriter(file, append: true);

                // ask questions to fill out movie record
                Console.WriteLine("Please enter a movie ID.");
                string id = Console.ReadLine();

                Console.WriteLine("Please enter a movie title.");
                string title = Console.ReadLine();

                Console.WriteLine("Would you like to add a genre? (Y/N)");
                string resp = Console.ReadLine().ToUpper();

                //write movie entry with up to 3 genres

                if(resp == "Y")
                {

                Console.WriteLine("Please enter a genre");

                ArrayList genre = new ArrayList();
                int i;
                for(i=0; i < 3; i++)
                {
                    string gen = Console.ReadLine();
                    genre.Add(gen);
                    Console.WriteLine("Would you like to add another genre? (Y/N)");
                    string res = Console.ReadLine().ToUpper();
                    if (res != "Y") {break;}
                }

                sw.Write($"{id},{title},");
                foreach(var d in genre)
                {
                    sw.Write("{0}|", d);
                }
                sw.WriteLine();

                }

                //write movie entry with no genre

                if(resp == "N")
                {

                    string ge = "(No genre listed)";
                    sw.WriteLine($"{id},{title},{ge}");

                }

                sw.Close();
                }

                catch(FileNotFoundException)
                {
                    Console.WriteLine("File Not Found");
                }
            
            }
            }while(input == "1" | input == "2");

            Console.Clear();
             logger.Info("Program ended");
        }


    }
}
