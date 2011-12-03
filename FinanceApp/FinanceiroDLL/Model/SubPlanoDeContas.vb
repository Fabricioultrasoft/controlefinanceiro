Namespace Model
    Public Class SubPlanoDeContas

        Private id_ As Integer
        Public Property Id() As Integer
            Get
                Return id_
            End Get
            Set(ByVal value As Integer)
                id_ = value
            End Set
        End Property

        Private idPlano_ As Integer
        Public Property IdPlano() As Integer
            Get
                Return idPlano_
            End Get
            Set(ByVal value As Integer)
                idPlano_ = value
            End Set
        End Property

        Private descricao_ As String
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

