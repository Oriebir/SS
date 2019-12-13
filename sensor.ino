#include <SPI.h>
#include <RF24.h>


// define pins
const int lightPin = A0;
const int trigPin = 4;
const int echoPin = 2;

// define variables
int Tlight;
double duration;
double lastT = 0;
double currentT = 0;
double fs =1; // F de amostragem em mega hz
char command;
int aq = 1;
RF24 radio(7,8);
String message;
char Cmessage[16];
const uint64_t pipe = 0xE8E8F0F0E1LL;
char rdTxt[16];
double light;
double distance;
String resultL;
String resultD;

// define functions
void radioRxMode()
{
  radio.begin();
  radio.openReadingPipe(0,pipe);
  radio.setPALevel(RF24_PA_MIN);
  radio.startListening();
  Serial.println("listening...");
}
void radioTxMode()
{
  radio.begin();
  radio.openWritingPipe(pipe);
  radio.setPALevel(RF24_PA_MIN);
  radio.stopListening();
  Serial.println("Stopped listening...");
}

void setup() {
  pinMode(trigPin, OUTPUT); 
  pinMode(echoPin, INPUT); 
  pinMode(lightPin, INPUT); 

  Serial.begin(9600); 
  Serial.println("setup");
  radioRxMode();
}

void loop() {
  if (Serial.available()){
      command=Serial.read();
      switch (command){
      case'a': //stop
        aq=0;
        break;
      case'b':  //distância
        aq=1;
        break;
      case'c':  //luz
        aq=2;
        break;
      case'd':  //ambos
        aq=3;
        break;
      }
  }     
  digitalWrite(trigPin, LOW);
  currentT=millis();
  
  if ((aq==2 || aq==3) && currentT-lastT>=1/fs)
  {
    lastT=currentT;
    Tlight = analogRead(lightPin);  // em micro s
  }

  if ((aq==1 || aq==3) && currentT-lastT>=1/fs)
  {
    lastT=currentT;
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
    duration = pulseIn(echoPin, HIGH);  // em micro s
  }    
    if (radio.available())
  {
    radio.read(&rdTxt,sizeof(rdTxt));
    Serial.println("eval");
    light = ((log(922.9351/(922.9351-Tlight)))-0.7098)/0.0024;
    distance = (duration-126.59)/54.99;    
    if (strcmp(rdTxt,"Query 05")==0){
      radioTxMode();
      if (aq==1){
        message="L:N/a D:" + String(distance);
      }
      if (aq==2){
        message="L:" + String(light) + "D:N/a";
      }
      if (aq==3){
        message="L:" + String(light) + "D:" + String(distance); 
      }
      if (aq==0){
        message="L:N/a D:N/a";
      }
      message.toCharArray(Cmessage,16);
      Serial.println(message);
      radio.write(Cmessage,sizeof(Cmessage));
      radioRxMode();
    }
  }
}
