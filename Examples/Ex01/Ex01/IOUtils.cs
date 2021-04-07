using Ex01.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    public static class IOUtils
    {
        private static IDictionary<string, string> ExternalValues = null;
        
        public static void SetExtValues(IDictionary<string, string> values)
        {
            ExternalValues = values;
        }

        public delegate void ValidationHandler(int value);

        public static int SafeReadInteger(string paramName, string message, ISpecification<int> specification = null)
        {
            if (ExternalValues == null && !string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = GetValue(paramName, message);                                   
                try
                {
                    int iValue = Int32.Parse(sValue);
                    if (specification != null)                               
                    {
                        specification.Validate(iValue);
                    }
                    return iValue;
                }
                catch (Exception ex)
                {
                    if ((ex is ValidationException) ||
                        (ex is OverflowException) ||
                        (ex is FormatException))
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                        if (ExternalValues != null)
                        {
                            throw new InvalidOperationException(ex.Message, ex);
                        }
                    }
                    throw ex;
                }
            }
        }

        private static string GetValue(string paramName, string message)
        {
            string sValue = null;
            if (ExternalValues == null)
            {
                sValue = Console.ReadLine();
            }
            else
            {
                if (!ExternalValues.TryGetValue(paramName, out sValue))
                {
                    throw new InvalidOperationException(string.Format("Parameter -{0} not specify.", paramName));
                }
            }
            return sValue;
        }

        public static int SafeReadInteger(string paramName, string message, ValidationHandler validator)
        {
            if (ExternalValues == null && !string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = GetValue(paramName, message);
                try
                {
                    int iValue = Int32.Parse(sValue);
                    if (validator != null)
                    {
                        validator(iValue);
                    }
                    return iValue;
                }
                catch (Exception ex)
                {
                    if ((ex is ValidationException) ||
                        (ex is OverflowException) ||
                        (ex is FormatException))
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                        if (ExternalValues != null)
                        {
                            throw new InvalidOperationException(ex.Message, ex);
                        }
                    }
                    throw ex;
                }
            }
        }

        public static DateTime SafeReadDate(string paramName, string message)
        {
            if (ExternalValues == null && !string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = GetValue(paramName, message);
                try
                {
                    DateTime date = DateTime.ParseExact(sValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                   
                    return date;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    if (ExternalValues != null)
                    {
                        throw new InvalidOperationException(ex.Message, ex);
                    }
                }
            }
        }
    }
}
