Imports System.Threading

Public Class BarberShopClass

   Public Enum BarberState
      Open
      Working
      Sleeping
      Closing
      Closed
   End Enum

   Public Delegate Sub PassMessage(ByVal msg As String)

   ' All customers must be waiting in the queue to get hair cut, 
   ' except those who come when the barber shop is closing. 
   ' The queue is shared by the barber and all customers, and
   ' mutual exclusion must be enforced by Monitor.
   Friend Shared TheCustomerQueue As New Queue

   ' The barber state is shared by all customers and the barber.
   ' The barber state object must be used for mutual exclusion on TheBarberState.
   Friend Shared TheBarberState As BarberState = BarberState.Closed
   Friend Shared TheBarberStateObj As New Object

   ' To wake up the barber.
   Friend Shared TheBarberEvent As New ManualResetEvent(False)
End Class
