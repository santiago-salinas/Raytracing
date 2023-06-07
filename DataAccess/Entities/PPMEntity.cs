using BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
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
        public byte[] RenderBytes { get; set; }

        public static PPMEntity FromDomain(PPM ppm)
        {
            BusinessLogic.Color[,] _pixels = ppm.PixelsValues;
            PPMEntity ret = new PPMEntity()
            {
                Id = Guid.NewGuid(),
                Width = ppm.Width,
                Height = ppm.Heigth,
                RenderBytes = ppmToBitmap(ppm)
            };

            return ret;
        }

        private static byte[] ppmToBitmap(PPM ppm)
        {
            int width = ppm.Width;
            int height = ppm.Heigth;
            Bitmap bitmap = new Bitmap(width, height);
            BusinessLogic.Color[,] pixels = ppm.PixelsValues;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int red = (int)pixels[row, column].Red;
                    int green = (int)pixels[row, column].Green;
                    int blue = (int)pixels[row, column].Blue;

                    bitmap.SetPixel(column, row, System.Drawing.Color.FromArgb(red, green, blue));
                }
            }

            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
        }

        public static PPM FromEntity(PPMEntity entity)
        {
            PPM ret = new PPM(entity.Width, entity.Height);

            Bitmap bitmap;
            using (MemoryStream stream = new MemoryStream(entity.RenderBytes))
            {
                bitmap = new Bitmap(stream);
            }

            for (int row = 0; row < ret.Heigth; row++)
            {
                for (int column = 0; column < ret.Width; column++)
                {
                    System.Drawing.Color pixel = bitmap.GetPixel(column, row);

                    double red = pixel.R/(double)255;
                    double green = pixel.G/ (double)255;
                    double blue = pixel.B/ (double)255;

                    BusinessLogic.Color color = new BusinessLogic.Color(red, green, blue);
                    int rowinput = -row + ret.Heigth - 1;
                    ret.SavePixel(rowinput, column, color);
                }
            }
            return ret;
        }
    }

}
