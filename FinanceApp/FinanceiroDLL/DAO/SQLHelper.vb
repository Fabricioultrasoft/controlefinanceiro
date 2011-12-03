Imports System.Data.SqlServerCe

Namespace FinanceiroDLL.DAO
    Public Class SQLHelper

        Private Shared conString As String = "Data Source=~\App_Data\FinanceiroDB.sdf"
        Public Shared myConnection As SqlCeConnection = Nothing

        Public Sub Connect()

        End Sub

        Public Sub Close()

        End Sub

        Public Function GetMaxID(ByVal Table As String) As Integer
            Dim id As Object = Nothing

            Try
                Connect()
                Dim com As New SqlCeCommand

                com.Connection = myConnection
                com.CommandType = CommandType.Text
                com.CommandText = "SELECT ISNULL (MAX(id), 0) + 1 AS id FROM " + Table
                id = com.ExecuteScalar

                If id Is Nothing AndAlso id.Equals(System.DBNull.Value) Then
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

