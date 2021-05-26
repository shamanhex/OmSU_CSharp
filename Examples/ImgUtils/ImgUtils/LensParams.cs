using Emgu.CV;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImgUtils
{
    public class LensParams
    {
        public double[,] K { get; set; }
        public double[,] D { get; set; }

        public LensParams()
        {
            this.K = null;
            this.D = null;
        }

        public LensParams(Matrix<double> k, Matrix<double> d)
        {
            this.K = MatrixToArray(k);
            this.D = MatrixToArray(d);
        }

        public static double[,] MatrixToArray(Matrix<double> m)
        {
            double[,] arr = new double[m.Rows, m.Cols];
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    arr[i, j] = m[i, j];
                }
            }
            return arr;
        }

        public static Matrix<double> ArrayToMatrix(double[,] arr)
        {
            Matrix<double> m = new Matrix<double>(arr.GetLength(0), arr.GetLength(1));
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    m[i, j] = arr[i, j];
                }
            }
            return m;
        }

        public void SaveToJsonFile(string outputFile)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(outputFile, json, Encoding.UTF8);
        }

        public static LensParams ReadFromJson(string jsonPath)
        {
            return JsonConvert.DeserializeObject<LensParams>(File.ReadAllText(jsonPath));
        }

        public IInputArray GetMatrixK()
        {
            return ArrayToMatrix(this.K);
        }

        public IInputArray GetMatrixD()
        {
            return ArrayToMatrix(this.D);
        }
    }
}
