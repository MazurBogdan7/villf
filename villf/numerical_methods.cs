using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace villf
{
    public class numerical_methods
    {
        public static float average_rating(List<int> listEstim, int count)
        {
            float estimation;
            int i = 0;
            int sum = 0;
            while (i < count)
            {
                sum = sum + listEstim[i];
                i++;
            }
            estimation = sum / count;

            return estimation;
        }

    }
}
