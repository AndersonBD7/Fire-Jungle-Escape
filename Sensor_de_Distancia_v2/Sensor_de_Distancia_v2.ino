#include <Ultrasonic.h>
 
const int H_imp_Pin = 2; 
const int H_out_Pin = 3; 
const int V_imp_Pin = 5; 
const int V_out_Pin = 6;

Ultrasonic ultrasonic_H(H_out_Pin,H_imp_Pin); 
Ultrasonic ultrasonic_V(V_out_Pin,V_imp_Pin); 

int distancia; 
String result; 
 
void setup(){
  pinMode(H_imp_Pin, INPUT);
  pinMode(H_out_Pin, OUTPUT); 
  pinMode(V_imp_Pin, INPUT);
  pinMode(V_out_Pin, OUTPUT);
  Serial.begin(9600);
  }
void loop(){
  
  H_hcsr04();
  V_hcsr04();
  
}
void H_hcsr04(){
    digitalWrite(H_out_Pin, LOW); 
    delayMicroseconds(2); 
    digitalWrite(H_out_Pin, HIGH); 
    delayMicroseconds(10); 
    digitalWrite(H_out_Pin, LOW); 
    distancia = (ultrasonic_H.Ranging(CM)); 
    result = String(distancia-11); 
    delay(100); 
    Serial.print("H");
    Serial.println(result); 
 }void V_hcsr04(){
    digitalWrite(V_out_Pin, LOW); 
    delayMicroseconds(2); 
    digitalWrite(V_out_Pin, HIGH); 
    delayMicroseconds(10); 
    digitalWrite(V_out_Pin, LOW); 
    distancia = (ultrasonic_V.Ranging(CM)); 
    result = String(distancia-11); 
    delay(100); 
    Serial.print("V");
    Serial.println(result); 
 }
