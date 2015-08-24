#include<iostream>

using namespace std;
void swap(int & x,int & y){
   int t=x;
   x=y;
   y=t;
}
int main(){
   int a=10,b=20;
   cout<<"Before SWAP";
   cout<<"\na : "<<a;
   cout<<"\nb : "<<b;   
   swap(a,b);
   cout<<"\nAFTER SWAP";
   cout<<"\na : "<<a;
   cout<<"\nb : "<<b;   
   return (0);
}