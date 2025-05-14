using System.Xml;
using static System.Console;

namespace _2025._04._22_C_
{
    internal class Program
    {
        //정적 할당 - 미리 할당  동적 할당 - 필요시 할당
        //(string[] args) - 매개변수   전달인자를 넣는것
        static void Main(string[] args)
        {
            #region
            //Write("-hi!");
            //Write("정수입력: ");
            //int n1 = int.Parse(Console.ReadLine()!);
            //int n2 = int.Parse(Console.ReadLine()!);
            //WriteLine("더하기 곱하기 나누기 나머지 결과값을 출력 하세요");
            //WriteLine($"{n1}＋ {n2} = {n1+n2}"); // ㄷ 입력후 한자키 누르면 특수문자 입력가능
            //WriteLine($"{n1} × {n2} = {n1 * n2}");
            //WriteLine($"{n1} ÷ {n2} = {n1 / n2}");
            //WriteLine($"{n1} ㄷ {n2} = {n1 % n2}");
            #endregion

            // [] 대괄호 , {} 중괄호 , () 소괄호
            if (args.Length == 0) // 문자열의 길이가 0이면 
            {
                WriteLine("2025-04-22-CSharp"); // 이라인을 출력
                return; //위에 조건에 맞다면 빠져나감
               
            }
            for (int i = 0; i < args.Length; i++)
            //위 조건이 아니라면 첫번쨰 문자열을 출력
            WriteLine($"2025-04-22-CSharp: {args[i]}");





        }
    }
}
