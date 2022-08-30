using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfTemplate.Utils
{
    public static class Utils
    {
        private static Random random = new Random();

        public static int RoundToClostest(int inputValue, int roundToClosest)
        {
            return (int)(Math.Round((double)inputValue / roundToClosest) * roundToClosest);
        }

        public static string RandomCharacterString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static SolidColorBrush GetColorBrushFromHex(string hex)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
        }
    }
}
