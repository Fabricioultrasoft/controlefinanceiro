Imports System.Data.SqlServerCe
Imports FinanceiroDLL.Model

Namespace DAO
    Public Class SubPlanoDeContasDAO
        Inherits SQLHelper

        Public Sub CreateSubPlanoDeContas(ByVal pc As SubPlanoDeContas)
            Dim InsertQuery As String = "INSERT INTO SubPlanoDeContas (id, idPlano, descricao) VALUES (@id, @idPlano, @descricao)"

            Dim insertCommand As New SqlCeCommand
            Dim id As Integer = GetMaxID("SubPlanoDeContas")
            Try
                pc.Id = id

                Connect()
                insertCommand.Connection = myConnection
                insertCommand.CommandType = CommandType.Text
                insertCommand.CommandText = InsertQuery

                insertCommand.Parameters.Add(New SqlCeParameter("@id", pc.Id))
                insertCommand.Parameters.Add(New SqlCeParameter("@idPlano", pc.IdPlano))
                insertCommand.Parameters.Add(New SqlCeParameter("@descricao", pc.Descricao))

                insertCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                insertCommand.Dispose()
                Close()
            End Try
        End Sub

        Public Function RetrieveSubPlanoDeContas(ByVal idSubPlanoDeConta As Integer) As SubPlanoDeContas
            Dim selectQuery As String = "SELECT * FROM SubPlanoDeContas WHERE id = @idSubPlanoDeConta"
            Dim dt As New DataTable
            Dim o As SubPlanoDeContas = Nothing

            Dim selectDA As New SqlCeDataAdapter
            Dim selectCommand As New SqlCeCommand

            Try
                Connect()
                selectCommand.Connection = myConnection
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = selectQuery
                selectCommand.Parameters.Add(New SqlCeParameter("@idSubPlanoDeConta", idSubPlanoDeConta))

                selectDA.SelectCommand = selectCommand
                selectDA.Fill(dt)

                If dt.Rows.Count > 0 Then
                    o = New SubPlanoDeContas
                    o.Id = dt.Rows(0)(0)
                    o.IdPlano = dt.Rows(0)(1)
                    o.Descricao = dt.Rows(0)(2)
                End If

            Catch ex As Exception
                'Log
            Finally
                Close()
            End Try

            Return o
        End Function

        Public Sub UpdateSubPlanoDeContas(ByVal pc As SubPlanoDeContas)
            Dim updateQuery As String = "UPDATE SubPlanoDeContas SET descricao = @descricao, idPlano = @idPlano WHERE id = @id"
            Dim updateCommand As New SqlCeCommand

            Try
                Connect()
                updateCommand.Connection = myConnection
                updateCommand.CommandType = CommandType.Text
                updateCommand.CommandText = updateQuery
                updateCommand.Parameters.Add(New SqlCeParameter("@id", pc.Id))
                updateCommand.Parameters.Add(New SqlCeParameter("@idPlano", pc.IdPlano))
                updateCommand.Parameters.Add(New SqlCeParameter("@descricao", pc.Descricao))

                updateCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                Close()
                updateCommand.Dispose()
            End Try
        End Sub

        Public Sub DeleteSubPlanoDeContas(ByVal idSubPlanoDeConta As Integer)
            Dim deleteQuery As String = "DELETE FROM SubPlanoDeContas WHERE id = @id"
            Dim deleteCommand As New SqlCeCommand

            Try
                Connect()
                deleteCommand.Connection = myConnection
                deleteCommand.CommandType = CommandType.Text
                deleteCommand.CommandText = deleteQuery
                deleteCommand.Parameters.Add(New SqlCeParameter("@id", idSubPlanoDeConta))

                deleteCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Log
            Finally
                deleteCommand.Dispose()
                Close()
            End Try
        End Sub

        Public Function ListSubPlanos() As List(Of SubPlanoDeContas)
            Dim selectQuery As String = "SELECT * FROM SubPlanoDeContas ORDER BY descricao"
            Dim dt As New DataTable
            Dim oPC As SubPlanoDeContas = Nothing
            Dim listSPC As New List(Of SubPlanoDeContas)

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
                        oPC = New SubPlanoDeContas
                        oPC.Id = r(0)
                        oPC.Descricao = r(2)
                        oPC.IdPlano = r(1)
                        listSPC.Add(oPC)
                    Next
                End If

            Catch ex As Exception
                'Log
            Finally
                Close()
            End Try

            Return listSPC
        End Function
    End Class
End Namespace
