using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Contacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Contact List\n");
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.View\n2.Add contact\n3.Update phone number\n" +
                    "4.Delete contact\n5.Search contact by name");
                int selection;
                if(int.TryParse(Console.ReadLine(),out selection))//input was converted 
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Contact contact = new Contact();
                    string firstName = "", lastName = "", phoneNumber = "", name="";
                    DataTable contactList;
                    switch (selection)
                    {
                        case 2:
                        case 3:
                            Console.Write("First name: ");
                            firstName = Console.ReadLine();
                            Console.Write("Last name: ");
                            lastName = Console.ReadLine();
                            Console.Write("Phone number: ");
                            phoneNumber = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("First name: ");
                            firstName = Console.ReadLine();
                            Console.Write("Last name: ");
                            lastName = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            break;
                    }
                    switch (selection)
                    {
                        case 1: contactList = contact.SelectContactsList();
                                PrintTable(contactList);
                            break;
                        case 2:
                            contact.AddContact(lastName, firstName, phoneNumber);
                            break;
                        case 3:
                            contact.UpdatePhoneNumber(lastName, firstName, phoneNumber);
                            break;
                        case 4:
                            contact.DeleteContact(lastName, firstName);
                            break;
                        case 5:
                            contactList = contact.SearchContactByName(name);
                            PrintTable(contactList);
                            break;
                        default: Console.WriteLine("Unvalid selection!"); break;
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }

        static void PrintTable(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.Write(dr[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
