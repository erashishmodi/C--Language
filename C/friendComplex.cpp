#include <iostream>
using namespace std;

class complex{
   float x;
   float y;
   public :
      void setData(float real,float image);
      friend complex sum(complex, complex);
      void showData();
};

void complex::setData(float real,float image){
   x=real;
   y=image;
}
void complex::showData(){
   cout<<"\n"<<x<<"+";
   cout<<y<<"i";
}


complex sum(complex a,complex b){
   complex c;
   c.x=a.x+b.x;
   c.y=a.y+b.y;
   return (c);
}

int main(){
   complex a,b,c;
   a.setData(3.1,5.65);
   b.setData(2.75,1.2);
   cout<<"\n.................. FIRST VECTOR..........";
   a.showData();
   cout<<"\n.................. SECOND VECTOR..........";
   b.showData();
   c=sum(a,b);
   cout<<"\n.................. THIRD VECTOR..........";
   c.showData();   
   return (0);
}