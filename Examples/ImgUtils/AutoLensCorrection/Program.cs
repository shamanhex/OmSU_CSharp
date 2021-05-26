using CmdLineUtils;
using Emgu.CV;
using ImgUtils;
using System;
using System.IO;
using System.Linq;

namespace AutoLensCorrection
{
    class Program
    {
        public static readonly string[] IMAGE_EXTENSIONS = new string[] { ".jpg", ".png", ".bmp" };

        static void Main(string[] args)
        {
            CmdLineParams cmdLineParams = new CmdLineParams();
            CmdLineArgsParser.Parse(args, cmdLineParams);

            LensParams lensParams = LensParams.ReadFromJson(cmdLineParams.LensParamsJsonPath);

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

            if (!Directory.Exists(cmdLineParams.OutputFolder))
            {
                Console.WriteLine("Create output folder: {0}", cmdLineParams.OutputFolder);
                Directory.CreateDirectory(cmdLineParams.OutputFolder);
            }

            string[] inputImages = Directory.GetFiles(cmdLineParams.InputFolder).Where(f => IMAGE_EXTENSIONS.Contains(Path.GetExtension(f).ToLower())).ToArray();

            foreach (string imgPath in inputImages/*.Take(1).ToArray()*/)
            {
                string fileName = Path.GetFileName(imgPath);
                Console.WriteLine("Image processing {0}...", fileName);
                Mat image = CvInvoke.Imread(imgPath);
                //CvInvoke.Imshow("before", image);
                //CvInvoke.WaitKey(0);
                Mat outputImg = LensCorrection.Correct(image, lensParams);
                //CvInvoke.Imshow("after", outputImg);
                //CvInvoke.WaitKey(0);
                outputImg.Save(Path.Combine(cmdLineParams.OutputFolder, fileName));
            }
        }
    }
}
