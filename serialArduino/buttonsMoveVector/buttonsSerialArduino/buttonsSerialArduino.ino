/*
 Two buttons serial communication to Unity
 Regina Cantu from https://www.youtube.com/watch?v=of_oLAvWfSI
 Winter 2017 ITP
 */
//the button pins are declared
const int buttonPin01 = 6;
const int buttonPin02=7;


void setup() {
  //serial communication is started at a 9600 baudrate 
  //and the button pins are setup as inputs that are high
  Serial.begin(9600);
  pinMode(buttonPin01, INPUT);
  pinMode(buttonPin02, INPUT);

  digitalWrite(buttonPin01, HIGH);
  digitalWrite(buttonPin02, HIGH);

}

void loop() {
  //This starts the transmision once you push
  if(digitalRead(buttonPin01) == LOW)
    {
      Serial.write(1);//what Unity will recieve
      Serial.flush();//Waits for the transmission of outgoing serial data to complete.
      delay(20);//Extra precaution so every message gets completly sent out
    }

    if(digitalRead(buttonPin02) == LOW)
    {
      Serial.write(2);
      Serial.flush();
      delay(20);
    }

}
