using System.Collections.Generic;
using System.Windows;

namespace WpfTemplate.CarloLib
{
    public class WindowManager
    {
        public static Dictionary<string, object> Store = new Dictionary<string, object>();
        public static Dictionary<string, Window> Windows = new Dictionary<string, Window>();

        public static void AddToStore(string key, object value)
        {
            Store.Add(key, value);
        }

        public static T GetStoreValue<T>(string key)
        {
            if (Store.ContainsKey(key))
                return (T)Store[key];
            return default;
        }

        public static void RemoveKey(string key)
        {
            if (Store.ContainsKey(key))
                Store.Remove(key);
        }

        public static void AddWindow(string name, Window window)
        {
            Windows.Add(name, window);
        }

        public static void RemoveWindowByName(string name)
        {
            if (Windows.ContainsKey(name))
                Windows.Remove(name);
        }
    }
}
