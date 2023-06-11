using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class SceneEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [ForeignKey(nameof(Owner))]
        [Column(Order = 2)]
        public string OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }
        // public PPM Preview { get; set; }
        public List<PositionedModel> PositionedModels { get; set; }
        public BLCameraDTO CameraDTO { get; set; }
        public bool Blur { get; set; }

        public static Scene FromEntity(ModelEntity entity)
        {
            throw new NotImplementedException();
        }

        public static SceneEntity FromDomain(Model model, EFContext efContext)
        {
            throw new NotImplementedException();
        }
    }
}
