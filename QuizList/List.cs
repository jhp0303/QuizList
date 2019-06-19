using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizList
{
    class List
    {
        public static void Quiz1()
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

        public static void Quiz2()
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

        public static void Quiz3()
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

        public static void Quiz4()
        {
            // 2520은 1부터 10까지의 숫자로 모두 나눠지는 최소의 수입니다.
            // 1부터 20까지의 숫자로 모두 나눠지는 최소의 수를 구하세요.

            /*
            유클리드 호제법
            1. 큰 수에서 작은 수를 나눈 나머지를 구합니다.
             - 큰 수, 작은 수의 구분은 없고 처음 수와 나중 수가 의미가 있습니다.
            2. 작은 수가 큰 수, 나머지가 작은 수의 역할을 하며 1의 과정을 다시합니다.
            3. 2의 과정을 하다가 나머지가 0이면 종료합니다.
            4. 마지막으로 나눈 값이 최대공약수 입니다. (아래 코드 중 int Gcf(int num1, int num2) 함수 참고)

            최소공배수
            최소공배수 = 큰 수 * 작은 수 / 최대공약수

            두 숫자 이상의 최소공배수 구하기
            최소공배수 = 이전 숫자의 최소공배수 * 새로운 숫자 / 이전 숫자의 최소공배수와 새로운 숫자의 최대공약수
             - 모든 숫자가 끝날 때까지 반복

            두 숫자 이상의 최대공약수 구하기
            1. 처음 하나의 숫자를 최대공약수와 최소공배수로 정의합니다.
             - 숫자가 하나일 때에는 그 수가 최대공약수이자 최소공배수이기 때문입니다.
            2. 지금까지 구해놓은 최대공약수와 새로운 수로 최대공약수를 구합니다.
            3. 또 지금까지 구해놓은 최소공배수와 새로운 수로 최소공배수를 구합니다.
             - 최소공배수 * 새로운 수를 나눌때에는 현재 곱하는 두 수의 최대공약수로 나누어야 합니다.
            4. 2, 3과정을 모든 숫자가 끝날 때까지 반복합니다.
            */

            int lcm = 1;    // lmc = 최소공배수의 약자  / 처음 수

            for (int i = 2; i < 20; i++)    // i = 나중수
            {
                lcm = Lcm(lcm, i);  // 1부터 20까지의 최소공배수
            }

            Console.WriteLine("{0}", lcm);

        }

        public static int Gcf(int a, int b) //최대공약수
        {
            int num;    //처음 수와 나중 수를 담을 변수
            int preNum = a;
            int aftNum = b;

            while(true)
            {
                num = preNum % aftNum;
                if(num == 0)
                {
                    break;
                }

                preNum = aftNum;
                aftNum = num;
            }
            return aftNum;
        }

        public static int Lcm(int num1, int num2)   //최소공배수
        {
            return num1 * num2 / Gcf(num1, num2);
        }

        public static void Quiz5()
        {
            int num = 1;  // 3부터 시작하는 홀수 검토
            int j;
            int count = 1;  // 2는 소수이고 그 이후에 홀수들만 비교
            
            while(true)
            {
                num += 2; // 홀수를 검토
                for (j = 3; (j * j < num) && (num % j != 0); j += 2) ;  
                if (j * j > num)
                {
                    count += 1;
                }
                else if (count == 10001)
                {
                    break;
                }
            }
            Console.WriteLine("10001번째 소수는 {0}입니다.", num);
        }
    }
}
