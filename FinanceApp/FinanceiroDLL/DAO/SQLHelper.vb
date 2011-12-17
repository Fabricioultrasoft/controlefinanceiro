Imports System.Data.SqlServerCe

Namespace DAO
    Public Class SQLHelper

        Private Shared conString As String = Configuration.ConfigurationManager.ConnectionStrings("FinanceiroDB").ToString()
        Public Shared myConnection As SqlCeConnection = Nothing

        Public Sub Connect()
            Try
                myConnection = New SqlCeConnection(conString)
                If myConnection.State = ConnectionState.Closed Then
                    myConnection.Open()
                End If
            Catch ex As Exception
                'Log
            End Try
        End Sub

        Public Sub Close()
            Try
                If myConnection.State = ConnectionState.Open Then
                    myConnection.Close()
                    myConnection.Dispose()
                End If
            Catch ex As Exception
                'Log
            End Try
        End Sub

        Public Function GetMaxID(ByVal Table As String) As Integer
            Dim id As Object = Nothing

            Try
                Connect()
                Dim com As New SqlCeCommand
                Dim dt As New DataTable

                com.Connection = myConnection
                com.CommandType = CommandType.Text
                com.CommandText = "SELECT MAX(id) + 1 AS id FROM " + Table
                id = com.ExecuteScalar()

                If id Is Nothing Or id.Equals(System.DBNull.Value) Then
                    id = 1
                End If
            Catch ex As Exception
                'Log
            Finally
                Close()
            End Try

            Return Integer.Parse(id.ToString())
        End Function

    End Class
End Namespace

