Imports GamingBot.MouseEvent

Public Class SimulateMouse
    Declare Function ApiMouseEvent Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Declare Function SetCursorPos Lib "user32" (ByVal x As Integer, ByVal y As Integer) As Integer

    Private Const MOUSEEVENTF_LEFTDOWN = &H2
    Private Const MOUSEEVENTF_LEFTUP = &H4
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8
    Private Const MOUSEEVENTF_RIGHTUP = &H10

    ''' <summary>
    ''' Perform a mouse click at the specified position. 
    ''' </summary>
    ''' <param name="Key">The mouse key. </param>
    ''' <param name="X">The x coordinate. </param>
    ''' <param name="Y">The y coordinate. </param>
    ''' <remarks></remarks>
    Public Shared Sub PerformClick(ByVal Key As MouseEvent, Optional ByVal X As Integer = -1, Optional ByVal Y As Integer = -1)
        If Not (X = -1 Or Y = -1) Then SetMouse(X, Y)
        Select Case Key
            Case LeftClick
                Call ApiMouseEvent(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call ApiMouseEvent(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            Case RightClick
                Call ApiMouseEvent(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
                Call ApiMouseEvent(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
            Case DoubleClick
                For i As Integer = 1 To 2
                    PerformClick(LeftClick, X, Y)
                Next
        End Select
    End Sub

    ''' <summary>
    ''' Set the mouse position
    ''' </summary>
    ''' <param name="X">The x coordinate. </param>
    ''' <param name="Y">The y coordinate. </param>
    ''' <remarks></remarks>
    Public Shared Sub SetMouse(ByVal X As Integer, ByVal Y As Integer)
        SetCursorPos(X + FormMain.ScreenX, Y + FormMain.ScreenY)
    End Sub
End Class