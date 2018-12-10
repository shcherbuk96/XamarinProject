using System;
using Android.Views;
using Android.Widget;
using ClassLibraryExample.Core;
using ClassLibraryExample.Core.Pojo;
using FFImageLoading.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.PhotosRecyclerView
{
    public class PhotosViewHolder : MvxRecyclerViewHolder
    {
        private readonly Action<HitModel> _itemClickAction;
        public TextView Tags { get; set; }
        public TextView User { get; set; }
        public ImageViewAsync Image { get; set; }
        private View _itemView;

        public PhotosViewHolder(View itemView, IMvxAndroidBindingContext context, Action<HitModel> itemClickAction) : base(
            itemView, context)
        {
            _itemView = itemView;
            _itemClickAction = itemClickAction;

            Tags = itemView.FindViewById<TextView>(Resource.Id.item_tags);
            User = itemView.FindViewById<TextView>(Resource.Id.item_user);
            Image = itemView.FindViewById<ImageViewAsync>(Resource.Id.item_image);

            Binding();

            _itemView.Click += OnClick;           
        }

        public void Binding()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PhotosViewHolder, HitModel>();

                set.Bind(Image)
                    .For(Constants.ImageAsyncBindingName)
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _itemView.Click -= OnClick;
            }

            base.Dispose(disposing);
        }
        private void OnClick(object sender, EventArgs e)
        {
            _itemClickAction.Invoke((HitModel)DataContext);
        }
    }
}