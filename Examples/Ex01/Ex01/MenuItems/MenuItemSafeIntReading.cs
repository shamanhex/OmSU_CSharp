using Ex01.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.MenuItems
{
    public class MenuItemSafeIntReading : MenuItemCore
    {
        public override string Title 
        {
            get
            {
                return "Safe read int >= 0";
            }
        }
       
        public override void Execute()
        {
            int value = IOUtils.SafeReadInteger("Enter int value:", new AndSpecification<int>(new IsNotZero(), new IsMoreThanZero()));
            Console.WriteLine("Value is {0}", value);
        }
    }
}
