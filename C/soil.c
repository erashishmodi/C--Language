#include <stdio.h>
int main(){
	float depth,existing_water_content,water_applied_to_soil,water_loss,area_of_plot,water_used_in_soil,total_dry_weight,need_water,new_water;
	printf("Enter the Root zone depth(in meter) : ");
	scanf("%f",&depth);
	printf("Enter the value of existing water content(in g/(cm*cm*cm) : ");
	scanf("%f",existing_water_content);
	printf("Enter the value water applied to soil : ");
	scanf("%f",water_applied_to_soil);
	printf("Enter the value of water loss due to evaporation (in %) : ");
	scanf("%f",water_loss);
	printf("Enter the value of area of plot (in sq.m) : ");
	scanf("%f",area_of_plot);
	water_used_in_soil=(water_applied_to_soil*(90/100));
	printf("\nwater used in the soil : %f",water_used_in_soil);
	total_dry_weight=area_of_plot*depth*existing_water_content;
	need_water=(450/total_dry_weight)*100;
	new_water=5+need_water;
	printf("needed water : %f /%",new_water);
	return 0;
}
