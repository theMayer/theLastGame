Public Class Game
    Public Event Score()
    Public Event Out()
    Public Event GameOver()

    Dim nAllowedOuts As Integer = 0
    Dim nTotalScore As Integer = 0
    Dim nTotalOut As Integer = 0

    Dim objLstGamePiece As List(Of GamePiece) = New List(Of GamePiece)
    Dim objLstMovingPiece As List(Of MovingPiece) = New List(Of MovingPiece)
    Dim objPlayer As Player = Nothing
    Dim objParentControl As Control

    Dim nState As StateEnum = StateEnum.NotStarted
    Dim nPlayingSurfaceMinTop As Integer = 0

    Public Enum StateEnum
        NotStarted
        Playing
        Paused
        Stopped
    End Enum

    Public Event StateChanged()

    Public Sub New(ParentControlObj As Control)
        objParentControl = ParentControlObj

    End Sub

    Public Sub Start()
        Me.SetMovingPiecesTimer(True)
        If nState <> StateEnum.Paused Then
            nTotalScore = 0
            nTotalOut = 0
            RaiseEvent Score()
            RaiseEvent Out()
        End If
        Me.State = StateEnum.Playing
    End Sub

    Public Sub Pause()
        Me.SetMovingPiecesTimer(False)
        Me.State = StateEnum.Paused
    End Sub

    Public Sub StopGame()
        Me.SetMovingPiecesTimer(False)
        Me.State = StateEnum.Stopped
    End Sub

    Public Sub Clear()
        Me.SetMovingPiecesTimer(False)
        For Each objP As GamePiece In objLstGamePiece
            objP.Disappear()
        Next
        objLstGamePiece.Clear()

        If objPlayer Is Nothing = False Then
            objPlayer.Disappear()
        End If


        For Each objP As GamePiece In objLstMovingPiece
            objP.Disappear()
        Next
        objLstMovingPiece.Clear()


        Me.State = StateEnum.NotStarted
    End Sub

    Private Sub SetMovingPiecesTimer(Value As Boolean)
        For Each objM As MovingPiece In objLstMovingPiece
            objM.TimerOn = Value
        Next
    End Sub

    Public Sub AddGamePiece(GamePieceObj As GamePiece)
        objLstGamePiece.Add(GamePieceObj)
        Me.DoAddGamePieceToParent(GamePieceObj)

    End Sub

    Public Sub AddMovingPiece(MovingPieceObj As MovingPiece)
        If objPlayer Is Nothing = True Then
            Throw New Exception("Before you add a Moving Piece you must add a Player")
        End If

        objLstMovingPiece.Add(MovingPieceObj)

        AddHandler MovingPieceObj.Score, AddressOf Me.DoScore
        AddHandler MovingPieceObj.Out, AddressOf Me.DoOut

        Me.DoAddGamePieceToParent(MovingPieceObj)
        MovingPieceObj.ListOfGamePieces = objLstGamePiece


        MovingPieceObj.Player = objPlayer


        If Me.State = StateEnum.Playing Then
            MovingPieceObj.TimerOn = True
        End If

    End Sub

    Public Sub AddPlayer(PlayerObj As Player)
        objPlayer = PlayerObj

        Me.DoAddGamePieceToParent(PlayerObj)

    End Sub

    Private Sub DoAddGamePieceToParent(GamePieceObj As GamePiece)
        If objParentControl Is Nothing = False Then
            objParentControl.Controls.Add(GamePieceObj)
        End If
    End Sub

    Private Sub DoScore()
        nTotalScore = nTotalScore + 1
        RaiseEvent Score()
    End Sub

    Private Sub DoOut()
        nTotalOut = nTotalOut + 1
        RaiseEvent Out()

        If nAllowedOuts > 0 And nTotalOut >= nAllowedOuts Then
            Me.StopGame()
            RaiseEvent GameOver()
        End If


    End Sub

    Public Property AllowedOuts As Integer
        Get
            Return nAllowedOuts
        End Get
        Set(value As Integer)
            nAllowedOuts = value
        End Set
    End Property

    Public ReadOnly Property TotalScore As Integer
        Get
            Return nTotalScore
        End Get

    End Property

    Public ReadOnly Property TotalOuts As Integer
        Get
            Return nTotalOut
        End Get
    End Property
    Public ReadOnly Property ParentControlWidth As Integer
        Get
            Dim nWidth As Integer = 0
            If objParentControl Is Nothing = False Then
                nWidth = objParentControl.Width
            End If
            Return nWidth
        End Get
    End Property

    Public Property State As StateEnum
        Get
            Return nState
        End Get
        Private Set(value As StateEnum)
            nState = value
            RaiseEvent StateChanged()
        End Set
    End Property

    Public Property PlayingSurfaceMinTop As Integer
        Get
            Return nPlayingSurfaceMinTop
        End Get
        Set(value As Integer)
            nPlayingSurfaceMinTop = value
        End Set
    End Property

    Public ReadOnly Property BottomOfGamePieces As Integer
        Get
            Dim nValue As Integer = 0

            If objLstGamePiece.Count > 0 Then
                With objLstGamePiece
                    nValue = .Item(.Count - 1).Bottom
                End With
            End If

            Return nValue
        End Get
    End Property


End Class
