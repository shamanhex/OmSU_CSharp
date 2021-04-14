using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CmdLineUtils
{
    public class CmdLineArgsParser
    {
        public static void Parse(string[] args, object cmdLineParams)
        {
            foreach (PropertyInfo property in cmdLineParams.GetType().GetProperties())
            {
                List<string> paramNames = new List<string>();
                foreach (Attribute attr in property.GetCustomAttributes(typeof(CmdLineParamAttribute)))
                {
                    CmdLineParamAttribute paramAttr = (CmdLineParamAttribute) attr;
                    paramNames.AddRange(paramAttr.ParamNames);
                }
                if (paramNames.Count == 0)
                {
                    continue;
                }
                foreach (string paramName in paramNames)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (string.Compare(args[i], paramName, ignoreCase:true) == 0)
                        {
                            if (i+1 >= args.Length)
                            {
                                throw new InvalidOperationException("Не указано значение для аргумента " + paramName);
                            }
                            string paramValueStr = args[i + 1];
                            object paramValue = Convert.ChangeType(paramValueStr, property.PropertyType);
                            property.SetValue(cmdLineParams, paramValue);
                            break;
                        }
                    }
                }
            }
        }
    }
}
