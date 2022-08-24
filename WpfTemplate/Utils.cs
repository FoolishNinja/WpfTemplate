using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissSkillsTemplate
{
    public static class Utils
    {
        private static Random random = new Random();

        public static int RoundToClostest(int inputValue, int roundToClosest)
        {
            return (int)(Math.Round((double) inputValue / roundToClosest) * roundToClosest);
        }

        public static string RandomCharacterString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
