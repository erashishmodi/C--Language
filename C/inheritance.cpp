#include <iostream>

using namespace std;

class B{
   public :
   void display(){
      cout<<"\nA DISPLAY()";
   }
};
class D : protected B{
   public :
      void show(){
         cout<<"\nB SHOW()";
      }   
};
class E : public D{
   public : 
      void put(){
        show();
        display();
       cout<<"\nPUT()";
      }
};

int main(){
   E e;
     e.put();
  // d.show();
 //  d.display();
   return 0;
}