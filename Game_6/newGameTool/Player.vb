Public Class Player
    Inherits GamePiece
    Dim bHorizontalMovement As Boolean = False
    Dim bVeritcalMovement As Boolean = False

    Public Sub New()
        Me.Width = 100
        Me.Height = Me.Width / 4
        Me.BackColor = Color.Black
    End Sub

    Public Property HorizontalMovement As Boolean
        Get
            Return bHorizontalMovement
        End Get
        Set(value As Boolean)
            bHorizontalMovement = value
        End Set
    End Property

    Public Property VerticalMovement As Boolean
        Get
            Return bVeritcalMovement
        End Get
        Set(value As Boolean)
            bVeritcalMovement = value
        End Set
    End Property

    Private Sub Player_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        If Me.Parent Is Nothing = False Then
            AddHandler Me.Parent.KeyDown, AddressOf Form_KeyDown
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) 'Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If bHorizontalMovement = True Then mdUtility.MovePlayer(Me, DirectionEnum.Left)
            Case Keys.Right
                If bHorizontalMovement = True Then mdUtility.MovePlayer(Me, DirectionEnum.Right)
            Case Keys.Up
                If bVeritcalMovement = True Then mdUtility.MovePlayer(Me, DirectionEnum.Up)
            Case Keys.Down
                If bVeritcalMovement = True Then mdUtility.MovePlayer(Me, DirectionEnum.Down)
        End Select
    End Sub
End Class
