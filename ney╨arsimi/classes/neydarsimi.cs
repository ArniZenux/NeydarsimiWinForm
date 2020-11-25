using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace neyðarsimi
{
    class neydarsimi : Global
    {
        #region "Class"
        dbConnection clsDatabase = new dbConnection();
        #endregion 

        #region "VARIABLES"
        public int numer;
        public int verk; 
        public string kennitala;
        public string byrja;
        public string endir;
        public string timi_byrja;
        public string timi_endir;
        public string vettvangur;

        public int day;
        public string[] dagur;
        public string month;
        public int month_string;
        public int year;
        
        public int day_DateTime_Now;
        public int month_DateTime_Now;
        public int year_DateTime_Now;

        public int bool_vinna = 1;
        public int bool_vinna_check;

        ListViewItem list;
        DateTime dt;
        #endregion

        #region "PROPERTIES"
        public void setNumber(int numer){
            this.numer = numer; 
        }

        public void setKennitala(string kennitala)
        {
            this.kennitala = kennitala; 
        }

        public void setByrja(string byrja)
        {
            this.byrja = byrja; 
        }

        public void setEndir(string endir)
        {
            this.endir = endir;
        }

        public void setTimiByrja(string timi_byrja)
        {
            this.timi_byrja = timi_byrja;
        }

        public void setTimiEndir(string timi_endir)
        {
            this.timi_endir = timi_endir;
        }

        public void setVettvangur(string vettvangur)
        {
            this.vettvangur = vettvangur; 
        }

        public int getNumber()
        {
            return numer;
        }

        public string getByrja()
        {
            return byrja;     
        }

        public string getEndir()
        {
            return endir;
        }

        public string getVettvangur()
        {
            return vettvangur;
        }
        #endregion 
    
        #region "Functions"
       
        #region "Opna neyðarsimi"
        public int getRok(int nr)
        {
            string sqlString = "SELECT OFF FROM VINNA WHERE NR = '" + nr + "';";
            clsDatabase.GetRecord(sqlString);

            while (reader.Read())
            {
                bool_vinna_check = Int32.Parse(reader["OFF"].ToString());
            }

            return bool_vinna_check;
        }
        #endregion

        #region "Skra neyðarsimi" 
        public void SkraVinnaNeydarsimi()
        {
            SkraNeydarsimi();
            SkraVinna(); 
        }

        public void SkraNeydarsimi()
        {
            string sqlString = "INSERT INTO NEYDARSIMI(BYRJA,ENDIR, TIMI_BYRJA, TIMI_ENDIR,TEGUND) VALUES('" + byrja + "','" + endir + "','" + timi_byrja + "','" + timi_endir + "','" + vettvangur + "');";
            clsDatabase.ExcuteQuery(sqlString); 
        }

        public void SkraVinna()
        {
            verk = 1; 
            string sqlString = "INSERT INTO VINNA(KT,OFF) VALUES('" + kennitala + "','" + verk + "') ;";
            clsDatabase.ExcuteQuery(sqlString); 
        }
        #endregion

        #region "Hlaða neyðarsimi"
        public void virkjaDagur()
        {
            dt = DateTime.Now;
            day_DateTime_Now = dt.Day;
            month_DateTime_Now = dt.Month;
            year_DateTime_Now = dt.Year;
        }

        public void skiptaDagurInteger(string byrja_)
        {
            dagur = byrja_.Split('.');
            day = Int32.Parse(dagur[0]);
            month = dagur[1];
            year = Int32.Parse(dagur[2]);
        }

        public void writeMonthInInteger()
        {
            if (month.Equals("janúar")) { month_string = 1; }
            if (month.Equals("febrúar")) { month_string = 2; }
            if (month.Equals("mars")) { month_string = 3; }
            if (month.Equals("apríl")) { month_string = 4; }
            if (month.Equals("maí")) { month_string = 5; }
            if (month.Equals("júní")) { month_string = 6; }
            if (month.Equals("júlí")) { month_string = 7; }
            if (month.Equals("ágúst")) { month_string = 8; }
            if (month.Equals("september")) { month_string = 9; }
            if (month.Equals("október")) { month_string = 10; }
            if (month.Equals("nóvember")) { month_string = 11; }
            if (month.Equals("desember")) { month_string = 12; }
        }

        public void HladaNeydarsimi(ListView listView1, string byrja)
        {
            numer = 0; 
            virkjaDagur(); 
            listView1.Items.Clear();

            string sqlString = "SELECT VINNA.OFF, NEYDARSIMI.NR, TULKUR.NAFN, NEYDARSIMI.BYRJA, NEYDARSIMI.ENDIR, NEYDARSIMI.TIMI_BYRJA, NEYDARSIMI.TIMI_ENDIR, NEYDARSIMI.TEGUND FROM TULKUR, VINNA, NEYDARSIMI WHERE TULKUR.KT=VINNA.KT AND VINNA.NR=NEYDARSIMI.NR ORDER BY NEYDARSIMI.NR DESC;";
            clsDatabase.GetRecord(sqlString);

            while (reader.Read())
            {
                numer++;
               
                list = new ListViewItem( reader["NR"].ToString() );
                bool_vinna = Int32.Parse(reader["OFF"].ToString());
                list.SubItems.Add(reader["NAFN"].ToString());
                skiptaDagurInteger( reader["BYRJA"].ToString() );
                writeMonthInInteger();
                //------------------------------------------------------------
                if (bool_vinna == 1)
                {
                    if (month_DateTime_Now <= month_string && year_DateTime_Now <= year)
                    {
                        if (day_DateTime_Now <= day || month_DateTime_Now < month_string)
                        {
                            list.BackColor = System.Drawing.Color.Gold;
                            list.SubItems.Add(reader["BYRJA"].ToString());
                        }
                        else
                        {
                            list.BackColor = System.Drawing.Color.Firebrick;
                            list.SubItems.Add(reader["BYRJA"].ToString());
                        }
                    }
                    else
                    {
                        list.BackColor = System.Drawing.Color.Firebrick;
                        list.SubItems.Add(reader["BYRJA"].ToString());
                    }
                }
                else
                {
                    list.BackColor = System.Drawing.Color.LightSlateGray;
                    list.SubItems.Add(reader["BYRJA"].ToString());
                }
                //------------------------------------------------------------
                list.SubItems.Add( reader["ENDIR"].ToString()) ; 
                list.SubItems.Add(reader["TIMI_BYRJA"].ToString());
                list.SubItems.Add(reader["TIMI_ENDIR"].ToString());
                list.SubItems.Add(reader["TEGUND"].ToString());

                listView1.Items.Add(list);               
            }
            reader.Close();
        }
        #endregion

        #region "Breyting" 
        //------------------------------//
        // Skipta                       // 
        //------------------------------//
        public void skiptaUmTulk()
        {
            afskraVinna();
            afritaNeydarsimi();
        }

        public void afskraVinna()
        {
            string sqlString = "UPDATE VINNA SET OFF = '" + 0 + "'  WHERE NR = '" + numer + "' ;";
            clsDatabase.ExcuteQuery(sqlString);
        }

        public void afritaNeydarsimi()
        {
            SkraVinna();
            skraAfritaNeydarsimi();            
        }

        public void skraAfritaNeydarsimi()
        {
            string sqlString = "INSERT INTO NEYDARSIMI(BYRJA,ENDIR, TIMI_BYRJA, TIMI_ENDIR,TEGUND) VALUES('" + byrja + "','" + endir + "','" + timi_byrja + "','" + timi_endir + "','" + vettvangur + "');";
            clsDatabase.ExcuteQuery(sqlString);
        }

        //------------------------------//
        // Breyta                       //
        //------------------------------//
        public void breytaNeydarsimi()
        {
            string sqlString = "UPDATE NEYDARSIMI SET BYRJA = '" + byrja + "',  ENDIR = '" + endir + "', TIMI_BYRJA = '" + timi_byrja + "', TIMI_ENDIR = '" + timi_endir + "', TEGUND = '" + vettvangur + "' WHERE NR = '" + numer + "' ;";
            clsDatabase.ExcuteQuery(sqlString);
        }
        #endregion

        #endregion
    }
}
