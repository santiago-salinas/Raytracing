using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using BusinessLogic;
using DataTransferObjects;


namespace Services
{
    public class PPMConverter
    {
        private ColorConverter _colorConverter;
        public PPMConverter (ColorConverter converter) 
        {
            _colorConverter = converter;
        }

        private ColorDTO[,] ConvertPixelsToDTO(Color[,] pixels, int height, int width)
        {
            ColorDTO[,] convertedPixels = new ColorDTO[height, width];
            for(int i = 0; i<height; i++)
            {
                for(int j = 0; j<width; j++)
                {
                    convertedPixels[i,j] = _colorConverter.ConvertToColorDTO(pixels[i,j]);
                }
            }

            return convertedPixels;
        }

        private Color[,] ConvertPixelsFromDTO(ColorDTO[,] pixels, int height, int width) 
        {
            Color[,] convertedPixels = new Color[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    convertedPixels[i, j] = _colorConverter.ConvertToColor(pixels[i, j]);
                }
            }

            return convertedPixels;
        }
        public PPM ConvertToPPM(PpmDTO ppmDTO)
        {
            if (ppmDTO == null) return null;
            PPM ppm = new PPM(ppmDTO.Heigth, ppmDTO.Width)
            {
                PixelsValues = ConvertPixelsFromDTO(ppmDTO.Pixels,ppmDTO.Heigth,ppmDTO.Width)
            };

            return ppm;
        }

        public PpmDTO ConvertToPpmDTO(PPM ppm)
        {
            if(ppm != null)
            {
                PpmDTO ppmDTO = new PpmDTO()
                {
                    Heigth = ppm.Heigth,
                    Width = ppm.Width,
                    Pixels = ConvertPixelsToDTO(ppm.PixelsValues, ppm.Heigth, ppm.Width)
                };
                return ppmDTO;
            }

            return null;
            
        }
    }
}
