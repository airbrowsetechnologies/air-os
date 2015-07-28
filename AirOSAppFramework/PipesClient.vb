
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO.Pipes
Imports System.Diagnostics


Public Class PipeClient
    Public Sub Send(SendStr As String, PipeName As String, Optional TimeOut As Integer = 1000)
        Try
            Dim pipeStream As New NamedPipeClientStream(".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous)

            ' The connect function will indefinitely wait for the pipe to become available
            ' If that is not acceptable specify a maximum waiting time (in ms)
            pipeStream.Connect(TimeOut)
            Debug.WriteLine("[Client] Pipe connection established")

            Dim _buffer As Byte() = Encoding.UTF8.GetBytes(SendStr)
            pipeStream.BeginWrite(_buffer, 0, _buffer.Length, AddressOf AsyncSend, pipeStream)
        Catch oEX As TimeoutException
            Debug.WriteLine(oEX.Message)
        End Try
    End Sub

    Private Sub AsyncSend(iar As IAsyncResult)
        Try
            ' Get the pipe
            Dim pipeStream As NamedPipeClientStream = DirectCast(iar.AsyncState, NamedPipeClientStream)

            ' End the write
            pipeStream.EndWrite(iar)
            pipeStream.Flush()
            pipeStream.Close()
            pipeStream.Dispose()
        Catch oEX As Exception
            Debug.WriteLine(oEX.Message)
        End Try
    End Sub
End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
