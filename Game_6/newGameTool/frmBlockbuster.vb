Public Class frmBlockbuster
    Dim WithEvents objGame As Game
    Dim WithEvents objTimerAddGamePieces As Timer = New Timer

    Private Enum GameEnum
        None
        Blockbuster
        Bomber
        Bugger
    End Enum

    Private Sub frmBlockbuster_Load(sender As Object, e As EventArgs) Handles Me.Load
        objGame = New Game(Me)
        Me.SetButtonsEnabled()
        If lstGame.Items.Count > 0 Then
            lstGame.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me.ChangeGameState(Game.StateEnum.Playing)
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        Me.ChangeGameState(Game.StateEnum.Paused)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Me.ChangeGameState(Game.StateEnum.Stopped)
    End Sub

    Private Sub ChangeGameState(Value As Game.StateEnum)
        Dim nCurrentState As Game.StateEnum = objGame.State
        Select Case Value
            Case Game.StateEnum.Playing
                Select Case nCurrentState
                    Case Game.StateEnum.NotStarted, Game.StateEnum.Stopped
                        Me.SetupBoard()
                    Case Game.StateEnum.Paused
                        objGame.Start()
                End Select
            Case Game.StateEnum.Paused
                If nCurrentState = Game.StateEnum.Playing Then
                    objGame.Pause()
                End If
            Case Game.StateEnum.Stopped
                Select Case nCurrentState
                    Case Game.StateEnum.Paused, Game.StateEnum.Playing
                        objGame.StopGame()
                End Select
        End Select
    End Sub

    Private Sub SetupBoard()
        lblGameOver.Visible = False
        objGame.Clear()
        objGame.PlayingSurfaceMinTop = tsMain.Bottom + 1
        Select Case Me.GetGameType()
            Case GameEnum.Blockbuster
                objGame.AllowedOuts = 100
                Dim objPlayer As Player = New Player
                With objPlayer
                    .BackColor = Color.Blue
                    .Top = Me.Height - .Height - 100
                    .Anchor = AnchorStyles.Bottom
                    .HorizontalMovement = True
                    .VerticalMovement = True
                End With
                objGame.AddPlayer(objPlayer)

                mdUtility.FillBoard(objGame, objGame.PlayingSurfaceMinTop, 5)
                Dim nBallStartTop As Integer = objGame.BottomOfGamePieces

                For i As Integer = 1 To 5
                    Dim objBall As MovingPiece = New MovingPiece()
                    With objBall
                        Me.AddGamePiece(i, nBallStartTop)
                    End With
                Next

                objTimerAddGamePieces.Interval = 5000
            Case GameEnum.Bomber, GameEnum.Bugger
                objGame.AllowedOuts = 5
                Dim objPlayer As Player = New Player
                With objPlayer
                    .BackColor = Color.Blue
                    .Top = Me.Height - .Height - 100
                    .Anchor = AnchorStyles.Bottom
                    .HorizontalMovement = True
                    .VerticalMovement = True
                    .HitEffect = GamePiece.EffectEnum.Out

                End With
                objGame.AddPlayer(objPlayer)
                objTimerAddGamePieces.Interval = 500
                objTimerAddGamePieces.Enabled = True

        End Select

        objGame.Start()
    End Sub

    Private Sub AddGamePiece(StartNum As Integer, BallStartTop As Integer)
        Select Case Me.GetGameType()
            Case GameEnum.Blockbuster
                Dim objBall As MovingPiece = New MovingPiece()
                With objBall
                    .MovementType = MovingPiece.MovementTypeEnum.Diagonal
                    .OutofBoundsBottomEffect = GamePiece.EffectEnum.Out
                    .OutofBoundsTopEffect = GamePiece.EffectEnum.Score
                    .OutofBoundsBottomAction = GamePiece.ActionEnum.None
                    .Left = .Width * StartNum
                    .Top = BallStartTop * StartNum
                    objGame.AddMovingPiece(objBall)
                End With
            Case GameEnum.Bomber
                Dim objBomb As MovingPiece = New MovingPiece
                Static objRandom As Random = New Random()
                Dim nLeft As Integer = objRandom.Next(0, Me.Width)
                With objBomb
                    .MovementType = MovingPiece.MovementTypeEnum.Vertical
                    .OutofBoundsBottomAction = GamePiece.ActionEnum.Disappear
                    .OutofBoundsBottomEffect = GamePiece.EffectEnum.Score
                    .Left = nLeft
                    objGame.AddMovingPiece(objBomb)
                End With
            Case GameEnum.Bugger
                Dim objBug As MovingPiece = New MovingPiece
                With objBug
                    .MovementType = MovingPiece.MovementTypeEnum.Random
                    .OutofBoundsRightAction = GamePiece.ActionEnum.Disappear
                    .OutofBoundsLeftAction = GamePiece.ActionEnum.Disappear
                    .OutofBoundsRightEffect = GamePiece.EffectEnum.Score
                    .OutofBoundsLeftEffect = GamePiece.EffectEnum.Score
                    .Top = (Me.Height - objGame.PlayingSurfaceMinTop) / 2
                    .Left = Me.Width \ 2
                    objGame.AddMovingPiece(objBug)
                End With
        End Select

    End Sub

    Private Sub SetButtonsEnabled()
        Dim bStart As Boolean = False, bPause As Boolean = False, bStop As Boolean = False
        Select Case objGame.State
            Case Game.StateEnum.NotStarted, Game.StateEnum.Stopped
                bStart = True
            Case Game.StateEnum.Paused
                bStart = True
                bStop = True
            Case Game.StateEnum.Playing
                bPause = True
                bStop = True
        End Select

        btnStart.Enabled = bStart
        btnPause.Enabled = bPause
        btnStop.Enabled = bStop
    End Sub


    Private Sub objGame_StateChanged() Handles objGame.StateChanged
        Me.SetButtonsEnabled()
        Dim bGameList As Boolean = False
        Dim bTimerAddPieces As Boolean = False

        Select Case objGame.State
            Case Game.StateEnum.Playing
                bTimerAddPieces = True
            Case Game.StateEnum.Stopped
                bGameList = True
            Case Game.StateEnum.NotStarted
                bGameList = True

        End Select

        lstGame.Enabled = bGameList
        objTimerAddGamePieces.Enabled = bTimerAddPieces
    End Sub

    Private Sub objGame_Out() Handles objGame.Out
        lblOuts.Text = objGame.TotalOuts
    End Sub

    Private Sub objGame_Score() Handles objGame.Score
        lblScore.Text = objGame.TotalScore
    End Sub

    Private Sub objGame_GameOver() Handles objGame.GameOver
        lblGameOver.Visible = True
    End Sub

    Private Sub objTimerAddGamePieces_Tick(sender As Object, e As EventArgs) Handles objTimerAddGamePieces.Tick
        Me.AddGamePiece(1, objGame.BottomOfGamePieces)
    End Sub

    Private Function GetGameType() As GameEnum
        Dim nGame As GameEnum = GameEnum.None
        Select Case lstGame.Text.ToLower
            Case "block buster"
                nGame = GameEnum.Blockbuster
            Case "bomber"
                nGame = GameEnum.Bomber
            Case "bugger"
                nGame = GameEnum.Bugger
        End Select
        Return nGame
    End Function
End Class