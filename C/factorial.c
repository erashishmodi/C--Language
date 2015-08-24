#include <stdio.h>
int findFactoirial(int);
int main(){
	int number;
	printf("Enter Number : ");
	scanf("%d",&number);
	printf("Factorial of %d : %d",number,findFactoirial(number));
	return 0;	
}
int findFactoirial(int arg){
	if(arg<1)
		return 1;
	int factorial=arg;
	factorial=factorial*findFactoirial(arg-1);
	return factorial;
}