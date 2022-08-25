using System.Collections.Generic;
using WpfTemplate.Types;

namespace WpfTemplate.Form
{
    public class FormWindowModel : Model
    {
        public List<List<FormField>> FormFieldGrid { get; set; }
        public MenuBar FormToolBar { get; set; }


        private string _Title { get; set; }
        public string Title
        {
            get => _Title;
            set  {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        private int _Width = -1;
        public int Width
        {
            get => _Width;
            set
            {
                _Width = value;
                OnPropertyChanged("Width");
            }
        }

        private int _Height = 0;
        public int Height
        {
            get => _Height;
            set
            {
                _Height = value;
                OnPropertyChanged("Height");
            }
        }


        public FormWindowModel(string title, List<List<FormField>> formFieldGrid, int width, MenuBar formToolBar)
        {
            Title = title;
            FormFieldGrid = formFieldGrid;
            FormToolBar = formToolBar;
            Width = width == -1 ? formFieldGrid.Count * (int) FormSize.M : width;

            int maxFormFieldsInARow = 0;
            foreach(List<FormField> row in formFieldGrid)
            {
                if (row.Count > maxFormFieldsInARow) maxFormFieldsInARow = row.Count;
            }

            Height = maxFormFieldsInARow * (120 + maxFormFieldsInARow) + 100;
        }
    }
}
