Imports System.Collections.Specialized
Imports System.Net
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not My.Computer.FileSystem.FileExists("test.txt") Then
            MsgBox("File not found.")
            End
        End If
        TextBox1.Text = post(My.Computer.FileSystem.ReadAllText("test.txt"))
    End Sub

    Function post(paste As String)
        Dim Data As New NameValueCollection()
        Data.Add("key", "") 'Developer key
        Data.Add("description", "Uploaded by program")
        Data.Add("paste", paste)
        Data.Add("format", "simple") 'see https://paste.ee/wiki/API:Formats
        'Data.Add("return", "raw")

        Using Client As New WebClient()
            Dim Response As String = Encoding.UTF8.GetString(Client.UploadValues("http://paste.ee/api", Data))

            'If Not Response.Contains("error_") Then
            Return Response
            'End If
        End Using
        Return "Error"
    End Function
End Class
