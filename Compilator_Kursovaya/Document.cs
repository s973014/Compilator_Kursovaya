using Compilator_Kursovaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator_kursovaya
{
    public class Document
    {
        public string filename;
        public string full_path;
        public string rtb1_text;
        public List<Error> errors;
        public string rtb3_text;
        public bool saved;
        public bool savedAs;

    }
}
