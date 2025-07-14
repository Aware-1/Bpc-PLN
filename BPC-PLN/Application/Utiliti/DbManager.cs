using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace BpcSupportPanel;

//public class DbManager
//{

//    public readonly SqlConnection appConnection;
//    public readonly SqlConnection unityConnection;
//    public readonly SqlConnection ucpConnection;
//    public readonly SqlConnection PercentageConnection;

//    public DbManager(IConfiguration configuration)
//    {
//        appConnection = GetAppConnection(configuration);
//        unityConnection = GetUnityConnection(configuration);
//        ucpConnection = GetUcpConnection(configuration);
//        PercentageConnection = GetPercentageConnection(configuration);
//    }

//    private SqlConnection GetAppConnection(IConfiguration _configuration)
//    {
//        return new(_configuration.GetConnectionString("ApplicationDb"));
//    }

//    private SqlConnection GetUnityConnection(IConfiguration _configuration)
//    {
//        return new(_configuration.GetConnectionString("UnityDb"));
//    }
    
//    private SqlConnection GetUcpConnection(IConfiguration _configuration)
//    {
//        return new(_configuration.GetConnectionString("UcpDb"));
//    }

//    private SqlConnection GetPercentageConnection(IConfiguration _configuration)
//    {
//        return new(_configuration.GetConnectionString("PercentageDb"));
//    }

//    public SqlConnection GetAppConnection()
//    {
//        if (appConnection.IsConncetionReadyToOpen())
//        {
//            appConnection.Open();
//        }

//        return appConnection;
//    }

//    public SqlConnection GetUnityConnection()
//    {
//        if (unityConnection.IsConncetionReadyToOpen())
//        {
//            unityConnection.Open();
//        }

//        return unityConnection;
//    }
  
//    public SqlConnection GetUcpConnection()
//    {
//        if (ucpConnection.IsConncetionReadyToOpen())
//        {
//            ucpConnection.Open();
//        }

//        return ucpConnection;
//    }

//    public SqlConnection GetPercentageConnection()
//    {
//        if (PercentageConnection.IsConncetionReadyToOpen())
//        {
//            PercentageConnection.Open();
//        }

//        return PercentageConnection;
//    }


//    public void CloseAppConnection()
//    {
//        if (appConnection != null && appConnection.State == ConnectionState.Open)
//        {
//            appConnection.Close();
//        }
//    }

//    public void CloseUnityConnection()
//    {
//        if (unityConnection != null && unityConnection.State == ConnectionState.Open)
//        {
//            unityConnection.Close();
//        }
//    }  
    
//    public void CloseUcpConnection()
//    {
//        if (ucpConnection != null && ucpConnection.State == ConnectionState.Open)
//        {
//            ucpConnection.Close();
//        }
//    }

//    public void ClosePercentageConnection()
//    {
//        if (PercentageConnection != null && PercentageConnection.State == ConnectionState.Open)
//        {
//            PercentageConnection.Close();
//        }
//    }

//}