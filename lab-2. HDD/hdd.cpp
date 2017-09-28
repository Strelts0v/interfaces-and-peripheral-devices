#include <cstdlib>
#include <iostream>

int main() {

	system("sudo hdparm -I /dev/sda | grep Number");
	system("sudo hdparm -I /dev/sda | grep Firmware");

	// info about HDD memory
	system( "df | awk '{hddVolume += $2; hddUsedVolume += $3; hddAvailableVolume+=$4} "
		"END {print \"\\tHDD volume: \" hddVolume \" bytes\\n\" "
		"\"\\tHDD used volume: \" hddUsedVolume \" bytes\\n\" "
		"\"\\tHDD available volume: \" hddAvailableVolume \" bytes\"}'");

	system("sudo hdparm -I /dev/sda | grep PIO");
	system("sudo hdparm -I /dev/sda | grep DMA");
	system("sudo hdparm -I /dev/sda | grep Supported");
	
	return 0;
}
