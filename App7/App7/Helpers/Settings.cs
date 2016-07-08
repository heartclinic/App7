// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace App7.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;
        private const string UserLogKey = "UserLog";
        private static readonly string UserLogDefault = "";
        private const string CurrentDayKey = "CurrentDayKey";
        private static readonly string CurrentDayDefault = "1";
        private const string BegginingStepKey = "BegginingStep";
        private static readonly float BegginingStepDefault = 0;
        #endregion


        public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
      }
    }
        public static string UserLog
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserLogKey, UserLogDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserLogKey, value);
            }
        }
        public static string CurrentDay
        {
            get
            {
                return AppSettings.GetValueOrDefault(CurrentDayKey, CurrentDayDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CurrentDayKey, value);
            }
        }
        public static float BegginingStep
        {
            get
            {
                return AppSettings.GetValueOrDefault(BegginingStepKey, BegginingStepDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(BegginingStepKey, value);
            }
        }

    }
}