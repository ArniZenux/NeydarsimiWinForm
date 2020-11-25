using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace neyðarsimi
{
    class Global
    {
        #region "VARIABLES"
        public static SQLiteConnection  conn; 
        public static SQLiteCommand     command;
        public static SQLiteDataReader  reader;
        #endregion
    }
}
