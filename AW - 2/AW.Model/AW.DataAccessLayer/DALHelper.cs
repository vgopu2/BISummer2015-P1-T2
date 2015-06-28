using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


namespace AW.DataAccessLayer
{
    public static class DALHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["RentACarIntegratedCS"].ConnectionString;
            }
        }
        public static int ExecuteNonQuerySP(string spName, Hashtable spParams)
        {
            int retVal;
            try
            {
                // Open the connection
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // 1. create a command object identifying
                    // the stored procedure
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    // 2. set the command object so it knows
                    // to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which
                    // will be passed to the stored procedure
                    foreach (DictionaryEntry spParam in spParams)
                    {
                        cmd.Parameters.Add(new SqlParameter(spParam.Key.ToString(), spParam.Value));
                    }

                    retVal = cmd.ExecuteNonQuery();

                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static Object ExecuteScalarSP(string spName, Hashtable spParams)
        {
            Object retVal;
            try
            {
                // Open the connection
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // 1. create a command object identifying
                    // the stored procedure
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    // 2. set the command object so it knows
                    // to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which
                    // will be passed to the stored procedure
                    foreach (DictionaryEntry spParam in spParams)
                    {
                        cmd.Parameters.Add(new SqlParameter(spParam.Key.ToString(), spParam.Value));
                    }

                    retVal = cmd.ExecuteScalar();

                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static DataSet GetDataset(string sqlQuery)
        {
            // Open the connection in a try/catch block.  
            // Create and execute the DataReader, writing the result 
            // set to the console window. 
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "ResultDS");
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static IDataReader GetDataReader(string sqlQuery)
        {

            //using (SqlConnection connection =
            //       new SqlConnection(ConnectionString))
            //   {


            // Open the connection in a try/catch block.  
            // Create and execute the DataReader, writing the result 
            // set to the console window. 
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }   }
}