using CmdLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLensCorrection
{
    class CmdLineParams
    {
        [CmdLineParam("-lens", "--lens-json")]
        public string LensParamsJsonPath { get; set; }

        [CmdLineParam("-i", "--input-folder")]
        public string InputFolder { get; set; }

        [CmdLineParam("-o", "--output-folder")]
        public string OutputFolder { get; set; }
    }
}
