Pi.Demo	
========

Connects the Adafruit 16-channel PWM/Servo Shield (PCA9685) to the Raspberry Pi via i2c. 
Demonstrates the use of mono & c# to control a servo, stepper and 9V DC motor.

The project uses:
- [Raspberry Sharp IO](https://github.com/raspberry-sharp/raspberry-sharp-io) for i2c comms.
- [PCA9685](https://github.com/neutmute/RPi.Demo/blob/master/Datasheets/PCA9685_PWM.pdf?raw=true)
- SN754410 quadruple half-H driver for bidirectional DC motor control
- 28BJY-48 5V stepper
- ULN2003A darlington array IC to drive the stepper


![Circuit Diagram](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/circuit2.gif)

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/bb.jpg)

A lego ping pong launcher was constructed to showcase the motors in action.

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/RPi.Slides/Content/slides/lego.jpg)