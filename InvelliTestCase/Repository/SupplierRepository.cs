using InvelliTestCaseWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Repository
{
    public class SupplierRepository
    {
        private string _connectionString;

        public SupplierRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllSuppliers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        suppliers.Add(new Supplier { ID = (Guid)dr["ID"], Code = Convert.ToString(dr["Code"]), Name = Convert.ToString(dr["Name"]), City = Convert.ToString(dr["City"]) });
                    }
                }
            }

            return suppliers;
        }

        public Supplier GetSupplier(Guid id)
        {
            Supplier supplier = new Supplier();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSupplier", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            supplier.ID = (Guid)reader["ID"];
                            supplier.Code = Convert.ToString(reader["Code"]);
                            supplier.Name = Convert.ToString(reader["Name"]);
                            supplier.City = Convert.ToString(reader["City"]);
                        }
                    }
                }
            }

            return supplier;
        }

        public bool AddSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddSupplier", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", supplier.Code);
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@City", supplier.City);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSupplier", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", supplier.ID);
                    cmd.Parameters.AddWithValue("@Code", supplier.Code);
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@City", supplier.City);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool DeleteSupplier(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSupplier", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}