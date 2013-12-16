using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RPi.Pwm;
using RPi.Pwm.Motors;

namespace RPi.WinForms
{
    public partial class FrmMain : Form
    {
        private PwmController _motorController;
        private Pca9685DeviceFactory _deviceFactory;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _deviceFactory = new Pca9685DeviceFactory();
            var device = _deviceFactory.GetDevice();
            _motorController = new PwmController(device);

            _motorController.Init();
            //LogBus.Instance.LogReceived += Instance_LogReceived;      
        }

        //void Instance_LogReceived(object sender, LogEvent e)
        //{
        //    textLog.Text = e.Message + Environment.NewLine + textLog.Text;
        //}
        
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _motorController.AllStop();
            _deviceFactory.Dispose();
        }

        private void trackBarServo_Scroll(object sender, EventArgs e)
        {
            if (!EnsureConnected())
            {
                return;
            }
            _motorController.Servo.MoveTo(trackBarServo.Value);
        }

        private void trackBarDcMotor_Scroll(object sender, EventArgs e)
        {
            TrackBar senderBar = (TrackBar) sender;
            if (!EnsureConnected())
            {
                return;
            }
            var tickValue = senderBar.Value;
            trackBarDcMotor.Value = tickValue;
            trackBarDcMotor2.Value = tickValue;
            if (tickValue == 0)
            {
                _motorController.DcMotor.Stop();
            }
            else
            {
                _motorController.DcMotor.Go(Math.Abs(tickValue),
                    tickValue > 0 ? MotorDirection.Forward : MotorDirection.Reverse);
            }
        }

        private void trackBarLed_Scroll(object sender, EventArgs e)
        {
            if (EnsureConnected())
            {
                _motorController.Led0.On(trackBarLed.Value);
            }
        }

        private bool EnsureConnected()
        {
            return true;
        }

        private void btnStepper_Click(object sender, EventArgs e)
        {
            if (!EnsureConnected())
            {
                return;
            }
            _motorController.StepperMotor.StepDelayMs = (int)numericStepperDelay.Value;
            _motorController.StepperMotor.Rotate(Convert.ToInt32(textStepperBasic.Text));

        }

        private void btnServoGo_Click(object sender, EventArgs e)
        {
            trackBarServo.Value = (int) numericServo.Value;
        }

        private void trackBarServo_ValueChanged(object sender, EventArgs e)
        {
            if (!EnsureConnected())
            {
                return;
            }
            _motorController.Servo.MoveTo(trackBarServo.Value);
            numericServo.Value = trackBarServo.Value;
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!EnsureConnected())
            {
                return;
            }

            _motorController.Servo.MoveTo(70);
            Thread.Sleep(750);
            _motorController.Servo.MoveTo(10);
        }

        private void btnStepperSequenceLoad_Click(object sender, EventArgs e)
        {
            txtSequence.Text = string.Join(Environment.NewLine, _motorController.StepperMotor.Sequence);
        }

        private void btnStepperSequenceSet_Click(object sender, EventArgs e)
        {

            var text = txtSequence.Text;
            var sequence = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            _motorController.StepperMotor.Sequence = sequence;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _motorController.StepperMotor.Rotate(30);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _motorController.StepperMotor.Rotate(-30);

        }
    }
}
