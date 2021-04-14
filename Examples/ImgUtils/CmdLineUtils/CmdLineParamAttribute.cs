using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdLineUtils
{
    public class CmdLineParamAttribute : Attribute
    {
        public string[] ParamNames { get; set; }

        public CmdLineParamAttribute(params string[] cmdLineParamNames)
        {
            if (cmdLineParamNames == null && cmdLineParamNames.Length == 0)
            {
                throw new ArgumentOutOfRangeException("cmdLineParamNames", "Список имём параметра командной строки не может быть пустым");
            }
            this.ParamNames = cmdLineParamNames;
        }
    }
}
