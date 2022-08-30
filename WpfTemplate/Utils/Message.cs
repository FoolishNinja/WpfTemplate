using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTemplate.Utils
{
    public class Message
    {
        public static void Info(string message, string? header = "Info", MessageBoxButton? button = MessageBoxButton.OK)
        {
            MessageBox.Show(message, header, (MessageBoxButton)button, MessageBoxImage.Information);
        }

        public static void Warning(string message, string? header = "Warning", MessageBoxButton? button = MessageBoxButton.OK)
        {
            MessageBox.Show(message, header, (MessageBoxButton)button, MessageBoxImage.Warning);
        }

        public static void Error(string message, string? header = "Error", MessageBoxButton? button = MessageBoxButton.OK)
        {
            MessageBox.Show(message, header, (MessageBoxButton)button, MessageBoxImage.Error);
        }

        public static bool Question(string question, string? header = "Question", MessageBoxButton? button = MessageBoxButton.YesNo)
        {
            return MessageBox.Show(question, header, (MessageBoxButton)button, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }
}
