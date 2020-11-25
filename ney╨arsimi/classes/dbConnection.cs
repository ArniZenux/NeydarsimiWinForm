using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace neyðarsimi
{
    class dbConnection : Global
    {
        #region "Connection"
        public void Connection()
        {
            try
            {
                conn = new SQLiteConnection("Data Source=neydarsimi.db;Version=3;");
            }
            catch (SQLiteException ex)
            {
                throw ex; 
            }
        }
        #endregion

        #region "Open connection"
        public void OpenConnection()
        {
            conn.Open(); 
        }
        #endregion

        #region "Close connection"
        public void CloseConnection()
        {
            conn.Close(); 
        }
        #endregion

        #region "Excute Non Query"
        public void ExcuteQuery(string sqlString)
        {
            Connection(); 
            OpenConnection();
            command = new SQLiteCommand(sqlString, conn);   
            command.ExecuteNonQuery();
            CloseConnection(); 
        }
        #endregion

        #region "Get Record - Excute Reader"
        public SQLiteDataReader GetRecord(string sqlString)
        {
                Connection(); 
                OpenConnection(); 
                command = new SQLiteCommand(sqlString, conn); 
                reader = command.ExecuteReader();
                //CloseConnection(); 
            return reader;
        }
        #endregion
    }
}
