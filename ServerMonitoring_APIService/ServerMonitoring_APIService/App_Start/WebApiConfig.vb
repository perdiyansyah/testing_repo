Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public oConnString As String = "Network Library=DBMSSOCN;Connect Timeout=30;Database=SERVERMONITORING;User ID=sa;Password=outlander;Server=localhost\FSI201701;Enlist=False"

    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub

    Public Property ConnectionString As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        End Get
        Set(ByVal value As String)
        End Set
    End Property
End Module
