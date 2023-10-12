using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class EmailValidation
    {
        public EmailValidation()
        {
            Regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
        public Regex Regex {get;}

        public bool Validation(string Email)
        {
            return Regex.Match(Email).Success;
        }


    }
}
