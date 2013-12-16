using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.InterIntegratedCircuit;

namespace RPi.Pwm
{
    public class Pca9685DeviceFactory : IDisposable
    {
        #region Fields

        private bool _disposed;
        public const ConnectorPin SdaPin = ConnectorPin.P1Pin03;
        public const ConnectorPin SclPin = ConnectorPin.P1Pin05;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private I2cDriver _i2cDriver;

        #endregion

        #region Properties

        public bool IsConnected { get; set; }
        public int PwmFrequency { get; set; }
        public int DeviceAddress { get; set; }

        #endregion


        #region Methods

        public IPwmDevice GetDevice()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return GetRealDevice();
            }
            else
            {
                return GetStubDevice();
            }
        }

        private IPwmDevice GetStubDevice()
        {
            Log.Info("This is not a pi. Giving fake device");
            return new PwmDeviceStub();
        }

        private IPwmDevice GetRealDevice()
        {
            PwmFrequency = 60;
            DeviceAddress = 0x40;

            _i2cDriver = new I2cDriver(SdaPin.ToProcessor(), SclPin.ToProcessor());

            Log.Info("Creating device...");
            var device = Pca9685Connection.Create(_i2cDriver.Connect(DeviceAddress));
            Log.Info("Setting frequency...");
            device.SetPwmUpdateRate(PwmFrequency); //                        # Set frequency to 60 Hz


            IsConnected = true;
            return device;
        }


        public void Dispose()
        {
            IsConnected = false;
            Dispose(true);

            // Call SupressFinalize in case a subclass implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // If you need thread safety, use a lock around these  
                // operations, as well as in your methods that use the resource. 
                if (disposing)
                {
                    // Free the necessary managed disposable objects. 
                    if (_i2cDriver != null)
                    {
                        _i2cDriver.Dispose();
                    }
                }

                _i2cDriver = null;
                _disposed = true;
            }
        }

        #endregion

    }
}
