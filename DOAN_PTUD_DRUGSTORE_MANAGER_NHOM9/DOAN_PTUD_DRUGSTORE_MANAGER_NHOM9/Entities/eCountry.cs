﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eCountry
    {
        string id, name;

        public eCountry(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public eCountry()
        {
            Id = "";
            Name = "";
        }


        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
