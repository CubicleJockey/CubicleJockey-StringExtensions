using System;

namespace CubicleJockey.StringExtensions
{
    public static class Actions
    {
        public static void ForEach(this string self, Action<char> action)
        {
            foreach (var character in self)
            {
                action(character);
            }
        }
    }
}
