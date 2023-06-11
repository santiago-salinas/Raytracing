﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DataAccess.Entities
{
    public class PositionedModelEntity
    {
        [Key]
        public Guid Id { get; set; }

        public ModelEntity Model { get; set; }

        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }


        public static PositionedModel FromEntity(PositionedModelEntity entity)
        {
            Vector position = new Vector(entity.PositionX, entity.PositionY, entity.PositionZ);

            PositionedModel positionedModel = new PositionedModel()
            {
                Model = ModelEntity.FromEntity(entity.Model),
                Position = position
            };

            return positionedModel;
        }

        public static PositionedModelEntity FromDomain(PositionedModel positionedModel, EFContext efContext)
        {
            Vector position = positionedModel.Position;
            PositionedModelEntity ret = new PositionedModelEntity()
            {
                Id = Guid.NewGuid(),
                Model = ModelEntity.FromDomain(positionedModel.Model,efContext),
                PositionX = position.FirstValue,
                PositionY = position.SecondValue,
                PositionZ = position.ThirdValue,

            };

            return ret;
        }
    }
}