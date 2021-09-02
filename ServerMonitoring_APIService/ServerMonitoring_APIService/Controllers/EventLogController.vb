Imports System.Net
Imports System.Web.Http
Imports ServerMonitoring_APIService.Models
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net.Http

Namespace Controllers
    Public Class EventLogController
        Inherits ApiController

        Private db As EventLogModel.EventLOgDBContext = New EventLogModel.EventLOgDBContext()

        'GET: api/eventlog/getvalues
        <HttpGet>
        <Route("api/eventlog/getvalues")>
        Public Function GetValues() As DataSet
            Dim ds As DataSet = New DataSet()
            Using connection As SqlConnection = New SqlConnection(ConnectionString)
                Dim da As SqlDataAdapter = New SqlDataAdapter()
                da.SelectCommand = New SqlCommand("SELECT*FROM tl_eventlog", connection)
                da.Fill(ds)
                Return ds
            End Using
        End Function

        'GET: api/eventlog/getvalue
        <HttpGet>
        <Route("api/eventlog/getvalue")>
        Public Function GetValue(ByVal id As Integer) As DataSet
            Dim ds As DataSet = New DataSet()
            Using connection As SqlConnection = New SqlConnection(ConnectionString)
                Dim da As SqlDataAdapter = New SqlDataAdapter()
                da.SelectCommand = New SqlCommand("SELECT*FROM tl_eventlog WHERE event_id=" & id, connection)
                da.Fill(ds)
                Return ds
            End Using
        End Function

        'POST: api/eventlog/postvalue
        <HttpPost>
        <Route("api/eventlog/postvalue")>
        Public Function PostValue(<FromBody> ByVal value As EventLogModel.EventLog)
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ed As EventLog = New EventLog()
            Dim sqlCommand As String

            conn.Open()
            sqlCommand = "INSERT INTO dbo.tl_eventlog( error_class, [level], event_id, source, ip_address, logged_user, logged_ou, [text], alert_type, [module], [function], [file]) " &
                            "VALUES(  '" & value.error_class & "', " &
                                " '" & value.level & "', " &
                                " " & value.event_id & ", " &
                                " '" & value.source & "', " &
                                " '" & value.ip_address & "', " &
                                " '" & value.logged_user & "', " &
                                " '" & value.logged_ou & "', " &
                                " '" & value.text & "', " &
                                " '" & value.alert_type & "', " &
                                " '" & value.module & "', " &
                                " '" & value.function & "', " &
                                " '" & value.file & "' )"
            da.InsertCommand = New SqlCommand(sqlCommand, conn)
            da.InsertCommand.ExecuteNonQuery()

            Return Ok()
        End Function

        <HttpGet>
        <Route("api/eventlog/GetData/Load")>
        Private Function LoadData() As DataSet
            Dim ds = New DataSet()
            Dim ConnectionString As String = "Data Source=localhost\FSI201701;Initial Catalog=SERVERMONITORING;Integrated Security=True;User ID=sa;Password=outlander;"
            Using connection As SqlConnection = New SqlConnection(ConnectionString)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter()
                adapter.SelectCommand = New SqlCommand("SELECT*FROM dbo.tl_eventlog", connection)
                adapter.Fill(ds)
                Return ds
            End Using

        End Function

    End Class
End Namespace