Imports System.Net
Imports System.Web.Http
Imports System.Collections.Generic

Imports System
Imports System.Data.Entity

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Models
    Public Class EventLogModel
        'Inherits ApiController

        Public Property City As String
        Public Property Temperature As Double

        Public ConnectionString As String = "Data Source=localhost\FSI201701;Initial Catalog=SERVERMONITORING;Integrated Security=True;User ID=sa;Password=outlander;"

        Public Class EventLog
            Public Property DateTime As DateTime
            Public Property error_class As String
            Public Property level As String
            Public Property event_id As Integer
            Public Property source As String
            Public Property ip_address As String
            Public Property logged_user As String
            Public Property logged_ou As String
            Public Property text As String
            Public Property alert_type As String
            Public Property [module] As String
            Public Property [function] As String
            Public Property file As String
        End Class

        Public Class EventLOgDBContext
            Public Property EventLogs As EventLog
        End Class

        Public Shared ReadOnly Property Data As List(Of EventLogModel)
            Get
                Dim testData As List(Of EventLogModel)

                testData = New List(Of EventLogModel)
                testData.Add(New EventLogModel With {.City = "Tallinn", .Temperature = 5.5})
                testData.Add(New EventLogModel With {.City = "Helsinki", .Temperature = 3.5})
                testData.Add(New EventLogModel With {.City = "Odessa", .Temperature = 18})
                testData.Add(New EventLogModel With {.City = "Varna", .Temperature = 19})

                Return testData
            End Get
        End Property

        'Public Shared ReadOnly Property Data As List(Of EventLogModel)
        '    Get

        '        Dim listData As List(Of EventLogModel)
        '        Dim aData = New get
        '    End Get
        'End Property

        '------------------
        'Public Shared Function Getconnectionstring(ByVal keyname As String) As String
        '    Dim connection As String = String.Empty

        '    Select Case keyname
        '        Case "ServerMonitoring"
        '            connection = ConfigurationManager.ConnectionStrings("ServerMonitoring").ConnectionString
        '        Case "Northwind"
        '            connection = ConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        '        Case Else
        '    End Select

        '    Return connection
        'End Function

        Public Enum Database
            DBServerMonitoring
            Northwind
        End Enum

        Public Shared Function Getconnectionstring(ByVal DBName As Database) As SqlConnection
            Dim connection As SqlConnection = Nothing

            Select Case DBName
                Case Database.DBServerMonitoring
                    connection = New SqlConnection("Data Source=localhost\FSI201701;Initial Catalog=SERVERMONITORING;Integrated Security=True;User ID=sa;Password=outlander;")
                    '"Network Library=DBMSSOCN;Connect Timeout=30;Database=SERVERMONITORING;User ID=sa;Password=outlander;Server=localhost\FSI201701;Enlist=False"
                Case Database.Northwind
                    connection = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True")
                Case Else
            End Select

            Return connection
        End Function


    End Class
End Namespace