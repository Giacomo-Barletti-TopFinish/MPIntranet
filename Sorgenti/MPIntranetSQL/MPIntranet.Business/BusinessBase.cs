using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class BusinessBase
    {
        protected string correggiString(string stringa,int lunghezzaMassima)
        {
            string str = stringa.Trim().ToUpper();
            return str.Length > lunghezzaMassima ? str.Substring(0, lunghezzaMassima) : str;
        }
    }
}
