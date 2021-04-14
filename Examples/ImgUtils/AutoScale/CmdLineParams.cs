using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineUtils;

namespace AutoScale
{
    public class CmdLineParams
    {
        [CmdLineParam("-i", "--input-path")]
        public string InputPath { get; set; }

        [CmdLineParam("-o", "--output-path")]
        public string OutputPath { get; set; }

        [CmdLineParam("-h", "--height")]
        public int MaxHeight { get; set; }

        [CmdLineParam("-w", "--width")]
        public int MaxWidth { get; set; }
    }
}
