using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7.DependencySvcDevice
{
    public interface IDevice
    {
        //ссылкаhttp://codeworks.it/blog/?p=260
        string GetIdentifier();
    }
}
