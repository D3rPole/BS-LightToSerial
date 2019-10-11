/*
  Test.h - Test library for Wiring - description
  Copyright (c) 2006 John Doe.  All right reserved.
*/

// ensure this library description is only included once
#ifndef BS_LightToSerial_h
#define BS_LightToSerial_h

#include <stdint.h>
#define byte uint8_t

struct BS_LightEvent
{
  int type;
  int value;
};
struct color
{
  int r;
  int g;
  int b;
};

// library interface description
class BS_LightToSerial
{
public:
  BS_LightToSerial();

  BS_LightEvent ParseMessage(byte[]);
  color left;
  color right;
  byte bpm;
  enum LightEvents
  {
    Off,
    Blue,
    BlueFlash,
    BlueFade,
    Unused,
    Red,
    RedFlash,
    RedFade
  };
};

#endif
