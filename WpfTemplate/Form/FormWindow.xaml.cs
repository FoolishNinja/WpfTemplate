using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfTemplate.Form;
using WpfTemplate.Form.FormFields;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for FormWindow.xaml
    /// </summary>
    public partial class FormWindow : Window
    {
        private FormWindowModel Model;

        public FormWindow(string title, List<List<FormField>> formFieldGrid, FormSize? formSize = FormSize.DYNAMIC)
        {
            Model = new FormWindowModel(title, formFieldGrid, (int) formSize);
            InitializeComponent();
            DataContext = Model;
            InitializeGrid();
            
        }

        private void InitializeGrid()
        {

            FormGrid.ShowGridLines = FormStyling.SHOW_GRID;
            GenerateColumnsAndRows();
            RenderFormFields();
        }

        private void GenerateColumnsAndRows()
        {
            for(int i = 0; i < (Model.FormFieldGrid.Count * FormStyling.COLUMNS + 1) + 2; i++)
            {
                // Left and right spacers
                FormGrid.ColumnDefinitions.Add(GetColumnDefinition(i == 0 || i % 25 == 0 ? 2 : 1));
            }

            int maxAmountOfRows = 0;
            // Generating rows
            foreach (List<FormField> formFields in Model.FormFieldGrid)
            {
                int currentAmountOfRows = 0;
                foreach (FormField field in formFields)
                {
                    currentAmountOfRows += field.Rowspan + 1;
                }
                if (currentAmountOfRows > maxAmountOfRows) maxAmountOfRows = currentAmountOfRows;
            }
            for (int i = 0; i < maxAmountOfRows; i++)
            {
                FormGrid.RowDefinitions.Add(GetRowDefinition(1));
            }

            // Bottom spacer
            FormGrid.RowDefinitions.Add(GetRowDefinition(3));
        }

        private void RenderFormFields()
        {

            int currentCol = 1;
            foreach (List<FormField> formFieldRow in Model.FormFieldGrid)
            {
                int currentRow = 1;
                foreach (FormField field in formFieldRow)
                {
                    field.RenderToGrid(FormGrid, currentRow, currentCol);
                    // +1 for validation message
                    currentRow += field.Rowspan + 1;
                }
                currentCol += 25;
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
