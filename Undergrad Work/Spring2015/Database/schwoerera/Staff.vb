Public Class Staff
    Private staffBindingSource As New BindingSource
    Private qualBindingSource As New BindingSource
    Private expBindingSource As New BindingSource

    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        Application.Exit()
    End Sub

    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set up staff data bindings
        staffBindingSource.DataSource = Oracle.staffTable

        staffNotxt.DataBindings.Add("Text", staffBindingSource, "staffNo")
        fNametxt.DataBindings.Add("Text", staffBindingSource, "fName")
        lNametxt.DataBindings.Add("Text", staffBindingSource, "lName")
        streettxt.DataBindings.Add("Text", staffBindingSource, "street")
        citytxt.DataBindings.Add("Text", staffBindingSource, "city")
        statetxt.DataBindings.Add("Text", staffBindingSource, "state")
        ziptxt.DataBindings.Add("Text", staffBindingSource, "ZIP")
        phonetxt.DataBindings.Add("Text", staffBindingSource, "phone")
        DOBdtp.DataBindings.Add("Text", staffBindingSource, "DOB")
        gendertxt.DataBindings.Add("Text", staffBindingSource, "gender")
        nintxt.DataBindings.Add("Text", staffBindingSource, "NIN")
        positiontxt.DataBindings.Add("Text", staffBindingSource, "position")
        cursalarytxt.DataBindings.Add("Text", staffBindingSource, "curSalary")
        salaryscaletxt.DataBindings.Add("Text", staffBindingSource, "salaryScale")
        hrsperwektxt.DataBindings.Add("Text", staffBindingSource, "hrsPerWk")
        pospertxt.DataBindings.Add("Text", staffBindingSource, "posPermTemp")
        typeofpaytxt.DataBindings.Add("Text", staffBindingSource, "typeOfPay")

        'set up qualifications data bindings
        qualBindingSource.DataSource = Oracle.qualTable

        qualDatedtp.DataBindings.Add("Text", qualBindingSource, "qualDate")
        typetxt.DataBindings.Add("Text", qualBindingSource, "type")
        instnametxt.DataBindings.Add("Text", qualBindingSource, "instName")

        ' set up work experience data bindings
        expBindingSource.DataSource = Oracle.expTable

        orgnametxt.DataBindings.Add("Text", expBindingSource, "orgName")
        positionWortxt.DataBindings.Add("Text", expBindingSource, "position")
        startdtp.DataBindings.Add("Text", expBindingSource, "startDate")
        fininshdtp.DataBindings.Add("Text", expBindingSource, "finishDate")

        SetQualExpTables()
        empTxt.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetStaffPositionButtons()
        SetQualPositionButtons()
        SetExpPositionButtons()
    End Sub

    Private Sub empNextbtn_Click(sender As Object, e As EventArgs) Handles empNextbtn.Click
        staffBindingSource.MoveNext()
        UpdateInformation()
    End Sub

    Private Sub empPrevbtn_Click(sender As Object, e As EventArgs) Handles empPrevbtn.Click
        staffBindingSource.MovePrevious()
        UpdateInformation()
    End Sub

    Private Sub empFirstbtn_Click(sender As Object, e As EventArgs) Handles empFirstbtn.Click
        staffBindingSource.MoveFirst()
        UpdateInformation()
    End Sub

    Private Sub empLastbtn_Click(sender As Object, e As EventArgs) Handles empLastbtn.Click
        staffBindingSource.MoveLast()
        UpdateInformation()
    End Sub

    Private Sub empSavebtn_Click(sender As Object, e As EventArgs) Handles empSavebtn.Click
        Try
            staffBindingSource.EndEdit()
            Oracle.staffAdapter.Update(Oracle.staffTable)
            EnableStaffButtons()
            SetQualExpTables()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub empNewbtn_Click(sender As Object, e As EventArgs) Handles empNewbtn.Click
        Dim r As DataRowView

        r = staffBindingSource.AddNew
        staffBindingSource.MoveLast()

        empTxt.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count

        empLastbtn.Enabled = False
        empFirstbtn.Enabled = False
        empNextbtn.Enabled = False
        empPrevbtn.Enabled = False
        empNewbtn.Enabled = False
    End Sub

    Private Sub empDeletebtn_Click(sender As Object, e As EventArgs) Handles empDeletebtn.Click
        Try
            staffBindingSource.RemoveCurrent()
            Oracle.staffAdapter.Update(Oracle.staffTable)
            empTxt.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
            EnableStaffButtons()
            SetQualExpTables()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EnableStaffButtons()
        empLastbtn.Enabled = True
        empFirstbtn.Enabled = True
        empNextbtn.Enabled = True
        empPrevbtn.Enabled = True
        empNewbtn.Enabled = True
    End Sub

    Private Sub SetStaffPositionButtons()
      If staffBindingSource.Count = 0 Or staffBindingSource.Count = 1 Then
         empLastbtn.Enabled = False
         empFirstbtn.Enabled = False
         empNextbtn.Enabled = False
         empPrevbtn.Enabled = False
      Else
         If staffBindingSource.Position + 1 = staffBindingSource.Count Then
            empNextbtn.Enabled = False
            empLastbtn.Enabled = False
            empFirstbtn.Enabled = True
            empPrevbtn.Enabled = True
         ElseIf staffBindingSource.Position = 0 Then
            empPrevbtn.Enabled = False
            empFirstbtn.Enabled = False
            empLastbtn.Enabled = True
            empNextbtn.Enabled = True
         Else
            EnableStaffButtons()
         End If
      End If
    End Sub

    Private Sub SetQualExpTables()
        Oracle.qualCommand.CommandText = "Select * from UWP_Qualifications " & _
                                   "Where staffNo = '" & staffNotxt.Text & "'"
        Oracle.qualTable.Clear()
        Oracle.qualAdapter.Fill(Oracle.qualTable)

        Oracle.expCommand.CommandText = "Select * from UWP_WorkExperience " & _
                                   "Where staffNo = '" & staffNotxt.Text & "'"
        Oracle.expTable.Clear()
      Oracle.expAdapter.Fill(Oracle.expTable)
    End Sub

    Private Sub qualFirstbtn_Click(sender As Object, e As EventArgs) Handles qualFirstbtn.Click
        qualBindingSource.MoveFirst()
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        SetQualPositionButtons()
    End Sub

    Private Sub qualPrevbtn_Click(sender As Object, e As EventArgs) Handles qualPrevbtn.Click
        qualBindingSource.MovePrevious()
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        SetQualPositionButtons()
    End Sub

    Private Sub qualNewbtn_Click(sender As Object, e As EventArgs) Handles qualNewbtn.Click
        Dim r As DataRowView

        r = qualBindingSource.AddNew
        qualBindingSource.MoveLast()
        r(0) = staffNotxt.Text

        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count

        qualLastbtn.Enabled = False
        qualFirstbtn.Enabled = False
        qualNextbtn.Enabled = False
        qualPrevbtn.Enabled = False
        qualNewbtn.Enabled = False
    End Sub

    Private Sub qualSavebtn_Click(sender As Object, e As EventArgs) Handles qualSavebtn.Click
        Try
            qualBindingSource.EndEdit()
            Oracle.qualAdapter.Update(Oracle.qualTable)
            EnableQualButtons()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub qualDeletebtn_Click(sender As Object, e As EventArgs) Handles qualDeletebtn.Click
        Try
            qualBindingSource.RemoveCurrent()
            Oracle.qualAdapter.Update(Oracle.qualTable)
            qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
            EnableQualButtons()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub qualNextbtn_Click(sender As Object, e As EventArgs) Handles qualNextbtn.Click
        qualBindingSource.MoveNext()
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        SetQualPositionButtons()
    End Sub

    Private Sub qualLastbtn_Click(sender As Object, e As EventArgs) Handles qualLastbtn.Click
        qualBindingSource.MoveLast()
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        SetQualPositionButtons()
    End Sub

    Private Sub workFirstbtn_Click(sender As Object, e As EventArgs) Handles workFirstbtn.Click
        expBindingSource.MoveFirst()
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetExpPositionButtons()
    End Sub

    Private Sub workPrevbtn_Click(sender As Object, e As EventArgs) Handles workPrevbtn.Click
        expBindingSource.MovePrevious()
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetExpPositionButtons()
    End Sub

    Private Sub workNewbtn_Click(sender As Object, e As EventArgs) Handles workNewbtn.Click
        Dim r As DataRowView

        r = expBindingSource.AddNew
        expBindingSource.MoveLast()
        r(0) = staffNotxt.Text

        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count

        workLastbtn.Enabled = False
        workFirstbtn.Enabled = False
        workNextbtn.Enabled = False
        workPrevbtn.Enabled = False
        workNewbtn.Enabled = False
    End Sub

    Private Sub workSavebtn_Click(sender As Object, e As EventArgs) Handles workSavebtn.Click
        Try
            expBindingSource.EndEdit()
            Oracle.expAdapter.Update(Oracle.expTable)
            EnableExpButtons()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub workDeletebtn_Click(sender As Object, e As EventArgs) Handles workDeletebtn.Click
        Try
            expBindingSource.RemoveCurrent()
            Oracle.expAdapter.Update(Oracle.expTable)
            worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
            EnableExpButtons()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub workNextbtn_Click(sender As Object, e As EventArgs) Handles workNextbtn.Click
        expBindingSource.MoveNext()
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetExpPositionButtons()
    End Sub

    Private Sub workLastbtn_Click(sender As Object, e As EventArgs) Handles workLastbtn.Click
        expBindingSource.MoveLast()
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetExpPositionButtons()
    End Sub

    Private Sub allbtn_Click(sender As Object, e As EventArgs) Handles allbtn.Click
        Oracle.staffCommand.CommandText = "Select * from UWP_Staff "
        Oracle.staffTable.Clear()
        Oracle.staffAdapter.Fill(Oracle.staffTable)

        SetQualExpTables()

        empNextbtn_Click(sender, e)
        empPrevbtn_Click(sender, e)
    End Sub

    Private Sub searchbtn_Click(sender As Object, e As EventArgs) Handles searchbtn.Click
        Dim fieldString As String = fieldDdl.SelectedItem.ToString

        If fieldString = "TYPE" Then
            Oracle.staffCommand.CommandText = "Select * from UWP_Staff " & _
                                              "Join UWP_Qualifications " & _
                                              "On UWP_Staff.StaffNo = UWP_Qualifications.StaffNo " & _
                                              "And " & fieldString & " = '" & valuetxt.Text & "'"
        Else
            Oracle.staffCommand.CommandText = "Select * from UWP_Staff " & _
                                     "Join UWP_WorkExperience " & _
                                     "On UWP_Staff.StaffNo = UWP_WorkExperience.StaffNo " & _
                                     "And " & fieldString & " = '" & valuetxt.Text & "'"
        End If

        Oracle.qualTable.Clear()
        Oracle.qualAdapter.Fill(Oracle.qualTable)

        Oracle.expTable.Clear()
        Oracle.expAdapter.Fill(Oracle.expTable)

        Oracle.staffTable.Clear()
        Oracle.staffAdapter.Fill(Oracle.staffTable)

        empNextbtn_Click(sender, e)
        empPrevbtn_Click(sender, e)
    End Sub

   Private Sub SetQualPositionButtons()
        If qualBindingSource.Count = 0 Or qualBindingSource.Count = 1 Then
            qualLastbtn.Enabled = False
            qualFirstbtn.Enabled = False
            qualNextbtn.Enabled = False
            qualPrevbtn.Enabled = False
        Else
            If qualBindingSource.Position + 1 = qualBindingSource.Count Then
                qualNextbtn.Enabled = False
                qualLastbtn.Enabled = False
                qualFirstbtn.Enabled = True
                qualPrevbtn.Enabled = True
            ElseIf qualBindingSource.Position = 0 Then
                qualPrevbtn.Enabled = False
                qualFirstbtn.Enabled = False
                qualLastbtn.Enabled = True
                qualNextbtn.Enabled = True
            Else
                EnableQualButtons()
            End If
        End If
   End Sub

    Private Sub EnableQualButtons()
        qualLastbtn.Enabled = True
        qualFirstbtn.Enabled = True
        qualNextbtn.Enabled = True
        qualPrevbtn.Enabled = True
        qualNewbtn.Enabled = True
    End Sub

    Private Sub SetExpPositionButtons()
        If expBindingSource.Count = 0 Or expBindingSource.Count = 1 Then
            workLastbtn.Enabled = False
            workFirstbtn.Enabled = False
            workNextbtn.Enabled = False
            workPrevbtn.Enabled = False
        Else
            If expBindingSource.Position + 1 = expBindingSource.Count Then
                workNextbtn.Enabled = False
                workLastbtn.Enabled = False
                workFirstbtn.Enabled = True
                workPrevbtn.Enabled = True
            ElseIf expBindingSource.Position = 0 Then
                workPrevbtn.Enabled = False
                workFirstbtn.Enabled = False
                workLastbtn.Enabled = True
                workNextbtn.Enabled = True
            Else
                EnableExpButtons()
            End If
        End If

   End Sub

    Private Sub EnableExpButtons()
        workLastbtn.Enabled = True
        workFirstbtn.Enabled = True
        workNextbtn.Enabled = True
        workPrevbtn.Enabled = True
        workNewbtn.Enabled = True
    End Sub

    Private Sub UpdateInformation()
        SetQualExpTables()
        empTxt.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        qualtxt.Text = (qualBindingSource.Position + 1) & "/" & qualBindingSource.Count
        worktxt.Text = (expBindingSource.Position + 1) & "/" & expBindingSource.Count
        SetStaffPositionButtons()
        SetQualPositionButtons()
        SetExpPositionButtons()
    End Sub

End Class
