Imports System.Threading

Public Class CustomerClass
   Private _customerThread As Threading.Thread
   Private _customerMessage As BarberShopClass.PassMessage
   Private _mainForm As Form
   Private _customerEvent As New ManualResetEvent(False)

   ' Indicates whether a haircut is done for the customer
   Private _hairCutDone As Boolean

   ' Sets the delegate member that will be used to pass customer messages
   Public WriteOnly Property CustomerMessage As BarberShopClass.PassMessage
      Set(value As BarberShopClass.PassMessage)
         _customerMessage = value
      End Set
   End Property

   ' Sets the Form member that will be used to invoke the delegate
   Public WriteOnly Property MainForm As Form
      Set(value As Form)
         _mainForm = value
      End Set
   End Property

   ' Returns your initials followed by the hash code of the customer thread object
   ' Example: QY47
   Public ReadOnly Property ID As String
      Get
         Dim s As String
         s = "BM" & _customerThread.GetHashCode()
         Return s
      End Get
   End Property

   ' Starts the customer thread
   Public Sub SpinUp()
      _customerThread = New Thread(AddressOf run)
      _customerThread.Start()
   End Sub

   ' Wakes up the customer with one parameter as Boolean to indicate 
   ' if hair cut is done or not
   Friend Sub WakeUp(ByVal hadHaircut As Boolean)
      _customerEvent.Set()
      _hairCutDone = hadHaircut
   End Sub

   Private Sub run()

      'If the barber state is Closing
      '   Pass a message "New Customer ID: Coming Tomorrow."
      'Else
      '   Put the customer itself into the customer queue
      '   If the barber state is Sleeping
      '      Pass a message "New Customer ID: Waking up the Barber."
      '      Set the barber state to Working
      '      Wake up the barber
      '      Wait on customerEvent
      '   Else
      '      Pass a message "New Customer ID: Waiting for the Barber."
      '      Wait on customerEvent

      '   If hair cut is done (after being waked up)
      '      Pass a message "Customer ID: Going home after hair cut."
      '   Else
      '      Pass a message "Customer ID: Going home without hair cut." 

      'The ID in the messages should be the string from the ID property.

      Monitor.Enter(BarberShopClass.TheBarberStateObj)
      Monitor.Enter(BarberShopClass.TheCustomerQueue)

      If BarberShopClass.TheBarberState = BarberShopClass.BarberState.Closing Then
         _mainForm.Invoke(_customerMessage, ID & ": Coming Tomorrow")
         Monitor.Exit(BarberShopClass.TheBarberStateObj)
         Monitor.Exit(BarberShopClass.TheCustomerQueue)
      Else
         BarberShopClass.TheCustomerQueue.Enqueue(Me)
         Monitor.Exit(BarberShopClass.TheCustomerQueue)
         If BarberShopClass.TheBarberState = BarberShopClass.BarberState.Sleeping Then
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
            _mainForm.Invoke(_customerMessage, ID & ": Waking up the Barber")
            BarberShopClass.TheBarberState = BarberShopClass.BarberState.Working
            BarberShopClass.TheBarberEvent.Set()
            _customerEvent.WaitOne()
         Else
            Monitor.Exit(BarberShopClass.TheBarberStateObj)
            _mainForm.Invoke(_customerMessage, ID & ": Waiting for the Barber")
            _customerEvent.WaitOne()
         End If
         Monitor.Enter(BarberShopClass.TheCustomerQueue)
         If BarberShopClass.TheCustomerQueue.Count > 0 Then
            Dim _cust As CustomerClass = BarberShopClass.TheCustomerQueue.Dequeue
            _cust.WakeUp(False)
         End If
         Monitor.Exit(BarberShopClass.TheCustomerQueue)
         If _hairCutDone = True Then
            _mainForm.Invoke(_customerMessage, ID & ": Going home after hair cut")
         Else
            _mainForm.Invoke(_customerMessage, ID & ": Going home without hair cut")
         End If
      End If
   End Sub
End Class
