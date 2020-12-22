using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Xamarin_Layout.Interface;
using Xamarin_Layout.Model;

namespace Xamarin_Layout.Adapter
{
    public class AdapterHome : RecyclerView.Adapter
    {
        private Context context;
        private List<ItemHome> itemList;

        public override int GetItemViewType(int position)
        {
            if (itemList.Count == 1) return 0;
            else
            {
                if (itemList.Count % Common.NUM_OF_COLUMNS == 0)
                    return 1;
                else
                    return (position > 1 && position == itemList.Count - 1) ? 0 : 1;
            }
        }

        public AdapterHome(Context context, List<ItemHome> itemList)
        {
            this.context = context;
            this.itemList = itemList;
        }

        public override int ItemCount => itemList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder myViewHolder = holder as MyViewHolder;

            myViewHolder.imgIcon.SetImageResource(itemList[position].Icon);
            myViewHolder.txtDescription.Text = itemList[position].Description;

            myViewHolder.SetOnClick(new HomeOnItemClick(context, itemList[position]));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(context).Inflate(Resource.Layout.lyt_menu_home, parent, false);
            return new MyViewHolder(itemView);
        }

        private class MyViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
        {
            public TextView txtDescription;
            public ImageView imgIcon;
            ICardItemListener listener;

            public void SetOnClick(ICardItemListener listener)
            {
                this.listener = listener;
            }

            public MyViewHolder(View itemView) : base(itemView)
            {
                txtDescription = itemView.FindViewById<TextView>(Resource.Id.txtDescription);
                imgIcon = itemView.FindViewById<ImageView>(Resource.Id.imgIcon);

                itemView.SetOnClickListener(this);
            }

            public void OnClick(View v)
            {
                listener.OnCardItemClick(v, AdapterPosition);
            }
        }

        private class HomeOnItemClick : ICardItemListener
        {
            private Context context;
            private ItemHome itemHome;

            public HomeOnItemClick(Context context, ItemHome itemHome)
            {
                this.context = context;
                this.itemHome = itemHome;
            }

            public void OnCardItemClick(View view, int position)
            {
                Toast.MakeText(context, "Clicked : " + itemHome.Description, ToastLength.Short).Show();
            }
        }
    }
}