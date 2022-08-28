using System.Collections.Generic;
using System.Windows;

namespace WpfTemplate.Lib
{
    public class WindowManager
    {
        public static Dictionary<string, BaseModel> Models { get; set; } = new Dictionary<string, BaseModel>();
        public static Dictionary<string, Window> Windows { get; set; } = new Dictionary<string, Window>();

        public static void AddWindow(string name, Window window)
        {
            Windows.Add(name, window);
        }

        public static void RemoveWindowByName(string name)
        {
            Windows.Remove(name);
        }
    }
}
