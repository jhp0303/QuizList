using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizList
{
    class List
    {
        public static void quiz1()
        {
            int third = 0;
            int fifth = 0;
            int sum = 0;
            Console.Write("1~10 사이의 3과 5의 배수는");
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 3 == 0)
                {
                    third = i;
                    Console.Write("{0}", third);
                    Console.Write(", ");
                    sum += third;
                }

                else if (i % 5 == 0)
                {
                    fifth = i;
                    Console.Write("{0}", fifth);
                    Console.Write(", ");
                    sum += fifth;
                }
            }


            Console.WriteLine("입니다. 이들의 합은 {0}입니다.", sum);
        }
    }
}
