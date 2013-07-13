Imports System.IO

Namespace Bot

    Public Class Bot

        Protected _FileName As String = ""
        Protected _FileStream As FileStream
        Protected _RawData As String = ""

        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

        Public Property FileStream() As FileStream
            Get
                Return _FileStream
            End Get
            Set(ByVal value As FileStream)
                _FileStream = value
            End Set
        End Property

        Sub New(ByVal FileName As String)
            Me.New(New FileStream(FileName, FileMode.Open, FileAccess.Read))
            Me.FileName = FileName
        End Sub

        Sub New(ByVal FileStream As FileStream)
            Me.FileStream = FileStream
        End Sub

        Public Function Read() As List(Of Command)
            Dim RawData As String = GetRawData()
            Dim ReturnData As New List(Of Command)
            For Each CurrentCommand As String In RawData.Split(";")
                ReturnData.Add(New Command(CurrentCommand))
            Next
            Return ReturnData
        End Function

        Public Function GetRawData() As String
            Dim RawData As String
            Try
                FileStream.Position = 0
                Dim FileStreamReader As New StreamReader(FileStream)
                RawData = FileStreamReader.ReadToEnd()
                FileStreamReader.Close()
                _RawData = RawData
            Catch ex As Exception
                RawData = _RawData
            End Try
            Return RawData
        End Function
    End Class
End Namespace