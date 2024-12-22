Imports MySql.Data.MySqlClient
Imports System.IO
Module dbconnection
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As DataTable
    Public dr As MySqlDataReader
    Public i As Integer
    Public result As Boolean
    Public pro_title As String = "SMS"

    Public Function dbconn() As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = "server=localhost;username=root;password=;database=stock_db"
                result = True
            End If
        Catch ex As Exception
            result = False
            MsgBox("Warning: Server Not Connected !", vbExclamation)
        End Try
        Return result
    End Function
End Module
