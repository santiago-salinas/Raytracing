using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ModelEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Owner { get; set; }

        public string MaterialName { get; set; }
        public string ShapeName { get; set; }
    }
}
