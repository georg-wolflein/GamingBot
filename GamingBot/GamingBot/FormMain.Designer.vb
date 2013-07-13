<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ButtonLoad = New System.Windows.Forms.Button
        Me.GroupBoxData = New System.Windows.Forms.GroupBox
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ButtonRawData = New System.Windows.Forms.Button
        Me.OpenFileDialogMain = New System.Windows.Forms.OpenFileDialog
        Me.GroupBoxRawData = New System.Windows.Forms.GroupBox
        Me.RichTextBoxRawData = New System.Windows.Forms.RichTextBox
        Me.LabelProgress = New System.Windows.Forms.Label
        Me.GroupBoxLogging = New System.Windows.Forms.GroupBox
        Me.TextBoxLog = New System.Windows.Forms.TextBox
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBoxScreen = New System.Windows.Forms.GroupBox
        Me.NumericUpDownScreenWidth = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownScreenHeight = New System.Windows.Forms.NumericUpDown
        Me.LabelScreenWidth = New System.Windows.Forms.Label
        Me.LabelScreenHeight = New System.Windows.Forms.Label
        Me.GroupBoxSampleData = New System.Windows.Forms.GroupBox
        Me.ButtonGenerateSampleData = New System.Windows.Forms.Button
        Me.GroupBoxData.SuspendLayout()
        Me.GroupBoxRawData.SuspendLayout()
        Me.GroupBoxLogging.SuspendLayout()
        Me.GroupBoxScreen.SuspendLayout()
        CType(Me.NumericUpDownScreenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownScreenHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSampleData.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Location = New System.Drawing.Point(6, 19)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(88, 23)
        Me.ButtonLoad.TabIndex = 0
        Me.ButtonLoad.Text = "Load Data"
        Me.ButtonLoad.UseVisualStyleBackColor = True
        '
        'GroupBoxData
        '
        Me.GroupBoxData.Controls.Add(Me.ButtonStart)
        Me.GroupBoxData.Controls.Add(Me.ButtonRawData)
        Me.GroupBoxData.Controls.Add(Me.ButtonLoad)
        Me.GroupBoxData.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxData.Name = "GroupBoxData"
        Me.GroupBoxData.Size = New System.Drawing.Size(309, 52)
        Me.GroupBoxData.TabIndex = 1
        Me.GroupBoxData.TabStop = False
        Me.GroupBoxData.Text = "Data"
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(100, 19)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(109, 23)
        Me.ButtonStart.TabIndex = 2
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonRawData
        '
        Me.ButtonRawData.Location = New System.Drawing.Point(215, 19)
        Me.ButtonRawData.Name = "ButtonRawData"
        Me.ButtonRawData.Size = New System.Drawing.Size(88, 23)
        Me.ButtonRawData.TabIndex = 1
        Me.ButtonRawData.Text = "Raw Data >>"
        Me.ButtonRawData.UseVisualStyleBackColor = True
        '
        'OpenFileDialogMain
        '
        Me.OpenFileDialogMain.Filter = "Farming Bot files|*.fbot|All files|*.*"
        '
        'GroupBoxRawData
        '
        Me.GroupBoxRawData.Controls.Add(Me.RichTextBoxRawData)
        Me.GroupBoxRawData.Location = New System.Drawing.Point(327, 12)
        Me.GroupBoxRawData.Name = "GroupBoxRawData"
        Me.GroupBoxRawData.Size = New System.Drawing.Size(425, 315)
        Me.GroupBoxRawData.TabIndex = 2
        Me.GroupBoxRawData.TabStop = False
        Me.GroupBoxRawData.Text = "Raw Data"
        '
        'RichTextBoxRawData
        '
        Me.RichTextBoxRawData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxRawData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxRawData.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxRawData.Location = New System.Drawing.Point(3, 16)
        Me.RichTextBoxRawData.Name = "RichTextBoxRawData"
        Me.RichTextBoxRawData.ReadOnly = True
        Me.RichTextBoxRawData.Size = New System.Drawing.Size(419, 296)
        Me.RichTextBoxRawData.TabIndex = 3
        Me.RichTextBoxRawData.Text = ""
        Me.RichTextBoxRawData.WordWrap = False
        '
        'LabelProgress
        '
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Location = New System.Drawing.Point(6, 16)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(117, 13)
        Me.LabelProgress.TabIndex = 3
        Me.LabelProgress.Text = "Please load a data file. "
        '
        'GroupBoxLogging
        '
        Me.GroupBoxLogging.Controls.Add(Me.TextBoxLog)
        Me.GroupBoxLogging.Controls.Add(Me.LabelProgress)
        Me.GroupBoxLogging.Location = New System.Drawing.Point(12, 70)
        Me.GroupBoxLogging.Name = "GroupBoxLogging"
        Me.GroupBoxLogging.Size = New System.Drawing.Size(309, 179)
        Me.GroupBoxLogging.TabIndex = 4
        Me.GroupBoxLogging.TabStop = False
        Me.GroupBoxLogging.Text = "Logging"
        '
        'TextBoxLog
        '
        Me.TextBoxLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLog.Location = New System.Drawing.Point(9, 32)
        Me.TextBoxLog.Multiline = True
        Me.TextBoxLog.Name = "TextBoxLog"
        Me.TextBoxLog.ReadOnly = True
        Me.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxLog.Size = New System.Drawing.Size(294, 141)
        Me.TextBoxLog.TabIndex = 4
        Me.TextBoxLog.WordWrap = False
        '
        'TimerMain
        '
        '
        'GroupBoxScreen
        '
        Me.GroupBoxScreen.Controls.Add(Me.LabelScreenHeight)
        Me.GroupBoxScreen.Controls.Add(Me.LabelScreenWidth)
        Me.GroupBoxScreen.Controls.Add(Me.NumericUpDownScreenHeight)
        Me.GroupBoxScreen.Controls.Add(Me.NumericUpDownScreenWidth)
        Me.GroupBoxScreen.Location = New System.Drawing.Point(12, 255)
        Me.GroupBoxScreen.Name = "GroupBoxScreen"
        Me.GroupBoxScreen.Size = New System.Drawing.Size(173, 72)
        Me.GroupBoxScreen.TabIndex = 5
        Me.GroupBoxScreen.TabStop = False
        Me.GroupBoxScreen.Text = "Screen Dimensions"
        '
        'NumericUpDownScreenWidth
        '
        Me.NumericUpDownScreenWidth.Location = New System.Drawing.Point(93, 19)
        Me.NumericUpDownScreenWidth.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownScreenWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownScreenWidth.Name = "NumericUpDownScreenWidth"
        Me.NumericUpDownScreenWidth.Size = New System.Drawing.Size(73, 20)
        Me.NumericUpDownScreenWidth.TabIndex = 0
        Me.NumericUpDownScreenWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDownScreenHeight
        '
        Me.NumericUpDownScreenHeight.Location = New System.Drawing.Point(93, 45)
        Me.NumericUpDownScreenHeight.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownScreenHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownScreenHeight.Name = "NumericUpDownScreenHeight"
        Me.NumericUpDownScreenHeight.Size = New System.Drawing.Size(73, 20)
        Me.NumericUpDownScreenHeight.TabIndex = 1
        Me.NumericUpDownScreenHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LabelScreenWidth
        '
        Me.LabelScreenWidth.AutoSize = True
        Me.LabelScreenWidth.Location = New System.Drawing.Point(6, 21)
        Me.LabelScreenWidth.Name = "LabelScreenWidth"
        Me.LabelScreenWidth.Size = New System.Drawing.Size(78, 13)
        Me.LabelScreenWidth.TabIndex = 2
        Me.LabelScreenWidth.Text = "Screen Width: "
        '
        'LabelScreenHeight
        '
        Me.LabelScreenHeight.AutoSize = True
        Me.LabelScreenHeight.Location = New System.Drawing.Point(6, 47)
        Me.LabelScreenHeight.Name = "LabelScreenHeight"
        Me.LabelScreenHeight.Size = New System.Drawing.Size(81, 13)
        Me.LabelScreenHeight.TabIndex = 3
        Me.LabelScreenHeight.Text = "Screen Height: "
        '
        'GroupBoxSampleData
        '
        Me.GroupBoxSampleData.Controls.Add(Me.ButtonGenerateSampleData)
        Me.GroupBoxSampleData.Location = New System.Drawing.Point(192, 256)
        Me.GroupBoxSampleData.Name = "GroupBoxSampleData"
        Me.GroupBoxSampleData.Size = New System.Drawing.Size(129, 71)
        Me.GroupBoxSampleData.TabIndex = 6
        Me.GroupBoxSampleData.TabStop = False
        Me.GroupBoxSampleData.Text = "Sample Data"
        '
        'ButtonGenerateSampleData
        '
        Me.ButtonGenerateSampleData.Location = New System.Drawing.Point(6, 19)
        Me.ButtonGenerateSampleData.Name = "ButtonGenerateSampleData"
        Me.ButtonGenerateSampleData.Size = New System.Drawing.Size(117, 46)
        Me.ButtonGenerateSampleData.TabIndex = 0
        Me.ButtonGenerateSampleData.Text = "Generate Sample Data"
        Me.ButtonGenerateSampleData.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 339)
        Me.Controls.Add(Me.GroupBoxSampleData)
        Me.Controls.Add(Me.GroupBoxScreen)
        Me.Controls.Add(Me.GroupBoxLogging)
        Me.Controls.Add(Me.GroupBoxRawData)
        Me.Controls.Add(Me.GroupBoxData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.Text = "FormMain"
        Me.TopMost = True
        Me.GroupBoxData.ResumeLayout(False)
        Me.GroupBoxRawData.ResumeLayout(False)
        Me.GroupBoxLogging.ResumeLayout(False)
        Me.GroupBoxLogging.PerformLayout()
        Me.GroupBoxScreen.ResumeLayout(False)
        Me.GroupBoxScreen.PerformLayout()
        CType(Me.NumericUpDownScreenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownScreenHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSampleData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBoxData As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialogMain As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonRawData As System.Windows.Forms.Button
    Friend WithEvents GroupBoxRawData As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBoxRawData As System.Windows.Forms.RichTextBox
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents GroupBoxLogging As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxLog As System.Windows.Forms.TextBox
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents GroupBoxScreen As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDownScreenHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownScreenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelScreenHeight As System.Windows.Forms.Label
    Friend WithEvents LabelScreenWidth As System.Windows.Forms.Label
    Friend WithEvents GroupBoxSampleData As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonGenerateSampleData As System.Windows.Forms.Button

End Class
