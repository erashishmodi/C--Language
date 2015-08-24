#include <iostream>
using namespace std;
class A{
   int a;   
   public :
      void setval(){a=24}
      friend void max(A,B);
};
class B{
   int b;
   public : 
      void setval(){b=45;}
      friend void max(A,B);  
};
void max(A o,B r){
   int avar=o.a;
   int bvar=r.b;
     if(avar>=bvar)
      cout<<avar;
     else
     cout<<bvar;
}

int main(){
   A c;
   B f;
   f.setval();
   c.setval();
   max(c,f);
   return 0;
}