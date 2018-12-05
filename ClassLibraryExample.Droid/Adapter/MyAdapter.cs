using System;
using Android.Support.V7.Widget;
using Android.Views;
using ClassLibraryExample.Core.Pojo;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.Adapter
{
    public class MyAdapter : MvxRecyclerAdapter
    {
        private readonly Action<HitModel> _itemClickAction;

        public MyAdapter(IMvxAndroidBindingContext bindingContext, Action<HitModel> itemClickAction) : base(bindingContext)
        {
            _itemClickAction = itemClickAction;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new MyViewHolder(view, itemBindingContext, _itemClickAction);
        }

    }
}