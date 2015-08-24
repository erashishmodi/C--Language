#include <iostream>
using namespace std;
class A{
   int a;
   int b;
   public :
      void setval(){a=24;b=24;}
      friend float mean(A o);
};
float mean(A o){
   return float(o.a+o.b)/2.0;
}

int main(){
   A c;
   c.setval();
   cout<<"Mean : "<<mean(c);
   return 0;
}