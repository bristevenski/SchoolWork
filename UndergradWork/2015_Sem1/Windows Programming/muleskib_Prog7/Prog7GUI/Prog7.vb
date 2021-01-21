'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/17/2015
' Description: Program 7
'              Class Prog7
'----------------------------------------------
Public Class Prog7

    ' Sets the table and runs FormClassProg7GUI
    Public Shared Sub Main()
        DataClass.setUpTable()
        Application.Run(New FormClassProg7GUI)
    End Sub
End Class
