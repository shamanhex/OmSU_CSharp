using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineUtils;
using ImgUtils;

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
            Console.WriteLine("Force:       {0}", cmdLineParams.ForceOverride);

            if (File.Exists(cmdLineParams.InputPath))
            {
                string outputPath = cmdLineParams.OutputPath ?? CmdLineParams.GetOutputFileName(cmdLineParams.InputPath, cmdLineParams.OutputPath);
                ProcessFile(cmdLineParams.InputPath, outputPath, cmdLineParams.MaxWidth, cmdLineParams.MaxHeight, cmdLineParams.ForceOverride);
            }
            else if (Directory.Exists(cmdLineParams.InputPath))
            {                                  
                ProcessDirectory(cmdLineParams.InputPath, cmdLineParams.OutputPath, cmdLineParams.MaxWidth, cmdLineParams.MaxHeight, cmdLineParams.ForceOverride);
            }
            else
            {
                throw new InvalidOperationException("Path access denied: " + cmdLineParams.InputPath);
            }
            
        }

        public static readonly string[] IMAGE_EXTENSIONS = new string[] { ".jpg", ".png", ".bmp" };

        private static void ProcessDirectory(string inputPath, string outputPath, int maxWidth, int maxHeight, bool forceOverride)
        {
            string[] inputFiles = Directory.GetFiles(inputPath);
            foreach (string inputFile in inputFiles)
            {
                string fileExt = Path.GetExtension(inputFile).ToLower();
                if (!IMAGE_EXTENSIONS.Contains(fileExt))
                {
                    Console.WriteLine(string.Format("File type not supported ({0}): {1}", fileExt, inputFile));
                    continue;
                }
                string outputFile = CmdLineParams.GetOutputFileName(inputFile, outputPath);
                ProcessFile(inputFile, outputFile, maxWidth, maxHeight, forceOverride);
            }
        }

        private static void ProcessFile(string inputPath, string outputPath, int maxWidth, int maxHeight, bool forceOverride)
        {
            Bitmap fileImg = (Bitmap) Image.FromFile(inputPath);
            Bitmap destImg = ImageScaler.Resize(fileImg, maxWidth, maxHeight);
            string folderPath = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine(string.Format("Create direcotry: {0}", folderPath));
                Directory.CreateDirectory(folderPath);
            }
            Console.WriteLine(string.Format("File processed: {0}", outputPath));
            if (File.Exists(outputPath))
            {
                if (forceOverride)
                {
                    Console.WriteLine("File override: " + outputPath);
                    destImg.Save(outputPath);
                }
                else
                {
                    Console.WriteLine("File exist. Skip file: " + outputPath);
                }
            }
            else
            {
                destImg.Save(outputPath);
            }
        }
    }
}
