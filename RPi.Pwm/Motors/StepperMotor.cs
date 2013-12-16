using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Raspberry.IO.Components.Controllers.Pca9685;

namespace RPi.Pwm.Motors
{
    public class StepperMotor : PwmComponentBase
    {
        public string[] Sequence
        {
            get { return _sequence; }
            set { _sequence = value;
                _currentStep = 0;
            }
        }

        private readonly PwmChannel[] _channels;
        private int _currentStep;
        private string[] _sequence;
        public int StepDelayMs { get; set; }

        public StepperMotor(
            IPwmDevice controller
            , PwmChannel controlChannel0
            , PwmChannel controlChannel1
            , PwmChannel controlChannel2
            , PwmChannel controlChannel3)
            : base(controller)
        {
            _channels = new [] {controlChannel0, controlChannel1, controlChannel2, controlChannel3};
            _currentStep = 0;
            StepDelayMs = 100;

            Sequence = new[]
            {
                "1000",
                "1100",
                "0100",
                "0110",
                "0010",
                "0011",
                "0001",
                "1001"
            };
        }

        public void Rotate(int steps)
        {
            if (steps == 0)
            {
                return;
            }
            var direction = GetDirection(steps);

            Log.Info(m=>m("Stepper: {0} steps {1}", steps, direction));
            for (int i = 0; i < Math.Abs(steps); i++)
            {
                AdvanceStep(direction);
                var sequenceCode = Sequence[_currentStep];
                for (int controllerIndex = 0; controllerIndex < _channels.Length; controllerIndex++)
                {
                    Controller.SetFull(_channels[controllerIndex], IsEnergised(sequenceCode, controllerIndex));
                }

                Log.Info(m=>m("Step {3}/{4}-{0}: {1}. sleep={2}", _currentStep, sequenceCode, StepDelayMs, i, steps));
                Thread.Sleep(StepDelayMs);    
            }

            foreach (PwmChannel channel in _channels)
            {
                Controller.SetFull(channel, false);
            }
        }

        private MotorDirection GetDirection(int steps)
        {
            return (MotorDirection) Enum.ToObject(typeof (MotorDirection), steps/Math.Abs(steps));
        }

        private bool IsEnergised(string code, int controller)
        {
            return code[controller] == '1';
        }

        private void AdvanceStep(MotorDirection direction)
        {
            _currentStep += (int) direction;
            if (_currentStep == Sequence.Length)
            {
                _currentStep = 0;
            }
            if (_currentStep == -1)
            {
                _currentStep = Sequence.Length - 1;
            }
        }
    }
}
