#include <iostream>
using namespace std;

class A{
   int x;
   int y;
   public :
   void setXY(int a,int b);
   void showXY();
};

void A::setXY(int a,int b){
   x=a;
   y=b;
}

void A:: showXY(){
   cout<<"\nx="<<x;
   cout<<" y="<<y;
}
int main(){
   A a;
   a.setXY(10,20);
   a.showXY();
   cout<<"\n By pointer variable";
   A *ptr=&a;
   ptr->setXY(100,522);
   ptr->showXY();
   a.showXY();
   cout<<"\n Accessing using alias variables ";
   (*ptr).setXY(400,500);
   (*ptr).showXY();
   a.showXY();
   return 0;
}