using Android.Views;
using Android.Widget;
using ClassLibraryExample.Core.Pojo;
using FFImageLoading.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System;

namespace ClassLibraryExample.Droid.Adapter
{
    public class MyViewHolder : MvxRecyclerViewHolder
    {
        public TextView Tags { get; set; }
        public TextView User { get; set; }
        public ImageViewAsync Image { get; set; }

        public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Tags = itemView.FindViewById<TextView>(Resource.Id.item_tags);
            User = itemView.FindViewById<TextView>(Resource.Id.item_user);
            Image = itemView.FindViewById<ImageViewAsync>(Resource.Id.item_image);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyViewHolder, Hit>();

                set.Bind(Image)
                .For("ImageAsync")
                .To(v => v.LargeImageURL);                        

                set.Bind(Tags)
                .For(l => l.Text)
                .To(vm => vm.Tags);

                set.Bind(User)
                .For(l => l.Text)
                .To(vm => vm.User);

                set.Apply();
            });
        }
    }
}