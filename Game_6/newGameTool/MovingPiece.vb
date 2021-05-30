Public Class MovingPiece
    Inherits GamePiece
    Dim WithEvents objTimer As Timer = New Timer
    Dim objPlayerObj As Player, objListOfBlocksObj As List(Of GamePiece)

    Public Event Score()
    Public Event Out()

    Public Enum MovementTypeEnum
        None
        Diagonal
        Horizontal
        Vertical
        Random
    End Enum

    Dim nMovementType As MovementTypeEnum = MovementTypeEnum.None

    Dim nOutOfBoundsTopEffect As EffectEnum = EffectEnum.None
    Dim nOutOfBoundsBottomEffect As EffectEnum = EffectEnum.None
    Dim nOutOfBoundsRightEffect As EffectEnum = EffectEnum.None
    Dim nOutOfBoundsLeftEffect As EffectEnum = EffectEnum.None

    Dim nOutOfBoundsTopAction As ActionEnum = ActionEnum.None
    Dim nOutOfBoundsBottomAction As ActionEnum = ActionEnum.None
    Dim nOutOfBoundsRightAction As ActionEnum = ActionEnum.None
    Dim nOutOfBoundsLeftAction As ActionEnum = ActionEnum.None

    Public Sub New()
        With Me
            .Width = 25
            .Height = .Width
        End With
    End Sub

    Public Property TimerOn As Boolean
        Get
            Return objTimer.Enabled
        End Get
        Set(value As Boolean)
            objTimer.Enabled = value
        End Set
    End Property
    Public Property ListOfGamePieces As List(Of GamePiece)
        Get
            Return objListOfBlocksObj
        End Get
        Set(value As List(Of GamePiece))
            objListOfBlocksObj = value
        End Set
    End Property

    Public Property Player As Player
        Get
            Return objPlayerObj
        End Get
        Set(value As Player)
            objPlayerObj = value
        End Set
    End Property

    Private Sub objTimer_Tick(sender As Object, e As EventArgs) Handles objTimer.Tick
        Me.MoveBall(0, objPlayerObj, objListOfBlocksObj)
    End Sub

    Private Sub MoveBall(MinTopValue As Integer, PlayerObj As Player, ListOfBlocksObj As List(Of GamePiece))
        Static nLeftDirection As Integer = 1
        Static nTopDirection As Integer = 1
        Static objRandom As Random = New Random
        Dim nRandomChance As Integer = 8
        Dim objParentControl As Control = Me.Parent
        If objParentControl Is Nothing Then Exit Sub

        With Me
            If nMovementType = MovementTypeEnum.Random Then
                'horizontal
                If .Left > 0 And .Right < objParentControl.Width Then
                    Dim n As Integer = objRandom.Next(1, 11)
                    If n > nRandomChance Then
                        nLeftDirection = -nLeftDirection
                    End If
                End If

                'vertical
                If .Top > 0 And .Bottom <= objParentControl.Height Then
                    Dim n As Integer = objRandom.Next(1, 11)
                    If n > nRandomChance Then
                        nTopDirection = -nTopDirection
                    End If
                End If
            End If
            'move ball
            Select Case nMovementType
                Case MovementTypeEnum.Diagonal, MovementTypeEnum.Horizontal, MovementTypeEnum.Random
                    .Left = .Left + (.Width * nLeftDirection)
            End Select

            Select Case nMovementType
                Case MovementTypeEnum.Diagonal, MovementTypeEnum.Vertical, MovementTypeEnum.Random
                    .Top = .Top + (.Height * nTopDirection)
            End Select

            Dim bLeftOutofBounds As Boolean = .Left <= 0
            Dim bRightOutofBounds As Boolean = .Right >= objParentControl.Width
            Dim bTopOutOfBounds As Boolean = .Top <= MinTopValue
            Dim bBottomOutOfBounds As Boolean = .Bottom >= objParentControl.Height


            'check action
            Dim bDisappear As Boolean = False
            If bLeftOutofBounds = True Then
                Select Case nOutOfBoundsLeftAction
                    Case ActionEnum.None
                        nLeftDirection = 1
                    Case ActionEnum.Disappear
                        bDisappear = True
                End Select
            End If

            If bRightOutofBounds = True Then
                Select Case nOutOfBoundsRightAction
                    Case ActionEnum.None
                        nLeftDirection = -1
                    Case ActionEnum.Disappear
                        bDisappear = True
                End Select

            End If

            If bTopOutOfBounds = True Then
                Select Case nOutOfBoundsTopAction
                    Case ActionEnum.None
                        nTopDirection = 1
                    Case ActionEnum.Disappear
                        bDisappear = True
                End Select

            End If

            If bBottomOutOfBounds = True Then
                Select Case nOutOfBoundsBottomAction
                    Case ActionEnum.None
                        nTopDirection = -1
                    Case Else
                        bDisappear = True
                End Select
            End If

            If CheckOverlap(Me, PlayerObj) = True Then
                Select Case PlayerObj.HitEffect
                    Case EffectEnum.Score
                        RaiseEvent Score()
                    Case EffectEnum.Out
                        RaiseEvent Out()
                End Select
                nTopDirection = -nTopDirection
            End If

            'check out
            If bBottomOutOfBounds = True Then
                Select Case nOutOfBoundsBottomEffect
                    Case EffectEnum.Out
                        RaiseEvent Out()
                    Case EffectEnum.Score
                        RaiseEvent Score()
                End Select
            End If


            If bTopOutOfBounds = True Then
                Select Case nOutOfBoundsTopEffect
                    Case EffectEnum.Out
                        RaiseEvent Out()
                    Case EffectEnum.Score
                        RaiseEvent Score()
                End Select
            End If

            If bLeftOutofBounds = True Then
                Select Case nOutOfBoundsLeftEffect
                    Case EffectEnum.Out
                        RaiseEvent Out()
                    Case EffectEnum.Score
                        RaiseEvent Score()
                End Select
            End If

            If bRightOutofBounds = True Then
                Select Case nOutOfBoundsRightEffect
                    Case EffectEnum.Out
                        RaiseEvent Out()
                    Case EffectEnum.Score
                        RaiseEvent Score()
                End Select
            End If

            'check overlap of blocks in list and score
            For Each objGamePiece As GamePiece In ListOfBlocksObj
                With objGamePiece
                    If .Visible = True And CheckOverlap(Me, objGamePiece) = True Then
                        nTopDirection = 1
                        Select Case .HitEffect
                            Case EffectEnum.Score
                                RaiseEvent Score()
                            Case EffectEnum.Out
                                RaiseEvent Out()
                        End Select

                        .Visible = False
                        Exit For
                    End If
                End With
            Next
            If bDisappear = True Then
                .Disappear()
                Exit Sub
            End If
        End With
    End Sub

    Private Function CheckOverlap(SourceLabel As Label, TargetLabel As GamePiece) As Boolean
        Dim bOverlap As Boolean = False
        Dim bLeft As Boolean = False
        Dim bTop As Boolean = False
        With SourceLabel
            If IsBetween(.Left, TargetLabel.Left, TargetLabel.Right) = True Then
                bLeft = True
            ElseIf IsBetween(.Right, TargetLabel.Left, TargetLabel.Right) Then
                bLeft = True
            ElseIf IsBetween(TargetLabel.Left, .Left, .Right) = True Then
                bLeft = True
            ElseIf IsBetween(TargetLabel.Right, .Left, .Right) Then
                bLeft = True
            End If

            If IsBetween(.Top, TargetLabel.Top, TargetLabel.Bottom) = True Then
                bTop = True
            ElseIf IsBetween(.Bottom, TargetLabel.Top, TargetLabel.Bottom) Then
                bTop = True
            ElseIf IsBetween(TargetLabel.Top, .Top, .Bottom) = True Then
                bTop = True
            ElseIf IsBetween(TargetLabel.Bottom, .Top, .Bottom) Then
                bTop = True
            End If

        End With

        If bLeft = True And bTop = True Then
            bOverlap = True
        End If

        Return bOverlap
    End Function

    Private Function IsBetween(SourceValue As Integer, MinValue As Integer, MaxValue As Integer) As Boolean
        Dim b As Boolean = False
        If SourceValue >= MinValue And SourceValue <= MaxValue Then
            b = True
        End If
        Return b
    End Function
