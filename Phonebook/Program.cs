using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {
            Console.WriteLine("Welcome to Phonebook 2019!");
            Console.WriteLine("Press A to add a phone number.");
            Console.WriteLine("Press V to view your phonebook.");
            Console.WriteLine("Press C to clear your phonebook.");
            Console.WriteLine("Press E to exit.");
            string Selection = Console.ReadLine();

            if (Selection.ToLower() == "a")
            {
                AddMenu();
            }
            else if (Selection.ToLower() == "v")
            {
                Phonebook();
            }
            else if (Selection.ToLower() == "c")
            {
                ClearBook();
            }
            else if (Selection.ToLower() == "e")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("{0} is not valid!", Selection);
                Thread.Sleep(1000);
                Console.Clear();
                MainMenu();
            }
        }
        static void AddMenu()
        {
            Console.Clear();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Phone number: ");
            long number = Convert.ToInt64(Console.ReadLine());
            using (StreamWriter sw = File.AppendText("numbers.txt"))
            {
                sw.WriteLine("Name: " + name + "\nNumber: " + number + "\n");
            }
            Console.Clear();
            MainMenu();
        }
        static void Phonebook()
        {
            Console.Clear();
            string line = "";
            using (StreamReader sr = new StreamReader("numbers.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("Press E to exit.");
            Console.ReadLine();
            Console.Clear();
            MainMenu();
        }
        static void ClearBook()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to clear your phonebook? (Y/N)");
            string Selection = Console.ReadLine();
            if(Selection.ToLower() == "y")
            {
                using (StreamWriter sw = new StreamWriter("numbers.txt"))
                {
                    sw.Write("");
                    sw.Close();
                }
                Console.Clear();
                MainMenu();
            }
            else if (Selection.ToLower() == "n")
            {
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0} is not valid!", Selection);
                Thread.Sleep(1000);
                ClearBook();
            }
        }
    }
}