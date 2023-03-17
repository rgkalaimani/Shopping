using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


namespace DBLayer
{
    public class ShoppingDatabase
    {
               
        public DataSet ExecuteProcedure(string procedureName, List<KeyValuePair<string, string>> parameters = null)
        {
            DataSet resultData = new DataSet();
            SqlDataAdapter da;
            SqlCommand cmd;
            try
            {
                string connStr = WebConfigurationManager.AppSettings["connection"].ToString();
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    cmd = new SqlCommand(procedureName, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, string> item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    da = new SqlDataAdapter(cmd);
                    da.Fill(resultData);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return resultData;
        }
    }
}
