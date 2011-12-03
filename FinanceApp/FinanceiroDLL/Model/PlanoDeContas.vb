Namespace Model
    Public Class PlanoDeContas
        Private id_ As Integer
        Private descricao_ As String

        Public Property Id() As String
            Get
                Return id_
            End Get
            Set(value As String)
                id_ = value
            End Set
        End Property

        Public Property Descricao() As String
            Get
                Return descricao_
            End Get
            Set(ByVal value As String)
                descricao_ = value
            End Set
        End Property


    End Class
End Namespace

