using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace neyðarsimi
{
    class tulkur : Global
    {
        #region "Class"
        dbConnection clsDatabase = new dbConnection(); 
        #endregion

        #region "VARIABLES"
        public string kennitala;
        public string nafn;
        #endregion 
                
        #region "PROPERTIES"
        public void setNafn(string nafn){
            this.nafn = nafn; 
        }

        public void setKennitala(string kennitala){
            this.kennitala = kennitala; 
        }

        public string getNafn(){
            return nafn; 
        }

        public string getKennitala(){
            return kennitala; 
        }
        #endregion
        
        #region "Functions"
        public void SkraTulkur(){
            string sqlString = "INSERT INTO TULKUR(KT, NAFN) VALUES('" + kennitala  + "','" + nafn + "') ;";
            clsDatabase.ExcuteQuery(sqlString); 
        }

        public void EydaTulkur(){
            string sqlString = "DELETE FROM TULKUR WHERE KT = '" + kennitala + "' ;";
            clsDatabase.ExcuteQuery(sqlString); 
        }

        public void BreytaTulkur(){
            string sqlString ="UPDATE TULKUR SET KT = '" + kennitala + "' ,  NAFN = '" + nafn + "' WHERE KT = '" + kennitala + "' ;";
            clsDatabase.ExcuteQuery(sqlString); 
        }

        //------------------------------------//
        // Form 3 - Breyta/Eyða - Buttons     // 
        //------------------------------------//
        public void HladaEinnTulkur(string nafn, TextBox textBox1, TextBox textBox2 ){
            string sqlString = "SELECT * FROM TULKUR WHERE NAFN = '" + nafn + "'; ";
            clsDatabase.GetRecord(sqlString); 

            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
            }
            reader.Close(); 
        }

        //------------------------------//
        // Form 1 - Skrá - Button       //
        //------------------------------//
        public void HladaKennitala(string nafn)
        {
            string sqlString = "SELECT * FROM TULKUR WHERE NAFN = '" + nafn + "'; ";
            clsDatabase.GetRecord(sqlString);
           
            while (reader.Read())
                {
                    kennitala = reader[0].ToString();
                }
                reader.Close();
        }

        public void HladaTulkur(ListBox listBox1)
        {
            listBox1.Items.Clear();
           
            string sqlString = "SELECT * FROM TULKUR;";
            clsDatabase.GetRecord(sqlString);

            while (reader.Read())
            {
                listBox1.Items.Add(reader["NAFN"].ToString());
            }
            reader.Close(); 
        }
        #endregion
    }
}
