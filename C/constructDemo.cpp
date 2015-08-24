#include <iostream>
using namespace std;
int count= 0;

class A{
   public :
      A(){
      count++;
      cout<<"\nObject created : "<<count;
      }
    ~A(){
      cout<<"\nObject Disposed : "<<count;
      count--; 
      }
};
int main(){
   A a,b,c;
   {
      cout<<"\n.......... IN THE INNER BLOCK .........";
      A d,e,f;
   }
   cout<<"\n......... OUT THE BLOCK ......";
   return 0;
}