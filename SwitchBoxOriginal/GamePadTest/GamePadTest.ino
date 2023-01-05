////include
#include <Joystick.h>

Joystick_ Joystick;

void setup() {
  // put your setup code here, to run once:

  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);  
  pinMode(6, OUTPUT);

  Joystick.begin();
}

void loop(){
  Joystick.setButton(1, false);
  Joystick.setButton(1, true);
}

/*
void loop() {
  // put your main code here, to run repeatedly:
  Joystick.setButton(1, outputMatrixPinStatus(2));
  Joystick.setButton(2, outputMatrixPinStatus(3));
}

boolean outputMatrixPinStatus(int _pinNo){
  boolean _pinStatus;
  _pinStatus = digitalRead(_pinNo);
  sendMessage((String)_pinStatus);
  return !_pinStatus;
}


void sendMessage(String _message){
    Serial.println(_message);
}*/