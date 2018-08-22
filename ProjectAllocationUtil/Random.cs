using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationUtil
{
    public class Random
    {
        // Methods
        public static string Next(int VcodeNum)
        {
            string[] strArray = "2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,W,X,Y,Z".Split(new char[] { ',' });
            string str2 = "";
            int num = -1;
            System.Random random = new System.Random();
            for (int i = 1; i < (VcodeNum + 1); i++)
            {
                if (num != -1)
                {
                    random = new System.Random((i * num) * ((int)DateTime.Now.Ticks));
                }
                int index = random.Next(strArray.Length);
                if ((num != -1) && (num == index))
                {
                    return Next(VcodeNum);
                }
                num = index;
                str2 = str2 + strArray[index];
            }
            return str2;
        }
    }


}
