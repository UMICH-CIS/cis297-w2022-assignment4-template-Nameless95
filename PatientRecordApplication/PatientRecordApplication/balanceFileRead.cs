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
    /// class purpsoe is to get file info and display it
    /// </summary>
    class balanceFileRead
    {

        public const string FILENAME = "Data.txt";
        
        /// <summary>
        /// function reads out all information from file and displays it to consle for user
        /// </summary>
        public void readfile()
        {
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
       FileMode.Open, FileAccess.Read);
            BinaryFormatter bFormatter = new BinaryFormatter();

            WriteLine("\n{0,-5}{1,-12}{2,8}\n",
               "ID", "Name", " balance");
            while (inFile.Position < inFile.Length)
            {
                emp = (Patientclass)bFormatter.Deserialize(inFile);
                WriteLine("{0,-5}{1,-12}{2,8}",
                   emp.idNum, emp.name, emp.balanceowed.ToString("C"));
            }
            inFile.Close();

        }


    }
}



