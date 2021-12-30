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
    Public host_api, token_moph, api_history As String
    Public save_cln As String = "10100"

    Public Function Connect_Api_Nhso() As Boolean
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("host.xml")
        Dim serverApi As XmlNode
        Dim serverApinhso As XmlNode

        For Each serverApinhso In doc.SelectNodes("//Serverapinhso")
            serverApinhso.InnerText = (serverApinhso.InnerText)
            host_api = serverApinhso.InnerText
        Next

    End Function

    Public Function Connect_sql() As Boolean 'ติดต่อฐานข้อมู sql 

        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("host.xml")

        Dim serVer As XmlNode
        Dim pOrt As XmlNode
        Dim userName As XmlNode
        Dim passWord As XmlNode
        Dim dataBase As XmlNode

        Dim machine As XmlNode = doc.DocumentElement
        Dim NetInOut As XmlElement = doc.CreateElement("NetInOut")

        For Each serVer In doc.SelectNodes("//Server")
            serVer.InnerText = (serVer.InnerText)
            'txtServer.AppendText("" & serVer.InnerText & "")
        Next

        For Each pOrt In doc.SelectNodes("//Port")
            pOrt.InnerText = (pOrt.InnerText)
            'txtPort.AppendText("" & pOrt.InnerText & "")

        Next

        For Each userName In doc.SelectNodes("//Username")
            userName.InnerText = (userName.InnerText)
            'txtUsername.AppendText("" & userName.InnerText & "")

        Next

        For Each passWord In doc.SelectNodes("//Password")
            passWord.InnerText = (passWord.InnerText)
            'txtPassword.AppendText("" & passWord.InnerText & "")

        Next

        For Each dataBase In doc.SelectNodes("//Database")
            dataBase.InnerText = (dataBase.InnerText)
            'txtDatabase.AppendText("" & dataBase.InnerText & "")

        Next

        strcon = "DATABASE='" & dataBase.InnerText & "';SERVER='" & serVer.InnerText & "';user id='" & userName.InnerText & "';password='" & passWord.InnerText & "';port='" & pOrt.InnerText & "';Allow Zero Datetime=true;Character Set=tis620"

    End Function

    Function executesqlcommand(sql As String) As DataTable
        Try
            Connect_sql()
            Dim dtAdapter As MySqlDataAdapter
            Dim objConn As New MySqlConnection
            Dim dt As New DataTable
            objConn.ConnectionString = strcon
            objConn.Open()
            dtAdapter = New MySqlDataAdapter(sql, objConn)
            dtAdapter.Fill(dt)
            objConn.Close()
            objConn = Nothing
            Return dt
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถเชื่อมต่อ Server ได้ กรุณาตรวจสอบการเชื่อมต่อฐานข้อมูล", "Error Database Server",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function
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
