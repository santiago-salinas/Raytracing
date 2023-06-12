using BusinessLogic.Exceptions;
using BusinessLogic.Utilities;

namespace DataTransferObjects
{
    public static class ColorMapper
    {
        private static int _upperBound = 255;
        private static int _lowerBound = 0;
        public static ColorDTO ConvertToDTO(Color color)
        {
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue,
            };

            return colorDTO;
        }

        public static Color ConvertToColor(ColorDTO colorDTO)
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

        private static bool IsBetweenBounds(double value)
        {

            return (value >= _lowerBound) && (value <= _upperBound);
        }
    }
}
