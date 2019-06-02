using Reflection.Interfaces;
using System.Drawing;
using System.Threading.Tasks;

namespace MakeColor
{
    public class MakeRed : IFilter
    {
        public Image RunPlugin(Image src)
        {
            return ApplyPlugin(src);
        }

        private static Image ApplyPlugin(Image src)
        {
            Bitmap bitmap = new Bitmap(src);
            for (int row = 0; row < bitmap.Height; ++row)
            {
                for (int col = 0; col < bitmap.Width; ++col)
                {
                    Color color = bitmap.GetPixel(col, row);
                    if (color.R > 0)
                    {
                        color = Color.FromArgb(color.A, 255, color.G, color.B);
                    }

                    bitmap.SetPixel(col, row, color);
                }
            }

            return bitmap;
        }

        public Task<Image> RunPluginAsync(Image src)
        {
            return Task.Run(() => ApplyPlugin(src));
        }

        public string Name => "Make Red";
    }

    public class MakeGreen : IFilter
    {
        public Image RunPlugin(Image src)
        {
            return ApplyPlugin(src);
        }

        public Task<Image> RunPluginAsync(Image src)
        {
            return Task.Run(() => ApplyPlugin(src));
        }

        private static Image ApplyPlugin(Image src)
        {
            Bitmap bitmap = new Bitmap(src);
            for (int row = 0; row < bitmap.Height; ++row)
            {
                for (int col = 0; col < bitmap.Width; ++col)
                {
                    Color color = bitmap.GetPixel(col, row);
                    if (color.G > 0)
                    {
                        color = Color.FromArgb(color.A, color.R, 255, color.B);
                    }

                    bitmap.SetPixel(col, row, color);
                }
            }

            return bitmap;
        }

        public string Name => "Make Green";
    }

    public class MakeBlue : IFilter
    {
        public Image RunPlugin(Image src)
        {
            return ApplyPlugin(src);
        }

        public Task<Image> RunPluginAsync(Image src)
        {
            return Task.Run(() => ApplyPlugin(src));
        }

        private static Image ApplyPlugin(Image src)
        {
            Bitmap bitmap = new Bitmap(src);
            for (int row = 0; row < bitmap.Height; ++row)
            {
                for (int col = 0; col < bitmap.Width; ++col)
                {
                    Color color = bitmap.GetPixel(col, row);
                    if (color.B > 0)
                    {
                        color = Color.FromArgb(color.A, color.R, color.G, 255);
                    }

                    bitmap.SetPixel(col, row, color);
                }
            }

            return bitmap;
        }

        public string Name => "Make Blue";
    }
}
