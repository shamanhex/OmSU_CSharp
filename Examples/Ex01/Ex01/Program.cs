using Ex01.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.ClearItems();
            Menu.AddItem(new MenuItemExit());
            Menu.AddItem(new MenuItemHelloWorld());
            Menu.AddItem(new MenuItemDate());                                                    
            Menu.AddItem(new MenuItemSafeIntReading());

            while (true)
            {
                Menu.Execute();
            }
        }
    }

    struct Point
    {
        int X;
        int Y;
    }

    interface IList
    {
        int Count { get; }
        void AddItem();
        void Clear();
    }
}
