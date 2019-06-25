using System;
using System.Collections;
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
            int re_diagonal = 0;
            int max_horizontal = 0;
            int max_verticality = 0;
            int max_diagonal = 0;
            int max_re_diagonal = 0;
            int max_number = 0;
            for (int i = 0; i <= grid.GetLength(0); i++)
            {
                for (int j = 0; j <= grid.GetLength(1); j++)
                {
                    if (i <= 19 && j <= 16)    // [y, x]
                    {
                        horizontal = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3];
                        verticality = grid[j, i] * grid[j + 1, i] * grid[j + 2, i] * grid[j + 3, i];
                        if (i <= 16 && j <= 16)
                        {
                            diagonal = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3];
                        }
                        if (3 < i && j <= 16)
                        {
                            re_diagonal = grid[i, j] * grid[i - 1, j + 1] * grid[i - 2, j + 2] * grid[i - 3, j + 3];
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
                        if (max_re_diagonal < re_diagonal)
                        {
                            max_re_diagonal = re_diagonal;
                        }

                    }
                }
            }

            if (max_verticality < max_horizontal)
            {
                max_number = max_horizontal;

                if (max_number < max_diagonal)
                {
                    if (max_diagonal < max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_re_diagonal);
                    }
                    else if (max_diagonal > max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_diagonal);
                    }
                }
                else if (max_number > max_diagonal)
                {
                    if (max_number < max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_re_diagonal);
                    }
                    else if (max_number > max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_diagonal);
                    }
                }
            }
            else if (max_verticality > max_horizontal)
            {
                max_number = max_verticality;

                if (max_number < max_diagonal)
                {
                    if (max_diagonal < max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_re_diagonal);
                    }
                    else if (max_diagonal > max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_diagonal);
                    }
                }
                else if (max_number > max_diagonal)
                {
                    if (max_number < max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_re_diagonal);
                    }
                    else if (max_number > max_re_diagonal)
                    {
                        Console.WriteLine("최대값: {0}", max_diagonal);
                    }
                }
            }
        }

        public static void Quiz7()
        {   // 정답 : 21124
            int ZERO = 0;
            int ONE = 3;    // string의 크기를 숫자로 지정해줌
            int TWO = 3;
            int THREE = 5;
            int FOUR = 4;
            int FIVE = 4;
            int SIX = 3;
            int SEVEN = 5;
            int EIGHT = 5;
            int NINE = 4;

            int[] A = { ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE };   // 일의 자리

            int TEN = 3;
            int ELEVEN = 6;
            int TWELVE = 6;
            int THIRTEEN = 8;
            int FOURTEEN = 8;
            int FIFTEEN = 7;
            int SIXTEEN = 7;
            int SEVENTEEN = 9;
            int EIGHTEEN = 8;
            int NINETEEN = 8;

            int[] B = { TEN, ELEVEN, TWELVE, THIRTEEN, FOURTEEN, FIFTEEN, SIXTEEN, SEVENTEEN, EIGHTEEN, NINETEEN }; // 십의 자리

            int TWENTY = 6;
            int THIRTY = 6;
            int FORTY = 5;
            int FIFTY = 5;
            int SIXTY = 5;
            int SEVENTY = 7;
            int EIGHTY = 6;
            int NINETY = 6;

            int[] C = { ZERO, ZERO, TWENTY, THIRTY, FORTY, FIFTY, SIXTY, SEVENTY, EIGHTY, NINETY }; // 백의 자리

            int HUNDRED = 7;
            int ONE_THOUSAND = 11;
            int AND = 3;

            int strCount = 0;
            for (int i = 0; i <= 1000; i++)
            {
                if (i < 10)
                {
                    strCount += A[i];   // 일의자리
                }
                else if (i >= 10 && i < 20)
                {
                    strCount += B[i % 10];  // 10~19까지의 지정된 단어
                }
                else if (i >= 20 && i < 100)
                {
                    strCount += (C[i / 10] + A[i % 10]);    // 21~99 까지의 십의 자리와 일의자리 구분
                }
                else if (i >= 100 && i < 1000)
                {
                    if (i % 100 == 0)
                    {
                        strCount += (A[i / 100] + HUNDRED); // 100, 200, 300 ... 백의자리만 필요함
                    }
                    else
                    {
                        if (((i / 10) % 10) == 0)   // i / 10 % 10 = 십의자리를 표현해줌 즉 101~109, 201~209 ...
                        {
                            strCount += (A[(i / 100)] + HUNDRED + AND + A[(i % 100)]);
                        }
                        else if (((i / 10) % 10) == 1)  // i / 10 % 10 = 십의자리를 표현해줌 즉 110~119, 210~219 ...
                        {
                            strCount += (A[(i / 100)] + HUNDRED + AND + B[((i % 100) - 10)]);
                        }
                        else
                        {
                            strCount += (A[(i / 100)] + HUNDRED + AND + C[((i / 10) % 10)] + A[(i % 10)]);
                        }
                    }
                }
                else
                {
                    strCount += ONE_THOUSAND;
                }
            }
            Console.WriteLine("1 ~ 1000 까지의 합  : " + strCount);

            /* 하다가 실패함
            string[] num = new[] {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                                     "eleven", "tweleve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
            string[] num_ten  =  {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string and = "and";
            string hundred = "hundred";
            string thousand = "thousand";
            int comparison = 0;

            for (int i = 1; i <= 1000; i++)
            {
                if (i <= 20)
                {
                    comparison += num[i].Length;    // 20이하의 숫자의 길이를 comparison에 중첩시켜준다.
                }

                else if (i > 20 && i < 100)
                {
                    comparison += num_ten[i / 10 % 10].Length + num[i % 10].Length; // i / 10 % 10 = 십의자리를 표현해주고 i % 10 = 일의 자리를 표현해줌.
                }

                else if (i >= 100 && i < 1000)
                {
                    if (i % 100 == 0)
                    {
                        comparison += num[i / 100].Length + hundred.Length; // 100, 200, 300 ... 백의 자리만 필요하므로 조건문 구성
                    }
                    else if (i / 10 % 10 == 1)
                    {
                        
                        comparison += num[i / 100].Length + hundred.Length + and.Length + num[i % 100].Length;  // 110~119, 210~219, ... 10~19까지는 십의자리와 일의자리를 구분치않음
                    }
                    else
                    {
                        comparison += num[i / 100].Length + hundred.Length + and.Length + num_ten[i / 10 % 10].Length + num[i % 10].Length;
                    }
                }
                
                else
                {
                    comparison += "onethousand".Length;
                }
                
                Console.WriteLine(comparison);
            }
            */

            //Console.WriteLine("Word Count: {0}", comparison);

        }

        public static int count = 0;  // 퀴즈 8에서 쓰일 정답을 담을 변수
        public static void Quiz8()
        {
            int century = 0;
            int hundredYear = 2;    // 1900년대의 매월 1일이 일요일인 경우의 수

            for (int year = 1900; year <= 2000; year++)
            {
                if (year / 400 == 0)    // 윤년 설정
                {
                    Month.LeapMonth();

                }

                else
                {
                    Month.NoLeapMonth();
                }
                century = count;
            }
            int answer = century - hundredYear;
            Console.WriteLine("20세기(1901년 1월 1일 ~ 2000년 12월 31일) 에서, 매월 1일이 일요일인 경우는 {0}입니다", answer);

        }

        class Month     //Quiz 8의 길이가 길어져서 따로 떼어서 만듬
        {
            public static void NoLeapMonth()
            {
                string[] day = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                string today = "";
                int preday = 0;
                int nextday = 0;

                for (int jan = 1; jan <= 31; jan++)
                {
                    if (1 <= jan && jan <= 7)
                    {
                        if (jan + preday > 7)
                        {
                            today = day[jan + preday - 7];
                        }
                        else
                        {
                            today = day[preday + jan];
                        }


                    }
                    else
                    {
                        today = day[(jan + preday) % 7];
                        nextday = (jan + preday) % 7;

                    }

                    if (jan == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }

                }
                preday = nextday;
                //Console.WriteLine(preday);       // 끝나는 일이 몇번째 배열인지 출력

                for (int feb = 1; feb <= 28; feb++)
                {
                    if (1 <= feb && feb <= 7)
                    {
                        if (feb + preday > 7)
                        {
                            today = day[(feb + preday) - 7];
                        }
                        else
                        {
                            today = day[preday + feb];
                        }
                    }
                    else
                    {
                        today = day[(feb + preday) % 7];
                        nextday = (feb + preday) % 7;
                    }
                    if (feb == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int mar = 1; mar <= 31; mar++)
                {
                    if (1 <= mar && mar <= 7)
                    {
                        if (mar + preday > 7)
                        {
                            today = day[(mar + preday) - 7];
                        }
                        else
                        {
                            today = day[preday + mar];
                        }
                    }
                    else
                    {
                        today = day[(mar + preday) % 7];
                        nextday = (mar + preday) % 7;
                    }

                    if (mar == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int apr = 1; apr <= 30; apr++)
                {
                    if (1 <= apr && apr <= 7)
                    {
                        if (apr + preday > 7)
                        {
                            today = day[((apr + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + apr];
                        }
                    }
                    else
                    {
                        today = day[(preday + apr) % 7];
                        nextday = (preday + apr) % 7;
                    }

                    if (apr == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int may = 1; may <= 31; may++)
                {
                    if (1 <= may && may <= 7)
                    {
                        if (may + preday > 7)
                        {
                            today = day[((may + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + may];
                        }
                    }
                    else
                    {
                        today = day[(preday + may) % 7];
                        nextday = (preday + may) % 7;
                    }

                    if (may == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int jun = 1; jun <= 30; jun++)
                {
                    if (1 <= jun && jun <= 7)
                    {
                        if (jun + preday > 7)
                        {
                            today = day[((jun + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + jun];
                        }
                    }
                    else
                    {
                        today = day[(preday + jun) % 7];
                        nextday = (preday + jun) % 7;
                    }

                    if (jun == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int jul = 1; jul <= 31; jul++)
                {
                    if (1 <= jul && jul <= 7)
                    {
                        if (jul + preday > 7)
                        {
                            today = day[((jul + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + jul];
                        }
                    }
                    else
                    {
                        today = day[(preday + jul) % 7];
                        nextday = (preday + jul) % 7;
                    }

                    if (jul == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int aug = 1; aug <= 31; aug++)
                {
                    if (1 <= aug && aug <= 7)
                    {
                        if (aug + preday > 7)
                        {
                            today = day[((aug + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + aug];
                        }
                    }
                    else
                    {
                        today = day[(preday + aug) % 7];
                        nextday = (preday + aug) % 7;
                    }

                    if (aug == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int sep = 1; sep <= 30; sep++)
                {
                    if (1 <= sep && sep <= 7)
                    {
                        if (sep + preday > 7)
                        {
                            today = day[((sep + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + sep];
                        }
                    }
                    else
                    {
                        today = day[(preday + sep) % 7];
                        nextday = (preday + sep) % 7;
                    }

                    if (sep == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int oct = 1; oct <= 31; oct++)
                {
                    if (1 <= oct && oct <= 7)
                    {
                        if (oct + preday > 7)
                        {
                            today = day[((oct + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + oct];
                        }
                    }
                    else
                    {
                        today = day[(preday + oct) % 7];
                        nextday = (preday + oct) % 7;
                    }

                    if (oct == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int nov = 1; nov <= 30; nov++)
                {
                    if (1 <= nov && nov <= 7)
                    {
                        if (nov + preday > 7)
                        {
                            today = day[((nov + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + nov];
                        }
                    }
                    else
                    {
                        today = day[(preday + nov) % 7];
                        nextday = (preday + nov) % 7;
                    }

                    if (nov == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int dec = 1; dec <= 31; dec++)
                {
                    if (1 <= dec && dec <= 7)
                    {
                        if (dec + preday > 7)
                        {
                            today = day[((dec + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + dec];
                        }
                    }
                    else
                    {
                        today = day[(preday + dec) % 7];
                        nextday = (preday + dec) % 7;
                    }

                    if (dec == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;


            }

            public static void LeapMonth()
            {
                string[] day = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                string today = "";
                int preday = 0;
                int nextday = 0;

                for (int jan = 1; jan <= 31; jan++)
                {
                    if (1 <= jan && jan <= 7)
                    {
                        if (jan + preday > 7)
                        {
                            today = day[jan + preday - 7];
                        }
                        else
                        {
                            today = day[preday + jan];
                        }

                    }
                    else
                    {
                        today = day[(jan + preday) % 7];
                        nextday = (jan + preday) % 7;
                    }

                    if (jan == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;
                Console.WriteLine(preday);

                for (int feb = 1; feb <= 29; feb++)
                {
                    if (1 <= feb && feb <= 7)
                    {
                        if (feb + preday > 7)
                        {
                            today = day[(feb + preday) - 7];
                        }
                        else
                        {
                            today = day[preday + feb];
                        }
                    }
                    else
                    {
                        today = day[(feb + preday) % 7];
                        nextday = (feb + preday) % 7;
                    }

                    if (feb == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;

                for (int mar = 1; mar <= 31; mar++)
                {
                    if (1 <= mar && mar <= 7)
                    {
                        if (mar + preday > 7)
                        {
                            today = day[(mar + preday) - 7];
                        }
                        else
                        {
                            today = day[preday + mar];
                        }

                        if (mar == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(mar + preday) % 7];
                        nextday = (mar + preday) % 7;
                    }
                }
                preday = nextday;

                for (int apr = 1; apr <= 30; apr++)
                {
                    if (1 <= apr && apr <= 7)
                    {
                        if (apr + preday > 7)
                        {
                            today = day[((apr + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + apr];
                        }

                        if (apr == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + apr) % 7];
                        nextday = (preday + apr) % 7;
                    }
                }
                preday = nextday;

                for (int may = 1; may <= 31; may++)
                {
                    if (1 <= may && may <= 7)
                    {
                        if (may + preday > 7)
                        {
                            today = day[((may + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + may];
                        }

                        if (may == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + may) % 7];
                        nextday = (preday + may) % 7;
                    }
                }
                preday = nextday;

                for (int jun = 1; jun <= 30; jun++)
                {
                    if (1 <= jun && jun <= 7)
                    {
                        if (jun + preday > 7)
                        {
                            today = day[((jun + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + jun];
                        }

                        if (jun == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + jun) % 7];
                        nextday = (preday + jun) % 7;
                    }
                }
                preday = nextday;

                for (int jul = 1; jul <= 31; jul++)
                {
                    if (1 <= jul && jul <= 7)
                    {
                        if (jul + preday > 7)
                        {
                            today = day[((jul + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + jul];
                        }

                        if (jul == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + jul) % 7];
                        nextday = (preday + jul) % 7;
                    }
                }
                preday = nextday;

                for (int aug = 1; aug <= 31; aug++)
                {
                    if (1 <= aug && aug <= 7)
                    {
                        if (aug + preday > 7)
                        {
                            today = day[((aug + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + aug];
                        }

                        if (aug == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + aug) % 7];
                        nextday = (preday + aug) % 7;
                    }
                }
                preday = nextday;

                for (int sep = 1; sep <= 30; sep++)
                {
                    if (1 <= sep && sep <= 7)
                    {
                        if (sep + preday > 7)
                        {
                            today = day[((sep + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + sep];
                        }

                        if (sep == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + sep) % 7];
                        nextday = (preday + sep) % 7;
                    }
                }
                preday = nextday;

                for (int oct = 1; oct <= 31; oct++)
                {
                    if (1 <= oct && oct <= 7)
                    {
                        if (oct + preday > 7)
                        {
                            today = day[((oct + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + oct];
                        }

                        if (oct == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + oct) % 7];
                        nextday = (preday + oct) % 7;
                    }
                }
                preday = nextday;

                for (int nov = 1; nov <= 30; nov++)
                {
                    if (1 <= nov && nov <= 7)
                    {
                        if (nov + preday > 7)
                        {
                            today = day[((nov + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + nov];
                        }

                        if (nov == 1)
                        {
                            if (today == "Sun")
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        today = day[(preday + nov) % 7];
                        nextday = (preday + nov) % 7;
                    }
                }
                preday = nextday;

                for (int dec = 1; dec <= 31; dec++)
                {
                    if (1 <= dec && dec <= 7)
                    {
                        if (dec + preday > 7)
                        {
                            today = day[((dec + preday) - 7)];
                        }
                        else
                        {
                            today = day[preday + dec];
                        }
                    }
                    else
                    {
                        today = day[(preday + dec) % 7];
                        nextday = (preday + dec) % 7;
                    }

                    if (dec == 1)
                    {
                        if (today == "Sun")
                        {
                            count++;
                        }
                    }
                }
                preday = nextday;
            }
        }


        public static void Quiz9()
        {
            ArrayList Num = new ArrayList();
            int Sum = 0;
            Num.Add(1);

            for (int factorial = 1; factorial <= 100; factorial++)
            {
                for (int j = 0; j < Num.Count; j++)
                {
                    Num[j] = (int)Num[j] * factorial;
                }

                for (int j = 0; j < Num.Count; j++)
                {
                    if ((int)Num[j] >= 10)
                    {
                        if (((int)Num[j] / 100) > 0)
                        {
                            if (Num.Count <= (j + 1)) Num.Add(0);

                            if (Num.Count <= (j + 2))
                            {
                                Num.Add((int)Num[j] / 100);
                                Num[j] = (int)Num[j] % 100;
                            }
                            else
                            {
                                Num[j + 2] = (int)Num[j + 2] + ((int)Num[j] / 100);
                                Num[j] = (int)Num[j] % 100;
                            }
                        }

                        if (Num.Count <= (j + 1))
                        {
                            Num.Add((int)Num[j] / 10);
                            Num[j] = (int)Num[j] % 10;
                        }
                        else
                        {
                            Num[j + 1] = (int)Num[j + 1] + ((int)Num[j] / 10);
                            Num[j] = (int)Num[j] % 10;
                        }
                    }
                }
            }
            for (int i = 0; i < Num.Count; i++)
            {
                Sum += (int)Num[i];
            }
            Console.WriteLine("100!의 자리수의 합: {0}", Sum);
        }

        public static void Quiz10()
        {
            int num;
            int big = 0;

            for (int i = 100; i < 1000; i++)
            {
                for (int j = i; j < 1000; j++)  // 연산하는 수가 적어 j초기값을 100이나 i로 두나 큰 차이가 없다.
                {
                    num = i * j;

                    /*가장 큰 대칭수를 찾으라 하여 자릿수를 6자리수 경우만 생각함 (범위 5~6자리임)*/ 

                    if (num / 100000 == num % 10)   // 1번째와 6번째 수
                    {
                        if (num / 10000 % 10 == num / 10 % 10)  // 2번째와 5번째 수
                        {
                            if (num / 1000 % 10 == num / 100 % 10)
                            {
                                if (big < num)
                                {
                                    big = num;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("3자리를 곱해 만들 수 있는 가장 큰 대칭수: {0}", big);
        }

    }
}
