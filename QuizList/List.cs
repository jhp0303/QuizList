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
            // 3과 5의 배수 숫자의 합 구하기
            // 1~10 사이의 3과 5의 배수는 3, 5, 6, 9입니다. 이들의 합은 23입니다. 1~1000 사이의 3과 5의 배수 합을 구하세요.
            int sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("1~1000 사이의 3과 5의 배수의 합은 {0}입니다.", sum);
        }
    }
}
