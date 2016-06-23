using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using App7.Droid;
using App7.DependencySvcStepCounter;
using App7.Droid.DependencySvcStepCounter;

using Android.Content.PM;
using Android.Util;



[assembly: Xamarin.Forms.Dependency(typeof(StepCounter_Android))]


namespace App7.Droid.DependencySvcStepCounter
{
    [Service(Enabled = true)]
   public class StepCounter_Android : Java.Lang.Object, IStepCounterDep, ISensorEventListener
    {
        private Action<float> _stepCountChanged;

        

     
        public void GetSteps(Action<float> stepCountChanged)
        {
            SensorManager senMgr = (SensorManager) Android.App.Application.Context.GetSystemService(Context.SensorService);
            Sensor counter = senMgr.GetDefaultSensor(SensorType.StepCounter);

            if (counter != null)
            {
                senMgr.RegisterListener(this, counter, SensorDelay.Normal);
            }

            _stepCountChanged = stepCountChanged;
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
           
        }

        public void OnSensorChanged(SensorEvent e)
        {
            _stepCountChanged(e.Values.First());
        }
    }
}