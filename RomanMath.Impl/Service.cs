using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RomanMath.Impl
{
	public static class Service
	{
		public static string S { get; set; }
		private static Dictionary<char, int> _romanSymb = new Dictionary<char, int>
		   {
				{'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
		   };
		private static Dictionary<string, int> _tempDictionary = new Dictionary<string, int> { };
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>

		public static string Evaluate(string expression)
		{
            StringBuilder stringBuilder = new StringBuilder(expression);
            char[] operat = { '-', '+', '*', '/', ' ' };
            String[] stringArr = expression.Split(operat, StringSplitOptions.None);

            foreach (string c in stringArr)
            {
                _tempDictionary.Add(c, 0);
            }

            int i = 0;
            int totalTemp = 0, prevTemp = 0;
            while (i < _tempDictionary.Count)
            {
                foreach (KeyValuePair<string, int> c in _tempDictionary.ToArray())
                {
                    foreach (char b in c.Key)
                    {
                        if (!_romanSymb.ContainsKey(b))
                            return null;
                        var crtTemp = _romanSymb[b];
                        totalTemp += crtTemp;
                        if (prevTemp != 0 && prevTemp < crtTemp)
                        {
                            if (prevTemp == 1 && (crtTemp == 5 || crtTemp == 10)
                                || prevTemp == 10 && (crtTemp == 50 || crtTemp == 100)
                                || prevTemp == 100 && (crtTemp == 500 || crtTemp == 1000))
                            {
                                totalTemp -= 2 * prevTemp;
                            }
                            else
                                return null;
                        }
                        prevTemp = crtTemp;
                    }
                    _tempDictionary[c.Key] += totalTemp;
                    totalTemp = 0;
                    prevTemp = 0;
                }
                foreach (KeyValuePair<string, int> d in _tempDictionary)
                {
                    stringBuilder.Replace(d.Key, d.Value.ToString());
                }
                S = stringBuilder.ToString();
                i++;
            }
            return S;
        }

        public static void Print(string s)
        {
            string num = Evaluate(s);
            DataTable dt = new DataTable();
            var v = dt.Compute(S, "");
            Console.WriteLine(s + " = " + v);
        }
	}
}
