using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creating_a_form_backend.Models.DTO
{
    public class Form_PasswordDTO
    {
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}