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
    ///   //searches for mininim balances owe and dispalys all that are greater than or equal
    /// </summary>
    class grabPatientData
    {

        /// <summary>
        ///   //searches for mininim balances owe and dispalys all that are greater than or equal
        /// </summary>

        public void Findbalanceorgreater()
        {
            const int END = 999;
            const string FILENAME = "Data.txt";
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            BinaryFormatter bFormatter = new BinaryFormatter();
            double bala;


            try
            {
                Write("Enter minimum balance to find or " +
                   END + " to quit >> ");
                bala = Convert.ToDouble(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("format expection thrown please enter an int");
                bala = Convert.ToDouble(Console.ReadLine());

            }

            while (bala != END)
            {

                try
                {
                    WriteLine("\n{0,-5}{1,-12}{2,8}\n",
                       "ID", "Name", "Balance");
                    inFile.Seek(0, SeekOrigin.Begin);

                    while (inFile.Position < inFile.Length)
                    {
                        emp = (Patientclass)bFormatter.Deserialize(inFile);
                        if (emp.balanceowed >= bala)
                        {
                            WriteLine("{0,-5}{1,-12}{2,8}",
                        emp.idNum, emp.name, emp.balanceowed.ToString("C"));
                        }
                    }
                    Write("\nEnter an ID number to find or " +
                       END + " to quit >> ");
                    bala = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("format expection thrown please enter an int");
                    bala = Convert.ToDouble(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("expection thrown error program will allow no new input and is prompty exiting");
                  bala = 999;

                }
                finally { }



            }
            inFile.Close(); //these two statements are reversed
        }
    }
}
