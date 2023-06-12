﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;

namespace DataTransferObjects
{
    public static class PositionedModelMapper
    {
        public static PositionedModelDTO ConvertPositionedModelToDTO(PositionedModel positionedModel)
        {
            PositionedModelDTO positionedModelDTO = new PositionedModelDTO()
            {
                ModelDTO = ModelMapper.ConvertToDTO(positionedModel.Model),
                Position = VectorMapper.ConvertToDTO(positionedModel.Position),
            };

            return positionedModelDTO;
        }
        public static PositionedModel ConvertToPositionedModel(PositionedModelDTO positionedModelDTO)
        {
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = ModelMapper.ConvertToModel(positionedModelDTO.ModelDTO),
                Position = VectorMapper.ConvertToVector(positionedModelDTO.Position),
            };

            return positionedModel;
        }
    }
}
