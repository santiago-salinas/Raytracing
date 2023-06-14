using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime? LastRenderDate { get; set; }
        // public PPM Preview { get; set; }
        public ICollection<PositionedModelEntity> PositionedModels { get; set; }
        public CameraEntity CameraDTO { get; set; }
        public bool Blur { get; set; }
        public PPMEntity PPMEntity { get; set; }

        public static Scene FromEntity(SceneEntity entity)
        {
            List<PositionedModel> posModels = new List<PositionedModel>();

            foreach (PositionedModelEntity elem in entity.PositionedModels)
            {
                PositionedModel newPosModel = new PositionedModel()
                {
                    Model = ModelEntity.FromEntity(elem.Model),
                    Position = new Vector(elem.PositionX, elem.PositionY, elem.PositionZ),
                };

                posModels.Add(newPosModel);
            }

            PPM ppm = null;
            if (entity.PPMEntity != null)
            {
                ppm = PPMEntity.FromEntity(entity.PPMEntity);
            }

            Scene ret = new Scene()
            {
                Name = entity.Name,
                Owner = entity.OwnerId,
                CreationDate = (DateTime)entity.CreationDate,
                LastModificationDate = (DateTime)entity.LastModificationDate,
                LastRenderDate = (DateTime)entity.LastRenderDate,
                CameraDTO = CameraEntity.FromEntity(entity.CameraDTO),
                Blur = entity.Blur,
                PositionedModels = posModels,
                Preview = ppm

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

            PPMEntity ppm = null;
            if (scene.Preview != null)
            {
                ppm = PPMEntity.FromDomain(scene.Preview);
            }

            SceneEntity ret = new SceneEntity()
            {
                Name = scene.Name,
                OwnerId = scene.Owner,
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderDate = scene.LastRenderDate,
                CameraDTO = CameraEntity.FromDomain(scene.CameraDTO),
                Blur = scene.Blur,
                PositionedModels = posModelsEntities,
                PPMEntity = ppm
            };

            return ret;
        }
    }
}
