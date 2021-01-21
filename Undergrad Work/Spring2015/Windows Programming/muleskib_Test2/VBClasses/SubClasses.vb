Public Class CS234
   Inherits CSSE

   Public Sub New()
      SCORE_HIGH_LIMIT = 100
      SCORE_LOW_LIMIT = 50
      DELTA_HIGH_LIMIT = 5
      DELTA_LOW_LIMIT = -5
      RaiseTotalCountEvent()
   End Sub

   Public Overrides Sub Modify()
      Dim temp = _score + _delta
      If temp < SCORE_LOW_LIMIT Or temp > SCORE_HIGH_LIMIT Then
         Throw New Exception("muleskib: Score would be out of range!")
      End If
      _score += _delta
   End Sub
End Class

Public Class CS334
   Inherits CSSE

   Public Sub New()
      SCORE_HIGH_LIMIT = 120
      SCORE_LOW_LIMIT = 60
      DELTA_HIGH_LIMIT = 10
      DELTA_LOW_LIMIT = 1
      RaiseTotalCountEvent()
   End Sub

   Public Overrides Sub Modify()
      Dim temp = _score + 2 * _delta
      If temp < SCORE_LOW_LIMIT Or temp > SCORE_HIGH_LIMIT Then
         Throw New Exception("muleskib: Score would be out of range!")
      End If
      _score += 2 * _delta
   End Sub
End Class
