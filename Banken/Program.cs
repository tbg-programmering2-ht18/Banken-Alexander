using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banken
{ 
   class Program
    {

        static void Main(string[] args)
        {

            string Filename = @"C:\test\mydoc.txt";

            if (!Directory.Exists(@"C:\test\"))
            {
                Directory.CreateDirectory(@"c:\test\");
            }

            List<Customer> list = new List<Customer>();
            int choice = 0;
            int i = 0;

            string filetext = File.ReadAllText(Filename);
            string[] name = filetext.Split(',');
            List<string> list2 = new List<string>(name);

            foreach (string word in list2)
            {
                string Name = list2[i];
                AddCustomer(Name, list);
                i++;
            }


            Console.WriteLine("Välkommen till banken\n");
            while (choice != 7)
            {
                Console.WriteLine("Ange vilket av följande alternativ önskar du göra.\n");

                Console.WriteLine("  1 : Lägga till en användare");
                Console.WriteLine("  2 : Ta bort en användare");
                Console.WriteLine("  3 : Visa alla befintliga användare");
                Console.WriteLine("  4 : Visa saldo för en användare");
                Console.WriteLine("  5 : Gör en insättning för en användare");
                Console.WriteLine("  6 : Gör ett uttag för en användare");
                Console.WriteLine("  7 : Avsluta programmet\n");

                Console.Write("Skriv in ditt tal: ");


                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exeption: " + e.Message);
                    Console.ReadKey();
                }
                switch (choice)
                {
                    case 1:
                        //lägg till en användare
                        Console.Clear();
                        Console.WriteLine("Du valde att lägga till en användare");

                        Console.Write("Ange användarens namn: ");
                        string Name = Console.ReadLine();
                        AddCustomer(Name, list);
                        break;

                    case 2:
                        //ta bort en användare
                        Console.WriteLine("Du valde att ta bort en användare");
                        i = 0;
                        foreach (Customer customer in list)
                        {
                            Console.WriteLine(i + " :" + customer.ShowCustomerName());
                            i++;
                        }
                        Console.WriteLine("Ange nummret för den användare du vill ta bort : ");
                        string deleteIndexString = Console.ReadLine();
                        int deleteIndex = int.Parse(deleteIndexString);
                        list.RemoveAt(deleteIndex);
                        break;

                    case 3:
                        //visa alla användare
                        i = 0;
                        Console.WriteLine("du valde att visa alla användare");
                        foreach (Customer info in list)
                        {
                            i++;
                            Console.WriteLine(i + " :" + info.ShowCustomerName());
                        }
                        break;

                    case 7:
                        //avsluta programmet
                        string mydoc = "";
                        foreach (Customer info in list)
                        {
                            mydoc = mydoc + info.ShowCustomerName() + ",";
                        }
                        File.WriteAllText(Filename, mydoc);
                        break;                
                }
            }

        }


        static void AddCustomer(string Name, List<Customer> list)
        {
            Customer Customer1 = new Customer();
            Customer1.Name = Name;
            list.Add(Customer1);
        }
        static void ReadFile(string Filename)
        {

            Console.WriteLine(File.ReadAllText(Filename));
            Console.WriteLine("again....");
            string[] lines = File.ReadAllLines(Filename);
            foreach (string i in lines)
            {
                Console.WriteLine(i);
            }
        }
    }
}