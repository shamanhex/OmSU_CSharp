using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineUtils;

namespace AutoScale
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdLineParams cmdLineParams = new CmdLineParams();
            CmdLineArgsParser.Parse(args, cmdLineParams);

            Console.WriteLine("Input path:  {0}", cmdLineParams.InputPath);
            Console.WriteLine("Output path: {0}", cmdLineParams.OutputPath);
            Console.WriteLine("Max width:   {0}", cmdLineParams.MaxWidth);
            Console.WriteLine("Max height:  {0}", cmdLineParams.MaxHeight);
        }
    }
}
