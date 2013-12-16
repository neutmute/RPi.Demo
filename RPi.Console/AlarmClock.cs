using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPi.Pwm;

namespace RPi.ConsoleApp
{
    class AlarmClock
    {
        private PwmController _pwmController;

        public AlarmClock(PwmController pwmController)
        {
            _pwmController = pwmController;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
