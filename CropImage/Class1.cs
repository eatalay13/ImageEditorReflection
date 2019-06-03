using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Interfaces;

namespace CropImage
{
    public class CropImage : IFilter
    {
        public string Name => "Crop Image";

        public Task<Image> RunPluginAsync(Image src)
        {
            return Task.Run(() => ApplyPlugin(src));
        }

        public Image RunPlugin(Image src)
        {
            return ApplyPlugin(src);
        }

        private Image ApplyPlugin(Image src)
        {
            Bitmap bmpImage = new Bitmap(src);
            Bitmap bmpCrop = bmpImage.Clone(new Rectangle(100, 100, 300, 300), bmpImage.
                PixelFormat);

            return bmpCrop;
        }
    }
}
