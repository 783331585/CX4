using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CX4.Chloe.Oracle
{
    /// <summary>
    /// 
    /// </summary>
    internal class OracleConnectionDecorator : IDbConnection, IDisposable
    {
        private readonly OracleConnection _oracleConnection;
        public OracleConnectionDecorator(OracleConnection oracleConnection)
        {
            _oracleConnection = oracleConnection ?? throw new Exception("oracleConnection is not null.");
        }

        public string ConnectionString
        {
            get { return _oracleConnection.ConnectionString; }
            set { _oracleConnection.ConnectionString = value; }
        }
        public int ConnectionTimeout
        {
            get { return _oracleConnection.ConnectionTimeout; }
        }
        public string Database
        {
            get { return _oracleConnection.Database; }
        }
        public ConnectionState State
        {
            get { return _oracleConnection.State; }
        }

        public IDbTransaction BeginTransaction()
        {
            return _oracleConnection.BeginTransaction();
        }
        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _oracleConnection.BeginTransaction(il);
        }
        public void ChangeDatabase(string databaseName)
        {
            _oracleConnection.ChangeDatabase(databaseName);
        }
        public void Close()
        {
            _oracleConnection.Close();
        }
        public IDbCommand CreateCommand()
        {
            var cmd = _oracleConnection.CreateCommand();
            cmd.BindByName = true; //修改 DbCommand 参数绑定方式
            return cmd;
        }
        public void Open()
        {
            _oracleConnection.Open();
        }
        public void Dispose()
        {
            _oracleConnection.Dispose();
        }
    }
}
