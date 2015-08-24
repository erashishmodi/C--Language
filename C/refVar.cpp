#include<iostream>

using namespace std;
int main(){
   int sum=10;
   int & total=sum;
   cout<<"SUM : "<<sum;
   cout<<"\nTOTAL : "<<total;
   sum=1+45;
   cout<<"\nSUM : "<<sum;
   cout<<"\nTOTAL : "<<total;
   total=45+57;
   cout<<"\nSUM : "<<sum;
   cout<<"\nTOTAL : "<<total;
  return (0);
}