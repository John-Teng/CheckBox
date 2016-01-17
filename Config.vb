Public Class Config

    Private Sub Config_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Checkboxes.Show() 'shows the checkboxes form
        Me.Hide() 'hides the current form
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'updates all the labels with their respective setting values
        lblLocation.Text = My.Settings.fileAddress

        lbl25A.Text = My.Settings.value25T
        lbl26A.Text = My.Settings.value26T
        lbl27A.Text = My.Settings.value27T
        lbl28A.Text = My.Settings.value28T
        lbl29A.Text = My.Settings.value29T
        lbl30A.Text = My.Settings.value30T

        lbl25B.Text = My.Settings.value25F
        lbl26B.Text = My.Settings.value26F
        lbl27B.Text = My.Settings.value27F
        lbl28B.Text = My.Settings.value28F
        lbl29B.Text = My.Settings.value29F
        lbl30B.Text = My.Settings.value30F

    End Sub
    Private Sub butChangeLocation_Click(sender As System.Object, e As System.EventArgs) Handles butChangeLocation.Click
        Dim lastLocation As String = My.Settings.fileAddress 'stores the current address in a temp string variable

        'takes user input for new file address
        My.Settings.fileAddress = InputBox("Confirm the read file location. Please include the file name and txt extension in this path", "File Location Confirmation", My.Settings.fileAddress)
        My.Settings.Save() 'saves user input to settings

        While Dir(My.Settings.fileAddress, vbDirectory) = "" 'loops while user inputs a file location that does not exist
            MsgBox("Error! The file path " & My.Settings.fileAddress & " does not exist. Please enter a new one") 'error message prompting to re-enter a file path

            'takes user input for new file address
            My.Settings.fileAddress = InputBox("Confirm the read file location. Please include the file name and txt extension in this path", "File Location Confirmation", My.Settings.fileAddress)
            My.Settings.Save() 'saves user input to settings

        End While

        If My.Settings.fileAddress = "" Then 'if user cancels, then restore the last file location
            My.Settings.fileAddress = lastLocation
            My.Settings.Save()
        End If

        lblLocation.Text = My.Settings.fileAddress 'sets the label text to the file address

    End Sub
    Private Sub but25A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but25A.Click

        My.Settings.value25T = changeStatement(My.Settings.value25T, lbl25A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub
    Function changeStatement(ByVal lastValue As String, ByVal lbllocation As Object) As String
        Dim changedValue As String 'new temporary variable to store user input

        'inputbox to ask user for new statement value
        changedValue = InputBox("Please enter a new statement. If you do not wish to use this statement, enter NULL value." & vbNewLine & "Warning: Clicking cancel will return a NULL value; if you do not wish to make changes, re-enter the original value and click OK", "Enter New True Statment", lastValue)

        lbllocation.Text = changedValue 'update the corresponding label object

        changeStatement = changedValue 'return the variable
    End Function
    Private Sub but26A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but26A.Click
        My.Settings.value26T = changeStatement(My.Settings.value26T, lbl26A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but27A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but27A.Click
        My.Settings.value27T = changeStatement(My.Settings.value27T, lbl27A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but28A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but28A.Click
        My.Settings.value28T = changeStatement(My.Settings.value28T, lbl28A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but29A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but29A.Click
        My.Settings.value29T = changeStatement(My.Settings.value29T, lbl29A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but30A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but30A.Click
        My.Settings.value30T = changeStatement(My.Settings.value30T, lbl30A) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but25B_Click(sender As System.Object, e As System.EventArgs) Handles but25B.Click
        My.Settings.value25F = changeStatement(My.Settings.value25F, lbl25B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but26B_Click(sender As System.Object, e As System.EventArgs) Handles but26B.Click
        My.Settings.value26F = changeStatement(My.Settings.value26F, lbl26B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but27B_Click(sender As System.Object, e As System.EventArgs) Handles but27B.Click
        My.Settings.value27F = changeStatement(My.Settings.value27F, lbl27B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but28B_Click(sender As System.Object, e As System.EventArgs) Handles but28B.Click
        My.Settings.value28F = changeStatement(My.Settings.value28F, lbl28B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but29B_Click(sender As System.Object, e As System.EventArgs) Handles but29B.Click
        My.Settings.value29F = changeStatement(My.Settings.value29F, lbl29B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub but30B_Click(sender As System.Object, e As System.EventArgs) Handles but30B.Click
        My.Settings.value30F = changeStatement(My.Settings.value30F, lbl30B) 'calls the changeStatement function to recieve user input
        My.Settings.Save() 'saves your changes into settings
    End Sub

    Private Sub butHelp_Click(sender As System.Object, e As System.EventArgs) Handles butHelp.Click
        'Messasgebox to help explain the current form
        MessageBox.Show("On this page you may configure the 6 additional checkboxes on the main form. You must enter BOTH a true statement and a false statement for every additional checkbox you wish to employ.", "Help")
    End Sub
End Class


