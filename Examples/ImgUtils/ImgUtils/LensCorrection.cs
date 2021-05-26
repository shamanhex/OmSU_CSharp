using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgUtils
{
    public class LensCorrection
    {
        public static readonly int CHESS_PATTERN_HEIGHT = 6;
        public static readonly int CHESS_PATTERN_WIDTH = 9;

        public static void Calibrate(string[] imgFiles, out LensParams lensParams)
        {
            Size patternSize = new Size(CHESS_PATTERN_WIDTH, CHESS_PATTERN_HEIGHT);

            VectorOfVectorOfPoint3D32F objPoints = new VectorOfVectorOfPoint3D32F();
            VectorOfVectorOfPointF imagePoints = new VectorOfVectorOfPointF();

            Size imageSize = Size.Empty;

            foreach (string file in imgFiles)
            {
                Mat img = CvInvoke.Imread(file, ImreadModes.Grayscale);
                if (imageSize == Size.Empty)
                {
                    imageSize = new Size(img.Width, img.Height);
                }
                //CvInvoke.Imshow("input", img);
                VectorOfPointF corners = new VectorOfPointF(patternSize.Width * patternSize.Height);
                bool find = CvInvoke.FindChessboardCorners(img, patternSize, corners);
                if (find)
                {
                    MCvPoint3D32f[] points = new MCvPoint3D32f[patternSize.Width * patternSize.Height];
                    int loopIndex = 0;
                    for (int i = 0; i < patternSize.Height; i++)
                    {
                        for (int j = 0; j < patternSize.Width; j++)
                            points[loopIndex++] = new MCvPoint3D32f(j, i, 0);
                    }
                    objPoints.Push(new VectorOfPoint3D32F(points));
                    imagePoints.Push(corners);
                }
            }

            Matrix<double> K = new Matrix<double>(3, 3);
            Matrix<double> D = new Matrix<double>(4, 1);
            Mat rotation = new Mat();
            Mat translation = new Mat();
            Fisheye.Calibrate(objPoints,
                imagePoints,
                imageSize,
                K,
                D,
                rotation,
                translation,
                Fisheye.CalibrationFlag.CheckCond,
                new MCvTermCriteria(30, 0.1)
            );
            lensParams = new LensParams(K, D);
        }

        public static Mat Correct(Mat img, LensParams lensParams)
        {
            Mat output = img.Clone();
            Fisheye.UndistorImage(img, output, lensParams.GetMatrixK(), lensParams.GetMatrixD());
            return output;
        }
    }                               
}
