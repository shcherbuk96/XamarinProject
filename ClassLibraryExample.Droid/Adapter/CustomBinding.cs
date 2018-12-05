using FFImageLoading;
using FFImageLoading.Views;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using System;

namespace ClassLibraryExample.Droid.Adapter
{
    public class CustomBinding : MvxTargetBinding<ImageViewAsync, string>
    {

        public CustomBinding(ImageViewAsync image) : base(image)
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