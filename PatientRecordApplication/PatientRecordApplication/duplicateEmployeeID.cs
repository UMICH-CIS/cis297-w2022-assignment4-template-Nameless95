using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{

    /// <summary>
    /// purpsoe of this class is to provide expection when user trys to enter id that has already been entered
    /// </summary>
    [Serializable]
    class duplicateEmployeeID: Exception
    {
       public duplicateEmployeeID(string message) : base(message) { }


    }
}
