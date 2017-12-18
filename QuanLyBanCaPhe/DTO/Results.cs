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
        public int TK_result { get; set; }
        public string TK_Message { get; set; }
        public int Create_result { get; set; }
        public string Create_message { get; set; }
        public Results()
        {
            ResultID = -1;
            Message = "DEFAULTERROR";

            TK_result = -1;
            TK_Message = "DEFAULTERROR";

            Create_result = -1;
            Create_message = "Mã nhân viên không tồn tại";
        }
    }
}
