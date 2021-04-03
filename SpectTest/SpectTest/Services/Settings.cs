using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpectTest.Services
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserLogged
        {
            get => AppSettings.GetValueOrDefault(nameof(UserLogged), "Unknown");
            set => AppSettings.AddOrUpdateValue(nameof(UserLogged), value);
        }

        public static void RemoveUserLogged()
        {
            AppSettings.Remove(nameof(UserLogged));
        }
    }
}
