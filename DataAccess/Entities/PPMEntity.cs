using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class PPMEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ICollection<PixelEntity> Pixels { get; set; }

        public static PPMEntity FromDomain(PPM ppm)
        {
            ICollection<PixelEntity> pixels = new List<PixelEntity>();

            Color[,] _pixels = ppm.PixelsValues;

            PPMEntity ret = new PPMEntity()
            {
                Id = Guid.NewGuid(),
                Width = ppm.Width,
                Height = ppm.Heigth,
            };

            for (int row = 0; row < ppm.Heigth; row++)
            {
                for (int column = 0; column < ppm.Width; column++)
                {
                    PixelEntity pix = new PixelEntity()
                    {
                        Id = Guid.NewGuid(),
                        Red = _pixels[row, column].Red,
                        Green = _pixels[row, column].Green,
                        Blue = _pixels[row, column].Blue,
                        ColumnPos = column,
                        RowPos = row,
                        PPMEntity = ret,
                    };
                    pixels.Add(pix);
                }
            }

            ret.Pixels = pixels;


            return ret;
        }

        public static PPM FromEntity(PPMEntity entity)
        {
            PPM ret = new PPM(entity.Width, entity.Height);
            foreach (PixelEntity pix in entity.Pixels)
            {
                Color color = new Color(pix.Red/255, pix.Green/255, pix.Blue/255);
                int row = -pix.RowPos + entity.Height -1;
                ret.SavePixel(row, pix.ColumnPos, color);
            }
            return ret;
        }
    }

    public class PixelEntity
    {
        [Key]
        public Guid Id { get; set; }
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public int ColumnPos { get; set; }
        public int RowPos { get; set; }


        public PPMEntity PPMEntity { get; set; }
    }

    
}
