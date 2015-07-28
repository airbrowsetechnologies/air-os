
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO.Pipes
Imports System.Diagnostics


' Delegate for passing received message back to caller
Public Delegate Sub DelegateMessage(Reply As String)

Public Class PipeServer
    Public Event PipeMessage As DelegateMessage
    Private _pipeName As String

    Public Sub Listen(PipeName As String)
        Try
            ' Set to class level var so we can re-use in the async callback method
            _pipeName = PipeName
            ' Create the new async pipe 
            Dim pipeServer As New NamedPipeServerStream(PipeName, PipeDirection.[In], 1, PipeTransmissionMode.[Byte], PipeOptions.Asynchronous)

            ' Wait for a connection
            pipeServer.BeginWaitForConnection(New AsyncCallback(AddressOf WaitForConnectionCallBack), pipeServer)
        Catch oEX As Exception
            Debug.WriteLine(oEX.Message)
        End Try
    End Sub

    Private Sub WaitForConnectionCallBack(iar As IAsyncResult)
        Try
            ' Get the pipe
            Dim pipeServer As NamedPipeServerStream = DirectCast(iar.AsyncState, NamedPipeServerStream)
            ' End waiting for the connection
            pipeServer.EndWaitForConnection(iar)

            Dim buffer As Byte() = New Byte(254) {}

            ' Read the incoming message
            pipeServer.Read(buffer, 0, 255)

            ' Convert byte buffer to string
            Dim stringData As String = Encoding.UTF8.GetString(buffer, 0, buffer.Length)
            Debug.WriteLine(stringData + Environment.NewLine)

            ' Pass message back to calling form
            RaiseEvent PipeMessage(stringData)

            ' Kill original sever and create new wait server
            pipeServer.Close()
            pipeServer = Nothing
            pipeServer = New NamedPipeServerStream(_pipeName, PipeDirection.[In], 1, PipeTransmissionMode.[Byte], PipeOptions.Asynchronous)

            ' Recursively wait for the connection again and again....
            pipeServer.BeginWaitForConnection(New AsyncCallback(AddressOf WaitForConnectionCallBack), pipeServer)
        Catch
            Return
        End Try
    End Sub
End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
