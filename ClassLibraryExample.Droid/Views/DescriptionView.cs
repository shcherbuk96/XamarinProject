﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ClassLibraryExample.Core;
using ClassLibraryExample.Core.ViewModels;
using FFImageLoading.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ClassLibraryExample.Droid.Views
{
    [Activity(Label = "DescriptionView")]
    public class DescriptionView : MvxAppCompatActivity<DescriptionViewModel>
    {
        private ImageViewAsync _photoImageViewAsync;
        private TextView _userTextView;
        private TextView _tagsTextView;
        private TextView _likesTextView;
        private TextView _commentsTextView;
        private Button _openWeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_description);

            _userTextView = FindViewById<TextView>(Resource.Id.description_user_text_view);
            _tagsTextView = FindViewById<TextView>(Resource.Id.description_tags_text_view);
            _likesTextView = FindViewById<TextView>(Resource.Id.description_likes_text_view);
            _commentsTextView = FindViewById<TextView>(Resource.Id.description_comments_text_view);
            _photoImageViewAsync = FindViewById<ImageViewAsync>(Resource.Id.description_photo_image_view);
            _openWeButton = FindViewById<Button>(Resource.Id.description_open_btn);

            Binding();

            _openWeButton.Click += ClickOpenPage;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _openWeButton.Click -= ClickOpenPage;
            }

            base.Dispose(disposing);
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<DescriptionView, DescriptionViewModel>();

            set.Bind(_userTextView)
                .For(v => v.Text)
                .To(vm => vm.HitModel.User);

            set.Bind(_tagsTextView)
                .For(v => v.Text)
                .To(vm => vm.HitModel.Tags);

            set.Bind(_likesTextView)
                .For(v => v.Text)
                .To(vm => vm.HitModel.Likes);

            set.Bind(_commentsTextView)
                .For(v => v.Text)
                .To(vm => vm.HitModel.Comments);

            set.Bind(_photoImageViewAsync)
                .For(Constants.ImageAsyncBindingName)
                .To(vm => vm.HitModel.LargeImageURL);

            set.Apply();
        }

        private void ClickOpenPage(object sender, EventArgs e)
        {
            var url = Android.Net.Uri.Parse(ViewModel?.HitModel.PageURL);
            var webIntent = new Intent(Intent.ActionView, url);
            StartActivity(webIntent);
        }

    }
}