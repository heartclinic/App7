﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7.DependencySvcStepCounter
{
    public interface IStepCounterDep
    {
       void GetSteps(Action<float> stepCountChanged );
    }
}
