using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class SphereEntity
    {
        [Key]
        [Column(Order = 1)]
        public string NameID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Owner { get; set; }
        public int Radius { get; set; }
    }
}
