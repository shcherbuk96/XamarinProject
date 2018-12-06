using Android.App;
using Android.Runtime;
using ClassLibraryExample.Core;
using MvvmCross.Platforms.Android.Views;
using System;

namespace ClassLibraryExample.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {           
        }
        
    }
}