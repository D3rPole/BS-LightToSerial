# BS-Lightoutput
A Beatsaber mod that allows you to output the lightning events as a serial signal to be used in a Arduino,ESP32 and more

The mod outputs a string as a serial signal each time a lightning event happens.
It outputs a string in the following format: Type(intenger)/Value(intenger) as Example "1/5"

The type can correspond to a specific light or speed of lasers.

Type 0-4 are the 5 main lights. The lights can be controlled with the following values:
Value : 0 = no light (turn completly off)
        1 = blue light on
        2 = blue light flash
        3 = blue light fade out
        4 = none
        5 = red light on
        6 = red light flash
        7 = red light fade out

Type 12 and 13 are the speed of the left/right laser (Type 2 and 3) and the value tied to the Speed types controlls the speed. 


Eachtime a beatmap starts it also sends out the colors used for the map. It does it in the following format:

C1 or C2(like Left saber/Right saber)/R/G/B       -R,G,B are all integers from 0-255

a valid example would be   "C1/255/0/0"           -which would be Red for the first color.


In the ingame options you can set wich COM port and baudrate it should use.
