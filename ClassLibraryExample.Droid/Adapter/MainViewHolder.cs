using System;
using Android.Views;
using Android.Widget;
using ClassLibraryExample.Core.Pojo;
using FFImageLoading.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.Adapter
{
    public class MainViewHolder : MvxRecyclerViewHolder
    {
        private readonly Action<HitModel> _itemClickAction;

        public TextView Tags { get; set; }
        public TextView User { get; set; }
        public ImageViewAsync Image { get; set; }

        public MainViewHolder(View itemView, IMvxAndroidBindingContext context, Action<HitModel> itemClickAction) : base(
            itemView, context)
        {
            _itemClickAction = itemClickAction;

            Tags = itemView.FindViewById<TextView>(Resource.Id.item_tags);
            User = itemView.FindViewById<TextView>(Resource.Id.item_user);
            Image = itemView.FindViewById<ImageViewAsync>(Resource.Id.item_image);

            itemView.Click += OnClick;

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MainViewHolder, HitModel>();


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

        private void OnClick(object sender, EventArgs e)
        {
            _itemClickAction.Invoke((HitModel)DataContext);
        }
    }
}