#include <stdio.h>
int isVovel(char);
int main(){
	printf("%d\n",isVovel('b'));
	return 0;
}
int isVovel(char ch){
	switch(ch){
		case 'a':return 1;
		case 'A':return 1;
		case 'e':return 1;
		case 'E':return 1;
		case 'i':return 1;
		case 'I':return 1;
		case 'o':return 1;
		case 'O':return 1;
		case 'u':return 1;
		case 'U':return 1;
		default:return 0;
	}
}