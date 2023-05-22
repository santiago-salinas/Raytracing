using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using BusinessLogic;
using Controllers.DTOs;

namespace Controllers.Converter
{
    public class ColorConverter
    {
        public ColorConverter() { }

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
            int upperRGBBound = 255;
            double redValue = colorDTO.Red;
            double greenValue = colorDTO.Green;
            double blueValue = colorDTO.Blue;
            if (!IsBetweenBounds(redValue) || !IsBetweenBounds(greenValue) || !IsBetweenBounds(blueValue))
            {
                throw new BusinessLogicException("Inserted RGB values must be between 0 and 255");
            }

            Color color = new Color()
            {
                Red = colorDTO.Red / upperRGBBound,
                Green = colorDTO.Green / upperRGBBound,
                Blue = colorDTO.Blue / upperRGBBound,
            };

            return color;
        }

        private bool IsBetweenBounds(double value)
        {
            int upperBound = 255;
            int lowerBound = 0;
            return (value >= lowerBound) && (value <= upperBound);
        }
    }
}
