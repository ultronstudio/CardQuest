using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardQuest.Helpers
{
    public class Cards
    {
        public static void ShuffleArray(Button[] arr)
        {
            int arrayLength = arr.Length;
            Random random = new Random();

            for(int i = 0; i < arrayLength; i++)
            {
                SwapArray(arr, i, i + random.Next(arrayLength - i));
            }
        }

        public static void SwapArray(Button[] arr, int a, int b)
        {
            Button temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
