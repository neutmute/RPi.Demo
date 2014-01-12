using System.Collections.Generic;
using System.Text;

namespace RPi.Comms
{
    public enum PwmChannel
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
        public PwmChannel Channel;

        public int DutyCyclePercent;

        public PwmCommand(PwmChannel channel, int dutyCyclePercent)
        {
            Channel = channel;
            DutyCyclePercent = dutyCyclePercent;
        }

        public override string ToString()
        {
            return string.Format("{0}={1}%", Channel, DutyCyclePercent);
        }
    }

    public class RpiCommand
    {
        public List<PwmCommand> PwmCommands { get; set; }

        public StepperCommand? Stepper { get; set; }

        public RpiCommand()
        {
            PwmCommands = new List<PwmCommand>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            PwmCommands.ForEach(pwmC => sb.AppendFormat("{0}; ", pwmC));

            if (Stepper.HasValue)
            {
                sb.AppendFormat("Stepper={0};", Stepper);
            }

            return sb.ToString();
        }
    }
}
