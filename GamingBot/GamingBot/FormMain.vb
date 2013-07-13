Imports System.IO
Imports GamingBot.Bot

Public Class FormMain

    Private EnableState As Boolean = False
    Private ExpandWindowState As Boolean = False

    Public MainBot As Bot.Bot
    Public BotCommands As List(Of Command)
    Public CurrentStep As Long = 0
    Public RepeatStep As Integer = 0
    Public ScreenX As Integer = 1
    Public ScreenY As Integer = 1

#Region "Main"

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.ConfigureWindow(Me)
        ExpandWindow(False)
        Enable(False)
        NumericUpDownScreenWidth.Value = My.Settings.ScreenWidth
        NumericUpDownScreenHeight.Value = My.Settings.ScreenHeight
    End Sub

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click
        OpenFileDialogMain.InitialDirectory = Main.QualifyDirectory(Environment.CurrentDirectory) & "bots\"
        Dim Result As DialogResult = OpenFileDialogMain.ShowDialog
        If Result = Windows.Forms.DialogResult.OK Then
            MainBot = New Bot.Bot(OpenFileDialogMain.FileName)
            Enable(True)
        End If
    End Sub

    Private Sub ButtonRawData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRawData.Click
        ' supported commands
        Dim Commands As String() = {"waitms", "setpos", "lclick", "rclick", "sndkey", "commnt"}
        With RichTextBoxRawData
            .Text = MainBot.GetRawData
            ' make everything black
            .SelectAll()
            .SelectionColor = Color.Black
            .DeselectAll()

            ' syntax highlighting
            Dim IndexCount As Integer = 0
            For i As Integer = 0 To .Lines.Length - 1
                For Each Command As String In Commands
                    Try
                        If Microsoft.VisualBasic.Left(.Lines(i), 6) = Command Then
                            .Select(IndexCount, 6)
                            .SelectionColor = Color.Blue
                            If Command = "commnt" Then
                                '.SelectionColor = Color.Green
                                .Select(IndexCount + 6, .Lines(i).Length - 7)
                                .SelectionColor = Color.Red
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                IndexCount += .Lines(i).Length + 1
            Next

            .DeselectAll()
        End With
        ' expand window
        ExpandWindow(Not ExpandWindowState)
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        Try
            ' screen
            My.Settings.ScreenWidth = NumericUpDownScreenWidth.Value
            My.Settings.ScreenHeight = NumericUpDownScreenHeight.Value
            CalculateScreen()

            BotCommands = MainBot.Read()
            ExecuteStep(0)
        Catch ex As Exception
            MsgBox("Syntax Error!" & vbCrLf & "Sorry for the inconvenience this may have caused you, but it's your mistake, moron!" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub ButtonGenerateSampleData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSampleData.Click
        If MessageBox.Show("Are you sure that you want to generate sample data? Contents in the ""bots"" directory will be overwritten with this sample data." & vbCrLf & vbCrLf & "Press ""yes"" to proceed.", Main.GetWindowText(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim BotsDirectory As String = Main.QualifyDirectory(Environment.CurrentDirectory) & "bots\"
                If Not Directory.Exists(BotsDirectory) Then Directory.CreateDirectory(BotsDirectory)
                Dim FStream As New FileStream(BotsDirectory & "Arcangrove(Rogue lvl 30).fbot", FileMode.Create, FileAccess.Write)
                Dim SWriter As New StreamWriter(FStream)
                SWriter.Write(My.Settings.SampleArcangrove)
                SWriter.Close()
                FStream.Close()
            Catch ex As Exception
                MsgBox("An error occured while generating sample data, aborting." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Enable(ByVal State As Boolean)
        Const PROGRESS_TEXT_DISABLED = "Please load a data file. "
        Const PROGRESS_TEXT_ENABLED = "Press ""start"" to run your script. "
        ButtonLoad.Enabled = Not State
        ButtonRawData.Enabled = State
        ButtonStart.Enabled = State
        If State Then
            LabelProgress.Text = PROGRESS_TEXT_ENABLED
        Else
            LabelProgress.Text = PROGRESS_TEXT_DISABLED
            ExpandWindow(State)
        End If
        EnableState = State
    End Sub

    Private Sub ExpandWindow(ByVal State As Boolean)
        Const WINDOW_WIDTH_NORMAL As Integer = 340
        Const WINDOW_WIDTH_EXPANDED As Integer = 770
        Const BUTTON_TEXT As String = "Raw Data"
        Const BUTTON_TEXT_NORMAL As String = ">>"
        Const BUTTON_TEXT_EXPANDED As String = "<<"
        Const EXPANDING_INTERVAL As Integer = 5

        ButtonRawData.Text = BUTTON_TEXT & " "
        If State Then
            ButtonRawData.Text &= BUTTON_TEXT_EXPANDED
            Dim i As Integer = WINDOW_WIDTH_NORMAL
            While True
                Me.Width = i
                If i >= WINDOW_WIDTH_EXPANDED Then Exit While
                i += EXPANDING_INTERVAL
            End While
        Else
            ButtonRawData.Text &= BUTTON_TEXT_NORMAL
            Dim i As Integer = WINDOW_WIDTH_EXPANDED
            While True
                Me.Width = i
                If i <= WINDOW_WIDTH_NORMAL Then Exit While
                i -= EXPANDING_INTERVAL
            End While
        End If
        GroupBoxRawData.Visible = State
        ExpandWindowState = State
    End Sub

    Private Sub CalculateScreen()
        ScreenX = (My.Settings.ScreenWidth - 960) / 2
        ScreenY = 101 '(My.Settings.ScreenHeight - 550) / 2
        If My.Settings.ScreenHeight < 1080 Then ScreenY -= 9
    End Sub
#End Region

#Region "Execution"

    Public Sub ExecuteStep(ByVal StepNumber As Long)
        If StepNumber >= BotCommands.Count - 1 Then
            StepNumber = 0
            RepeatStep += 1
            Log("Finished: Starting over...")
        End If
        CurrentStep = StepNumber
        Dim CurrentCommand As Command = BotCommands.Item(CurrentStep)
        Select Case CurrentCommand.Type
            Case CommandType.WaitMs
                If Not CurrentCommand.Parameters.Length = 1 Then
                    Log("Syntax error: waitms: too many or too little parameters, ignoring!")
                    NextStep()
                End If
                If Not IsNumeric(CurrentCommand.Parameters(0)) Then
                    Log("Syntax error: waitms: interval is not numeric or nonexistent, ignoring!")
                    NextStep()
                End If
                Log(CurrentCommand.CommandRaw)
                SetInterval(CurrentCommand.Parameters(0))
            Case CommandType.LClick
                If Not CurrentCommand.Parameters.Length = 2 Then
                    Log("Syntax error: lclick: too many or too little parameters, ignoring!")
                    NextStep()
                End If
                If Not IsNumeric(CurrentCommand.Parameters(0)) Then
                    Log("Syntax error: lclick: x-position is not numeric or nonexistent, ignoring!")
                    NextStep()
                End If
                If Not IsNumeric(CurrentCommand.Parameters(1)) Then
                    Log("Syntax error: lclick: y-position is not numeric or nonexistent, ignoring!")
                    NextStep()
                End If
                Log(CurrentCommand.CommandRaw)
                LeftClick(CurrentCommand.Parameters(0), CurrentCommand.Parameters(1))
            Case CommandType.RClick
                If Not CurrentCommand.Parameters.Length = 2 Then
                    Log("Syntax error: rclick: too many or too little parameters, ignoring!")
                    NextStep()
                End If
                If Not IsNumeric(CurrentCommand.Parameters(0)) Then
                    Log("Syntax error: rclick: x-position is not numeric or nonexistent, ignoring!")
                    NextStep()
                End If
                If Not IsNumeric(CurrentCommand.Parameters(1)) Then
                    Log("Syntax error: rclick: y-position is not numeric or nonexistent, ignoring!")
                    NextStep()
                End If
                Log(CurrentCommand.CommandRaw)
                RightClick(CurrentCommand.Parameters(0), CurrentCommand.Parameters(1))
            Case CommandType.SndKey
                Log(CurrentCommand.CommandRaw)
                SendKey(CurrentCommand.ParameterString)
            Case CommandType.SetPos
                Log("Syntax error: setpos: is not supported (yet), ignoring!")
                NextStep()
            Case CommandType.Commnt
                Log(CurrentCommand.CommandRaw)
                NextStep()
            Case Else
                Log("Syntax error: unknown command, ignoring!")
                NextStep()
        End Select
    End Sub

    Private Sub Log(ByVal Text As String)
        Text = CurrentStep & "[" & RepeatStep & "]. " & Text
        LabelProgress.Text = Text
        TextBoxLog.Text &= Text & vbCrLf
        TextBoxLog.Select(TextBoxLog.Text.Length, 0)
        TextBoxLog.ScrollToCaret()
    End Sub

    Private Sub NextStep()
        ExecuteStep(CurrentStep + 1)
    End Sub

    Private Sub SetInterval(ByVal Interval As Integer)
        If Interval = 0 Then
            NextStep()
        Else
            TimerMain.Interval = Interval
            TimerMain.Start()
        End If
    End Sub

    Private Sub LeftClick(ByVal X As Integer, ByVal Y As Integer, Optional ByVal ExecuteNextStep As Boolean = True)
        SimulateMouse.PerformClick(MouseEvent.LeftClick, X, Y)
        If ExecuteNextStep Then NextStep()
    End Sub

    Private Sub RightClick(ByVal X As Integer, ByVal Y As Integer, Optional ByVal ExecuteNextStep As Boolean = True)
        SimulateMouse.PerformClick(MouseEvent.RightClick, X, Y)
        If ExecuteNextStep Then NextStep()
    End Sub

    Private Sub SendKey(ByVal Key As String)
        SendKeys.Send(Key)
        NextStep()
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        TimerMain.Stop()
        NextStep()
    End Sub
#End Region
End Class
