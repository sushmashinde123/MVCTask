using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask.Models
{
    public class EmployeeModel
    {
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string email_Address { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
    }
}