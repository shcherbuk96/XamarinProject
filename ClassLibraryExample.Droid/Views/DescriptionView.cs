using Android.App;
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


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_description);

            _userTextView = FindViewById<TextView>(Resource.Id.description_user_text_view);
            _tagsTextView = FindViewById<TextView>(Resource.Id.description_tags_text_view);
            _likesTextView = FindViewById<TextView>(Resource.Id.description_likes_text_view);
            _commentsTextView = FindViewById<TextView>(Resource.Id.description_comments_text_view);
            _photoImageViewAsync = FindViewById<ImageViewAsync>(Resource.Id.description_photo_image_view);
            
            Binding();
        }

        public void Binding()
        {
            var set = this.CreateBindingSet<DescriptionView, DescriptionViewModel>();

            set.Bind(_userTextView)
                .For(v => v.Text)
                .To(vm => vm.User);

            set.Bind(_tagsTextView)
                .For(v => v.Text)
                .To(vm => vm.Tags);

            set.Bind(_likesTextView)
                .For(v => v.Text)
                .To(vm => vm.Likes);

            set.Bind(_commentsTextView)
                .For(v => v.Text)
                .To(vm => vm.Comments);

            set.Bind(_photoImageViewAsync)
                .For(Constants.ImageAsyncBindingName)
                .To(vm => vm.PhotoUrl);

            set.Apply();
        }
    }
}