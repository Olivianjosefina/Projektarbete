using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Vinlista.Models
{
    public class VinMetod
    {
        private string connectionString = "Data Source=localhost,1433;Database=OliviaDB;User Id=sa;Password=AAroh12345;";

        public List<Vin> GetVin()
        {
            List<Vin> vinList = new List<Vin>();

            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                String sqlstring = "SELECT * FROM Vin;";

                try
                {
                    dbConnection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlstring, dbConnection);
                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            Vin vin = new Vin
                            {
                                VinID = Convert.ToInt32(row["VinID"]),
                                VinNamn = row["VinNamn"].ToString(),
                                VinTyp = row["VinTyp"].ToString(),
                                Argang = Convert.ToInt32(row["Argang"]),
                                AlkoholHalt = Convert.ToSingle(row["AlkoholHalt"]),
                                Producent = row["Producent"].ToString(),
                                Land = row["Land"].ToString(),
                                BildNamn = row["BildNamn"].ToString(),
                                VinFarg = row["VinFarg"].ToString(),
                                Pris = Convert.ToInt32(row["Pris"])
                            };

                            vinList.Add(vin);
                        }
                    }

                    return vinList;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public (Vin, string) GetVinById(int vinID)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                String sqlString = "SELECT * FROM Vin WHERE VinID = @vinID;";
                SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);
                dbCommand.Parameters.Add("vinID", SqlDbType.Int).Value = vinID;

                try
                {
                    dbConnection.Open();
                    SqlDataReader reader = dbCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        Vin vin = new Vin
                        {
                            VinID = Convert.ToInt32(reader["VinID"]),
                            VinNamn = reader["VinNamn"].ToString(),
                            VinTyp = reader["VinTyp"].ToString(),
                            Argang = Convert.ToInt32(reader["Argang"]),
                            AlkoholHalt = Convert.ToSingle(reader["AlkoholHalt"]),
                            Producent = reader["Producent"].ToString(),
                            Land = reader["Land"].ToString(),
                            BildNamn = reader["BildNamn"].ToString(),
                            VinFarg = reader["VinFarg"].ToString(),
                            Pris = Convert.ToInt32(reader["Pris"])
                        };

                        return (vin, "");
                    }

                    return (null, "Vinet hittades inte.");
                }
                catch (Exception e)
                {
                    return (null, e.Message);
                }
            }
        }

        public int InsertVin(Vin vin, out string errormsg)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                String sqlString = "INSERT INTO Vin (VinNamn, VinTyp, Argang, AlkoholHalt, Producent, Land, BildNamn, VinFarg, Pris) " +
                                   "VALUES (@VinNamn, @VinTyp, @Argang, @AlkoholHalt, @Producent, @Land, @BildNamn, @VinFarg, @Pris);";

                SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

                dbCommand.Parameters.Add("VinNamn", SqlDbType.NVarChar, 255).Value = vin.VinNamn;
                dbCommand.Parameters.Add("VinTyp", SqlDbType.NVarChar, 255).Value = vin.VinTyp;
                dbCommand.Parameters.Add("Argang", SqlDbType.Int).Value = vin.Argang;
                dbCommand.Parameters.Add("AlkoholHalt", SqlDbType.Float).Value = vin.AlkoholHalt;
                dbCommand.Parameters.Add("Producent", SqlDbType.NVarChar, 255).Value = vin.Producent;
                dbCommand.Parameters.Add("Land", SqlDbType.NVarChar, 255).Value = vin.Land;
                dbCommand.Parameters.Add("BildNamn", SqlDbType.NVarChar, 255).Value = vin.BildNamn;
                dbCommand.Parameters.Add("VinFarg", SqlDbType.NVarChar, 50).Value = vin.VinFarg;
                dbCommand.Parameters.Add("Pris", SqlDbType.Int).Value = vin.Pris;

                try
                {
                    dbConnection.Open();
                    int i = dbCommand.ExecuteNonQuery();
                    if (i == 1) { errormsg = ""; }
                    else { errormsg = "Det skapas inte en användare i databasen."; }
                    return i;
                }
                catch (Exception e)
                {
                    errormsg = e.Message;
                    return 0;
                }
            }
        }

        public int UpdateVin(int vinID, Vin vin, out string errormsg)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                String sqlString = "UPDATE Vin SET VinNamn = @VinNamn, VinTyp = @VinTyp, Argang = @Argang, AlkoholHalt = @AlkoholHalt, Producent = @Producent, Land = @Land, BildNamn = @BildNamn, VinFarg = @VinFarg, Pris = @Pris WHERE VinID = @vinID;";

                SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);
                dbCommand.Parameters.Add("vinID", SqlDbType.Int).Value = vinID;
                dbCommand.Parameters.Add("VinNamn", SqlDbType.NVarChar, 255).Value = vin.VinNamn ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("VinTyp", SqlDbType.NVarChar, 255).Value = vin.VinTyp ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("Argang", SqlDbType.Int).Value = vin.Argang != null ? (object)vin.Argang : DBNull.Value;
                dbCommand.Parameters.Add("AlkoholHalt", SqlDbType.Float).Value = vin.AlkoholHalt != null ? (object)vin.AlkoholHalt : DBNull.Value;
                dbCommand.Parameters.Add("Producent", SqlDbType.NVarChar, 255).Value = vin.Producent ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("Land", SqlDbType.NVarChar, 255).Value = vin.Land ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("BildNamn", SqlDbType.NVarChar, 255).Value = vin.BildNamn ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("VinFarg", SqlDbType.NVarChar, 255).Value = vin.VinFarg ?? (object)DBNull.Value;
                dbCommand.Parameters.Add("Pris", SqlDbType.Int).Value = vin.Pris != null ? (object)vin.Pris : DBNull.Value;

                try
                {
                    dbConnection.Open();
                    int i = dbCommand.ExecuteNonQuery();
                    if (i == 1)
                    {
                        errormsg = "";
                    }
                    else
                    {
                        errormsg = "Vinuppgifterna uppdaterades inte.";
                    }
                    return i;
                }
                catch (Exception e)
                {
                    errormsg = e.Message;
                    return 0;
                }
            }
        }

        public int DeleteVin(int vinID, out string errormsg)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                String sqlString = "DELETE FROM Vin WHERE VinID = @vinID;";

                SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);
                dbCommand.Parameters.Add("vinID", SqlDbType.Int).Value = vinID;

                try
                {
                    dbConnection.Open();
                    int i = dbCommand.ExecuteNonQuery();
                    if (i == 1)
                    {
                        errormsg = "";
                    }
                    else
                    {
                        errormsg = "Vinet togs inte bort.";
                    }
                    return i;
                }
                catch (Exception e)
                {
                    errormsg = e.Message;
                    return 0;
                }
            }
        }
    }
}
