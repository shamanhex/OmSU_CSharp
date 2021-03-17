using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.MenuItems
{
    public class MenuItemWDelegate : MenuItemCore
    {
        private string _Title = "Title";

        public delegate void ExecuteHandler();
        private event ExecuteHandler OnExecute;

        public MenuItemWDelegate(string title, ExecuteHandler handler)
        {
            this._Title = title;
            this.OnExecute += handler;
        }

        public override string Title
        {
            get
            {
                return this._Title;
            }
        }

        public override void Execute()
        {
            this.OnExecute();
        }
    }
}
