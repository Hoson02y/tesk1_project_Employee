using System.Data.SqlClient;

namespace Employee.Pages
{
    internal class sqlCommand
    {
        private string sql;
        private SqlConnection sqlConnection;

        public sqlCommand(string sql, SqlConnection sqlConnection)
        {
            this.sql = sql;
            this.sqlConnection = sqlConnection;
        }
    }
}