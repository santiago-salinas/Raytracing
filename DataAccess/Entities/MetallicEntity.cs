using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MetallicEntity
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
        public int Roughness { get; set; }
    }
}
