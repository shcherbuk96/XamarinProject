using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views
{
    class DescriptionView: MvxView
    {
        public UIImageView PhotoImageView { get; set; }
        public UILabel DescriptionLabel { get; set; }

        public DescriptionView()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetupSubviews();
            SetupSubviewsConstraints();
            SetupLayout();
            SetupLayoutConstraints();
        }

        protected virtual void SetupSubviews()
        {
            BackgroundColor = UIColor.White;
            PhotoImageView = new UIImageView();
            DescriptionLabel=new UILabel();
            
        }

        protected virtual void SetupSubviewsConstraints()
        {
        }

        protected virtual void SetupLayout()
        {
            AddSubviews(PhotoImageView, DescriptionLabel);
        }

        protected virtual void SetupLayoutConstraints()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                DescriptionLabel.Below(PhotoImageView,8),
                DescriptionLabel.AtRightOf(this,8),
                DescriptionLabel.AtLeftOf(this,8),
                PhotoImageView.Height().EqualTo(300),
                PhotoImageView.AtTopOfSafeArea(this),
                PhotoImageView.AtLeftOf(this),
                PhotoImageView.AtRightOf(this));
        }
    }
}