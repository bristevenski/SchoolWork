Imports System.Threading

Public Class BarberClass
   Private _barberThread As Thread
   Private _barberMessage As BarberShopClass.PassMessage
   Private _mainForm As Form
   Private endProgram As New AutoResetEvent(False)

   ' Indicates if the barber should exit from the while loop or not 
   Private _done As Boolean

   ' Generates the amount of time needed for each haircut
   Private _barberRand As Random = New Random(Now.Second)

   Public WriteOnly Property BarberMessage As BarberShopClass.PassMessage
      Set(value As BarberShopClass.PassMessage)
         _barberMessage = value
      End Set
   End Property

   Public WriteOnly Property MainForm As Form
      Set(value As Form)
         _mainForm = value
      End Set
   End Property

   ' Creates a new barber thread, sets the barber state to Open,
   ' and starts the barber thread
   Public Sub OpenBarberShop()
      _barberThread = New Thread(AddressOf run)
      Monitor.Enter(BarberShopClass.TheBarberStateObj)
      BarberShopClass.TheBarberState = BarberShopClass.BarberState.Open
      Monitor.Exit(BarberShopClass.TheBarberStateObj)
      _barberThread.Start()
   End Sub

   ' Sets the barber state to Closing, wakes up the barber thread, and waits until the barber 
   ' thread is terminated
   Public Sub CloseBarberShop()
      Monitor.Enter(BarberShopClass.TheBarberStateObj)
      BarberShopClass.TheBarberState = BarberShopClass.BarberState.Closing
      Monitor.Exit(BarberShopClass.TheBarberStateObj)
      BarberShopClass.TheBarberEvent.Set()
      BarberShopClass.TheBarberEvent.WaitOne()
   End Sub

   ' It will be called by the user from the main form when the user wants to exit but 
   ' the barber shop is closed (some customers might be waiting). 
   ' It removes the customers from the queue, one by one, and wakes up the customer 
   ' with a parameter telling the customer that hair cut is not done. 
   ' So the customer thread will terminate before the program is terminated.
   Public Sub ClearCustomerQueue()
      Monitor.Enter(BarberShopClass.TheCustomerQueue)
      If BarberShopClass.TheCustomerQueue.Count > 0 Then
         Dim _cust As CustomerClass = BarberShopClass.TheCustomerQueue.Dequeue
         _cust.WakeUp(False)
      End If
         Monitor.Exit(BarberShopClass.TheCustomerQueue)
   End Sub

   Private Sub run()
      'While Not done
      '   If the State is Open
      '      Pass a message "The Barber Shop Is Now Open."
      '      Set the state to Working
      '   Else If the State is Sleeping
      '      Pass a message "The Barber Goes to Sleep."
      '      Wait on barberEvent
      '   Else If the State is Closing
      '      Pass a message "The Barber Shop Is Now Closing."
      '      Call FinishingAll() to cut hair for all waiting customers
      '      Set state to Closed
      '   Else If the State is Closed
      '      Pass a message "The Barber Shop Is Now Closed."
      '      Set done to true
      '   Else (Working)
      '      If no customer
      '         Set state to Sleeping
      '      Else
      '         Remove the first customer from CustomerQueue
      '         Call CutHairForOneCustomer to cut hair for the customer

      While _done = False
         Monitor.Enter(BarberShopClass.TheBarberStateObj)
         If BarberShopClass.TheBarberState = BarberShopClass.BarberState.Open Then
            _mainForm.Invoke(_barberMessage, "The Barber Shop Is Now Open")
            BarberShopClass.TheBarberState = BarberShopClass.BarberState.Working
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
         ElseIf BarberShopClass.TheBarberState = BarberShopClass.BarberState.Sleeping Then
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
            _mainForm.Invoke(_barberMessage, "The Barber Goes To Sleep")
            BarberShopClass.TheBarberEvent.WaitOne()
         ElseIf BarberShopClass.TheBarberState = BarberShopClass.BarberState.Closing Then
            _mainForm.Invoke(_barberMessage, "The Barber Shop Is Now Closing")
            FinishingAll()
            BarberShopClass.TheBarberState = BarberShopClass.BarberState.Closed
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
         ElseIf BarberShopClass.TheBarberState = BarberShopClass.BarberState.Closed Then
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
            _mainForm.Invoke(_barberMessage, "The Barber Shop Is Now Closed")
            _done = True
         Else
            Monitor.Enter(BarberShopClass.TheCustomerQueue)
            If BarberShopClass.TheCustomerQueue.Count = 0 Then
               BarberShopClass.TheBarberState = BarberShopClass.BarberState.Sleeping
            Else
               Dim _cust As CustomerClass = BarberShopClass.TheCustomerQueue.Dequeue()
               CutHairForOneCustomer(_cust)
            End If
            Monitor.Exit(BarberShopClass.TheCustomerQueue)
         End If
      End While
   End Sub

   ' Does haircut for one customer, including passing messages before and after the haircut
   ' and waking up the customer
   Private Sub CutHairForOneCustomer(ByVal c As CustomerClass)
      ' Pass a message "Cut Hair for Customer " followed by the customer’s ID
      ' The barber needs 2 – 5 seconds for a customer 
      ' (A Random object should be used to generate the amount of time)
      ' Pass a message "Finished Hair Cut for Customer " followed by ID
      ' Wake up the customer with parameter that hair cut is done
      _mainForm.Invoke(_barberMessage, "Cut Hair for Customer " & c.ID)
      Dim _cutTime As Integer = _barberRand.Next(2, 5)
      Thread.Sleep(_cutTime)
      _mainForm.Invoke(_barberMessage, "Finished Hair Cut for Customer " & c.ID)
      c.WakeUp(True)
   End Sub

   ' Should be called after the barber shop is closing to do hair cut for all waiting customers.
   Private Sub FinishingAll()
      If BarberShopClass.TheCustomerQueue.Count = 0 Then

      Else
         endProgram.Reset()

         endProgram.WaitOne()
      End If
   End Sub

End Class
