using FFImageLoading;
using FFImageLoading.Views;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace ClassLibraryExample.Droid.Binding
{
    public class ImageAsyncBinding : MvxTargetBinding<ImageViewAsync, string>
    {

        public ImageAsyncBinding(ImageViewAsync image) : base(image)
        {
       
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.Default;

        protected override void SetValue(string value)
        {
            ImageService.Instance
                .LoadUrl(value)
                .Into(Target);
        }
    }
}