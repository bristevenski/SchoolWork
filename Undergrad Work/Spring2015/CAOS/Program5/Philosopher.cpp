

	bool going_home;
	int think_time;
	int eat_time;

 // each Philosopher is assigned an integer ID and two forks
void Philosopher::run()
{
	while (!going_home)
	{
		cout << this_thread::get_id() << " " << "THINKING";
		think_time = rand() % 1000;
		 // TODO: obtain the fork on the left
		// TODO: obtain the fork on the right

		cout << this_thread::get_id() << " " << "EATING";
		eat_time = rand() % 1000;
		 // TODO: release the fork on the left
		 // TODO: release the fork on the right
	}
}


