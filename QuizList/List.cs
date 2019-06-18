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
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("1~1000 사이의 3과 5의 배수의 합은 {0}입니다.", sum);
        }

        public static void quiz2()
        {
            // 피보나치 수열은 연속된 숫자의 합을 계속해서 붙여나갑니다.
            // 1과 2부터 시작해서 10개까지 이어보면 다음과 같이 됩니다.
            // ex) 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            // 400만을 초과하지 않는 값 중에 짝수 수열의 합을 구하세요.

            int preNum = 1; // 첫번째 숫자
            int aftNum = 1; // i값을 저장할 변수
            int result = 0;  //결과 값

            for (int i = 1; i < 4000000; i = i+preNum)
            {
                preNum = aftNum;

                if ( (i%2) == 0 )
                {
                    result += i;
                }

                aftNum = i;
            }
            Console.WriteLine(result);
        }

        public static void quiz3()
        {
            // 13195의 소인수는 5, 7, 13, 29 입니다.
            // 600851475143 의 최대 소인수는 무엇입니까?
            long result = GetMaxPrimeValue();
            Console.WriteLine("600851475143의 최대 소인수는 {0} 입니다.", result);
        }
        static long GetMaxPrimeValue() // quiz3에 사용되는 소인수 구하는 함수
        {
            long value = 600851475143;
            long checkValue = 2;
            long maxPrimeValue = 0;

            while (checkValue * checkValue <= value)
            {
                if (value % checkValue == 0)
                {
                    maxPrimeValue = checkValue;
                    while (value % checkValue == 0)
                    {
                        value /= checkValue;
                    }
                }
                else
                {
                    checkValue++;
                }
            }
            if (value > maxPrimeValue)
            {
                maxPrimeValue = value;
            }

            return maxPrimeValue;
        }


    }
}
