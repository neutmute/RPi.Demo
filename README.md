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

![Circuit Diagram](http://raw.github.com/neutmute/RPi.Demo/master/src/RPi.Slides/Content/slides/circuit2.gif)

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/src/RPi.Slides/Content/slides/bb.jpg)

A lego ping pong launcher was constructed to showcase the motors in action.

![Breadboard](http://raw.github.com/neutmute/RPi.Demo/master/src/RPi.Slides/Content/slides/lego.jpg)



The solution expects the raspberry-sharp-io repo to be checked out into a sibling directory.

## SignalR ##
The original code at one point targeted Mono 2.x with a WinForms UI to allow interactive control of the motors (WinForms running in X-Windows).

The current solution targets mono 3, uses async/await and has several SignalR configurations:

1) Client-Server-Client topology.
SignalR hub is hosted on IIS 8 with two hubs: one hub for a web browser remote control client using jQuery mobile; a second hub for the pi itself to connect to via the signalR c# client.
This works well, apart from the requirement of IIS 8 as the mediator
see: Rpi.Console with signalR mode

2) Console app with an OWIN hosted webserver, using Nancy, SignalR and NoWin.
SignalR on mono cannot host websockets and the transport falls back to Server Side Events.
Response is very slow while dragging a slider backward and foward with several seconds lag before the server sees this response. see RPi.Nancy

WinForms on mono 3.x is broken at the time of writing.  