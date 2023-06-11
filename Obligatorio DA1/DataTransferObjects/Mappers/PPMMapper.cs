using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataTransferObjects;


namespace DataTransferObjects
{
    public static class PPMMapper
    {
        private static ColorDTO[,] ConvertPixelsToDTO(Color[,] pixels, int height, int width)
        {
            ColorDTO[,] convertedPixels = new ColorDTO[height, width];
            for(int i = 0; i<height; i++)
            {
                for(int j = 0; j<width; j++)
                {
                    convertedPixels[i,j] = ColorMapper.ConvertToDTO(pixels[i,j]);
                }
            }

            return convertedPixels;
        }

        private static Color[,] ConvertPixelsFromDTO(ColorDTO[,] pixels, int height, int width) 
        {
            Color[,] convertedPixels = new Color[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    convertedPixels[i, j] = ColorMapper.ConvertToColor(pixels[i, j]);
                }
            }

            return convertedPixels;
        }
        public static PPM ConvertToPPM(PpmDTO ppmDTO)
        {
            if (ppmDTO == null) return null;
            PPM ppm = new PPM(ppmDTO.Width, ppmDTO.Heigth)
            {
                PixelsValues = ConvertPixelsFromDTO(ppmDTO.Pixels,ppmDTO.Heigth,ppmDTO.Width)
            };

            return ppm;
        }

        public static PpmDTO ConvertToDTO(PPM ppm)
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
