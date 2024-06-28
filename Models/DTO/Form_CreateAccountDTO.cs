using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creating_a_form_backend.Models.DTO
{
    public class Form_CreateAccountDTO
    {
        public int ID { get; set; }
        public string? Email_Username { get; set; }
        public string? Password { get; set; }
    }
}