int buttonPin = 10;//button
int LedPin = 12;//led
bool detected = false;// avoid contact bounce (also called chatter)
char data_rx; //data received by Visual Studio(C# program)



void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(buttonPin, INPUT);
  pinMode(LedPin, OUTPUT);
  digitalWrite(LedPin, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (digitalRead(buttonPin)==  LOW && !detected)
  {
  detected=true;
  }
  else if (digitalRead(buttonPin)== HIGH && detected){
    Serial.println("1");
    detected = false;
    }
    data_rx = Serial.read();//read the data form C# program
    //if email sent =>turn on led//
    if (data_rx =='1')
     digitalWrite(LedPin,HIGH);
     delay(2000);
     digitalWrite(LedPin, LOW);
}
