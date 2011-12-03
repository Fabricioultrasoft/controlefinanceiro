Namespace Model
    Public Class Usuario
        Private id_ As Integer
        Private usuario_ As String
        Private senha_ As String
        Private nome_ As String
        Private deletado_ As Boolean

        Public Property Id() As Integer
            Get
                Return id_
            End Get
            Set(value As Integer)
                id_ = value
            End Set
        End Property

        Public Property Usuario() As String
            Get
                Return usuario_
            End Get
            Set(value As String)
                usuario_ = value
            End Set
        End Property

        Public Property Senha() As String
            Get
                Return senha_
            End Get
            Set(value As String)
                senha_ = value
            End Set
        End Property

        Public Property Nome() As String
            Get
                Return nome_
            End Get
            Set(value As String)
                nome_ = value
            End Set
        End Property

        Public Property Deletado() As Boolean
            Get
                Return deletado_
            End Get
            Set(value As Boolean)
                deletado_ = value
            End Set
        End Property

    End Class
End Namespace

