using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProg
{
    public class CheckCl
    {
        public bool Class_Check(string text)
        {
            Regex cl = new Regex(@"[^0-9а-еА-Е ]");

            bool check = cl.IsMatch(text);

            if ((check) == true)
            {
                return false;
            }
            else return true;
        }
        public bool Cyr_Check(string text)
        {
            Regex cur = new Regex(@"[^а-яА-ЯёЁ ]");

            bool check = cur.IsMatch(text);

            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Num_Check(string text)
        {
            Regex cur = new Regex(@"[^0-9]");

            bool check = cur.IsMatch(text);

            if (check == true)
            {
                return false;
            }
            else return true;
        }
        public bool Date_Check(string text)
        {
            Regex cur = new Regex(@"[^0-9. ]");

            bool check = cur.IsMatch(text);

            if (check == true)
            {
                return false;
            }
            else return true;
        }
    }
}
