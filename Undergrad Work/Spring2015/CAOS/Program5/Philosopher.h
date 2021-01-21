#include <thread>
#include <sys/types.h>
#include <stdio.h>

// don't think we need this at the end becuase I think he is running it from the command line
// but we can use it to test the code.
#include <iostream>
using namespace std;

enum PhilState
{
	THINKING,
	WAIT_LEFT_FORK,
	WAIT_RIGHT_FORK,
	EATING
};

class Philosopher
{

};