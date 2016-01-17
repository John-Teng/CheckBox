Public Class Checkboxes
    Private Sub Checkboxes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Begin by reading the file and checking which statements are true, if so, their checkboxes will be checked
        Dim lastLocation As String

        lastLocation = My.Settings.fileAddress 'stores the a copy of the file address in a temporary string variable

        While Dir(My.Settings.fileAddress, vbDirectory) = "" 'loops continuously until the user inputs a valid location

            MsgBox("File path " & My.Settings.fileAddress & " does not exist, please enter a new one") 'msgbox to notify the path they entered does not exit
            My.Settings.fileAddress = InputBox("Please enter the file read location. Please include the file name and txt extension in this path" & vbNewLine & "Warning: clicking cancel or exit will enter a NULL input", "Input File Location", My.Settings.fileAddress)

        End While

        If My.Settings.fileAddress = "" Then        'If user clicks cancel or exit
            My.Settings.fileAddress = lastLocation  'the file address will be set to its previous value
        End If
        My.Settings.Save()

        'For each checkbox, call the void "reload" function 
        reload(My.Settings.value1T, My.Settings.value1F, box1)
        reload(My.Settings.value2T, My.Settings.value2F, box2)
        reload(My.Settings.value3T, My.Settings.value3F, box3)
        reload(My.Settings.value4T, My.Settings.value4F, box4)
        reload(My.Settings.value5T, My.Settings.value5F, box5)
        reload(My.Settings.value6T, My.Settings.value6F, box6)
        reload(My.Settings.value7T, My.Settings.value7F, box7)
        reload(My.Settings.value8T, My.Settings.value8F, box8)
        reload(My.Settings.value9T, My.Settings.value9F, box9)
        reload(My.Settings.value10T, My.Settings.value10F, box10)
        reload(My.Settings.value11T, My.Settings.value11F, box11)
        reload(My.Settings.value12T, My.Settings.value12F, box12)
        reload(My.Settings.value13T, My.Settings.value13F, box13)
        reload(My.Settings.value14T, My.Settings.value14F, box14)
        reload(My.Settings.value15T, My.Settings.value15F, box15)
        reload(My.Settings.value16T, My.Settings.value16F, box16)
        reload(My.Settings.value17T, My.Settings.value17F, box17)
        reload(My.Settings.value18T, My.Settings.value18F, box18)
        reload(My.Settings.value19T, My.Settings.value19F, box19)
        reload(My.Settings.value20T, My.Settings.value20F, box20)
        reload(My.Settings.value21T, My.Settings.value21F, box21)
        reload(My.Settings.value22T, My.Settings.value22F, box22)
        reload(My.Settings.value23T, My.Settings.value23F, box23)
        reload(My.Settings.value24T, My.Settings.value24F, box24)
        reload(My.Settings.value25T, My.Settings.value25F, box25)
        reload(My.Settings.value26T, My.Settings.value26F, box26)
        reload(My.Settings.value27T, My.Settings.value27F, box27)
        reload(My.Settings.value28T, My.Settings.value28F, box28)
        reload(My.Settings.value29T, My.Settings.value29F, box29)
        reload(My.Settings.value30T, My.Settings.value30F, box30)

    End Sub
    Public Sub reload(ByVal valueT As String, ByVal valueF As String, ByRef box As Object)
        Dim fileReader As String = My.Computer.FileSystem.ReadAllText(My.Settings.fileAddress) 'reads the file address and assigns all of the content to a string

        If valueT <> "" Then 'Checks to see if the value is in use; if checkbox is unused, it should not be checked
            If fileReader.IndexOf(valueT) >= 0 And fileReader.IndexOf(valueF) = -1 Then 'if the "true" string is found and the "false" string is not
                box.Checked = True
                box.Text = valueT   'set the checkbox label to the true statement (its current state)
            ElseIf fileReader.IndexOf(valueT) = -1 And fileReader.IndexOf(valueF) >= 0 Then  'if the "false" string is found and the "true" string is not
                box.Checked = False
                box.Text = valueF 'set the checkbox label to the false statement (its current state)
            ElseIf fileReader.IndexOf(valueT) >= 0 And fileReader.IndexOf(valueF) >= 0 Then ' if both "true" and "false" strings were found
                MsgBox("Warning: both " & valueT & " and " & valueF & " were found in the document") 'notify user about issue
            Else 'if neither "true" nor "false" strings were found
                MsgBox("Warning: both """ & valueT & """ and """ & valueF & """ were not found in the document") 'notify user about issue
                box.Text = "Unused" 'set checkbox text to unused to represent unverified state
            End If
        Else
            box.Text = "Unused" 'If the value is not in use, set the checkbox label say unused
        End If

    End Sub
    Public Sub checkAndChange(ByVal valueT As String, ByVal valueF As String, ByRef box As Object)
        Dim fileReader As String = My.Computer.FileSystem.ReadAllText(My.Settings.fileAddress) 'reads the file address and assigns all of the content to a string
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Settings.fileAddress, False) 'streamwriter object

        If valueT <> "" And valueF <> "" Then 'Checks to see if the value is in use; if checkbox is unused, it should not be checked (this prevents huge problems)
            If (fileReader.IndexOf(valueT) <> -1 Or fileReader.IndexOf(valueF) <> -1) Then  'Checks to make sure that the the T/F statements are found in the file
                If box.checked = True Then                                                  'if neither statement is found, no replacement will occur (this prevents crashes)
                    fileReader = fileReader.Replace(valueF, valueT) 'Replaces all detected false values into true values
                    box.text = valueT 'set the checkbox label to the true statement (its current state)
                Else
                    fileReader = fileReader.Replace(valueT, valueF) 'Replaces all detected true values into false values
                    box.text = valueF 'set the checkbox label to the false statement (its current state)
                End If
            End If
        End If

        file.WriteLine(fileReader) 'write the changes into the file

        file.Close() 'closes the streamwriter object
    End Sub
    Public Sub checkAll(ByVal valueT As String, ByVal valueF As String, ByRef box As Object)
        Dim fileReader As String = My.Computer.FileSystem.ReadAllText(My.Settings.fileAddress) 'reads the file address and assigns all of the content to a string

        If valueT <> "" And valueF <> "" Then 'Checks to ensure that the value is in use and not empty
            If (fileReader.IndexOf(valueT) <> -1 Or fileReader.IndexOf(valueF) <> -1) Then  'checks to make sure the T/F statements are found in the file
                box.checked = True                                                          'if neither statement is found, the checkbox should not change state 
            End If
        End If
    End Sub
    Public Sub unCheckAll(ByVal valueT As String, ByVal valueF As String, ByRef box As Object)
        Dim fileReader As String = My.Computer.FileSystem.ReadAllText(My.Settings.fileAddress) 'reads the file address and assigns all of the content to a string

        If valueT <> "" And valueF <> "" Then 'Checks to ensure that the value is in use and not empty
            If (fileReader.IndexOf(valueT) <> -1 Or fileReader.IndexOf(valueF) <> -1) Then  'checks to make sure the T/F statements are found in the file
                box.checked = False                                                         'if neither statement is found, the checkbox should not change state 
            End If
        End If
    End Sub
    Private Sub box1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box1.CheckedChanged

        checkAndChange(My.Settings.value1T, My.Settings.value1F, box1) 'call the Check and Change function

    End Sub
    Private Sub box2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box2.CheckedChanged

        checkAndChange(My.Settings.value2T, My.Settings.value2F, box2) 'call the Check and Change function

    End Sub
    Private Sub box3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box3.CheckedChanged

        checkAndChange(My.Settings.value3T, My.Settings.value3F, box3) 'call the Check and Change function

    End Sub
    Private Sub box4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box4.CheckedChanged

        checkAndChange(My.Settings.value4T, My.Settings.value4F, box4) 'call the Check and Change function

    End Sub
    Private Sub box5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box5.CheckedChanged

        checkAndChange(My.Settings.value5T, My.Settings.value5F, box5) 'call the Check and Change function

    End Sub
    Private Sub box6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box6.CheckedChanged

        checkAndChange(My.Settings.value6T, My.Settings.value6F, box6) 'call the Check and Change function

    End Sub
    Private Sub box7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box7.CheckedChanged

        checkAndChange(My.Settings.value7T, My.Settings.value7F, box7) 'call the Check and Change function

    End Sub
    Private Sub box8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box8.CheckedChanged

        checkAndChange(My.Settings.value8T, My.Settings.value8F, box8) 'call the Check and Change function

    End Sub
    Private Sub box9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box9.CheckedChanged

        checkAndChange(My.Settings.value9T, My.Settings.value9F, box9) 'call the Check and Change function

    End Sub
    Private Sub box10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box10.CheckedChanged

        checkAndChange(My.Settings.value10T, My.Settings.value10F, box10) 'call the Check and Change function

    End Sub
    Private Sub box11_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box11.CheckedChanged

        checkAndChange(My.Settings.value11T, My.Settings.value11F, box11) 'call the Check and Change function

    End Sub
    Private Sub box12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box12.CheckedChanged

        checkAndChange(My.Settings.value12T, My.Settings.value12F, box12) 'call the Check and Change function

    End Sub
    Private Sub box13_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box13.CheckedChanged

        checkAndChange(My.Settings.value13T, My.Settings.value13F, box13) 'call the Check and Change function

    End Sub
    Private Sub box14_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box14.CheckedChanged

        checkAndChange(My.Settings.value14T, My.Settings.value14F, box14) 'call the Check and Change function

    End Sub
    Private Sub box15_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box15.CheckedChanged

        checkAndChange(My.Settings.value15T, My.Settings.value15F, box15) 'call the Check and Change function

    End Sub
    Private Sub box16_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box16.CheckedChanged

        checkAndChange(My.Settings.value16T, My.Settings.value16F, box16) 'call the Check and Change function

    End Sub
    Private Sub box17_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box17.CheckedChanged

        checkAndChange(My.Settings.value17T, My.Settings.value17F, box17) 'call the Check and Change function

    End Sub
    Private Sub box18_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box18.CheckedChanged

        checkAndChange(My.Settings.value18T, My.Settings.value18F, box18) 'call the Check and Change function

    End Sub
    Private Sub box19_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box19.CheckedChanged

        checkAndChange(My.Settings.value19T, My.Settings.value19F, box19) 'call the Check and Change function

    End Sub
    Private Sub box20_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box20.CheckedChanged

        checkAndChange(My.Settings.value20T, My.Settings.value20F, box20) 'call the Check and Change function

    End Sub
    Private Sub box21_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box21.CheckedChanged

        checkAndChange(My.Settings.value21T, My.Settings.value21F, box21) 'call the Check and Change function

    End Sub
    Private Sub box22_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box22.CheckedChanged

        checkAndChange(My.Settings.value22T, My.Settings.value22F, box22) 'call the Check and Change function

    End Sub
    Private Sub box23_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box23.CheckedChanged

        checkAndChange(My.Settings.value23T, My.Settings.value23F, box23) 'call the Check and Change function

    End Sub
    Private Sub box24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box24.CheckedChanged

        checkAndChange(My.Settings.value24T, My.Settings.value24F, box24) 'call the Check and Change function

    End Sub
    Private Sub box25_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box25.CheckedChanged

        checkAndChange(My.Settings.value25T, My.Settings.value25F, box25) 'call the Check and Change function


    End Sub
    Private Sub box26_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box26.CheckedChanged

        checkAndChange(My.Settings.value26T, My.Settings.value26F, box26) 'call the Check and Change function

    End Sub
    Private Sub box27_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box27.CheckedChanged

        checkAndChange(My.Settings.value27T, My.Settings.value27F, box27) 'call the Check and Change function

    End Sub
    Private Sub box28_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box28.CheckedChanged

        checkAndChange(My.Settings.value28T, My.Settings.value28F, box28) 'call the Check and Change function

    End Sub
    Private Sub box29_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box29.CheckedChanged

        checkAndChange(My.Settings.value29T, My.Settings.value29F, box29) 'call the Check and Change function

    End Sub
    Private Sub box30_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles box30.CheckedChanged

        checkAndChange(My.Settings.value30T, My.Settings.value30F, box30) 'call the Check and Change function

    End Sub
    Private Sub butCheckAll_Click(sender As System.Object, e As System.EventArgs) Handles butCheckAll.Click
        'Calls the checkAll function for every checkbox
        checkAll(My.Settings.value1T, My.Settings.value1F, box1)
        checkAll(My.Settings.value2T, My.Settings.value2F, box2)
        checkAll(My.Settings.value3T, My.Settings.value3F, box3)
        checkAll(My.Settings.value4T, My.Settings.value4F, box4)
        checkAll(My.Settings.value5T, My.Settings.value5F, box5)
        checkAll(My.Settings.value6T, My.Settings.value6F, box6)
        checkAll(My.Settings.value7T, My.Settings.value7F, box7)
        checkAll(My.Settings.value8T, My.Settings.value8F, box8)
        checkAll(My.Settings.value9T, My.Settings.value9F, box9)
        checkAll(My.Settings.value10T, My.Settings.value10F, box10)
        checkAll(My.Settings.value11T, My.Settings.value11F, box11)
        checkAll(My.Settings.value12T, My.Settings.value12F, box12)
        checkAll(My.Settings.value13T, My.Settings.value13F, box13)
        checkAll(My.Settings.value14T, My.Settings.value14F, box14)
        checkAll(My.Settings.value15T, My.Settings.value15F, box15)
        checkAll(My.Settings.value16T, My.Settings.value16F, box16)
        checkAll(My.Settings.value17T, My.Settings.value17F, box17)
        checkAll(My.Settings.value18T, My.Settings.value18F, box18)
        checkAll(My.Settings.value19T, My.Settings.value19F, box19)
        checkAll(My.Settings.value20T, My.Settings.value20F, box20)
        checkAll(My.Settings.value21T, My.Settings.value21F, box21)
        checkAll(My.Settings.value22T, My.Settings.value22F, box22)
        checkAll(My.Settings.value23T, My.Settings.value23F, box23)
        checkAll(My.Settings.value24T, My.Settings.value24F, box24)
        checkAll(My.Settings.value25T, My.Settings.value25F, box25)
        checkAll(My.Settings.value26T, My.Settings.value26F, box26)
        checkAll(My.Settings.value27T, My.Settings.value27F, box27)
        checkAll(My.Settings.value28T, My.Settings.value28F, box28)
        checkAll(My.Settings.value29T, My.Settings.value29F, box29)
        checkAll(My.Settings.value30T, My.Settings.value30F, box30)
    End Sub
    Private Sub butUncheckAll_Click(sender As System.Object, e As System.EventArgs) Handles butUncheckAll.Click
        'Calls the unCheckAll function for every checkbox
        unCheckAll(My.Settings.value1T, My.Settings.value1F, box1)
        unCheckAll(My.Settings.value2T, My.Settings.value2F, box2)
        unCheckAll(My.Settings.value3T, My.Settings.value3F, box3)
        unCheckAll(My.Settings.value4T, My.Settings.value4F, box4)
        unCheckAll(My.Settings.value5T, My.Settings.value5F, box5)
        unCheckAll(My.Settings.value6T, My.Settings.value6F, box6)
        unCheckAll(My.Settings.value7T, My.Settings.value7F, box7)
        unCheckAll(My.Settings.value8T, My.Settings.value8F, box8)
        unCheckAll(My.Settings.value9T, My.Settings.value9F, box9)
        unCheckAll(My.Settings.value10T, My.Settings.value10F, box10)
        unCheckAll(My.Settings.value11T, My.Settings.value11F, box11)
        unCheckAll(My.Settings.value12T, My.Settings.value12F, box12)
        unCheckAll(My.Settings.value13T, My.Settings.value13F, box13)
        unCheckAll(My.Settings.value14T, My.Settings.value14F, box14)
        unCheckAll(My.Settings.value15T, My.Settings.value15F, box15)
        unCheckAll(My.Settings.value16T, My.Settings.value16F, box16)
        unCheckAll(My.Settings.value17T, My.Settings.value17F, box17)
        unCheckAll(My.Settings.value18T, My.Settings.value18F, box18)
        unCheckAll(My.Settings.value19T, My.Settings.value19F, box19)
        unCheckAll(My.Settings.value20T, My.Settings.value20F, box20)
        unCheckAll(My.Settings.value21T, My.Settings.value21F, box21)
        unCheckAll(My.Settings.value22T, My.Settings.value22F, box22)
        unCheckAll(My.Settings.value23T, My.Settings.value23F, box23)
        unCheckAll(My.Settings.value24T, My.Settings.value24F, box24)
        unCheckAll(My.Settings.value25T, My.Settings.value25F, box25)
        unCheckAll(My.Settings.value26T, My.Settings.value26F, box26)
        unCheckAll(My.Settings.value27T, My.Settings.value27F, box27)
        unCheckAll(My.Settings.value28T, My.Settings.value28F, box28)
        unCheckAll(My.Settings.value29T, My.Settings.value29F, box29)
        unCheckAll(My.Settings.value30T, My.Settings.value30F, box30)

    End Sub
    Private Sub butConfig_Click(sender As System.Object, e As System.EventArgs) Handles butConfig.Click

        Config.Show() 'opens the config form
        Me.Hide() 'hides the current form

    End Sub
    Private Sub butRefresh_Click(sender As System.Object, e As System.EventArgs) Handles butRefresh.Click

        'For each checkbox, call the void "reload" function 
        reload(My.Settings.value1T, My.Settings.value1F, box1)
        reload(My.Settings.value2T, My.Settings.value2F, box2)
        reload(My.Settings.value3T, My.Settings.value3F, box3)
        reload(My.Settings.value4T, My.Settings.value4F, box4)
        reload(My.Settings.value5T, My.Settings.value5F, box5)
        reload(My.Settings.value6T, My.Settings.value6F, box6)
        reload(My.Settings.value7T, My.Settings.value7F, box7)
        reload(My.Settings.value8T, My.Settings.value8F, box8)
        reload(My.Settings.value9T, My.Settings.value9F, box9)
        reload(My.Settings.value10T, My.Settings.value10F, box10)
        reload(My.Settings.value11T, My.Settings.value11F, box11)
        reload(My.Settings.value12T, My.Settings.value12F, box12)
        reload(My.Settings.value13T, My.Settings.value13F, box13)
        reload(My.Settings.value14T, My.Settings.value14F, box14)
        reload(My.Settings.value15T, My.Settings.value15F, box15)
        reload(My.Settings.value16T, My.Settings.value16F, box16)
        reload(My.Settings.value17T, My.Settings.value17F, box17)
        reload(My.Settings.value18T, My.Settings.value18F, box18)
        reload(My.Settings.value19T, My.Settings.value19F, box19)
        reload(My.Settings.value20T, My.Settings.value20F, box20)
        reload(My.Settings.value21T, My.Settings.value21F, box21)
        reload(My.Settings.value22T, My.Settings.value22F, box22)
        reload(My.Settings.value23T, My.Settings.value23F, box23)
        reload(My.Settings.value24T, My.Settings.value24F, box24)
        reload(My.Settings.value25T, My.Settings.value25F, box25)
        reload(My.Settings.value26T, My.Settings.value26F, box26)
        reload(My.Settings.value27T, My.Settings.value27F, box27)
        reload(My.Settings.value28T, My.Settings.value28F, box28)
        reload(My.Settings.value29T, My.Settings.value29F, box29)
        reload(My.Settings.value30T, My.Settings.value30F, box30)

    End Sub
    Private Sub butHelp_Click(sender As System.Object, e As System.EventArgs) Handles butHelp.Click
        'explains abstractly how this program functions
        MessageBox.Show("This program reads the file location and searches for either 'true' statements or 'false' statements. When a checkbox is checked, this program will swap the true/false statements in the file." & vbNewLine & "Unexpected behaviour may occur if neither true/false statements are found in the file, or if both true/false statements are found in the file.", "How Does This Work?")
    End Sub

End Class

