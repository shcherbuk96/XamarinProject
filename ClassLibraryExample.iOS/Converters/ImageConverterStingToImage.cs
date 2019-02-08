using System;
using System.Globalization;
using Foundation;
using MvvmCross.Converters;
using UIKit;

namespace Blank.Converters
{
    public class ImageConverterStingToImage : MvxValueConverter<string, UIImage>
    {
        public const string DEFAULT_IMAGE = "1.jpg";

        protected override UIImage Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            using (var url = new NSUrl(value))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}