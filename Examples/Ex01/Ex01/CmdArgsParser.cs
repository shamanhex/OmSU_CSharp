using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    public class CmdArgsParser
    {
        public static IDictionary<string, string> Parse(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return null;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int iArg = 0; iArg < args.Length; iArg++)
            {
                string arg = args[iArg];
                if (arg.StartsWith("-"))
                {
                    string paramName = arg.TrimStart('-');
                    if (iArg + 1 >= args.Length)
                    {
                        throw new InvalidOperationException(string.Format("Incorrect args. {0} must have value.", arg));
                    }
                    if (dic.Keys.Contains(paramName))
                    {
                        throw new InvalidOperationException(string.Format("Incorrect args. {0} must specify once.", paramName));
                    }
                    string paramValue = args[++iArg];
                    dic.Add(paramName, paramValue);
                }
            }
            return dic;
        }
    }
}
