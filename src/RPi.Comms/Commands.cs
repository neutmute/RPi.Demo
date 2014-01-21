using System.Collections.Generic;
using System.Text;

namespace RPi.Comms
{
    public enum DeviceChannel
    {
        Unknown,
        Led,
        Servo,
        DcMotor
    }

    public struct StepperCommand
    {
        public int Steps { get; set; }

        public int DelayMs { get; set; }

        public StepperCommand(int steps, int delayMs) : this()
        {
            Steps = steps;
            DelayMs = delayMs;
        }

        public override string ToString()
        {
            return string.Format("Steps={0}, Delay={1}", Steps, DelayMs);
        }
    }

    public struct PwmCommand
    {
        public DeviceChannel Channel;

        public int DutyCyclePercent;

        public PwmCommand(DeviceChannel channel, int dutyCyclePercent)
        {
            Channel = channel;
            DutyCyclePercent = dutyCyclePercent;
        }

        public override string ToString()
        {
            return string.Format("{0}={1}%", Channel, DutyCyclePercent);
        }
    }
}
