using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin_Layout.Model
{
    public class ItemHome
    {
        public int Icon { get; set; }
        public string Description { get; set; }

        public ItemHome(int Icon, string Description)
        {
            this.Icon = Icon;
            this.Description = Description;
        }
    }
}