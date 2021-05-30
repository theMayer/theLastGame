Public Class GamePiece
    Inherits Label
    Public Enum EffectEnum
        None
        Score
        Out
    End Enum

    Public Enum ActionEnum
        None
        Disappear
    End Enum

    Dim nHitEffect As EffectEnum = EffectEnum.None
    Dim nHitAction As ActionEnum = ActionEnum.None

    Public Sub New()
        Me.Text = ""
        Me.AutoSize = False
        Me.BackColor = mdUtility.GetRandomColor
    End Sub

    Public Sub Disappear()
        Me.Visible = False
        If Me.Parent Is Nothing = False Then
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub

    'Public Sub SetBackColorToRandom()
    '    Me.BackColor = mdUtility.GetRandomColor
    'End Sub

    Public Property HitEffect As EffectEnum
        Get
            Return nHitEffect
        End Get
        Set(value As EffectEnum)
            nHitEffect = value
        End Set
    End Property

    Public Property HitAction As ActionEnum
        Get
            Return nHitAction
        End Get
        Set(value As ActionEnum)
            nHitAction = value
        End Set
    End Property
End Class
