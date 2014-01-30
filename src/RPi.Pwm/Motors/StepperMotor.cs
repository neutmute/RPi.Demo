using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private Task _rotateTask;

        public int StepDelayMs { get; set; }

        public event EventHandler RotationCompleted;

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

        private Task GetRotateTask(int steps)
        {
            var rotateAction = new Action<int>(s =>
            {
                lock(_sequence)
                {
                    if (s == 0)
                    {
                        return;
                    }
                    var direction = GetDirection(s);

                    Log.Info(m => m("Stepper: {0} steps {1}", s, direction));
                    for (int i = 0; i < Math.Abs(s); i++)
                    {
                        AdvanceStep(direction);
                        var sequenceCode = Sequence[_currentStep];
                        for (int controllerIndex = 0; controllerIndex < _channels.Length; controllerIndex++)
                        {
                            Controller.SetFull(_channels[controllerIndex], IsEnergised(sequenceCode, controllerIndex));
                        }

                        Log.Debug(m => m("Step {3}/{4}-{0}: {1}. sleep={2}", _currentStep, sequenceCode, StepDelayMs, i, s));

                        Task.Delay(TimeSpan.FromMilliseconds(StepDelayMs)).Wait();
                    }

                    foreach (PwmChannel channel in _channels)
                    {
                        Controller.SetFull(channel, false);
                    }
                    Log.Info(m => m("Step task complete"));
                }
            });

            var task = new Task(() => rotateAction(steps));
            return task;
        }

        public void Rotate(int steps)
        {
            if (_rotateTask != null && !_rotateTask.IsCompleted)
            {
                Log.WarnFormat("Still executing prior rotation command. Command ignored.");
                return;
            }
            if (_rotateTask != null)
            {
                _rotateTask.Dispose();
            }

            _rotateTask = GetRotateTask(steps);
            _rotateTask.ContinueWith(RotationComplete);
            _rotateTask.Start();

        }


        private void FireRotationCompleted()
        {
            EventHandler handler = RotationCompleted;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        private void RotationComplete(Task task)
        {
            if (task.IsFaulted)
            {
                Log.Error("Rotation task", task.Exception);
            }
            FireRotationCompleted();
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
