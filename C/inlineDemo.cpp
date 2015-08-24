#include<iostream>
using namespace std;

inline float multiply(float a,float b){
   return (a*b);
}
inline double div(double a ,double b){
   return (a/b);
}

int main(){
   float a= 12.2412;
   float b=45.45;
   cout<<"Multiplication : "<<multiply(a,b);
   cout<<"\nDivision : "<<div(a,b);
   return 0;
}