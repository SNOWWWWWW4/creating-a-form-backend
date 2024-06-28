using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creating_a_form_backend.Models
{
    public class Form_UserModels
    {
        public int ID { get; set; }
        public string Email_Username { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        public Form_UserModels()
        {

        }
    }
}