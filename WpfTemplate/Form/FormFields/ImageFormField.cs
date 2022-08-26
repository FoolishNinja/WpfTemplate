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
            Colspan = 12;
            Rowspan = 6;
            PrimaryUIElement = new Image();
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri($"pack://application:,,,/WpfTemplate;component/Resources/{Path}");
            bitmapImage.EndInit();
            PrimaryUIElement.Source = bitmapImage;
            Row = currentCol;
            Col = currentCol;
            PrimaryUIElement.Width = Width == -1 ? bitmapImage.Width : Width;
            PrimaryUIElement.Height = Height == -1 ? bitmapImage.Height : Height;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }
    }
}
}
