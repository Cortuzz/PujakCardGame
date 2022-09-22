using System;

namespace PujakCardGame.Utils
{
    public static class ArrayExtentions
    {
        public static void Shuffle<T>(this T[] array)
        {
            var rnd = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rnd.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
