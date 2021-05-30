Module mdUtility
    Public Enum DirectionEnum
        Right
        Left
        Up
        Down
    End Enum
    Public Function GetRandomColor() As Color
        Dim cValue As Color
        Static objRandom As Random = New Random

        Dim nRed As Integer = objRandom.Next(0, 256), nGreen As Integer = objRandom.Next(0, 256), nBlue As Integer = objRandom.Next(0, 256)


        cValue = Color.FromArgb(nRed, nGreen, nBlue)
        Return cValue
    End Function

    Public Function FillBoard(GameObj As Game, TopValue As Integer, NumRows As Integer) As List(Of GamePiece)
        Dim objLst As List(Of GamePiece) = New List(Of GamePiece)
        Dim objRandom As Random = New Random
        Dim nPreviousRight As Integer = 0
        Dim nPreviousTop As Integer = TopValue
        Dim nHeight As Integer = 25
        Dim nParentWidth As Integer = GameObj.ParentControlWidth
        For i As Integer = 1 To NumRows
            Do
                Dim objGamePiece As GamePiece = New GamePiece
                With objGamePiece
                    .HitEffect = GamePiece.EffectEnum.Score
                    .Width = objRandom.Next(15, nParentWidth / 10)
                    .Height = nHeight
                    '.SetBackColorToRandom()
                    .Top = nPreviousTop
                    .Left = nPreviousRight
                    nPreviousRight = .Right
                    nPreviousTop = .Top
                End With
                GameObj.AddGamePiece(objGamePiece)
                objLst.Add(objGamePiece)
                Application.DoEvents()
            Loop Until nPreviousRight >= nParentWidth
            nPreviousTop = nPreviousTop + nHeight
            nPreviousRight = 0
        Next
        Return objLst
    End Function


    Public Sub MovePlayer(PlayerObj As Player, DirectionValue As DirectionEnum)
        Dim objParent As Control = PlayerObj.Parent
        If objParent Is Nothing = True Then Exit Sub

        Dim nHorizontalDirection As Integer = 0
        Dim nVerticalDirection As Integer = 0
        Select Case DirectionValue
            Case DirectionEnum.Left
                nHorizontalDirection = -1
            Case DirectionEnum.Right
                nHorizontalDirection = 1
            Case DirectionEnum.Up
                nVerticalDirection = -1
            Case DirectionEnum.Down
                nVerticalDirection = 1
        End Select


        With PlayerObj
            Select Case DirectionValue
                Case DirectionEnum.Left, DirectionEnum.Right
                    Dim nNewPosition As Integer = .Left + (.Width * nHorizontalDirection)
                    If nNewPosition < 0 Then
                        nNewPosition = 0
                    ElseIf nNewPosition + PlayerObj.Width > objParent.Width Then
                        nNewPosition = objParent.Width - PlayerObj.Width
                    End If
                    .Left = nNewPosition
                Case DirectionEnum.Up, DirectionEnum.Down
                    Dim nNewPosition As Integer = .Top + (.Height * nVerticalDirection)
                    If nNewPosition < 0 Then
                        nNewPosition = 0
                    ElseIf nNewPosition + .Height > objParent.Height Then
                        nNewPosition = objParent.Height - .Height
                    End If
                    .Top = nNewPosition
            End Select


        End With
    End Sub
End Module
