#include "BS_LightToSerial.h"
#include "Arduino.h"
#define byte uint8_t

BS_LightToSerial::BS_LightToSerial()
{
	Serial.begin(9600);

	left = (color){255, 0, 0};
	right = (color){0, 0, 255};
}

BS_LightEvent BS_LightToSerial::ParseMessage(byte msg[])
{
	BS_LightEvent message = (BS_LightEvent){255, 0};
	
	if(msg[0] == 0){
		left.r = msg[1];
		left.g = msg[2];
		left.b = msg[3];
	}else if(msg[0] == 1){
		right.r = msg[1];
		right.g = msg[2];
		right.b = msg[3];
	}else if(msg[0] == 2){
		bpm = msg[1];
	}else if(msg[0] == 3){
		message = (BS_LightEvent){msg[1], msg[2]};
	}

	return message;
}