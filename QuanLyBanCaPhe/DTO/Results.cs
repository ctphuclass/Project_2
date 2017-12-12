using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Results
    {
        public int ResultID { get; set; }
        public string Message { get; set; }
        public Results()
        {
            ResultID = -1;
            Message = "DEFAULTERROR";
        }
    }
}
