using Reflection.Interfaces;
using System.Drawing;
using System.Threading.Tasks;

namespace FlipImage
{
    public class FlipImage : IFilter
    {
        public string Name => "Flip Image";

        public Image RunPlugin(Image src)
        {
            return ApplyPlugin(src);
        }

        private static Image ApplyPlugin(Image src)
        {
            Bitmap bitmap = new Bitmap(src);
            Bitmap newBitmap = new Bitmap(src);
            for (int row = 0; row < bitmap.Height; ++row)
            {
                for (int col = 0; col < bitmap.Width; ++col)
                {
                    newBitmap.SetPixel(bitmap.Width - col - 1, bitmap.Height - row - 1, bitmap.GetPixel(col, row));
                }
            }

            bitmap.Dispose();
            return newBitmap;
        }

        public Task<Image> RunPluginAsync(Image src)
        {
            return Task.Run(() => ApplyPlugin(src));
        }
    }
}
