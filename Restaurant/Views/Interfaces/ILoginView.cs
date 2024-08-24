using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Views
{
    internal interface ILoginView
    {
        // Properties - Fields
        string Username { get; set; }
        string Password { get; set; }

        //Events
        event EventHandler LoginEvent;

        void HideWindow();

        void ShowError(string message);

    }
}
