﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator_Kursovaya
{
    public class Error
    {
        public int index;
        public int code;
        public string token_type;
        public string token;
        public string location;
    }
}
