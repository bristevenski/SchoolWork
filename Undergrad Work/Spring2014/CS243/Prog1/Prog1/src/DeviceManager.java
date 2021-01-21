import java.util.Scanner;

/**
DeviceManager class manipulates an array of Devices. The user can use six
different commands to manipulate the array: Add, Delete, Output, Update, 
Print, and Quit.
@author Brianna Muleski
*/
public class DeviceManager
{
   final int MAX_DEVICES = 5;
   final int NOT_FOUND = -1;
   
   private Device list[] = new Device[MAX_DEVICES];
   private int numDevices = 0;
   
   Scanner stdin;
   
   /**
   Uses input of different commands to run the command methods. Runs through
   the while loop until the "Quit" command is inputted. A termination message
   is then outputted.
   @throws java.io.IOException 
   */
   public void run() throws java.io.IOException
   {
      stdin = new Scanner(System.in);
     
      String command = stdin.next();
       
      while ( !command.equals("Q"))
      {
         if ( command.equalsIgnoreCase("A") )
            addCommand();
         else if ( command.equalsIgnoreCase("D") )
            deleteCommand();
         else if ( command.equalsIgnoreCase("O") )
            outputCommand();
         else if ( command.equalsIgnoreCase("P") )
            printCommand();
         else if ( command.equalsIgnoreCase("U") )
            updateCommand();
         command = stdin.next();
      }
      System.out.println( "Normal Termination of Program 1" );
   }
   
   /**
   Adds the Device name, the number of readings for that device, and the
   initial settings for those readings. A success message is outputted. If
   the list is full, the information on the device is still accepted, but
   not added to the list. A failure message is outputted.
   */
   private void addCommand()
   {
      if (numDevices < MAX_DEVICES)
      {
         String name = stdin.next();
         int numReadings = stdin.nextInt();
         float reading = stdin.nextFloat();
           
         list[numDevices++] = new Device (name, numReadings, reading);
         System.out.println( name + " device has been added to the list." );
      }
      else 
      {
         String name = stdin.next();
         int numReadings = stdin.nextInt();
         float reading = stdin.nextFloat();
         System.out.println("The list was full. " + name + 
                            " not added to the list.");
      }
   }
   
   /**
   Deletes the device and shift the remaining devices upward. A success
   message is outputted. If the device is not in the list then a failure
   message is outputted.
   */
   private void deleteCommand()
   {
      String name = stdin.next();
      int index = find( name );
      if( index == NOT_FOUND )
         System.out.println( name + " not deleted.  It is not in the list.");
      else
      {
         --numDevices;
         for( int i = index; i < numDevices; i++ )
            list[i] = list[i + 1];
         System.out.println( name + " was deleted from the list.");
      }
   }
   
   /**
   Outputs the average reading of the device. If the device is not in the
   list then a failure message is outputted.
   */
   private void outputCommand()
   {
      String name = stdin.next();
      int index = find( name );
      if ( index == NOT_FOUND )
         System.out.println( name + " not outputted.  "
                             + "It is not in the list." );
      else
         System.out.println( "Device " + name + " reads " 
                             + list[index].aveReading() );
   }
   
   /**
   Prints the list of devices and their current indexes and readings. If the
   list is empty, the heading is still printed.
   */
   private void printCommand()
   {
      System.out.println( "The list of Devices is:" );
      for( int i = 0; i < numDevices; i++ )
         System.out.println( list[i].toString() );
   }
   
   /**
   Updates the device the the reading given. A success reading is outputted.
   If the device is not in the list, then a failure message is outputted.
   */
   private void updateCommand()
   {
      String name = stdin.next();
      int index = find( name );
      if ( index == NOT_FOUND )
         System.out.println( name + " not updated.  "
                             + "It is not in the list." );
      else
      {
         float reading = stdin.nextFloat();
         list[index].storeReading(reading);
         System.out.println( "Device " + name + " updated with " + reading );
      }
   }
   
   /**
   Find the Device in the list of devices.
   @param deviceName is the name of the device being searched for
   @return index of the device, NOT_FOUND if not found
   */
   private int find( String deviceName )
   {
      for ( int i = 0; i < numDevices; i++ )
         if ( deviceName.equals(list[i].getName()) )
            return i;
      return NOT_FOUND;
   }

}
