using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
        public ICollection<PositionedModelEntity> PositionedModels { get; set; }
        public BLCameraDTO CameraDTO { get; set; }
        public bool Blur { get; set; }

        public static Scene FromEntity(SceneEntity entity)
        {
            List<PositionedModel> posModels = new List<PositionedModel>();

            foreach(PositionedModelEntity elem in entity.PositionedModels)
            {
                PositionedModel newPosModel = new PositionedModel()
                {
                    Model = ModelEntity.FromEntity(elem.Model),
                    Position = new Vector(elem.PositionX, elem.PositionY, elem.PositionZ),
                };

                posModels.Add(newPosModel);
            }

            Scene ret = new Scene()
            {
                Name = entity.Name,
                Owner = entity.OwnerId,
                CreationDate = entity.CreationDate,
                LastModificationDate = entity.LastModificationDate,
                LastRenderDate = entity.LastRenderDate,
                CameraDTO = entity.CameraDTO,
                Blur = entity.Blur,
                PositionedModels = posModels
            };
            return ret;
        }

        public static SceneEntity FromDomain(Scene scene, EFContext efContext)
        {
            ICollection<PositionedModelEntity> posModelsEntities = new List<PositionedModelEntity>();

            foreach (PositionedModel elem in scene.PositionedModels)
            {
                Vector position = elem.Position;
                PositionedModelEntity newPosModelEntity = new PositionedModelEntity()
                {
                    Id = Guid.NewGuid(),
                    Model = ModelEntity.FromDomain(elem.Model, efContext),
                    PositionX = position.FirstValue,
                    PositionY = position.SecondValue,
                    PositionZ = position.ThirdValue,

                };

                posModelsEntities.Add(newPosModelEntity);
            }

            SceneEntity ret = new SceneEntity() { 
                Name = scene.Name,
                OwnerId = scene.Owner,
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderDate = scene.LastRenderDate,
                CameraDTO = scene.CameraDTO,
                Blur = scene.Blur,
                PositionedModels = posModelsEntities
            };

            return ret;
        }
    }
}
