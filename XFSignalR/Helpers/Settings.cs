using System;
using Xamarin.Essentials;

namespace XFSignalR.Helpers
{
    public static class Settings
    {
        public static readonly string ServerIP = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2:" : "localhost:";
    }
}
