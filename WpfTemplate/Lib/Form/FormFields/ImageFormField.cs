using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfTemplate.Form.FormFields
{
    public class ImageFormField : FormField<Image>
    {
        public string Path { get; set; }
        public int Width = -1;
        public int Height = -1;

        public ImageFormField()
        {
            PrimaryUIElement = new Image();
        }

        public override void RenderToGrid(Grid grid)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri($"pack://application:,,,/WpfTemplate;component/Resources/{Path}");
            bitmapImage.EndInit();
            PrimaryUIElement.Source = bitmapImage;
            PrimaryUIElement.Width = Width == -1 ? bitmapImage.Width : Width;
            PrimaryUIElement.Height = Height == -1 ? bitmapImage.Height : Height;
            grid.Children.Add(PrimaryUIElement);
        }
    }
}
