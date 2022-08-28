using System.Windows;
using System.Windows.Controls;
using WpfTemplate.Form;

namespace WpfTemplate.Lib
{
    public abstract class BaseWindow : Window
    {

    }

    public class BaseWindow<T> : BaseWindow where T : BaseModel
    {
        public T Model { get; set; }
        public string Title { get; set; }
        public Grid Grid = new Grid();

        public BaseWindow(string title, T model)
        {
            Title = title;
            Model = model;
            GenerateGrid();
            RenderModelFormFields();
        }

        private void GenerateGrid()
        {
            for(int i = 0; i < Model.Rows; i++)
            {
                Grid.RowDefinitions.Add(GetRowDefinition(1));
            }
            for(int i = 0; i < Model.Columns; i++)
            {
                Grid.ColumnDefinitions.Add(GetColumnDefinition(1));
            }
            Grid.ShowGridLines = true;
            AddChild(Grid);
        }

        private void RenderModelFormFields()
        {
            foreach(FormField field in Model.Fields)
            {
                field.RenderToGrid(Grid);
            }
        }

        private ColumnDefinition GetColumnDefinition(double widthRatio)
        {
            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(widthRatio, GridUnitType.Star);
            return columnDefinition;
        }

        private RowDefinition GetRowDefinition(double heightRatio)
        {
            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = new GridLength(heightRatio, GridUnitType.Star);
            return rowDefinition;
        }
    }
}
