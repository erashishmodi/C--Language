#include <stdio.h>
int isArmstrong(int arg){
	int tempNumber=arg;
	int bufferNumber=0;
	int sum=0;
	while(arg){
		bufferNumber=arg%10;
		sum+=(bufferNumber*bufferNumber*bufferNumber);
		arg=arg/10;
	}
	return(tempNumber==sum);
}
int main(){
	for(int i=0;i<100000;i++)
		if(isArmstrong(i))
			printf("%d is armstrong.\n",i);
	return 0;
}