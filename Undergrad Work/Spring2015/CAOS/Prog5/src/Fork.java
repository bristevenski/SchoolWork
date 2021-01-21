import java.util.concurrent.Semaphore;

/**
 *
 * @author Brianna
 */
public class Fork extends Semaphore
{

    public Fork(int permits) 
    {
        super(permits);
    }
    
}
