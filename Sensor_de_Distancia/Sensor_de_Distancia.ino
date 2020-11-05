float SensorDistancia =0;

void setup() {
  // put your setup code here, to run once:
  pinMode(2, INPUT);
  pinMode(3, OUTPUT);
  Serial.begin(9600);
}

void loop() {
   leitura(); 
  // put your main code here, to run repeatedly:
}
void leitura(){
  digitalWrite(3, HIGH);
  delayMicroseconds(10);
  digitalWrite(3, LOW);
  
  SensorDistancia = pulseIn(2, HIGH); 
  SensorDistancia = SensorDistancia/2; 
  SensorDistancia = SensorDistancia*0.035; 
  SensorDistancia = map(SensorDistancia,0,4000,-16,3984);
  Serial.print("D");
  Serial.println(SensorDistancia);
  delay(200);
}
