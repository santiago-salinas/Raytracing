﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Entities;

namespace DataAccess
{
    public class LambertianEntity
    {
        [Key]
        [ForeignKey(nameof(Material))]
        [Column(Order = 1)]
        public string MaterialName { get; set; }

        [Key]
        [ForeignKey(nameof(Material))]
        [Column(Order = 2)]
        public string MaterialOwnerId { get; set; }

        public MaterialEntity Material { get; set; }
        public int RedValue { get; set; }
        public int GreenValue { get; set; }
        public int BlueValue { get; set; }
    }
}
