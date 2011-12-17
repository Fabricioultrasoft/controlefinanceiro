Imports System.Data.SqlServerCe
Imports FinanceiroDLL.Model

Namespace DAO
    Public Class PlanoDeContasDAO
        Inherits SQLHelper

        Public Sub CreatePlanoDeContas(ByVal pc As PlanoDeContas)
            Dim InsertQuery As String = "INSERT INTO PlanoDeContas (id, descricao) VALUES (@id, @descricao)"

            Dim insertCommand As New SqlCeCommand
            Dim id As Integer = GetMaxID("PlanoDeContas")
            Try
                pc.Id = id

                Connect()
                insertCommand.Connection = myConnection
                insertCommand.CommandType = CommandType.Text
                insertCommand.CommandText = InsertQuery

                insertCommand.Parameters.Add(New SqlCeParameter("@id", pc.Id))
                insertCommand.Parameters.Add(New SqlCeParameter("@descricao", pc.Descricao))

                insertCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                insertCommand.Dispose()
                Close()
            End Try
        End Sub

        Public Function RetrievePlanoDeContas(ByVal idPlanoDeConta As Integer) As PlanoDeContas
            Dim selectQuery As String = "SELECT * FROM PlanoDeContas WHERE id = @idPlanoDeConta"
            Dim dt As New DataTable
            Dim o As PlanoDeContas = Nothing

            Dim selectDA As New SqlCeDataAdapter
            Dim selectCommand As New SqlCeCommand

            Try
                Connect()
                selectCommand.Connection = myConnection
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = selectQuery
                selectCommand.Parameters.Add(New SqlCeParameter("@idPlanoDeConta", idPlanoDeConta))

                selectDA.SelectCommand = selectCommand
                selectDA.Fill(dt)

                If dt.Rows.Count > 0 Then
                    o = New PlanoDeContas
                    o.Id = dt.Rows(0)(0)
                    o.Descricao = dt.Rows(0)(1)
                End If

            Catch ex As Exception
                'Log
            Finally
                Close()
            End Try

            Return o
        End Function

        Public Sub UpdatePlanoDeContas(ByVal pc As PlanoDeContas)
            Dim updateQuery As String = "UPDATE PlanoDeContas SET descricao = @descricao WHERE id = @id"
            Dim updateCommand As New SqlCeCommand

            Try
                Connect()
                updateCommand.Connection = myConnection
                updateCommand.CommandType = CommandType.Text
                updateCommand.CommandText = updateQuery
                updateCommand.Parameters.Add(New SqlCeParameter("@id", pc.Id))
                updateCommand.Parameters.Add(New SqlCeParameter("@descricao", pc.Descricao))

                updateCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                Close()
                updateCommand.Dispose()
            End Try
        End Sub

        Public Sub DeletePlanoDeContas(ByVal idPlanoDeConta As Integer)
            Dim deleteQuery As String = "DELETE FROM PlanoDeContas WHERE id = @id"
            Dim deleteCommand As New SqlCeCommand

            Try
                Connect()
                deleteCommand.Connection = myConnection
                deleteCommand.CommandType = CommandType.Text
                deleteCommand.CommandText = deleteQuery
                deleteCommand.Parameters.Add(New SqlCeParameter("@id", idPlanoDeConta))

                deleteCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                deleteCommand.Dispose()
                Close()
            End Try
        End Sub

        Public Function ListPlanos() As List(Of PlanoDeContas)
            Dim selectQuery As String = "SELECT * FROM PlanoDeContas ORDER BY descricao"
            Dim dt As New DataTable
            Dim oPC As PlanoDeContas = Nothing
            Dim listPC As New List(Of PlanoDeContas)

            Dim selectDA As New SqlCeDataAdapter
            Dim selectCommand As New SqlCeCommand

            Try
                Connect()
                selectCommand.Connection = myConnection
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = selectQuery

                selectDA.SelectCommand = selectCommand
                selectDA.Fill(dt)

                If dt.Rows.Count > 0 Then
                    For Each r As DataRow In dt.Rows
                        oPC = New PlanoDeContas
                        oPC.Id = r(0)
                        oPC.Descricao = r(1)
                        listPC.Add(oPC)
                    Next
                End If

            Catch ex As Exception
                'Log
            Finally
                Close()
            End Try

            Return listPC
        End Function
    End Class
End Namespace

