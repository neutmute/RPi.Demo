Pi.Demo	
========

Connects the [Adafruit 16-channel PWM/Servo Shield](http://www.adafruit.com/products/1411) (PCA9685) to the Raspberry Pi via i2c. 

Demonstrates the use of mono & c# to control a servo, stepper and 9V DC motor from the Raspberry Pi.

The project uses:


- [PCA9685](https://github.com/neutmute/RPi.Demo/blob/master/Datasheets/PCA9685_PWM.pdf?raw=true) 16-channel, 12-bit PWM Fm+ I2C-bus LED controller (IC used in the [Adafruit 16-channel PWM/Servo Shield](http://www.adafruit.com/products/1411))
- [Raspberry Sharp IO](https://github.com/raspberry-sharp/raspberry-sharp-io) for i2c comms
- [SN754410](https://github.com/neutmute/RPi.Demo/blob/master/Datasheets/SN754410.pdf?raw=true) quadruple half-H driver for bidirectional DC motor control
- [28BJY-48](https://github.com/neutmute/RPi.Demo/blob/master/Datasheets/28BYJ-48_Stepper.pdf?raw=true)  5V stepper
- [ULN2003A](https://github.com/neutmute/RPi.Demo/blob/master/Datasheets/ULN2003A.pdf?raw=true) darlington array IC to drive the stepper

![Circuit Diagram](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/circuit2.gif)

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/bb.jpg)

A lego ping pong launcher was constructed to showcase the motors in action.

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/lego.jpg)

The original code used Mono 2 and a WinForms app for the UI.
The code now targets mono 3 and uses an IIS Windows based MVC app running SignalR to communicate with the pi's console app.

The solution expects the raspberry-sharp-io repo to be checked out into a sibling directory.