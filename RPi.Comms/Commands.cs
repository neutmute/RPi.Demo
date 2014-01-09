using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPi.Comms
{
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
            public int DutyCyclePercent;

            public PwmCommand(int dutyCyclePercent)
            {
                DutyCyclePercent = dutyCyclePercent;
            }

            public override string ToString()
            {
                return string.Format("{0}%", DutyCyclePercent);
            }
        }

        public class RpiCommand
        {
            public PwmCommand? Led { get; set; }

            public PwmCommand? Servo { get; set; }

            public PwmCommand? DcMotor { get; set; }

            public StepperCommand? Stepper { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();

                Action<string, PwmCommand?> pwmCommandBuilder = (name, command) =>
                {
                    if (command.HasValue)
                    {
                        sb.AppendFormat("{0}={1};", name, command);
                    }
                };

                pwmCommandBuilder("Led", Led);
                pwmCommandBuilder("Servo", Servo);
                pwmCommandBuilder("DcMotor", DcMotor);

                if (Stepper.HasValue)
                {
                    sb.AppendFormat("Stepper={0};", Stepper);
                }

                return sb.ToString();
            }
        }
}