#Region "Properties"
    Public Property MovementType As MovementTypeEnum
        Get
            Return nMovementType
        End Get
        Set(value As MovementTypeEnum)
            nMovementType = value
        End Set
    End Property

    Public Property OutofBoundsTopEffect As EffectEnum
        Get
            Return nOutOfBoundsTopEffect
        End Get
        Set(value As EffectEnum)
            nOutOfBoundsTopEffect = value
        End Set
    End Property

    Public Property OutofBoundsBottomEffect As EffectEnum
        Get
            Return nOutOfBoundsBottomEffect
        End Get
        Set(value As EffectEnum)
            nOutOfBoundsBottomEffect = value
        End Set
    End Property

    Public Property OutofBoundsRightEffect As EffectEnum
        Get
            Return nOutOfBoundsRightEffect
        End Get
        Set(value As EffectEnum)
            nOutOfBoundsRightEffect = value
        End Set
    End Property

    Public Property OutofBoundsLeftEffect As EffectEnum
        Get
            Return nOutOfBoundsLeftEffect
        End Get
        Set(value As EffectEnum)
            nOutOfBoundsLeftEffect = value
        End Set
    End Property

    Public Property OutofBoundsTopAction As ActionEnum
        Get
            Return nOutOfBoundsTopAction
        End Get
        Set(value As ActionEnum)
            nOutOfBoundsTopAction = value
        End Set
    End Property

    Public Property OutofBoundsBottomAction As ActionEnum
        Get
            Return nOutOfBoundsBottomAction
        End Get
        Set(value As ActionEnum)
            nOutOfBoundsBottomAction = value
        End Set
    End Property

    Public Property OutofBoundsRightAction As ActionEnum
        Get
            Return nOutOfBoundsRightAction
        End Get
        Set(value As ActionEnum)
            nOutOfBoundsRightAction = value
        End Set
    End Property

    Public Property OutofBoundsLeftAction As ActionEnum
        Get
            Return nOutOfBoundsLeftAction
        End Get
        Set(value As ActionEnum)
            nOutOfBoundsLeftAction = value
        End Set
    End Property
#End Region
End Class
