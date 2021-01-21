import java.util.Random;
/**
 *
 * @author Brianna Muleski
 */
public class Philosopher extends Thread
{
    
     // each Philosopher is assigned an integer ID and two forks
    private int ID, think_time, eat_time;
    private boolean going_home = false;
    private Random rand_gen = new Random();
    private Fork left, right;
    
    public enum State
    {
        THINKING,
        WAIT_LEFT_FORK,
        WAIT_RIGHT_FORK,
        EATING
    }
    
    public Philosopher(int in_id)
    {
        ID = in_id;
    }
    
    public void setForks(Fork in_left, Fork in_right)
    {
        left = in_left;
        right = in_right;
    }
    @Override
    public void run()
    {
        while (!going_home)
        {
            System.out.println(ID + " Thinking");
            think_time = rand_gen.nextInt(1000);
            // TODO: obtain the fork on the left
            // TODO: obtain the fork on the right
            System.out.println(ID + " Eating");
            eat_time = rand_gen.nextInt(1000);
            // TODO: release the fork on the left
            // TODO: release the fork on the right
        }
    } 
}
