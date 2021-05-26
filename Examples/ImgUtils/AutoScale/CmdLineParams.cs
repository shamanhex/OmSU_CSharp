using System;
using System.Collections.Generic;
using System.IO;
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

        private int _maxHeight = 0;
        [CmdLineParam("-h", "--height")]
        public int MaxHeight {
            get
            {
                if (_maxHeight == 0)
                {
                    _maxHeight = AppSettings.MaxHeight;
                }
                return _maxHeight;
            }
            set
            {
                _maxHeight = value;
            }
        }

        private int _maxWidth = 0;
        [CmdLineParam("-w", "--width")]
        public int MaxWidth
        {
            get
            {
                if (_maxWidth == 0)
                {
                    _maxWidth = AppSettings.MaxWidth;
                }
                return _maxWidth;
            }
            set
            {
                _maxWidth = value;
            }
        }

        [CmdLineParam("-f", "--force")]
        public bool ForceOverride { get; set; }

        public static string GetOutputFileName(string inputFileName, string outputPath)
        {
            string inputFolder = Path.GetDirectoryName(inputFileName);
            string inputFileNameWoExt = Path.GetFileNameWithoutExtension(inputFileName);
            string inputFileExt = Path.GetExtension(inputFileName);

            string outputFileName = inputFileNameWoExt + ".mini" + inputFileExt;
            if (!string.IsNullOrWhiteSpace(outputPath))
            {
                return Path.Combine(outputPath, outputFileName);
            }
            else
            {
                return Path.Combine(inputFolder, outputFileName);
            }
        }
    }
}
