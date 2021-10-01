using System;

namespace Ex01.MenuItems
{
    public class MenuItemHelloWorld : MenuItemCore
    {
        public static readonly string HELLO_WORLD = "Hello world!";

        private string _HelloWorld = "Hello world!";

        public override string Title { 
            get 
            { 
                if (_HelloWorld == null)
                {
                    _HelloWorld = HELLO_WORLD;
                }
                return _HelloWorld; 
            } 
        }


        public void setTitle(string value) 
        {
            if (value == null)
            {
                _HelloWorld = HELLO_WORLD;
            }
            else
            {
                _HelloWorld = value;
            }
        } 

        public override void Execute()
        {
            this.setTitle("New Hello world!");
            Console.WriteLine("Hello world!");
        }
    }
}
