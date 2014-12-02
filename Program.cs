using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephonebook
{
    class Program
    {
        static void AddContant()
        {
            bool flag = true;
            Console.Write("Create a new contact. Enter name:");
            string s = Console.ReadLine();
            string number;
            Console.Write("Enter phone number (+XXX XX XXX XXXX):");

            double numbrdoub;
            while (flag)
            {
                number = Console.ReadLine();
                bool num = Double.TryParse(number, out numbrdoub);
                if (num)
                {
                    flag = false;
                    Console.Write("Ready to add contact. Name: " + s + " Phone number:" + number + " . Confirm: press 1, cancel: press 2: ");
                    string i = Console.ReadLine();
                    if (i == "1")
                    {
                        Console.WriteLine("New contact " + s + " added");
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter("Telephonebook.txt", true))
                        {
                            string line = s + " " + number;
                            file.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cancel");
                    }

                }
                else
                {
                    Console.Write("Wrong phone number. It should be (+XXX XX XXX XXXX): ");
                }
            }
        }
        static void FindFirstName()
        {
            Console.Write("Write word for find:");
            string word = Console.ReadLine().ToUpper();
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
            bool finded = false;
            foreach (string s_each in lines)
            {
                string s = s_each.ToUpper();
                string sub = "";
                int i = 0;
                while (s[i] == ' ' && i<s.Length) i++;
                int k = 0;
                while (s[i + k] != ' ' && (i+k) < s.Length)
                {
                    sub += s[i + k];
                    k++;
                }
                int a = sub.IndexOf(word);
                if (a != -1)
                {
                    finded = true;
                    Console.WriteLine(lines[count]);
                }
                count++;
            }
            if (!finded)
            {
                Console.WriteLine("Information not found");
            }
        }
        static void FindLastName()
        {

            Console.Write("Write word for find:");
            string word = Console.ReadLine().ToUpper();
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
            bool finded = false;
            foreach (string s_each in lines)
            {
                string s = s_each.ToUpper();
                string sub = "";
                int i = 0;
                while (s[i] == ' ' && i < s.Length) i++;
                while (s[i] != ' ' && i < s.Length) i++;
                while (s[i] == ' ' && i < s.Length) i++;
                int k = 0;
                while (s[i + k] != ' ' && (i + k) < s.Length)
                {
                    sub += s[i + k];
                    k++;
                }
                int a = sub.IndexOf(word);
                if (a != -1)
                {
                    finded = true;
                    Console.WriteLine(lines[count]);
                }
                count++;
            }
            if (!finded)
            {
                Console.WriteLine("Information not found");
            }
        }
        static int ReadALLContants()
        {
            string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
            int count = 1;
            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of Telephone book = ");
            foreach (string line in lines)
            {
                //string s = line.ToUpper();
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + count + "." + line);
                count++;
            }
            return count;
        }
        static void FindPhoneNumber()
        {

            Console.Write("Write number for find:");
            string word = Console.ReadLine().ToUpper();
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
            bool finded = false;
            foreach (string s_each in lines)
            {
                string s = s_each.ToUpper();
                string sub = "";
                int i = 0;
                while (s[i] == ' ' && i < s.Length) i++;
                while (s[i] != ' ' && i < s.Length) i++;
                while (s[i] == ' ' && i < s.Length) i++;
                while (s[i] != ' ' && i < s.Length) i++;
                while (s[i] == ' ' && i < s.Length) i++;
                int k = 0;
                while (s[i + k] != ' ')
                {
                    sub += s[i + k];
                    k++;
                    if ((i + k) >= s.Length)
                        break;
                }
                int a = sub.IndexOf(word);
                if (a != -1)
                {
                    finded = true;
                    Console.WriteLine(lines[count]);
                }
                count++;
            }
            if (!finded)
            {
                Console.WriteLine("Information not found");
            }
        }
        static void Delete()
        {
         int count=ReadALLContants();
         int numbrdoub;
            Console.Write("Choose number of contact that will be remove:");
           string number = Console.ReadLine();
           bool num = Int32.TryParse(number, out numbrdoub);
           if (numbrdoub > count)
           {
               Console.WriteLine("You choose wrong number");
           }
           if (num)
           {
               int counter = 1;
               string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
               using (System.IO.StreamWriter file = new System.IO.StreamWriter("Telephonebook.txt"))
               {
               }
               // Display the file contents by using a foreach loop.
               foreach (string line in lines)
               {
                   if (numbrdoub == counter)
                   {
                   }
                   else
                   {
                       using (System.IO.StreamWriter file = new System.IO.StreamWriter("Telephonebook.txt", true))
                       {
                           file.WriteLine(line);
                       }
                   }
                   counter++;

               }
           }
           else
           {
               Console.WriteLine("You write wrong symbols");
           }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the phonebook.");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter one of the following actions: ");
                Console.WriteLine("1. list all contacts");
                Console.WriteLine("2. add a contact");
                Console.WriteLine("3. remove a contact");
                Console.WriteLine("4. find contact by first name");
                Console.WriteLine("5. find contact by last name");
                Console.WriteLine("6. find contact by number ");
                Console.WriteLine("7. exit");
                Console.Write("Enter your action:");
                string s = (Console.ReadLine());
                switch (s)
                {
                    case "1": int i = ReadALLContants(); break;
                    case "2": AddContant(); Console.ReadLine(); break;
                    case "3": Delete(); break;
                    case "4": FindFirstName(); break;
                    case "5": FindLastName(); break;
                    case "6": FindPhoneNumber(); break;
                    case "7": Console.WriteLine("BY"); flag = false; break;
                    default: Console.WriteLine("You choose wrong menu"); break;

                }
            }
            Console.ReadLine();

        }
    }
}
