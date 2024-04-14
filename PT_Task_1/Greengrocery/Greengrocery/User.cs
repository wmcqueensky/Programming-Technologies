using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class User
    {
        private string surname;
        private string name;
        private int phone;
        private string email;

        public User(string surname, string name, int phone, string email)
        {
            this.surname = surname;
            this.name = name;
            this.phone = phone;
            this.email = email;
        }

        public string getSurname()
        {
            return this.surname;
        }

        public void setSurname(string value)
        {
            this.surname = value;
        } 

        public string getName()
        {
            return this.name;
        }

        public void setName(string value)
        {
            this.name = value;
        }

        public int getPhone() { 
            return this.phone;
        }

        public void setPhone(int value) { 
            this.phone = value;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setEmail(string value) {
            this.email = value;
        }
    }
}
