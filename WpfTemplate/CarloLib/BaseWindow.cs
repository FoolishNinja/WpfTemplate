using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTemplate.Models;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib
{
    public class BaseWindow<T> : Window
    {
        public string Name { get; set; }
        public T Model { get; set; }
        public Grid BaseGrid { get; set; } = new Grid();
        
        private GridSize _GridSize { get; set; }
        public GridSize GridSize
        {
            get => _GridSize;
            set
            {
                _GridSize = value;
                Width = (double) value;
                Height = 700;
            }
        }

        public void Initialize()
        {
            WindowManager.AddWindow(Name, this);
            GenerateGrid();
            RenderUserControls();
            KeyDown += BaseWindow_KeyDown;
        }

        private void BaseWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.NumPad5))
            {
                BaseGrid.ShowGridLines = !BaseGrid.ShowGridLines;
            }
        }

        private void RenderUserControls()
        {
            foreach(FieldInfo fieldInfo in Model.GetType().GetFields())
            {
                if(Model.GetType().GetField(fieldInfo.Name).GetCustomAttribute(typeof(Field), false) != null)
                {
                    BaseGrid.Children.Add((UserControl) Model.GetType().GetField(fieldInfo.Name).GetValue(Model));
                }
            }
        }



        private void GenerateGrid()
        {
            // Borders
            BaseGrid.ColumnDefinitions.Add(GetColumnDefinition(1));
            BaseGrid.RowDefinitions.Add(GetRowDefinition(2));

            for (int i = 0; i < 12; i++)
            {
                BaseGrid.ColumnDefinitions.Add(GetColumnDefinition(3));
            }

            for(int i = 0; i < 24; i++)
            {
                BaseGrid.RowDefinitions.Add(GetRowDefinition(3));
            }

            // Borders
            BaseGrid.ColumnDefinitions.Add(GetColumnDefinition(1));
            BaseGrid.RowDefinitions.Add(GetRowDefinition(2));
            AddChild(BaseGrid);
        }

        private ColumnDefinition GetColumnDefinition(int width, GridUnitType gridTypeUnit = GridUnitType.Star)
        {
            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(width, gridTypeUnit);
            return columnDefinition;
        }
        private RowDefinition GetRowDefinition(int height, GridUnitType gridTypeUnit = GridUnitType.Star)
        {
            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = new GridLength(height, gridTypeUnit);
            return rowDefinition;
        }
    }
}
