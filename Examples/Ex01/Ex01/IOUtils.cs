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
        public delegate void ValidationHandler(int value);

        public static int SafeReadInteger(string message, ISpecification<int> specification = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                int iValue = 0;
                if (Int32.TryParse(sValue, out iValue))
                {
                    try
                    {
                        if (specification != null)
                        {
                            specification.Validate(iValue);
                        }
                        return iValue;
                    }
                    catch (ValidationException ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Incorrect format. Enter integer value...");
                }
            }
        }


        public static int SafeReadInteger(string message, ValidationHandler validator)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                int iValue = 0;
                if (Int32.TryParse(sValue, out iValue))
                {
                    try
                    {
                        if (validator != null)
                        {
                            validator(iValue);
                        }
                        return iValue;
                    }
                    catch (ValidationException ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Incorrect format. Enter integer value...");
                }
            }
        }

        public static DateTime SafeReadDate(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }
                Console.WriteLine("ERROR: Incorrect format. Enter correct date time...");
            }
        }
    }
}
