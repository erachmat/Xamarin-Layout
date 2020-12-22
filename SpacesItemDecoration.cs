using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Xamarin_Layout
{
    public class SpacesItemDecoration : RecyclerView.ItemDecoration
    {
        int space;

        public SpacesItemDecoration(int space)
        {
            this.space = space;
        }

        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            base.GetItemOffsets(outRect, view, parent, state);
            outRect.Top = outRect.Bottom = outRect.Left = outRect.Right = space;
        }
    }
}