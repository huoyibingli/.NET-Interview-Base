using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Equal();
        }


        public static string Reverse1(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new Exception();
            }

            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = str.Length; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static string Reverse2(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new Exception();
            }

            char[] chars = str.ToCharArray();
            int begin = 0;
            int end = chars.Length - 1;
            char tmpChar;
            while (begin < end)
            {
                tmpChar = chars[end];
                chars[end] = chars[begin];
                chars[begin] = tmpChar;
                begin++;
                end--;
            }
            string result = new string(chars);
            return result;
        }

        public static string Reverse3(string str)
        {
            char[] arr = str.ToCharArray();
            arr.Reverse();
            return new string(arr);
        }

        public static void Equal()
        {
            object a = new int[2];
            object b = new int[2];
            if (a == b)
            {
                Console.WriteLine(1);
            }

            if (object.Equals(a, b))
            {
                Console.WriteLine(2);
            }

            if (ReferenceEquals(a, b))
            {
                Console.WriteLine(3);
            }
        }
    }
}
