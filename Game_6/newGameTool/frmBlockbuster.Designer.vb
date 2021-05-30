<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBlockbuster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBlockbuster))
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.lstGame = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblScoreCaption = New System.Windows.Forms.ToolStripLabel()
        Me.lblScore = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblOutsCaption = New System.Windows.Forms.ToolStripLabel()
        Me.lblOuts = New System.Windows.Forms.ToolStripLabel()
        Me.lblGameOver = New System.Windows.Forms.Label()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lstGame, Me.ToolStripSeparator5, Me.btnStart, Me.ToolStripSeparator1, Me.btnPause, Me.ToolStripSeparator3, Me.btnStop, Me.ToolStripSeparator4, Me.lblScoreCaption, Me.lblScore, Me.ToolStripSeparator2, Me.lblOutsCaption, Me.lblOuts})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMain.Size = New System.Drawing.Size(800, 33)
        Me.tsMain.TabIndex = 2
        Me.tsMain.Text = "ToolStrip1"
        '
        'lstGame
        '
        Me.lstGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstGame.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lstGame.Items.AddRange(New Object() {"Block Buster", "Bomber", "Bugger"})
        Me.lstGame.Name = "lstGame"
        Me.lstGame.Size = New System.Drawing.Size(121, 33)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 33)
        '
        'btnStart
        '
        Me.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(54, 30)
        Me.btnStart.Text = "Start"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'btnPause
        '
        Me.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPause.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
        Me.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(65, 30)
        Me.btnPause.Text = "Pause"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnStop.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(53, 30)
        Me.btnStop.Text = "Stop"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 33)
        '
        'lblScoreCaption
        '
        Me.lblScoreCaption.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblScoreCaption.Name = "lblScoreCaption"
        Me.lblScoreCaption.Size = New System.Drawing.Size(59, 30)
        Me.lblScoreCaption.Text = "Score"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = False
        Me.lblScore.BackColor = System.Drawing.Color.PapayaWhip
        Me.lblScore.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblScore.ForeColor = System.Drawing.Color.Lime
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(100, 22)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'lblOutsCaption
        '
        Me.lblOutsCaption.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblOutsCaption.Name = "lblOutsCaption"
        Me.lblOutsCaption.Size = New System.Drawing.Size(51, 30)
        Me.lblOutsCaption.Text = "Outs"
        '
        'lblOuts
        '
        Me.lblOuts.AutoSize = False
        Me.lblOuts.BackColor = System.Drawing.Color.PapayaWhip
        Me.lblOuts.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblOuts.ForeColor = System.Drawing.Color.Red
        Me.lblOuts.Name = "lblOuts"
        Me.lblOuts.Size = New System.Drawing.Size(100, 22)
        '
        'lblGameOver
        '
        Me.lblGameOver.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGameOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGameOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameOver.ForeColor = System.Drawing.Color.Red
        Me.lblGameOver.Location = New System.Drawing.Point(5, 345)
        Me.lblGameOver.Name = "lblGameOver"
        Me.lblGameOver.Size = New System.Drawing.Size(802, 37)
        Me.lblGameOver.TabIndex = 3
        Me.lblGameOver.Text = "GAME OVER"
        Me.lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblGameOver.Visible = False
        '
        'frmBlockbuster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.lblGameOver)
        Me.Name = "frmBlockbuster"
        Me.Text = "frmBlockbuster"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents lstGame As ToolStripComboBox
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnStart As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnPause As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnStop As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents lblScoreCaption As ToolStripLabel
    Friend WithEvents lblScore As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents lblOutsCaption As ToolStripLabel
    Friend WithEvents lblOuts As ToolStripLabel
    Friend WithEvents lblGameOver As Label
End Class
