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
            bool flag=true;
            Console.Write("Create a new contact. Enter name:");
            string s = Console.ReadLine();
            //string s =st.ToUpper();
            string number;
            Console.Write("Enter phone number (+XXX XX XXX XXXX):");
           
            double numbrdoub ;
            while (flag)
            {
                number = Console.ReadLine();
                bool num = Double.TryParse(number,out numbrdoub);
                if (num)
                {
                    flag = false;
                    Console.Write("Ready to add contact. Name: "+s+" Phone number:"+number+" . Confirm: press 1, cancel: press 2: ");
                   string i= Console.ReadLine();
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
        static void FindName()
        {
        
            Console.Write("Write word for find:");
            string word=Console.ReadLine().ToUpper();
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
            foreach (string line in lines)
            {
                string s = line.ToUpper();
                int i = s.IndexOf(word);
               
                    if (i == -1)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine(line);
                        
                    }
                
            }
            if (count == lines.Length)
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
                Console.WriteLine("\t"+count + "." + line);
                count++;
            }
            return count;
        }
        static void FindbyPhone()
        {
         
            Console.Write("Write number for find:");
            double numbre;
            
            string numb=Console.ReadLine().ToUpper();
            //string word = numb;
            bool num = Double.TryParse(numb, out numbre);
            int count = 0;
            if (num)
            {
                string[] lines = System.IO.File.ReadAllLines("Telephonebook.txt");
                foreach (string line in lines)
                {
                    string s = line.ToUpper();
                    int i = s.IndexOf(numb);

                    if (i == -1)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine(line);

                    }

                }
                if (count == lines.Length)
                {
                    Console.WriteLine("Information not found");
                }
            }
            else
            {
                Console.WriteLine("Wrong symbols");
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
           if (num
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
                Console.WriteLine("4. find contact by name");
                Console.WriteLine("5. find contact by number ");
                Console.WriteLine("6. exit");
                Console.Write("Enter your action:");
                string  s = (Console.ReadLine());
                switch (s)
                {
                    case "1": int i=ReadALLContants(); break;
                    case "2": AddContant(); Console.ReadLine();  break;
                    case "3": Delete(); break;
                    case "4": FindName(); break;
                    case "5": FindbyPhone(); break;
                    case "6": Console.WriteLine("BY"); flag = false; break;
                    default: Console.WriteLine("You choose wrong menu"); break;

                }
            }
            Console.ReadLine();

        }
    }
}
