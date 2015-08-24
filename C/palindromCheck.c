#include <stdio.h>
int IsPalindrom(int);
int main(){
	printf("Enter the number : ");
	int number;
	scanf("%d",&number);
	if(IsPalindrom(number))
		printf("%d is a Palindrom number.",number);
	else
		printf("%d is not a palindrom number.",number);
	return 0;
}
int IsPalindrom(int argNumber){
	int reverseNumber=0;
	int bufferNumber=argNumber;
	while(bufferNumber)
	{
		reverseNumber*=10;
		reverseNumber=reverseNumber+(bufferNumber%10);
		bufferNumber=bufferNumber/10;		
	}
	return (argNumber==reverseNumber);
}