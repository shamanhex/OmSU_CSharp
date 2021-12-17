using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Reflection
{
    public class ReflectionUtil
    {
        public static void ShowObjectStruct(object obj)
        {
            Type objType = obj.GetType();
            Console.WriteLine("class {0}", objType.FullName);
            Console.WriteLine("{");

            Console.WriteLine("\t//Fields");
            foreach (FieldInfo fi in objType.GetFields())
            {
                Console.WriteLine("\t{0} {1} = {2};", fi.FieldType.Name, fi.Name, fi.GetValue(obj));
            }
            Console.WriteLine(" ");
            Console.WriteLine("\t//Properties");
            foreach (PropertyInfo pi in objType.GetProperties())
            {
                Console.WriteLine("\t{0} {1}", pi.PropertyType.Name, pi.Name);
                Console.WriteLine("\t{");
                MethodInfo getter = pi.GetGetMethod();
                if (getter != null)
                {
                    Console.WriteLine("\t\tget; //{0}", getter.Invoke(obj, null));                    
                }
                MethodInfo setter = pi.GetSetMethod();
                if (setter != null)
                {
                    Console.WriteLine("\t\tset;");
                }
                Console.WriteLine("\t}");
            }

            Console.WriteLine(" ");
            Console.WriteLine("\t//Methods");
            foreach (MethodInfo mi in objType.GetMethods())
            {
                Console.Write("\t{0} {1}(", mi.ReturnType, mi.Name);
                foreach(ParameterInfo pi in mi.GetParameters())
                {
                    Console.Write("{0} {1},", pi.ParameterType, pi.Name);
                }
                Console.WriteLine(");");
            }

            Console.WriteLine("}");
        }

        internal static void SetFieldValue(object obj, string fieldName, object fieldValue)
        {
            FieldInfo field = obj.GetType().GetField(fieldName);
            if (field != null)
            {
                field.SetValue(obj, Convert.ChangeType(fieldValue, field.FieldType));
            }
        }
    }
}
