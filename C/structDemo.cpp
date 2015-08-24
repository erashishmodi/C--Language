#include<iostream>
using namespace std;


struct student{
   int RollNo;
   int Age;
   int sum(int a,int b){
     return add(a,b);
   }
   private : int add(int a,int b){return a+b;}
};

int main(){
   student s;
   s.RollNo=10;
   cout<<s.sum(5,45);
   
   s.Age=23;
   return 0;
}