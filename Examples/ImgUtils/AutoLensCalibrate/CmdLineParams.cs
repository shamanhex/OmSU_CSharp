using CmdLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLensCalibrate
{
    class CmdLineParams
    {
        [CmdLineParam("-i", "--input-folder")]
        public string InputFolder { get; set; }

        [CmdLineParam("-o", "--output-file")]
        public string OutputFile { get; set; }
    }
}
