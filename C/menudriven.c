#include <stdio.h>
int main(){
	int choice;
	int escape=1;
	while(escape){
		printf("Enter choice : ");
		scanf("%d",&choice);
		switch(choice){
			case 1 : printf("first\n");
					break;
			case 2 : printf("Second\n");
					break;
			default:printf("No Proper Choice.\n");
					break;		
		}
		printf("Press 0 to exit. : ");
		scanf("%d",&escape);
	}
	return 0;
}