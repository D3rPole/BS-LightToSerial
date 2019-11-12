#include "BS_LightToSerial.h"
#include "Arduino.h"
#define byte uint8_t

BS_LightToSerial::BS_LightToSerial()
{
	Serial.begin(9600);

	left = (color){255, 0, 0};
	right = (color){0, 0, 255};

	chroma = false;

	light0 = (color){ 0,0,0 };
	light1 = (color){ 0,0,0 };
	light2 = (color){ 0,0,0 };
	light3 = (color){ 0,0,0 };
	light4 = (color){ 0,0,0 };

}

BS_LightEvent BS_LightToSerial::ParseMessage(byte msg[])
{
	BS_LightEvent message = (BS_LightEvent){255, 0};
	
	if(msg[0] == 0){
		left.r = msg[1];
		left.g = msg[2];
		left.b = msg[3];
		chroma = false;
	}else if(msg[0] == 1){
		right.r = msg[1];
		right.g = msg[2];
		right.b = msg[3];
		chroma = false;
	}else if(msg[0] == 2){
		bpm = msg[1];
	}else if(msg[0] == 3){
		message = (BS_LightEvent){msg[1], msg[2]};
	}else if(msg[0] == 4){
		light0.r = msg[1];
		light0.g = msg[2];
		light0.b = msg[3];
		chroma = true;
	}
	else if (msg[0] == 5) {
		light1.r = msg[1];
		light1.g = msg[2];
		light1.b = msg[3];
		chroma = true;
	}
	else if (msg[0] == 6) {
		light2.r = msg[1];
		light2.g = msg[2];
		light2.b = msg[3];
		chroma = true;
	}
	else if (msg[0] == 7) {
		light3.r = msg[1];
		light3.g = msg[2];
		light3.b = msg[3];
		chroma = true;
	}
	else if (msg[0] == 8) {
		light4.r = msg[1];
		light4.g = msg[2];
		light4.b = msg[3];
		chroma = true;
	}

	return message;
}