/*
  Example sketch for BS_LightToSerial library
  This sketch writes out all received events and values
*/

#include <BS_LightToSerial.h> // Include the library

BS_LightToSerial bslts; // Create a BS_LightToSerial instance for parsing events

void setup() {
  Serial.begin(9600); // Open the serial port
}

void loop() {
  if (Serial.available()) { // Only do something if there's new data

    byte buf[4]; // Array for storing incoming data
    int index = 0; // How many bytes have been received

    while (index < 4) { // Wait until 4 bytes have been received
      if (Serial.available()) { // If there's a byte available, read and store it
        buf[index] = Serial.read();
        index++; // Increment byte counter
      }
    }

    BS_LightEvent test = bslts.ParseMessage(buf); // The ParseMessage function returns a BS_LightEvent containing the type of event and it's value 
    Serial.print("Type "); // Then print *everything*
    Serial.println(test.type);
    Serial.print("Value ");
    Serial.println(test.value);
    Serial.print("Left R ");
    Serial.println(bslts.left.r);
    Serial.print("Left G ");
    Serial.println(bslts.left.g);
    Serial.print("Left B ");
    Serial.println(bslts.left.b);

    Serial.print("Right R ");
    Serial.println(bslts.right.r);
    Serial.print("Right G ");
    Serial.println(bslts.right.g);
    Serial.print("Right B ");
    Serial.println(bslts.right.b);
    Serial.print("BPM ");
    Serial.println(bslts.bpm);
    Serial.println();
  }
  // Repeat!
}
