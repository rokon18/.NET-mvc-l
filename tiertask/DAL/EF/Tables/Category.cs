﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Category
    {
        public int Id { get; set; }
       
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

    }
}
