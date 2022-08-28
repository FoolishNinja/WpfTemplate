using System.Collections.Generic;
using System.Windows;

namespace WpfTemplate.Lib
{
    public class WindowManager
    {
        public static Dictionary<string, BaseModel> Models { get; set; } = new Dictionary<string, BaseModel>();
        public static Dictionary<string, BaseWindow> Windows { get; set; } = new Dictionary<string, BaseWindow>();

        public static void AddWindow(string name, BaseWindow window)
        {
            Windows.Add(name, window);
        }

        public static void RemoveWindowByName(string name)
        {
            Windows.Remove(name);
        }

        public static void AddModel(string name, BaseModel baseModel)
        {
            Models.Add(name, baseModel);
        }

        public static void RemoveModelByName(string name)
        {
            Models.Remove(name);
        }
    }
}
