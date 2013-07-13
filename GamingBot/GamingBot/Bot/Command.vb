Namespace Bot

    Public Class Command
        Private COMMAND_SEPARATOR As Char() = " "

        Private _CommandRaw As String = ""
        Private _CommandArray() As String
        Private _Type As CommandType = CommandType.Undefined
        Private _ParameterString As String
        Private _Parameters() As String

        Public ReadOnly Property CommandRaw() As String
            Get
                Return _CommandRaw
            End Get
        End Property

        Public ReadOnly Property CommandArray() As String()
            Get
                Return _CommandArray
            End Get
        End Property

        Public ReadOnly Property Type() As CommandType
            Get
                Return _Type
            End Get
        End Property

        Public ReadOnly Property ParameterString() As String
            Get
                Return _ParameterString
            End Get
        End Property

        Public ReadOnly Property Parameters() As String()
            Get
                Return _Parameters
            End Get
        End Property

        Sub New(ByVal CommandRaw As String)
            CommandRaw = StripSpaces(CommandRaw)
            If CommandRaw.Length <= 1 Then
                _Type = CommandType.Undefined
                Exit Sub
            End If
            If CommandRaw(CommandRaw.Length - 1) = ";" Then CommandRaw = Microsoft.VisualBasic.Left(CommandRaw, CommandRaw.Length - 1)
            _CommandRaw = CommandRaw
            _CommandArray = CommandRaw.Split(COMMAND_SEPARATOR)
            _Type = GetCommandType(CommandArray(0))
            _ParameterString = Microsoft.VisualBasic.Right(CommandRaw, CommandRaw.Length - CommandRaw.IndexOf(COMMAND_SEPARATOR) - 1)
            _Parameters = _ParameterString.Split(COMMAND_SEPARATOR)
        End Sub

        Private Function StripSpaces(ByVal Data As String) As String
            Const SPACE_CHAR As Char = " "
            Const CR_BYTE As Byte = 13
            Const LF_BYTE As Byte = 10
            ' space at start
            While True
                If Data.Length > 0 Then
                    Dim CurrentChar As String = Microsoft.VisualBasic.Left(Data, 1)
                    Dim CurrentByte As Byte = Convert.ToByte(Convert.ToChar(CurrentChar))
                    If CurrentChar = SPACE_CHAR Or CurrentByte = CR_BYTE Or CurrentByte = LF_BYTE Then
                        Data = Microsoft.VisualBasic.Right(Data, Data.Length - 1)
                    Else
                        Exit While
                    End If
                Else
                    Exit While
                End If
            End While
            ' space at end
            While True
                If Data.Length > 0 Then
                    Dim CurrentChar As String = Microsoft.VisualBasic.Right(Data, 1)
                    Dim CurrentByte As Byte = Convert.ToByte(Convert.ToChar(CurrentChar))
                    If CurrentChar = SPACE_CHAR Or CurrentByte = CR_BYTE Or CurrentByte = LF_BYTE Then
                        Data = Microsoft.VisualBasic.Left(Data, Data.Length - 1)
                    Else
                        Exit While
                    End If
                Else
                    Exit While
                End If
            End While
            ' return
            Return Data
        End Function

        Public Shared Function GetCommandType(ByVal Command As String) As CommandType
            Select Case Command
                Case "waitms" : Return CommandType.WaitMs
                Case "setpos" : Return CommandType.SetPos
                Case "lclick" : Return CommandType.LClick
                Case "rclick" : Return CommandType.RClick
                Case "sndkey" : Return CommandType.SndKey
                Case "commnt" : Return CommandType.Commnt
                Case Else : Return CommandType.Undefined
            End Select
        End Function
    End Class
End Namespace