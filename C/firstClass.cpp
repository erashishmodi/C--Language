#include<iostream>

using namespace std;

class person{
   private : 
      int age;
      char name[24];
   public :
      void getData();
      void showData();
};
   void person:: getData(){
      cout<<"Enter Name : ";
      cin>>name;
      cout <<"Enter Age : ";
      cin>>age;
   }
   void person ::showData(){
      cout<<"\nName : "<<name;
      cout<<"\nAge : "<<age;
   }

int main(){
   person p ;
   p.getData();
   p.showData();
   return 0;
}