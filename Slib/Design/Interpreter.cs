using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Interpreter
    {
        public static class ChineseEnglishDict
        {
            private static Dictionary<string, string> dictionary = new Dictionary<string, string>();
            static ChineseEnglishDict()
            {
                dictionary.Add("this", "这");
                dictionary.Add("is", "是");
                dictionary.Add("an", "一个");
                dictionary.Add("apple", "苹果");
            }
            public static string GetEnglish(string value)
            {
                return dictionary[value];
            }
        }
        interface IExpression
        {
            void Interpret(StringBuilder sb);
        }

        public class WordExpression : IExpression
        {
            private string value;
            public WordExpression(string value)
            {
                this.value = value;
            }
            public void Interpret(StringBuilder sb)
            {
                sb.Append(ChineseEnglishDict.GetEnglish(value.ToLower()));
            }
        }

        public class SymbolExpression : IExpression
        {
            private string value;
            public SymbolExpression(string value)
            {
                this.value = value;
            }
            public void Interpret(StringBuilder sb)
            {
                switch (value)
                {
                    case ".":
                        sb.Append("。");
                        break;
                }
            }
        }

        public static class Translator
        {
            public static string Translate(string sentense)
            {
                StringBuilder sb = new StringBuilder();
                List<IExpression> expressions = new List<IExpression>();
                string[] elements = sentense.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in elements)
                {
                    string[] words = element.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        expressions.Add(new WordExpression(word));
                    }
                }
                foreach (IExpression expression in expressions)
                {
                    expression.Interpret(sb);
                }
                return sb.ToString();
            }
        }

        public static void invoke()
        {
            string english = "This is an apple";
            string chinese = Translator.Translate(english);
            Console.WriteLine(chinese);
        }
    }
}
