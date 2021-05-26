using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgUtils
{
    public static class ImageScaler
    {
        public static Bitmap Resize(Bitmap img, int maxWidth, int maxHeight)
        {
            double k = GetResizeCoeff(img.Width, img.Height, maxHeight, maxHeight);
            
            int destWidth = (int) (img.Width * k);
            int destHeight = (int) (img.Height * k);
            
            Rectangle destRect = new Rectangle(0, 0, destWidth, destHeight);
            Bitmap destImg = new Bitmap(destWidth, destHeight);
            destImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImg))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImg;
        } 

        public static double GetResizeCoeff(int width, int height, int maxWidth, int maxHeight)
        {
            double kWidth = maxWidth / (double)width;
            double kHeight = maxHeight / (double)height;
            return Math.Min(kWidth, kHeight);
        }
    }

}
