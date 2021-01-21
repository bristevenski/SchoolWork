/**
Stores the information of a device. The name is stored as a string, the
readings as an array of floats, and the current index as an integer.
@author Brianna Muleski
*/
public class Device
{
   private String name;           // name of the device
   private float readings[];      // array of readings
   private int curIndex;          // index where next reading goes

   /**
   Constructor of a device.
   @param deviceName is the name of the device being constructed
   @param numReadings is the number of readings for the device
   @param initValue is the initial value for the number of readings 
   */
   public Device ( String deviceName, int numReadings, float initValue  )
   {
      name = deviceName;
      curIndex = 0;
      readings = new float[numReadings];
       
      for ( int i = 0; i < numReadings; i++ )
         readings[i] = initValue;
   }
   
   /**
   A getter method to obtain the name of the device.
   @return the name of the device in a String
   */
   public String getName()
   { 
      return name;
   }
   
   /**
   Converts the device's information to a String.
   @return the device's information formatted in a String.
   */
   @Override
   public String toString()
   {
      String temp1 = name + ": " + curIndex;
      String temp2 = "";
      for ( int i = 0; i < readings.length; i++ )
         temp2 += "," + readings[i];
      return temp1 + temp2;
   }
   
   /**
   Stores the reading at the current index in the readings array.
   @param reading is the reading that is being stored
   */
   public void storeReading( float reading )
   {
      readings[curIndex] = reading;
      if ( curIndex == readings.length - 1)
         curIndex = 0;
      else
         curIndex++;
   }
   
   /**
   Computes the average of all the readings, including the readings that
   have been initialized, but not stored with a new reading.
   @return the average reading as a float
   */
   public float aveReading()
   {
      float sum = 0;
      for ( int i = 0; i < readings.length; i++ )
         sum += readings[i];
      return sum/readings.length;
   }
}