using System;
using Ex01;

namespace Ex01.MenuItems
{
    public class MenuItemDate : MenuItemCore
    {      
        public override string Title { get { return "Date parse"; } }

        public override void Execute()
        {
            DateTime date = IOUtils.SafeReadDate("Enter date:");
            Console.WriteLine("Value is {0}.{1}.{2}", date.Day, date.Month, date.Year);
        }
    }
}
