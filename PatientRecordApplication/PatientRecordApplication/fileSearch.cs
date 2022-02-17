using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PatientRecordApplication
{
    /// <summary>
    /// class is resonible for serachign file for specific id
    /// </summary>
    class fileSearch
    {

        /// <summary>
        /// find id get user input and proceeds to search file for id if id found prints out specific patient info 
        /// </summary>
        //searches for employee of a specific id than prints it out
       public  void FindID()
        {
            const int END = 999;
            const string FILENAME = "Data.txt";
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            BinaryFormatter bFormatter = new BinaryFormatter();
            int id;
            try
            {
                Write("Enter id number to find or " +
                   END + " to quit >> ");
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) {
                Console.WriteLine("format expection thrown please enter an int");
     id = Convert.ToInt32(Console.ReadLine());

            }

            while (id != END)
            {
                try
                {
                    WriteLine("\n{0,-5}{1,-12}{2,8}\n",
                       "ID", "Name", "Balance");
                    inFile.Seek(0, SeekOrigin.Begin);

                    while (inFile.Position < inFile.Length)
                    {
                        emp = (Patientclass)bFormatter.Deserialize(inFile);
                        if (emp.idNum == id)
                        {
                            WriteLine("{0,-5}{1,-12}{2,8}",
                        emp.idNum, emp.name, emp.balanceowed.ToString("C"));
                            break;
                        }
                    }
                    Write("\nEnter an ID number to find or " +
                       END + " to quit >> ");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("format expection thrown please enter an int");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("expection thrown error program will allow no new input and is prompty exiting");
                    id = 999;

                }
                finally { }

            }
            inFile.Close(); //these two statements are reversed
        }

    }
}
