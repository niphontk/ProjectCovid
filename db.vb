Imports MySql.Data.MySqlClient
Imports System.Xml

Module db
    Public strcon As String
    Public setM As String
    Public setY As String
    Public SetCh As String
    Public i As String
    Public sShow As String
    Public f As String
    Public DayWeek As String = Date.Today.DayOfWeek.ToString()
    Public msgCri As String = "แจ้งเตือน"
    Public hcode As String

    Public Function Connect_sql_hi() As Boolean 'ติดต่อฐานข้อมู sql 

        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("host.xml")

        Dim serVerhi As XmlNode
        Dim pOrthi As XmlNode
        Dim userNamehi As XmlNode
        Dim passWordhi As XmlNode
        Dim dataBasehi As XmlNode

        Dim machinehi As XmlNode = doc.DocumentElement
        Dim NetInOuthi As XmlElement = doc.CreateElement("NetInOuthi")

        For Each serVerhi In doc.SelectNodes("//Serverhi")
            serVerhi.InnerText = (serVerhi.InnerText)
            'txtServer.AppendText("" & serVer.InnerText & "")
        Next

        For Each pOrthi In doc.SelectNodes("//Porthi")
            pOrthi.InnerText = (pOrthi.InnerText)
            'txtPort.AppendText("" & pOrt.InnerText & "")

        Next

        For Each userNamehi In doc.SelectNodes("//Usernamehi")
            userNamehi.InnerText = (userNamehi.InnerText)
            'txtUsername.AppendText("" & userName.InnerText & "")

        Next

        For Each passWordhi In doc.SelectNodes("//Passwordhi")
            passWordhi.InnerText = (passWordhi.InnerText)
            'txtPassword.AppendText("" & passWord.InnerText & "")

        Next

        For Each dataBasehi In doc.SelectNodes("//Databasehi")
            dataBasehi.InnerText = (dataBasehi.InnerText)
            'txtDatabase.AppendText("" & dataBase.InnerText & "")

        Next

        strcon = "DATABASE='" & dataBasehi.InnerText & "';SERVER='" & serVerhi.InnerText & "';user id='" & userNamehi.InnerText & "';password='" & passWordhi.InnerText & "';port='" & pOrthi.InnerText & "';Allow Zero Datetime=true;Character Set=tis620"

    End Function

    Function executesqlcommandhi(sqlhi As String) As DataTable
        Try
            Connect_sql_hi()
            Dim dtAdapter As MySqlDataAdapter
            Dim objConn As New MySqlConnection
            Dim dt As New DataTable
            objConn.ConnectionString = strcon
            objConn.Open()
            dtAdapter = New MySqlDataAdapter(sqlhi, objConn)
            dtAdapter.Fill(dt)
            objConn.Close()
            objConn = Nothing
            Return dt
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถเชื่อมต่อ Server ได้ กรุณาตรวจสอบการเชื่อมต่อฐานข้อมูล", "Error Database Server",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function

End Module
