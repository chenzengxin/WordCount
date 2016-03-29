using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace WordCount
{
    public static class WordCounting
    {
        /// <summary>
        /// Count words with Regex.
        /// </summary>
        public static int CountWords1(string s)//标点数
        {
            MatchCollection collection = Regex.Matches(s, @"\p{P}");
            return collection.Count;
        }
        /// <summary>
        /// Count word with loop and character tests.
        /// </summary>
        public static int CountWords2(string s)//汉字
        {
            MatchCollection collection = Regex.Matches(s, "[\u4e00-\u9fa5]");
            return collection.Count;
        }
        public static int CountWords3(string s)//注释
        {
            MatchCollection collection = Regex.Matches(s, "//");
            return collection.Count;
        }
        public static int CountWords4(string s)//空行
        {
            MatchCollection collection = Regex.Matches(s, @"\n\r");
            return collection.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = args[0];//"C:\\Users\\Administrator\\Desktop\\新建文件夹\\1.txt";//args[0];
            Console.WriteLine(Environment.CurrentDirectory);
            StreamReader sr = new StreamReader(url, Encoding.Default);
            string line;
            line = sr.ReadToEnd();
            Console.WriteLine(line);
            Console.WriteLine("标点符号数:" + WordCounting.CountWords1(line));
            Console.WriteLine("汉字数:" + WordCounting.CountWords2(line));
            Console.WriteLine("注释行数:" + WordCounting.CountWords3(line));
            Console.WriteLine("空行数:" + WordCounting.CountWords4(line));
        }
    }
}