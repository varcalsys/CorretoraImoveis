using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorretoraImoveis.Data.ContextDb
{
    public class DbContext
    {
        private SqlConnection _conn;
        private SqlTransaction _transaction;

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["CorretoraImoveis"].ConnectionString);
        }

        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;

        private SqlCommand CreateSqlCommand(CommandType cmdType, string cmdSql)
        {
            _conn = CreateConnection();
            _conn.Open();
            _transaction = _conn.BeginTransaction();
            var cmd = _conn.CreateCommand();
            cmd.Transaction = _transaction;
            cmd.CommandType = cmdType;           
            cmd.CommandText = cmdSql;
            cmd.CommandTimeout = 7200;

            foreach (SqlParameter sqlParameter in _sqlParameterCollection)
                cmd.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            
            return cmd;
        }

        protected void ClearParameters()
        {
            _sqlParameterCollection.Clear();
        }

        protected void AddParameters(string parameterName, object value)
        {
            _sqlParameterCollection.AddWithValue(parameterName, value);
        }

        protected void ExecCommand(CommandType cmdType, string cmdSql)
        {
            try
            {
                var cmd = CreateSqlCommand(cmdType, cmdSql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        protected SqlDataReader ExecQuery(CommandType cmdType, string cmdSql)
        {
            try
            {
                var cmd = CreateSqlCommand(cmdType, cmdSql);
                var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception ex)
            {
                _conn.Close();
                throw new Exception(ex.Message);
            }
        }


        protected void ExecCommit()
        {
            _transaction.Commit();
            _conn.Close();
        }
    }
}
