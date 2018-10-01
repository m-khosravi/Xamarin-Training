using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (char c in raw)
            {
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                else
                {
                    int? result = TranslateToNumber(c);
                    if (result!=null)
                    {
                        newNumber.Append(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return newNumber.ToString();
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        private static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
