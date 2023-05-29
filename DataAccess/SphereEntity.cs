using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class SphereEntity
    {
        [Key]
        public string NameID { get; set; }
        public string Owner { get; set; }
        public int Radius { get; set; }
    }
}
