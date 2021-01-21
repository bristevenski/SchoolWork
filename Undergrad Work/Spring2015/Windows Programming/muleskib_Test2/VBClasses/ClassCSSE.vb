Public MustInherit Class CSSE
   Implements IDisposable


   ' The class does not store all created objects,
   ' but keeps such a count and updates it whenever an object is created or disposed of.
   Private Shared TotalCount As Integer = 0

   Protected _score As Integer
   Protected SCORE_LOW_LIMIT As Integer
   Protected SCORE_HIGH_LIMIT As Integer

   Protected _delta As Integer
   Protected DELTA_LOW_LIMIT As Integer
   Protected DELTA_HIGH_LIMIT As Integer

   Public Shared Event TotalCountUpdated(ByVal num As Integer)
   Public Event PerfectScore()

   ' Reads and writes _score.
   ' Throws an exception when the new score would be out of the range.
   Public Property Score As Integer
      Get
         Return _score
      End Get
      Set(ByVal value As Integer)
         If value < SCORE_LOW_LIMIT Or value > SCORE_HIGH_LIMIT Then
            Throw New Exception("muleskib: Invalid score!")
         Else
            _score = value
            If _score = SCORE_HIGH_LIMIT Then
               RaiseEvent PerfectScore()
            End If
         End If
      End Set
   End Property

   ' Reads and writes _delta.
   ' Throws an exception when the new delta would be out of the range.
   Public Property Delta As Integer
      Get
         Return _delta
      End Get
      Set(ByVal value As Integer)
         If value < DELTA_LOW_LIMIT Or value > DELTA_HIGH_LIMIT Then
            Throw New Exception("muleskib: Invalid delta!")
         Else
            _delta = value
         End If
      End Set
   End Property

   ' Sets _score and _delta to their low limits.
   Public Sub Reset()
      _score = SCORE_LOW_LIMIT
      _delta = DELTA_LOW_LIMIT
   End Sub

   ' Modifies _score using _delta. The sub-classes decide how to modify it.
   ' Throws an exception when the new score would be out of range. 
   Public MustOverride Sub Modify()

   Protected Sub RaiseTotalCountEvent()
      RaiseEvent TotalCountUpdated(TotalCount)
   End Sub

#Region "IDisposable Support"
   Private disposedValue As Boolean ' To detect redundant calls

   ' IDisposable
   Private Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
         If disposing Then
            TotalCount -= 1
            RaiseEvent TotalCountUpdated(TotalCount)

         End If

         ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
         ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
   End Sub

   ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
   'Protected Overrides Sub Finalize()
   '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
   '    Dispose(False)
   '    MyBase.Finalize()
   'End Sub

   ' This code added by Visual Basic to correctly implement the disposable pattern.
   Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
   End Sub
#End Region

End Class
