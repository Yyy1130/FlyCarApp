using System;
using System.Collections.Generic;
using System.Text;

namespace FlyCarApp.Interface
{
    public interface IMessageShow
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
