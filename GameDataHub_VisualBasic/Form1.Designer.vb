<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TabControlOption = New TabControl()
        TabPage1 = New TabPage()
        BtnDelet = New Button()
        BtnSearchName = New Button()
        TextBoxName = New TextBox()
        ComBoxFormat = New ComboBox()
        BtnSaveData = New Button()
        BtnFillTreeView = New Button()
        TreeViewSql = New TreeView()
        PictureBoxGameIcon = New PictureBox()
        DataGrideShowData = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TabPage2 = New TabPage()
        label11 = New Label()
        label10 = New Label()
        FomPlotPlatform = New ScottPlot.WinForms.FormsPlot()
        FromPlotGenre = New ScottPlot.WinForms.FormsPlot()
        TxtFilter = New TextBox()
        Label5 = New Label()
        ComBoxFiltrer = New ComboBox()
        label7 = New Label()
        TextBoxUser = New TextBox()
        BtnSeend = New Button()
        label6 = New Label()
        ComBoxFormat_Ver = New ComboBox()
        BtnSave = New Button()
        BtnLoad = New Button()
        DataGrideViewShowData = New DataGridView()
        dataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        dataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        dataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        dataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
        dataGridViewTextBoxColumn5 = New DataGridViewTextBoxColumn()
        dataGridViewTextBoxColumn6 = New DataGridViewTextBoxColumn()
        TabPage3 = New TabPage()
        BtnSend = New Button()
        BtnReceive = New Button()
        BtnUpload = New Button()
        DataGrideShowSql = New DataGridView()
        TabControlOption.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(PictureBoxGameIcon, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGrideShowData, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        CType(DataGrideViewShowData, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        CType(DataGrideShowSql, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabControlOption
        ' 
        TabControlOption.Controls.Add(TabPage1)
        TabControlOption.Controls.Add(TabPage2)
        TabControlOption.Controls.Add(TabPage3)
        TabControlOption.Dock = DockStyle.Fill
        TabControlOption.Location = New Point(0, 0)
        TabControlOption.Name = "TabControlOption"
        TabControlOption.SelectedIndex = 0
        TabControlOption.Size = New Size(1490, 673)
        TabControlOption.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(BtnDelet)
        TabPage1.Controls.Add(BtnSearchName)
        TabPage1.Controls.Add(TextBoxName)
        TabPage1.Controls.Add(ComBoxFormat)
        TabPage1.Controls.Add(BtnSaveData)
        TabPage1.Controls.Add(BtnFillTreeView)
        TabPage1.Controls.Add(TreeViewSql)
        TabPage1.Controls.Add(PictureBoxGameIcon)
        TabPage1.Controls.Add(DataGrideShowData)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(Label2)
        TabPage1.Controls.Add(Label1)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1482, 645)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Archivo"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' BtnDelet
        ' 
        BtnDelet.Location = New Point(295, 47)
        BtnDelet.Margin = New Padding(3, 2, 3, 2)
        BtnDelet.Name = "BtnDelet"
        BtnDelet.Size = New Size(82, 22)
        BtnDelet.TabIndex = 28
        BtnDelet.Text = "Borrar"
        BtnDelet.UseVisualStyleBackColor = True
        ' 
        ' BtnSearchName
        ' 
        BtnSearchName.Location = New Point(295, 10)
        BtnSearchName.Margin = New Padding(3, 2, 3, 2)
        BtnSearchName.Name = "BtnSearchName"
        BtnSearchName.Size = New Size(82, 22)
        BtnSearchName.TabIndex = 27
        BtnSearchName.Text = "Buscar"
        BtnSearchName.UseVisualStyleBackColor = True
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(95, 11)
        TextBoxName.Margin = New Padding(3, 2, 3, 2)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(133, 23)
        TextBoxName.TabIndex = 26
        ' 
        ' ComBoxFormat
        ' 
        ComBoxFormat.FormattingEnabled = True
        ComBoxFormat.Items.AddRange(New Object() {"CSV", "TXT", "XML", "JSON", "PDF"})
        ComBoxFormat.Location = New Point(95, 102)
        ComBoxFormat.Name = "ComBoxFormat"
        ComBoxFormat.Size = New Size(133, 23)
        ComBoxFormat.TabIndex = 25
        ' 
        ' BtnSaveData
        ' 
        BtnSaveData.Location = New Point(283, 96)
        BtnSaveData.Margin = New Padding(3, 2, 3, 2)
        BtnSaveData.Name = "BtnSaveData"
        BtnSaveData.Size = New Size(94, 31)
        BtnSaveData.TabIndex = 24
        BtnSaveData.Text = "guardar"
        BtnSaveData.UseVisualStyleBackColor = True
        ' 
        ' BtnFillTreeView
        ' 
        BtnFillTreeView.Location = New Point(8, 236)
        BtnFillTreeView.Margin = New Padding(3, 2, 3, 2)
        BtnFillTreeView.Name = "BtnFillTreeView"
        BtnFillTreeView.Size = New Size(115, 35)
        BtnFillTreeView.TabIndex = 23
        BtnFillTreeView.Text = "Graficar Arbol"
        BtnFillTreeView.UseVisualStyleBackColor = True
        ' 
        ' TreeViewSql
        ' 
        TreeViewSql.Location = New Point(8, 293)
        TreeViewSql.Name = "TreeViewSql"
        TreeViewSql.Size = New Size(304, 267)
        TreeViewSql.TabIndex = 22
        ' 
        ' PictureBoxGameIcon
        ' 
        PictureBoxGameIcon.Location = New Point(328, 283)
        PictureBoxGameIcon.Margin = New Padding(3, 2, 3, 2)
        PictureBoxGameIcon.Name = "PictureBoxGameIcon"
        PictureBoxGameIcon.Size = New Size(330, 289)
        PictureBoxGameIcon.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBoxGameIcon.TabIndex = 9
        PictureBoxGameIcon.TabStop = False
        ' 
        ' DataGrideShowData
        ' 
        DataGrideShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGrideShowData.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6})
        DataGrideShowData.Dock = DockStyle.Right
        DataGrideShowData.Location = New Point(697, 3)
        DataGrideShowData.Margin = New Padding(3, 2, 3, 2)
        DataGrideShowData.MultiSelect = False
        DataGrideShowData.Name = "DataGrideShowData"
        DataGrideShowData.ReadOnly = True
        DataGrideShowData.RowHeadersWidth = 51
        DataGrideShowData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGrideShowData.Size = New Size(782, 639)
        DataGrideShowData.TabIndex = 5
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "ID"
        Column1.MinimumWidth = 6
        Column1.Name = "Column1"
        Column1.ReadOnly = True
        Column1.Width = 125
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Nombre"
        Column2.MinimumWidth = 6
        Column2.Name = "Column2"
        Column2.ReadOnly = True
        Column2.Width = 125
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Genero"
        Column3.MinimumWidth = 6
        Column3.Name = "Column3"
        Column3.ReadOnly = True
        Column3.Width = 125
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Desarrolladora"
        Column4.MinimumWidth = 6
        Column4.Name = "Column4"
        Column4.ReadOnly = True
        Column4.Width = 125
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "Plataforma"
        Column5.MinimumWidth = 6
        Column5.Name = "Column5"
        Column5.ReadOnly = True
        Column5.Width = 125
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "URL Imagen"
        Column6.MinimumWidth = 6
        Column6.Name = "Column6"
        Column6.ReadOnly = True
        Column6.Width = 125
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(480, 236)
        Label4.Name = "Label4"
        Label4.Size = New Size(38, 15)
        Label4.TabIndex = 3
        Label4.Text = "Juego"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(123, 78)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 15)
        Label3.TabIndex = 2
        Label3.Text = "Guardar Datos"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(8, 110)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 15)
        Label2.TabIndex = 1
        Label2.Text = "formateo"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(8, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 0
        Label1.Text = "Nombre"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(label11)
        TabPage2.Controls.Add(label10)
        TabPage2.Controls.Add(FomPlotPlatform)
        TabPage2.Controls.Add(FromPlotGenre)
        TabPage2.Controls.Add(TxtFilter)
        TabPage2.Controls.Add(Label5)
        TabPage2.Controls.Add(ComBoxFiltrer)
        TabPage2.Controls.Add(label7)
        TabPage2.Controls.Add(TextBoxUser)
        TabPage2.Controls.Add(BtnSeend)
        TabPage2.Controls.Add(label6)
        TabPage2.Controls.Add(ComBoxFormat_Ver)
        TabPage2.Controls.Add(BtnSave)
        TabPage2.Controls.Add(BtnLoad)
        TabPage2.Controls.Add(DataGrideViewShowData)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1482, 645)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Ver"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' label11
        ' 
        label11.AutoSize = True
        label11.Location = New Point(8, 162)
        label11.Name = "label11"
        label11.Size = New Size(45, 15)
        label11.TabIndex = 44
        label11.Text = "Genero"
        ' 
        ' label10
        ' 
        label10.AutoSize = True
        label10.Location = New Point(6, 376)
        label10.Name = "label10"
        label10.Size = New Size(65, 15)
        label10.TabIndex = 43
        label10.Text = "Plataforma"
        ' 
        ' FomPlotPlatform
        ' 
        FomPlotPlatform.DisplayScale = 1F
        FomPlotPlatform.Dock = DockStyle.Bottom
        FomPlotPlatform.Location = New Point(3, 400)
        FomPlotPlatform.Name = "FomPlotPlatform"
        FomPlotPlatform.Size = New Size(694, 242)
        FomPlotPlatform.TabIndex = 42
        ' 
        ' FromPlotGenre
        ' 
        FromPlotGenre.DisplayScale = 1F
        FromPlotGenre.Location = New Point(8, 180)
        FromPlotGenre.Name = "FromPlotGenre"
        FromPlotGenre.Size = New Size(679, 193)
        FromPlotGenre.TabIndex = 41
        ' 
        ' TxtFilter
        ' 
        TxtFilter.Location = New Point(63, 109)
        TxtFilter.Margin = New Padding(3, 2, 3, 2)
        TxtFilter.Name = "TxtFilter"
        TxtFilter.Size = New Size(200, 23)
        TxtFilter.TabIndex = 40
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(10, 109)
        Label5.Name = "Label5"
        Label5.Size = New Size(47, 15)
        Label5.TabIndex = 39
        Label5.Text = "Filtrado"
        ' 
        ' ComBoxFiltrer
        ' 
        ComBoxFiltrer.FormattingEnabled = True
        ComBoxFiltrer.Items.AddRange(New Object() {"ID", "Nombre", "Genero", "Desarrolladora", "Plataforma"})
        ComBoxFiltrer.Location = New Point(282, 109)
        ComBoxFiltrer.Name = "ComBoxFiltrer"
        ComBoxFiltrer.Size = New Size(133, 23)
        ComBoxFiltrer.TabIndex = 38
        ' 
        ' label7
        ' 
        label7.AutoSize = True
        label7.Location = New Point(10, 79)
        label7.Name = "label7"
        label7.Size = New Size(43, 15)
        label7.TabIndex = 37
        label7.Text = "Correo"
        ' 
        ' TextBoxUser
        ' 
        TextBoxUser.Location = New Point(59, 76)
        TextBoxUser.Name = "TextBoxUser"
        TextBoxUser.Size = New Size(180, 23)
        TextBoxUser.TabIndex = 36
        ' 
        ' BtnSeend
        ' 
        BtnSeend.Location = New Point(245, 72)
        BtnSeend.Name = "BtnSeend"
        BtnSeend.Size = New Size(120, 28)
        BtnSeend.TabIndex = 35
        BtnSeend.Text = "Enviar"
        BtnSeend.UseVisualStyleBackColor = True
        ' 
        ' label6
        ' 
        label6.AutoSize = True
        label6.Location = New Point(35, 22)
        label6.Name = "label6"
        label6.Size = New Size(52, 15)
        label6.TabIndex = 34
        label6.Text = "Formato"
        ' 
        ' ComBoxFormat_Ver
        ' 
        ComBoxFormat_Ver.FormattingEnabled = True
        ComBoxFormat_Ver.Items.AddRange(New Object() {"CSV", "TXT", "XML", "JSON"})
        ComBoxFormat_Ver.Location = New Point(93, 18)
        ComBoxFormat_Ver.Name = "ComBoxFormat_Ver"
        ComBoxFormat_Ver.Size = New Size(133, 23)
        ComBoxFormat_Ver.TabIndex = 33
        ' 
        ' BtnSave
        ' 
        BtnSave.Location = New Point(245, 17)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(120, 22)
        BtnSave.TabIndex = 32
        BtnSave.Text = "Guardar"
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' BtnLoad
        ' 
        BtnLoad.Location = New Point(495, 17)
        BtnLoad.Name = "BtnLoad"
        BtnLoad.Size = New Size(120, 46)
        BtnLoad.TabIndex = 31
        BtnLoad.Text = "Abrir"
        BtnLoad.UseVisualStyleBackColor = True
        ' 
        ' DataGrideViewShowData
        ' 
        DataGrideViewShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGrideViewShowData.Columns.AddRange(New DataGridViewColumn() {dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6})
        DataGrideViewShowData.Dock = DockStyle.Right
        DataGrideViewShowData.Location = New Point(697, 3)
        DataGrideViewShowData.Margin = New Padding(3, 2, 3, 2)
        DataGrideViewShowData.MultiSelect = False
        DataGrideViewShowData.Name = "DataGrideViewShowData"
        DataGrideViewShowData.RowHeadersWidth = 51
        DataGrideViewShowData.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGrideViewShowData.Size = New Size(782, 639)
        DataGrideViewShowData.TabIndex = 6
        ' 
        ' dataGridViewTextBoxColumn1
        ' 
        dataGridViewTextBoxColumn1.HeaderText = "ID"
        dataGridViewTextBoxColumn1.MinimumWidth = 6
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
        dataGridViewTextBoxColumn1.Width = 125
        ' 
        ' dataGridViewTextBoxColumn2
        ' 
        dataGridViewTextBoxColumn2.HeaderText = "Nombre"
        dataGridViewTextBoxColumn2.MinimumWidth = 6
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
        dataGridViewTextBoxColumn2.Width = 125
        ' 
        ' dataGridViewTextBoxColumn3
        ' 
        dataGridViewTextBoxColumn3.HeaderText = "Genero"
        dataGridViewTextBoxColumn3.MinimumWidth = 6
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
        dataGridViewTextBoxColumn3.Width = 125
        ' 
        ' dataGridViewTextBoxColumn4
        ' 
        dataGridViewTextBoxColumn4.HeaderText = "Desarrolladora"
        dataGridViewTextBoxColumn4.MinimumWidth = 6
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
        dataGridViewTextBoxColumn4.Width = 125
        ' 
        ' dataGridViewTextBoxColumn5
        ' 
        dataGridViewTextBoxColumn5.HeaderText = "Plataforma"
        dataGridViewTextBoxColumn5.MinimumWidth = 6
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5"
        dataGridViewTextBoxColumn5.Width = 125
        ' 
        ' dataGridViewTextBoxColumn6
        ' 
        dataGridViewTextBoxColumn6.HeaderText = "URL Imagen"
        dataGridViewTextBoxColumn6.MinimumWidth = 6
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
        dataGridViewTextBoxColumn6.Width = 125
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(BtnSend)
        TabPage3.Controls.Add(BtnReceive)
        TabPage3.Controls.Add(BtnUpload)
        TabPage3.Controls.Add(DataGrideShowSql)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(1482, 645)
        TabPage3.TabIndex = 2
        TabPage3.Text = "SQL"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' BtnSend
        ' 
        BtnSend.Location = New Point(237, 105)
        BtnSend.Margin = New Padding(3, 2, 3, 2)
        BtnSend.Name = "BtnSend"
        BtnSend.Size = New Size(115, 35)
        BtnSend.TabIndex = 21
        BtnSend.Text = "Enviar a Sql"
        BtnSend.UseVisualStyleBackColor = True
        ' 
        ' BtnReceive
        ' 
        BtnReceive.Location = New Point(237, 40)
        BtnReceive.Margin = New Padding(3, 2, 3, 2)
        BtnReceive.Name = "BtnReceive"
        BtnReceive.Size = New Size(115, 35)
        BtnReceive.TabIndex = 20
        BtnReceive.Text = "Cargar de SQl"
        BtnReceive.UseVisualStyleBackColor = True
        ' 
        ' BtnUpload
        ' 
        BtnUpload.Location = New Point(69, 40)
        BtnUpload.Margin = New Padding(3, 2, 3, 2)
        BtnUpload.Name = "BtnUpload"
        BtnUpload.Size = New Size(115, 35)
        BtnUpload.TabIndex = 19
        BtnUpload.Text = "Cargar Archivo"
        BtnUpload.UseVisualStyleBackColor = True
        ' 
        ' DataGrideShowSql
        ' 
        DataGrideShowSql.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGrideShowSql.Dock = DockStyle.Right
        DataGrideShowSql.Location = New Point(444, 3)
        DataGrideShowSql.Margin = New Padding(3, 2, 3, 2)
        DataGrideShowSql.MultiSelect = False
        DataGrideShowSql.Name = "DataGrideShowSql"
        DataGrideShowSql.ReadOnly = True
        DataGrideShowSql.RowHeadersWidth = 51
        DataGrideShowSql.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGrideShowSql.Size = New Size(1035, 639)
        DataGrideShowSql.TabIndex = 6
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1490, 673)
        Controls.Add(TabControlOption)
        Name = "Form1"
        Text = "Form1"
        TabControlOption.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        CType(PictureBoxGameIcon, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGrideShowData, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(DataGrideViewShowData, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        CType(DataGrideShowSql, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControlOption As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Private WithEvents BtnDelet As Button
    Private WithEvents BtnSearchName As Button
    Private WithEvents TextBoxName As TextBox
    Private WithEvents ComBoxFormat As ComboBox
    Private WithEvents BtnSaveData As Button
    Private WithEvents BtnFillTreeView As Button
    Private WithEvents TreeViewSql As TreeView
    Private WithEvents PictureBoxGameIcon As PictureBox
    Private WithEvents DataGrideShowData As DataGridView
    Private WithEvents Column1 As DataGridViewTextBoxColumn
    Private WithEvents Column2 As DataGridViewTextBoxColumn
    Private WithEvents Column3 As DataGridViewTextBoxColumn
    Private WithEvents Column4 As DataGridViewTextBoxColumn
    Private WithEvents Column5 As DataGridViewTextBoxColumn
    Private WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents label11 As Label
    Private WithEvents label10 As Label
    Private WithEvents FomPlotPlatform As ScottPlot.WinForms.FormsPlot
    Private WithEvents FromPlotGenre As ScottPlot.WinForms.FormsPlot
    Private WithEvents TxtFilter As TextBox
    Private WithEvents Label5 As Label
    Private WithEvents ComBoxFiltrer As ComboBox
    Private WithEvents label7 As Label
    Private WithEvents TextBoxUser As TextBox
    Private WithEvents BtnSeend As Button
    Private WithEvents label6 As Label
    Private WithEvents ComBoxFormat_Ver As ComboBox
    Private WithEvents BtnSave As Button
    Private WithEvents BtnLoad As Button
    Private WithEvents DataGrideViewShowData As DataGridView
    Private WithEvents dataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Private WithEvents BtnSend As Button
    Private WithEvents BtnReceive As Button
    Private WithEvents BtnUpload As Button
    Private WithEvents DataGrideShowSql As DataGridView

End Class
