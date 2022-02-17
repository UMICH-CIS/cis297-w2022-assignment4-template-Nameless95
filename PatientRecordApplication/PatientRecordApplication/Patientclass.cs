using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;

namespace PatientRecordApplication
{
    /// <summary>
    /// purpose of this class is to get user input and put into file that will be used to read latter
    /// </summary>
    class Patientfilereadin
    {
        ArrayList tracker = new ArrayList();

        public const string FILENAME = "Data.txt";

        /// <summary>
        /// purpose of this function is to get user input and put into file that will be used to read latter
        /// </summary>
        public void SerializableDemonstration()
        {
            const int END = 999;

            Patientclass emp = new Patientclass();
            FileStream outFile = new FileStream(FILENAME,
               FileMode.Create, FileAccess.Write);
            BinaryFormatter bFormatter = new BinaryFormatter();
            Write("Enter a patient id number or " + END +
               " to quit >> ");
            emp.idNum = Convert.ToInt32(ReadLine());
            tracker.Add(emp.idNum);
            while (emp.idNum != END)
            {
                try
                {
                    Write("Enter last name >> ");
                    emp.name = ReadLine();
                    Write("Enter balance >> ");
                    emp.balanceowed = Convert.ToDouble(ReadLine());
                    bFormatter.Serialize(outFile, emp);
                    Write("Enter employee number or " + END +
                       " to quit >> ");
                    emp.idNum = Convert.ToInt32(ReadLine());
                    foreach (int elements in tracker)
                    {
                        if (emp.idNum == elements)
                            throw (new duplicateEmployeeID("expection id number has already been used please enter a valid id number"));
                    }
                }
                catch (duplicateEmployeeID x)
                {

                    Console.WriteLine(x.Message.ToString());
                    emp.idNum = Convert.ToInt32(ReadLine());

                }
                catch (FormatException) {
                    Console.WriteLine("formating expection thrown error program will exit to window apps");
                    emp.idNum = 999;

                }
                catch (Exception)
                {
                    Console.WriteLine("expection thrown error program will allow no new input");
                    emp.idNum = 999;
                }
                finally { }




            }
            outFile.Close();

        }

    }


    /// <summary>
    /// stores info that user is entering
    /// </summary>
    [Serializable]
    class Patientclass
    {
        public int idNum { get; set; }
        public string name { get; set; }
        public double balanceowed { get; set; }
    }


}