int ByteReceived;

void setup() {
  Serial.begin(9600);
}

void loop()
{
  if(Serial.available()>0){
    
   ByteReceived = Serial.read();
   if (ByteReceived == '1')
    {
      int nrAbs = random(100, 1000);
      int nrC = random(100, 1000);
      int nrR = random(100, 1000);

      Serial.print((String)nrAbs + " ");
      Serial.print((String)nrR + " ");
      Serial.print((String)nrC + " ");
      Serial.print((String)"9999 ");
   }
  }
   delay(2500);
}
