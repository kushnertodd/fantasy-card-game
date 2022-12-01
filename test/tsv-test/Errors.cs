using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSV_test
{

    class Errors
    {
        private List<string> errorList = new List<string>();
        public void Add(string error)
        {
            errorList.Add(error);
        }
        public bool Have()
        {
            return errorList.Count > 0;
        }
        public string ToString()
        {
            string text = "";
            foreach (string error in errorList) { text += error + "\n"; }
            return text;
        }
    }
}
