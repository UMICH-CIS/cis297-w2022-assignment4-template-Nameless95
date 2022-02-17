using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{

    /// <summary>
    /// This program implements patient record and ultizes expectiosn throughout
    /// </summary>
    /// <Student>Jaxon Pecora</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    /// 
    

    
    
    class PatientRecordSystem
    {
        static void Main(string[] args)
        {
            Patientfilereadin x = new Patientfilereadin(); //A
            balanceFileRead z = new balanceFileRead(); //  B
            fileSearch y = new fileSearch(); // C
            grabPatientData w = new grabPatientData(); // D
            x.SerializableDemonstration();
            int check;

            Console.WriteLine("what would you like to do\n1 Read file\n2 find a specific patient information" +
                "\n3 find all patient with specific balance or greater \n type anything else to quit");
            check = Convert.ToInt32(Console.ReadLine());

            while (check >=1 && check <=3) {
                try
                {
                    if (check == 1)
                        z.readfile();
                    else if (check == 2)
                        y.FindID();
                    else if (check == 3)
                        w.Findbalanceorgreater();
                    Console.WriteLine("what would you like to do\n1 Read file\n2 find a specific patient information" +
                "\n3 find all patient with specific balance or greater \n type anything else to quit");
                    check = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(); // something else was typed thus program ends
                    check = 999;
                }
                finally { }
            }
            Console.WriteLine("Have a wonderful day");
            Console.ReadLine();

        }
    }
}
