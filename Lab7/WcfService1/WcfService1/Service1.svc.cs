using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Library4;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Shipping;Integrated Security=True";
        public double F4(double x)
        {
            return KI3_Class_4.F4(x, 3);
        }
        public System.Data.DataSet GetAllMembers()
        {
            System.Data.DataSet data = new System.Data.DataSet();
            string select = "SELECT * FROM City";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(select, connectionString);
                ad.Fill(data);
            }
            return data;
        }
        public System.Data.DataSet GetMemberByID(int ID)
        {
            System.Data.DataSet data = new System.Data.DataSet();
            string select = "SELECT * FROM City where ID='" + ID + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(select, connectionString);
                ad.Fill(data);
            }
            return data;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
