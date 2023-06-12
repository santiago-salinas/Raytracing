﻿using BusinessLogic.Utilities;

namespace DataTransferObjects
{
    public static class VectorMapper
    {
        public static VectorDTO ConvertToDTO(Vector vector)
        {
            VectorDTO vectorDTO = new VectorDTO()
            {
                FirstValue = vector.FirstValue,
                SecondValue = vector.SecondValue,
                ThirdValue = vector.ThirdValue,
            };

            return vectorDTO;
        }

        public static Vector ConvertToVector(VectorDTO dto)
        {
            Vector vector = new Vector()
            {
                FirstValue = dto.FirstValue,
                SecondValue = dto.SecondValue,
                ThirdValue = dto.ThirdValue,
            };

            return vector;
        }
    }
}
