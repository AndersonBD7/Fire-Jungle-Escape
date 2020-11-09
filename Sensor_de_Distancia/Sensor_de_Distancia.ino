
float Sensor_H = 0;
float Sensor_V = 0;
float valor = 0;
float SensorDistancia = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(2, INPUT);
  pinMode(3, OUTPUT);
  pinMode(5, INPUT);
  pinMode(6, OUTPUT);

  Serial.begin(9600);
}

void loop() {
   Sensor_H = leitura(2,3); 
   Serial.print("H");
   Serial.println(Sensor_H);
   delay(200);
  Serial.println();
   Sensor_V = leitura(5,6); 
   Serial.print("V");
   Serial.println(Sensor_V);
   delay(200);
  // put your main code here, to run repeatedly:
}
float leitura(float I, float O){
  digitalWrite(O, HIGH);
  delayMicroseconds(10);
  digitalWrite(O, LOW);
  
  valor = pulseIn(I, HIGH); 
  valor = valor/I; 
  valor = valor*0.035; 
 // valor = map(valor,0,4000,-16,3984);
  return valor;
}
