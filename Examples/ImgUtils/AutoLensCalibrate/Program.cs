using CmdLineUtils;
using Emgu.CV;
using ImgUtils;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AutoLensCalibrate
{
    class Program
    {
        public static readonly string[] IMAGE_EXTENSIONS = new string[] { ".jpg", ".png", ".bmp" };

        static void Main(string[] args)
        {
            CmdLineParams cmdLineParams = new CmdLineParams();
            CmdLineArgsParser.Parse(args, cmdLineParams);

            Console.WriteLine("Input folder:  {0}", cmdLineParams.InputFolder);
            Console.WriteLine("Output file : {0}", cmdLineParams.OutputFile);

            string[] inputImages = Directory.GetFiles(cmdLineParams.InputFolder).Where(f => IMAGE_EXTENSIONS.Contains(Path.GetExtension(f).ToLower())).ToArray();

            LensParams lensParams = null;

            LensCorrection.Calibrate(inputImages, out lensParams);

            Console.WriteLine("Lens correction matrix (K):");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0:0000.000}; ", lensParams.K[i, j]);
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("Distorsion coefficients (D):");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0:0.000}; ", lensParams.D[i, 0]);
            }
            Console.WriteLine(" ");

            lensParams.SaveToJsonFile(cmdLineParams.OutputFile);
        }
    }
}

