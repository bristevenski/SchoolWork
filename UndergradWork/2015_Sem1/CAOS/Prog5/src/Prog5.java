import java.util.Scanner;
import java.util.concurrent.Semaphore;

/**
 *
 * @author Brianna Muleski
 */
public class Prog5 
{

    /**
     * @param args the command line arguments
     */
    @SuppressWarnings("CallToThreadRun")
    public static void main(String[] args) 
    {
        Scanner in = new Scanner(System.in);
        System.out.println("Enter number of Philosophers:");
        int num = in.nextInt();
        Thread[] Philosophers = new Thread[num];
        Semaphore[] Forks = new Semaphore[num];
        
        for(int i = 0; i < num; i++)
        {
            Philosophers[i] = new Philosopher(i);
            Forks[i] = new Fork(1);
            //assign pair of forks to each philosopher
            Philosophers[i].run();
        }        
    }  
}
