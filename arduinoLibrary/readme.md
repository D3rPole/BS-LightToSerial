
# BS_LightToSerial

This is an Arduino library for processing lighting events from the Beat Saber mod.

For a usage example, check out the .ino in the examples folder.

To install, drag this entire folder into wherever you have your `arduino/libraries` folder (usually somewhere in Program Files!).

# Docs
## Types

### BS_LightToSerial

Created with `BS_LightToSerial bslts = BS_LightToSerial`

**Methods**

    BS_LightEvent BS_LightToSerial.ParseMessage(byte[])

Takes a 4 byte long array and returns a `BS_LightEvent` which contains light event details.

**Properties**

  

    color BS_LightToSerial.left

and

  

    color BS_LightToSerial.right

A `color` struct which contains the colours for the left and right sabres. These are automatically updated whenever the right event is passed to `ParseEvent`.

  

    byte BS_LightToSerial.bpm

The BPM of the current song. Updated automatically when the right event is passed to `ParseEvent`.

  

##

### struct color

A struct containing three bytes, r, g, and b making up a colour.

Used either as

    color c = (color){255, 0, 0};

or

    color c;
    c.r = 255;
    c.g = 0;
    c.b = 0;  
##

### BS_LightEvent

A struct containing the values of a light event

**Properties**

    int BS_LightEvent.type

The type of light event. According to the original author, these are the corresponding lights:

Type 0-4 are the 5 main lights.

0 = no light (turn completely off)

1 = blue light on

2 = blue light flash

3 = blue light fade out

4 = none

5 = red light on

6 = red light flash

7 = red light fade out

Type 12 and 13 are the speed of the left/right laser (Type 2 and 3) and the event value controls the speed.

    int BS_LightEvent.value

The value of the event. Corresponds to different things depending on the event type, for example, brightness or rotation speed.

**IMPORTANT!** `type` equals 255 if the given event was not a lighting event (or if something else went wrong). Make sure to add a check if `event.type == 255` to make sure you are only using good values!
