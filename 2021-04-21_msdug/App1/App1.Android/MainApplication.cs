using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace App1.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }


        public override void OnCreate()
        {
            this.ShinyOnCreate(new MyShinyStartup());
            base.OnCreate();
        }
    }
}