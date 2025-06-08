Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports Microsoft.Data.SqlClient
Imports Newtonsoft.Json.Linq
Imports ScottPlot.WinForms

Public Class Form1

    Inherits Form
    Private connectionDB As String = "Server=LUX_ALAN\SQLEXPRESS;Database=Game_Library;Trusted_Connection=True;TrustServerCertificate=True"
    ' private string connectionDB = @"Server=ALANAZASUS\MSSQLSERVER02;Database=Game_Library;Trusted_Connection=True;TrustServerCertificate=True";
    'private string connectionDB = @"Data Source=192.168.1.15\MSSQLserver02,1433;Database=Game_Library;User Id=Lux;Password=1234567890;TrustServerCertificate=True";
    Private clientId As String = "s87stzlrar3716fqqtfyao1wtaf0b6"
    Private accessToken As String
    Private clientSecret As String = "0iptgu744ucm2s3fi2g8dnehnuiktr"
    Private tokenExpiration As Date

    Private Async Sub BtnSearchName_Click(sender As Object, e As EventArgs) Handles BtnSearchName.Click
        If String.IsNullOrWhiteSpace(TextBoxName.Text) Then
            MessageBox.Show("Ingresa un nombre para buscar.")
            Return
        End If


        Try
            accessToken = Await ObtenerTokenAsync()
            Dim juegos As List(Of Games) = Await BuscarJuegosAsync(TextBoxName.Text)

            ' Agregar resultados al DataGridView
            For Each juego As Games In juegos
                Dim rowIndex As Integer = DataGrideShowData.Rows.Add(juego.id, juego.name, juego.genre, juego.developer, juego.platform, juego.imageUrl)
                DataGrideShowData.Rows(rowIndex).Tag = juego
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub BtnDelet_Click(sender As Object, e As EventArgs) Handles BtnDelet.Click
        ' clear the row selected in the datagridview
        If DataGrideShowData.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In DataGrideShowData.SelectedRows
                If Not row.IsNewRow Then ' Asegurarse de no eliminar la fila nueva
                    DataGrideShowData.Rows.Remove(row)
                End If
            Next
        Else
            MessageBox.Show("Selecciona una fila para eliminar.")
        End If
    End Sub

    Private Sub BtnSaveData_Click(sender As Object, e As EventArgs) Handles BtnSaveData.Click
        Dim selection As String = ComBoxFormat.SelectedItem?.ToString()
        Dim juego As Games = Nothing
        Try
            Select Case selection
                Case "CSV"
                    Dim csvContent As StringBuilder = New StringBuilder()
                    ' Agregar encabezados
                    csvContent.AppendLine("ID,Name,Genre,Developer,Platform,ImageUrl")
                    ' Agregar filas
                    For Each row As DataGridViewRow In DataGrideShowData.Rows
                        If row.IsNewRow Then Continue For ' Ignorar la fila nueva
                        Dim game = TryCast(row.Tag, Games)
                        If game IsNot Nothing Then
                            csvContent.AppendLine($"""{game.id}"",""{game.name}"",""{game.genre}"",""{game.developer}"",""{game.platform}"",""{game.imageUrl}""")
                        End If
                    Next
                    ' Guardar el contenido CSV en un archivo
                    Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                        If saveFileDialog.ShowDialog() = DialogResult.OK Then
                            Call File.WriteAllText(saveFileDialog.FileName, csvContent.ToString())
                            MessageBox.Show("Datos guardados exitosamente en formato CSV.")
                        End If
                    End Using
                Case "TXT"
                    'sace the datagridview data to a txt file
                    If DataGrideShowData.Rows.Count <= 1 Then
                        MessageBox.Show("No hay datos para guardar.")
                        Return
                    End If
                    Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                        If saveFileDialog.ShowDialog() = DialogResult.OK Then
                            Try
                                Dim sb As StringBuilder = New StringBuilder()
                                For Each row As DataGridViewRow In DataGrideShowData.Rows

                                    If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                        sb.AppendLine($"""{juego.id}"",""{juego.name}"",""{juego.genre}"",""{juego.developer}"",""{juego.platform}"",""{juego.imageUrl}""")
                                    End If
                                Next
                                Call File.WriteAllText(saveFileDialog.FileName, sb.ToString())
                                MessageBox.Show("Datos guardados correctamente.")
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                            End Try
                        End If
                    End Using

                Case "XML"
                    'save the datagridview data to a xml file
                    If DataGrideShowData.Rows.Count <= 1 Then
                        MessageBox.Show("No hay datos para guardar.")
                        Return
                    End If
                    Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                        saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
                        If saveFileDialog.ShowDialog() = DialogResult.OK Then
                            Try
                                Dim xmlDoc = New XDocument(New XElement("Games"))
                                For Each row As DataGridViewRow In DataGrideShowData.Rows

                                    If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                        xmlDoc.Root.Add(New XElement("Game", New XElement("id", juego.id), New XElement("name", juego.name), New XElement("genre", juego.genre), New XElement("developer", juego.developer), New XElement("platform", juego.platform), New XElement("imageUrl", juego.imageUrl)))
                                    End If
                                Next
                                xmlDoc.Save(saveFileDialog.FileName)
                                MessageBox.Show("Datos guardados correctamente.")
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                            End Try
                        End If
                    End Using

                Case "JSON"
                    'save the datagridview data to a json file
                    If DataGrideShowData.Rows.Count <= 1 Then
                        MessageBox.Show("No hay datos para guardar.")
                        Return
                    End If
                    Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
                        If saveFileDialog.ShowDialog() = DialogResult.OK Then
                            Try
                                Dim juegos = New JArray()
                                For Each row As DataGridViewRow In DataGrideShowData.Rows

                                    If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                        Dim juegoJson = New JObject From {
                                        {"id", juego.id},
                                        {"name", juego.name},
                                        {"genre", juego.genre},
                                        {"developer", juego.developer},
                                        {"platform", juego.platform},
                                        {"imageUrl", juego.imageUrl}
                                        }
                                        juegos.Add(juegoJson)
                                    End If
                                Next
                                Call File.WriteAllText(saveFileDialog.FileName, juegos.ToString())

                                MessageBox.Show("Datos guardados correctamente.")
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                            End Try
                        End If
                    End Using
                Case "PDF"
                    ' Guardar el contenido del DataGridView en un archivo PDF
                    If DataGrideViewShowData.Rows.Count <= 0 Then
                        MessageBox.Show("No hay datos para guardar.")
                        Return
                    End If

                    Using saveDialog As SaveFileDialog = New SaveFileDialog()
                        saveDialog.Filter = "PDF files (*.pdf)|*.pdf"
                        saveDialog.FileName = "Exportado"

                        If saveDialog.ShowDialog() = DialogResult.OK Then
                            Try
                                ExportarDataGridViewAPDF(DataGrideShowData, saveDialog.FileName)
                                MessageBox.Show("PDF guardado correctamente.")
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el PDF: " & ex.Message)
                            End Try
                        End If
                    End Using

                Case Else
                    MessageBox.Show("Selecciona un formato válido para guardar los datos.")
            End Select

        Catch

            MessageBox.Show("selecciona un formato para guardar los datos")
        End Try
    End Sub

    Private Sub DataGrideShowData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrideShowData.CellContentClick
        Dim juego As Games = Nothing
        ' Asegúrate de que no se está haciendo clic en el encabezado
        If e.RowIndex >= 0 Then
            Dim fila = DataGrideShowData.Rows(e.RowIndex)

            If CSharpImpl.__Assign(juego, TryCast(fila.Tag, Games)) IsNot Nothing AndAlso Not String.IsNullOrEmpty(juego.imageUrl) Then
                Try
                    ' Asegúrate de que tenga el prefijo correcto
                    Dim url As String = juego.imageUrl
                    If Not url.StartsWith("http") Then
                        url = "https:" & url
                    End If

                    Using wc = New WebClient()
                        Dim bytes = wc.DownloadData(url)
                        Using ms = New MemoryStream(bytes)
                            PictureBoxGameIcon.Image = Drawing.Image.FromStream(ms)
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("No se pudo cargar la imagen: " & ex.Message)
                    PictureBoxGameIcon.Image = Nothing
                End Try
            Else
                PictureBoxGameIcon.Image = Nothing
            End If
        End If
    End Sub

    'section 2
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'if the datagridview is empty, show a message
        If DataGrideViewShowData.Rows.Count <= 1 Then
            MessageBox.Show("No hay datos para guardar.")
            Return
        End If

        Dim selection As String = ComBoxFormat_Ver.SelectedItem?.ToString()
        Dim juego As Games = Nothing

        Select Case selection
            Case "CSV"
                ' if the file exists, save the data to a csv file, but if it doesn't exist, create a new file
                Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        Try
                            Dim csvContent As StringBuilder = New StringBuilder()
                            ' Agregar encabezados
                            csvContent.AppendLine("ID,Name,Genre,Developer,Platform,ImageUrl")
                            ' Agregar filas
                            For Each row As DataGridViewRow In DataGrideViewShowData.Rows
                                If row.IsNewRow Then Continue For ' Ignorar la fila nueva
                                Dim game = TryCast(row.Tag, Games)
                                If game IsNot Nothing Then
                                    csvContent.AppendLine($"{game.id},{game.name},{game.genre},{game.developer},{game.platform},{game.imageUrl}")
                                End If
                            Next
                            ' Guardar el contenido CSV en un archivo
                            Call File.WriteAllText(saveFileDialog.FileName, csvContent.ToString())
                            MessageBox.Show("Datos guardados exitosamente en formato CSV.")
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                        End Try
                    End If
                End Using
            Case "TXT"
                'if the txt file exists, save the data to a txt file, but if it doesn't exist, create a new file
                Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        Try
                            Dim sb As StringBuilder = New StringBuilder()
                            For Each row As DataGridViewRow In DataGrideViewShowData.Rows

                                If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                    sb.AppendLine($"{juego.id},{juego.name},{juego.genre},{juego.developer},{juego.platform},{juego.imageUrl}")
                                End If
                            Next
                            Call File.WriteAllText(saveFileDialog.FileName, sb.ToString())
                            MessageBox.Show("Datos guardados correctamente.")
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                        End Try
                    End If
                End Using

            Case "XML"
                'if the xml file exists, save the data to a xml file, but if it doesn't exist, create a new file
                Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        Try
                            Dim xmlDoc = New XDocument(New XElement("Games"))
                            For Each row As DataGridViewRow In DataGrideViewShowData.Rows

                                If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                    xmlDoc.Root.Add(New XElement("Game", New XElement("id", juego.id), New XElement("name", juego.name), New XElement("genre", juego.genre), New XElement("developer", juego.developer), New XElement("platform", juego.platform), New XElement("imageUrl", juego.imageUrl)))
                                End If
                            Next
                            xmlDoc.Save(saveFileDialog.FileName)
                            MessageBox.Show("Datos guardados correctamente.")
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                        End Try
                    End If
                End Using

            Case "JSON"
                'if the json file exists, save the data to a json file, but if it doesn't exist, create a new file
                Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        Try
                            Dim juegos = New JArray()
                            For Each row As DataGridViewRow In DataGrideViewShowData.Rows

                                If CSharpImpl.__Assign(juego, TryCast(row.Tag, Games)) IsNot Nothing Then
                                    Dim juegoJson = New JObject From {
                                        {"id", juego.id},
                                        {"name", juego.name},
                                        {"genre", juego.genre},
                                        {"developer", juego.developer},
                                        {"platform", juego.platform},
                                        {"imageUrl", juego.imageUrl}
                                    }
                                    juegos.Add(juegoJson)
                                End If
                            Next
                            Call File.WriteAllText(saveFileDialog.FileName, juegos.ToString())
                            MessageBox.Show("Datos guardados correctamente.")
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                        End Try
                    End If
                End Using

            Case Else
                MessageBox.Show("Selecciona un formato válido para guardar los datos.")
        End Select
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        'open file dialog to select a file,  CSV, TXT, XML or JSON
        Using openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml|JSON files (*.json)|*.json|All files (*.*)|*.*"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim filePath = openFileDialog.FileName
                    Dim fileExtension As String = Path.GetExtension(filePath).ToLower()

                    ' Limpiar columnas antes de cargar nuevo archivo
                    DataGrideViewShowData.Columns.Clear()

                    Select Case fileExtension
                        Case ".csv"
                            LoadCsv(filePath, DataGrideViewShowData)
                        Case ".txt"
                            LoadTxt(filePath, DataGrideViewShowData)
                        Case ".xml"
                            LoadXml(filePath, DataGrideViewShowData)
                        Case ".json"
                            LoadJson(filePath, DataGrideViewShowData)
                        Case Else
                            MessageBox.Show("Formato de archivo no soportado.")
                            Return
                    End Select

                    If DataGrideViewShowData.Rows.Count > 0 Then
                        ' Graficar por género (columna 2)
                        Dim datosAgrupados = ObtenerFrecuenciasDeColumna(DataGrideViewShowData, 2)
                        GraficarPieScottPlot5(FromPlotGenre, datosAgrupados)

                        ' Graficar por plataforma (columna 4)
                        datosAgrupados = ObtenerFrecuenciasDeColumna(DataGrideViewShowData, 4)
                        GraficarPieScottPlot5(FomPlotPlatform, datosAgrupados)
                    Else
                        MessageBox.Show("No se encontraron datos para graficar.")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al cargar el archivo: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub BtnSeend_Click(sender As Object, e As EventArgs) Handles BtnSeend.Click
        Dim saveDialog As SaveFileDialog = New SaveFileDialog()
        saveDialog.Filter = "PDF (*.pdf)|*.pdf|CSV (*.csv)|*.csv|Texto (*.txt)|*.txt|JSON (*.json)|*.json|XML (*.xml)|*.xml"
        Try
            saveDialog.FileName = "Tabla de juegos"
            Try
                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Dim extension As String = Path.GetExtension(saveDialog.FileName).ToLower()

                    Try
                        Select Case extension
                            Case ".pdf"
                                If DataGrideViewShowData.Rows.Count <= 1 Then
                                    MessageBox.Show("No hay datos para exportar.")
                                    Return
                                End If

                                Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Exportado.pdf")

                                Try
                                    ExportarDataGridViewAPDF(DataGrideViewShowData, tempPath)
                                    EnviarArchivoPorCorreo(tempPath, "Exportado.pdf")
                                    MessageBox.Show("PDF enviado por correo.")
                                Catch ex As Exception
                                    MessageBox.Show("Error al generar o enviar el PDF: " & ex.Message)
                                End Try
                            Case ".csv"
                                ExportarDataGridViewACSV(saveDialog.FileName)
                            Case ".txt"
                                ExportarDataGridViewATxt(saveDialog.FileName)
                            Case ".json"
                                ExportarDataGridViewAJson(saveDialog.FileName)
                            Case ".xml"
                                ExportarDataGridViewAXml(saveDialog.FileName)
                            Case Else
                                MessageBox.Show("Formato no soportado.")
                                Return
                        End Select

                        EnviarArchivoPorCorreo(saveDialog.FileName, Path.GetFileName(saveDialog.FileName))
                    Catch ex As Exception
                        MessageBox.Show("Error al exportar el archivo: " & ex.Message)
                        Return
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("Error al enviar el archivo: " & ex.Message)
                Return
            End Try
        Catch ex As Exception
            MessageBox.Show("Error al establecer el nombre del archivo: " & ex.Message)
            Return
        End Try
    End Sub

    Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles TxtFilter.TextChanged
        AplicarFiltro(DataGrideViewShowData)
    End Sub

    Private Sub ComBoxFiltrer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComBoxFiltrer.SelectedIndexChanged
        AplicarFiltro(DataGrideViewShowData)
    End Sub


    'section 3

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        'load the data of the a document (xml,csv, jason and txt) in the datagridview
        Using openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml|JSON files (*.json)|*.json|All files (*.*)|*.*"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim filePath = openFileDialog.FileName
                    Dim fileExtension As String = Path.GetExtension(filePath).ToLower()
                    Select Case fileExtension
                        Case ".csv"
                            LoadCsv(filePath, DataGrideShowSql)
                        Case ".txt"
                            LoadTxt(filePath, DataGrideShowSql)
                        Case ".xml"
                            LoadXml(filePath, DataGrideShowSql)
                        Case ".json"
                            LoadJson(filePath, DataGrideShowSql)
                        Case Else
                            MessageBox.Show("Formato de archivo no soportado.")
                    End Select
                Catch ex As Exception
                    MessageBox.Show("Error al cargar el archivo: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub BtnReceive_Click(sender As Object, e As EventArgs) Handles BtnReceive.Click
        'receive data the sql database and show it in the datagridview
        Using connection As SqlConnection = New SqlConnection(connectionDB)
            Dim consulta = "SELECT * FROM games"

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(consulta, connection)
            Dim dt As DataTable = New DataTable()

            Try
                connection.Open()
                adapter.Fill(dt)  ' Llenamos el DataTable con los datos
                DataGrideShowSql.DataSource = dt  ' Asignamos el DataTable como fuente de datos
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        'send data datagridview to the sql database
        Using connection As SqlConnection = New SqlConnection(connectionDB)
            Try
                connection.Open()

                For Each row As DataGridViewRow In DataGrideShowSql.Rows
                    If row.IsNewRow Then Continue For

                    ' Armar la lista de columnas y parámetros
                    Dim columnas As List(Of String) = New List(Of String)()
                    Dim parametros As List(Of String) = New List(Of String)()
                    Dim cmd As SqlCommand = New SqlCommand()
                    cmd.Connection = connection

                    For i = 0 To row.Cells.Count - 1
                        Dim columnName = DataGrideShowSql.Columns(i).Name ' Asegúrate que los nombres coincidan con los de SQL
                        Dim paramName As String = "@param" & i.ToString()

                        columnas.Add(columnName)
                        parametros.Add(paramName)

                        Dim value = If(row.Cells(i).Value, DBNull.Value)
                        cmd.Parameters.AddWithValue(paramName, value)
                    Next

                    Dim query = $"INSERT INTO games ({String.Join(",", columnas)}) VALUES ({String.Join(",", parametros)})"
                    cmd.CommandText = query
                    cmd.ExecuteNonQuery()
                Next

                MessageBox.Show("Datos enviados correctamente a la base de datos.")
            Catch ex As Exception
                MessageBox.Show("Error al enviar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    'METHODS

    Private Async Function ObtenerTokenAsync() As Task(Of String)
        ' Si el token es válido y no expiró, regresarlo
        If Not String.IsNullOrEmpty(accessToken) AndAlso Date.Now < tokenExpiration Then
            Return accessToken
        End If

        Using client = New Http.HttpClient()
            Dim url = $"https://id.twitch.tv/oauth2/token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials"

            Dim response = Await client.PostAsync(url, Nothing)

            If Not response.IsSuccessStatusCode Then
                Throw New Exception("No se pudo obtener el token de acceso.")
            End If

            Dim json = Await response.Content.ReadAsStringAsync()
            Dim data = JObject.Parse(json)

            accessToken = data("access_token").ToString()

            ' Guardamos la expiración sumando los segundos que dura el token
            Dim expiresIn As Integer = data("expires_in").ToObject(Of Integer)()
            tokenExpiration = Date.Now.AddSeconds(expiresIn - 60) ' -60 para renovar 1 minuto antes

            Return accessToken
        End Using
    End Function

    Private Async Function BuscarJuegosAsync(nombre As String) As Task(Of List(Of Games))
        Dim juegos As New List(Of Games)()

        Using client As New Http.HttpClient()
            client.DefaultRequestHeaders.Add("Client-ID", clientId)
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}")

            Dim query As String = $"fields id, name, genres.name, platforms.name, involved_companies.company.name, cover.url; search ""{nombre}"";limit 1;"
            Dim content As New Http.StringContent(query, Encoding.UTF8, "text/plain")

            Dim response = Await client.PostAsync("https://api.igdb.com/v4/games", content)

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error en la API IGDB: {response.StatusCode}")
            End If

            Dim json As String = Await response.Content.ReadAsStringAsync()
            Dim data As JArray = JArray.Parse(json)

            For Each item As JObject In data
                Dim genres As String = If(item("genres") IsNot Nothing,
                                          String.Join(", ", item("genres").Select(Function(g) g("name").ToString())),
                                          "Desconocido")

                Dim platforms As String = If(item("platforms") IsNot Nothing,
                                             String.Join(", ", item("platforms").Select(Function(p) p("name").ToString())),
                                             "Desconocido")

                Dim developer As String = If(item("involved_companies") IsNot Nothing,
                                             String.Join(", ", item("involved_companies").Select(Function(c)
                                                                                                     Dim comp = c("company")
                                                                                                     Return If(comp IsNot Nothing AndAlso comp("name") IsNot Nothing, comp("name").ToString(), "Desconocido")
                                                                                                 End Function)),
                                             "Desconocido")

                Dim imageUrl As String = If(item("cover")?("url")?.ToString(), "")
                If Not String.IsNullOrEmpty(imageUrl) AndAlso Not imageUrl.StartsWith("http") Then
                    imageUrl = "https:" & imageUrl.Replace("t_thumb", "t_cover_big")
                End If

                juegos.Add(New Games With {
                    .id = item("id")?.ToString(),
                    .name = item("name")?.ToString(),
                    .genre = genres,
                    .platform = platforms,
                    .developer = developer,
                    .imageUrl = imageUrl
                })
            Next
        End Using

        Return juegos
    End Function


    Public Sub LoadCsv(filePath As String, dataGridView As DataGridView)
        dataGridView.Rows.Clear()

        Using reader = New StreamReader(filePath)
            Dim line As String
            Dim isFirstLine = True
            Dim headers As List(Of String) = Nothing

            While Not Equals((CSharpImpl.__Assign(line, reader.ReadLine())), Nothing)
                Dim values = ParseCsvLine(line) ' Este método debe dividir por ',' y considerar comillas si hay

                ' Reemplazar celdas vacías o con solo espacios por "n/a"
                For i = 0 To values.Count - 1
                    If String.IsNullOrWhiteSpace(values(i)) Then
                        values(i) = "n/a"
                    End If
                Next

                If isFirstLine Then
                    headers = values
                    isFirstLine = False

                    ' Crear columnas solo si no existen
                    If dataGridView.Columns.Count = 0 Then
                        For Each header In headers
                            dataGridView.Columns.Add(header, header)
                        Next
                    End If

                    Continue While ' No cargar los encabezados como datos
                End If

                ' Asegurar que tenga al menos tantas columnas como se esperan
                If values.Count >= dataGridView.Columns.Count Then
                    Dim rowIndex As Integer = dataGridView.Rows.Add(values.ToArray())

                    ' Asignar al objeto Game si es necesario
                    Dim game = New Games With {
    .id = values(0),
    .name = values(1),
    .genre = values(2),
    .developer = values(3),
    .platform = values(4),
    .imageUrl = values(5)
}

                    dataGridView.Rows(rowIndex).Tag = game
                End If
            End While
        End Using
    End Sub


    Public Sub LoadTxt(filePath As String, dataGridView As DataGridView)
        dataGridView.Rows.Clear()

        Using reader = New StreamReader(filePath)
            Dim line As String
            Dim isFirstLine = True
            Dim headers As List(Of String) = Nothing

            While Not Equals((CSharpImpl.__Assign(line, reader.ReadLine())), Nothing)
                Dim values = ParseCsvLine(line) ' Asegúrate de adaptar ParseCsvLine si usas tabulaciones en vez de comas

                ' Reemplazar valores vacíos o con solo espacios por "n/a"
                For i = 0 To values.Count - 1
                    If String.IsNullOrWhiteSpace(values(i)) Then
                        values(i) = "n/a"
                    End If
                Next

                If isFirstLine Then
                    headers = values
                    isFirstLine = False

                    If dataGridView.Columns.Count = 0 Then
                        For Each header In headers
                            dataGridView.Columns.Add(header, header)
                        Next
                    End If

                    Continue While ' Saltar encabezado como fila de datos
                End If

                If values.Count >= dataGridView.Columns.Count Then
                    Dim rowIndex As Integer = dataGridView.Rows.Add(values.ToArray())

                    ' Vincular el objeto Game como Tag (si se requiere)
                    Dim game = New Games With {
    .id = values(0),
    .name = values(1),
    .genre = values(2),
    .developer = values(3),
    .platform = values(4),
    .imageUrl = values(5)
}

                    dataGridView.Rows(rowIndex).Tag = game
                End If
            End While
        End Using
    End Sub




    Public Sub LoadXml(filePath As String, dataGridView As DataGridView)
        dataGridView.Rows.Clear()

        Dim xmlDoc = XDocument.Load(filePath)
        Dim gameElements = xmlDoc.Descendants("Game").ToList()

        If Not gameElements.Any() Then Return

        ' Crear columnas solo si no existen
        If dataGridView.Columns.Count = 0 Then
            Dim firstGame = gameElements.First()
            For Each element In firstGame.Elements()
                dataGridView.Columns.Add(element.Name.LocalName, element.Name.LocalName)
            Next
        End If

        For Each gameElement In gameElements
            ' Obtener valores con "n/a" si están vacíos
            Dim values = dataGridView.Columns.Cast(Of DataGridViewColumn)().[Select](Function(col)
                                                                                         Dim value = If(gameElement.Element(col.Name)?.Value, "")
                                                                                         Return If(String.IsNullOrWhiteSpace(value), "n/a", value)
                                                                                     End Function).ToArray()

            Dim rowIndex = dataGridView.Rows.Add(values)

            ' Asociar objeto Game, usando también "n/a" para campos vacíos
            Dim game = New Games With {
    .id = If(String.IsNullOrWhiteSpace(gameElement.Element("id")?.Value), "n/a", gameElement.Element("id")?.Value),
    .name = If(String.IsNullOrWhiteSpace(gameElement.Element("name")?.Value), "n/a", gameElement.Element("name")?.Value),
    .genre = If(String.IsNullOrWhiteSpace(gameElement.Element("genre")?.Value), "n/a", gameElement.Element("genre")?.Value),
    .developer = If(String.IsNullOrWhiteSpace(gameElement.Element("developer")?.Value), "n/a", gameElement.Element("developer")?.Value),
    .platform = If(String.IsNullOrWhiteSpace(gameElement.Element("platform")?.Value), "n/a", gameElement.Element("platform")?.Value),
    .imageUrl = If(String.IsNullOrWhiteSpace(gameElement.Element("imageUrl")?.Value), "n/a", gameElement.Element("imageUrl")?.Value)
}

            dataGridView.Rows(rowIndex).Tag = game
        Next
    End Sub



    Public Sub LoadJson(filePath As String, dataGridView As DataGridView)
        dataGridView.Rows.Clear()

        Dim json As String = File.ReadAllText(filePath)
        Dim juegos As JArray = JArray.Parse(json)

        If juegos.Count = 0 Then Return

        ' Crear columnas automáticamente SOLO si no existen
        If dataGridView.Columns.Count = 0 Then
            For Each prop As JProperty In juegos(0)
                dataGridView.Columns.Add(prop.Name, prop.Name)
            Next
        End If

        For Each item As JObject In juegos
            Dim rowData As New List(Of String)()

            For Each col As DataGridViewColumn In dataGridView.Columns
                Dim value As String = If(item(col.Name)?.ToString(), "")
                rowData.Add(If(String.IsNullOrWhiteSpace(value), "n/a", value))
            Next

            Dim rowIndex As Integer = dataGridView.Rows.Add(rowData.ToArray())

            ' Función auxiliar para obtener valores seguros
            Dim GetSafeValue As Func(Of String, String) = Function(key)
                                                              Dim val = If(item(key)?.ToString(), "")
                                                              Return If(String.IsNullOrWhiteSpace(val), "n/a", val)
                                                          End Function

            Dim game As New Games With {
                .id = GetSafeValue("id"),
                .name = GetSafeValue("name"),
                .genre = GetSafeValue("genre"),
                .developer = GetSafeValue("developer"),
                .platform = GetSafeValue("platform"),
                .imageUrl = GetSafeValue("imageUrl")
            }

            dataGridView.Rows(rowIndex).Tag = game
        Next
    End Sub


    Private Function ParseCsvLine(line As String) As List(Of String)
        Dim values = New List(Of String)()
        Dim inQuotes = False
        Dim value As StringBuilder = New StringBuilder()

        For i = 0 To line.Length - 1
            Dim c = line(i)

            If inQuotes Then
                If c = """"c Then
                    ' Revisa si es una comilla escapada ("")
                    If i + 1 < line.Length AndAlso line(i + 1) = """"c Then
                        value.Append(""""c)
                        i += 1 ' Saltar la siguiente comilla
                    Else
                        inQuotes = False ' Finaliza comillas
                    End If
                Else
                    value.Append(c)
                End If
            Else
                If c = """"c Then
                    inQuotes = True
                ElseIf c = ","c Then
                    values.Add(value.ToString())
                    value.Clear()
                Else
                    value.Append(c)
                End If
            End If
        Next

        values.Add(value.ToString()) ' Último valor
        Return values
    End Function



    'grafica en forma de pastel la columna de genero de los juegos en un fromplot
    Public Sub GraficarPieScottPlot5(plot As FormsPlot, datosAgrupados As Dictionary(Of String, Integer))
        plot.Plot.Clear()

        ' Ordenar por frecuencia descendente
        Dim ordenado = datosAgrupados.OrderByDescending(Function(kv) kv.Value).ToList()

        ' Separar valores y etiquetas
        Dim values As Double() = ordenado.[Select](Function(kv) CDbl(kv.Value)).ToArray()
        Dim labels As String() = ordenado.[Select](Function(kv) kv.Key).ToArray()

        ' Crear gráfico
        Dim pie = plot.Plot.Add.Pie(values)

        pie.ExplodeFraction = 0.1
        pie.SliceLabelDistance = 0.5

        Dim total As Double = values.Sum()

        For i = 0 To pie.Slices.Count - 1
            pie.Slices(i).Label = $"{labels(i)}" ' Etiqueta que aparece en el gráfico
            pie.Slices(i).LegendText = $"{labels(i)} ({values(i) / total:P1})" ' Texto de la leyenda
            pie.Slices(i).LabelFontSize = 16
        Next

        ' Opcional: estilo visual
        plot.Plot.Axes.Frameless()
        plot.Plot.HideGrid()

        ' Mostrar
        plot.Refresh()
    End Sub


    Public Function ObtenerFrecuenciasDeColumna(dgv As DataGridView, columna As Integer) As Dictionary(Of String, Integer)
        Dim frecuencias As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

        For Each fila As DataGridViewRow In dgv.Rows
            If Not fila.IsNewRow AndAlso fila.Cells(columna).Value IsNot Nothing Then
                Dim valorCelda As String = fila.Cells(columna).Value.ToString()

                ' Separar por comas y procesar cada uno
                Dim elementos = valorCelda.Split({","c}, StringSplitOptions.RemoveEmptyEntries)

                For Each elemento In elementos
                    Dim limpio As String = elemento.Trim() ' Quita espacios extra

                    If frecuencias.ContainsKey(limpio) Then
                        frecuencias(limpio) += 1
                    Else
                        frecuencias(limpio) = 1
                    End If
                Next
            End If
        Next

        Return frecuencias
    End Function
    Private Sub EnviarArchivoPorCorreo(archivoRuta As String, archivoNombre As String)
        Try
            Dim correo As MailMessage = New MailMessage()
            correo.From = New MailAddress("meliodassama242@gmail.com")
            correo.To.Add(TextBoxUser.Text)
            correo.Subject = "Archivo exportado desde la app"
            correo.Body = "Se adjunta el archivo generado."

            correo.Attachments.Add(New Attachment(archivoRuta))

            Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com", 587)
            smtp.Credentials = New NetworkCredential("meliodassama242@gmail.com", "lerc shaf ekeu ahen")
            smtp.EnableSsl = True

            smtp.Send(correo)

            MessageBox.Show("Correo enviado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al enviar el correo: " & ex.Message)
        End Try
    End Sub

    Private Sub ExportarDataGridViewAPDF(gridView As DataGridView, rutaArchivo As String)
        Dim pd As PrintDocument = New PrintDocument()

        pd.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        pd.PrinterSettings.PrintToFile = True
        pd.PrinterSettings.PrintFileName = rutaArchivo

        AddHandler pd.PrintPage, Sub(sender, ev)
                                     Dim x = 20
                                     Dim y = 20
                                     Dim anchoColumna = 100
                                     Dim altoFila = 25
                                     Dim font As Drawing.Font = New Drawing.Font("Arial", 10)
                                     Dim pen = Drawing.Pens.Black
                                     Dim brush = Drawing.Brushes.Black

                                     Dim totalColumnas = gridView.Columns.Count
                                     Dim totalFilas = gridView.Rows.Count - 1 ' Omitir última fila vacía

                                     ' Dibujar encabezados
                                     For col = 0 To totalColumnas - 1
                                         Dim rect As Drawing.Rectangle = New Drawing.Rectangle(x, y, anchoColumna, altoFila)
                                         ev.Graphics.DrawRectangle(pen, rect)
                                         ev.Graphics.DrawString(gridView.Columns(col).HeaderText, font, brush, rect, New Drawing.StringFormat With {
                                                  .Alignment = Drawing.StringAlignment.Center,
                                                  .LineAlignment = Drawing.StringAlignment.Center
                                              })
                                         x += anchoColumna
                                     Next

                                     y += altoFila
                                     x = 20

                                     ' Dibujar filas
                                     For fila = 0 To totalFilas - 1
                                         For col = 0 To totalColumnas - 1
                                             Dim rect As Drawing.Rectangle = New Drawing.Rectangle(x, y, anchoColumna, altoFila)
                                             ev.Graphics.DrawRectangle(pen, rect)
                                             Dim texto As String = If(gridView.Rows(fila).Cells(col).Value?.ToString(), "n/a")
                                             ev.Graphics.DrawString(texto, font, brush, rect, New Drawing.StringFormat With {
                                                  .Alignment = Drawing.StringAlignment.Center,
                                                  .LineAlignment = Drawing.StringAlignment.Center
                                              })
                                             x += anchoColumna
                                         Next
                                         y += altoFila
                                         x = 20

                                         If y + altoFila > ev.MarginBounds.Bottom Then
                                             ev.HasMorePages = True
                                             Return
                                         End If
                                     Next

                                     ev.HasMorePages = False
                                 End Sub

        Try
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("Error al imprimir como PDF: " & ex.Message)
        End Try
    End Sub


    Private Sub ExportarDataGridViewAJson(filePath As String)
        Dim array As JArray = New JArray()

        For Each row As DataGridViewRow In DataGrideViewShowData.Rows
            If row.IsNewRow Then Continue For

            Dim obj As JObject = New JObject()
            For Each col As DataGridViewColumn In DataGrideViewShowData.Columns
                Dim key = col.HeaderText
                Dim value As String = If(row.Cells(col.Index).Value?.ToString(), "")
                obj(key) = If(String.IsNullOrWhiteSpace(value), "n/a", value)
            Next

            array.Add(obj)
        Next

        Call File.WriteAllText(filePath, array.ToString())
    End Sub

    Private Sub ExportarDataGridViewAXml(filePath As String)
        Dim root As XElement = New XElement("Games")

        For Each row As DataGridViewRow In DataGrideViewShowData.Rows
            If row.IsNewRow Then Continue For

            Dim game As XElement = New XElement("Game")

            For Each col As DataGridViewColumn In DataGrideViewShowData.Columns
                Dim key = col.HeaderText
                Dim value As String = If(row.Cells(col.Index).Value?.ToString(), "n/a")
                game.Add(New XElement(key, If(String.IsNullOrWhiteSpace(value), "n/a", value)))
            Next

            root.Add(game)
        Next

        root.Save(filePath)
    End Sub

    Private Sub ExportarDataGridViewATxt(filePath As String)
        Using writer As StreamWriter = New StreamWriter(filePath)
            ' Encabezados
            Dim headers = DataGrideViewShowData.Columns.Cast(Of DataGridViewColumn)().[Select](Function(col) col.HeaderText)
            writer.WriteLine(String.Join(vbTab, headers)) ' Usa tabulación

            ' Filas
            For Each row As DataGridViewRow In DataGrideViewShowData.Rows
                If Not row.IsNewRow Then
                    Dim values = row.Cells.Cast(Of DataGridViewCell)().[Select](Function(cell) If(cell.Value?.ToString(), ""))
                    writer.WriteLine(String.Join(vbTab, values))
                End If
            Next
        End Using
    End Sub

    Private Sub ExportarDataGridViewACSV(filePath As String)
        Using writer As StreamWriter = New StreamWriter(filePath)
            ' Encabezados
            Dim headers = DataGrideViewShowData.Columns.Cast(Of DataGridViewColumn)().[Select](Function(col) col.HeaderText)
            writer.WriteLine(String.Join(",", headers))

            ' Filas
            For Each row As DataGridViewRow In DataGrideViewShowData.Rows
                If Not row.IsNewRow Then
                    Dim values = row.Cells.Cast(Of DataGridViewCell)().[Select](Function(cell) """" & (If(cell.Value?.ToString(), "")) & """")
                    writer.WriteLine(String.Join(",", values))
                End If
            Next
        End Using
    End Sub
    Private Sub AplicarFiltro(dgv As DataGridView)
        Dim texto As String = TxtFilter.Text.Trim()
        Dim columna = ComBoxFiltrer.SelectedIndex               ' 0?based

        ' Si la caja está vacía, muestra todo
        If String.IsNullOrEmpty(texto) Then
            For Each fila As DataGridViewRow In dgv.Rows
                fila.Visible = True
            Next
            Return
        End If

        For Each fila As DataGridViewRow In dgv.Rows
            If fila.IsNewRow Then Continue For                 ' omite fila de edición
            Dim valorCelda As String = If(fila.Cells(columna).Value?.ToString(), "")

            ' Visible solo si contiene el texto (ignora mayúsc/minúsc)
            fila.Visible = valorCelda.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
        Next
    End Sub


    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Private Sub BtnFillTreeView_Click(sender As Object, e As EventArgs) Handles BtnFillTreeView.Click
        TreeViewSql.Nodes.Clear()

        ' Índices de las columnas que usarás (ajusta según tu DataGridView)
        Dim genreColIndex As Integer = If(DataGrideShowData.Columns("genre")?.Index, 2)
        Dim nameColIndex As Integer = If(DataGrideShowData.Columns("name")?.Index, 1)

        ' Diccionario para evitar duplicados de géneros
        Dim genreNodes As New Dictionary(Of String, TreeNode)()

        For Each row As DataGridViewRow In DataGrideShowData.Rows
            If row.IsNewRow Then Continue For

            Dim genre As String = If(row.Cells(genreColIndex).Value?.ToString(), "Sin Género")
            Dim name As String = If(row.Cells(nameColIndex).Value?.ToString(), "Sin Nombre")

            ' Crear nodo género si no existe
            If Not genreNodes.ContainsKey(genre) Then
                Dim genreNode As New TreeNode(genre)
                genreNodes.Add(genre, genreNode)
                TreeViewSql.Nodes.Add(genreNode)
            End If

            ' Añadir juego bajo el género
            Dim gameNode As New TreeNode(name)
            genreNodes(genre).Nodes.Add(gameNode)
        Next

        TreeViewSql.ExpandAll()
    End Sub
End Class
