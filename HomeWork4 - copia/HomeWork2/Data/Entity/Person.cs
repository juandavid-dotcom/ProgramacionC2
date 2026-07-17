using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeWork2.Data.Entity
{
    public class Person
    {

        
        public int ids { get; set; }

        public string names { get; set; }

        public string lastnames { get; set; }

        public string emails { get; set; }

        public string addresses { get; set; }

        public int ages { get; set; }

        public string descriptions { get; set; }

        public double weights { get; set; }

        public string statuses { get; set; }

    }
}

