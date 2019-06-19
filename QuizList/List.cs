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

            for (int i = 1; i < 4000000; i = i + preNum)
            {
                preNum = aftNum;

                if ((i % 2) == 0)
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

            while (true)
            {
                num = preNum % aftNum;
                if (num == 0)
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

            while (true)
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

        public static void Quiz6()
        {
            int[,] grid = new int[20, 20] {
                            { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
                            { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                            { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                            { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                            { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                            { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                            { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                            { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                            { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                            { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                            { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                            { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                            { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                            { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                            { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                            { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                            { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                            { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                            { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                            { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 }
            };
            int horizontal = 0;
            int verticality = 0;
            int diagonal = 0;
            int max_horizontal = 0;
            int max_verticality = 0;
            int max_diagonal = 0;
            int max_number = 0;
            for (int i = 0; i <= grid.GetLength(0); i++)
            {
                for (int j = 0; j <= grid.GetLength(1); j++)
                {
                    if ( i <= 19 && j <= 16)
                    {
                        horizontal = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3];
                        verticality = grid[j, i] * grid[j + 1, i] * grid[j + 2, i] * grid[j + 3, i];
                        if (i < 17 && j < 16)
                        {
                            diagonal = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3];
                        }
                        
                        if (max_horizontal < horizontal)
                        {
                            max_horizontal = horizontal;
                        }
                        if (max_verticality < verticality)
                        {
                            max_verticality = verticality;
                        }
                        if (max_diagonal < diagonal)
                        {
                            max_diagonal = diagonal;
                        }

                    }
                }
            }

            if (max_verticality < max_horizontal)
            {
                max_number = max_horizontal;

                if (max_number < max_diagonal)
                {
                    Console.WriteLine("최대값: {0}", max_diagonal);
                }
                else if (max_number > max_diagonal)
                {
                    Console.WriteLine("최대값: {0}", max_number);
                }
            }
            else if (max_verticality > max_horizontal)
            {
                max_number = max_verticality;

                if (max_number < max_diagonal)
                {
                    Console.WriteLine("최대값: {0}", max_diagonal);
                }
                else if (max_number > max_diagonal)
                {
                    Console.WriteLine("최대값: {0}", max_number);
                }
            }
        }
    }
}
