﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using BusinessLogic;

namespace Services
{
    public class ColorConverter
    {
        public ColorConverter() { }
        private int _upperBound = 255;
        private int _lowerBound = 0;
        public ColorDTO ConvertToColorDTO(Color color)
        {
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue,
            };

            return colorDTO;
        }

        public Color ConvertToColor(ColorDTO colorDTO)
        {
            double redValue = colorDTO.Red;
            double greenValue = colorDTO.Green;
            double blueValue = colorDTO.Blue;
            if (!IsBetweenBounds(redValue) || !IsBetweenBounds(greenValue) || !IsBetweenBounds(blueValue))
            {
                throw new BusinessLogicException($"Inserted RGB values must be between {_lowerBound} and {_upperBound}");
            }

            Color color = new Color()
            {
                Red = colorDTO.Red / _upperBound,
                Green = colorDTO.Green / _upperBound,
                Blue = colorDTO.Blue / _upperBound,
            };

            return color;
        }

        private bool IsBetweenBounds(double value)
        {
            
            return (value >= _lowerBound) && (value <= _upperBound);
        }
    }
}