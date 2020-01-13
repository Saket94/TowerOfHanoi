# Project Name: Tower of Hanoi

The Project tower of Hanoi is a mathematical game or puzzle. It consists of three rods and a number of disks 
of different sizes, which can slide onto any rod. The puzzle starts with the disks in a neat stack in ascending
order of size on one rod, the smallest at the top, thus making a conical shape.

This project is build using Microsoft .Net Console Application. I consist of following Objects -

	1. TowerOfHanoi :- This object consist of methods that implements the algorithm of Tower of hanoi game play 
	                  and records the statistics of gameplay movements of disks.   
			 
	2. Problem :-      This object consists of methods that invokes gameplay and  method to get last 9 digits number 
	                  of n between 1 to 100000  E(n,10n,3n,6n,9n) 
			  
	3. Logger :-       This object generates log into log file whenever there exception arises.

## Unit Test Case :
    The unit tests are created using MS Test and uses data driven approach for testing. The test data comes comes from test files which is in 
	"TestDataFiles"  directory.These folder consist of three files namely 
	
	1. LogtestData.xml
	2. ProblemTestData.xml
	3. TowerOfHanoiTestData.xml
	
	If the test case project doesn't work then please open "TestDataFiles" directory & then open each file properties & set them to "Copy if newer".



## How To :

 This Project output can be easily run by following two ways - 
 1. Run the project in Visual studio Debugging.
 2. Run the Executables present in bin folder of the Project Solution


