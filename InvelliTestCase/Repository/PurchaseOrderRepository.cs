using InvelliTestCaseWebAPI.Models;
using InvelliTestCaseWebAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Repository
{
    public class PurchaseOrderRepository
    {
         private string _connectionString;

         public PurchaseOrderRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        }

         public List<PurchaseOrderViewModel> GetAllPurchaseOrders()
        {
            List<PurchaseOrderViewModel> purchaseOrders = new List<PurchaseOrderViewModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllPurchaseOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        purchaseOrders.Add(new PurchaseOrderViewModel
                        {
                            ID = (Guid)dr["ID"],
                            Code = Convert.ToString(dr["Code"]),
                            PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"]),
                            SupplierCode = Convert.ToString(dr["SupplierCode"]),
                            SupplierName = Convert.ToString(dr["SupplierName"]),
                            Remarks = Convert.ToString(dr["Remarks"])
                        });
                    }
                }
            }

            return purchaseOrders;
        }

        public PurchaseOrderViewModel GetPurchaseOrder(Guid id)
        {
            PurchaseOrderViewModel purchaseOrder = new PurchaseOrderViewModel();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPurchaseOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchaseOrder.ID = (Guid)reader["ID"];
                            purchaseOrder.Code = Convert.ToString(reader["Code"]);
                            purchaseOrder.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]);
                            purchaseOrder.SupplierCode = Convert.ToString(reader["SupplierCode"]);
                            purchaseOrder.SupplierName = Convert.ToString(reader["SupplierName"]);
                            purchaseOrder.Remarks = Convert.ToString(reader["Remarks"]);
                        }
                    }
                }
            }

            return purchaseOrder;
        }

        public PurchaseOrder GetPurchaseOrderWith(Guid id)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPurchaseOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchaseOrder.ID = (Guid)reader["ID"];
                            purchaseOrder.Code = Convert.ToString(reader["Code"]);
                            purchaseOrder.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]);
                            purchaseOrder.SupplierID = (Guid)reader["SupplierID"]; 
                            purchaseOrder.Remarks = Convert.ToString(reader["Remarks"]);
                        }
                    }
                }
            }

            return purchaseOrder;
        }

        public bool AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddPurchaseOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", purchaseOrder.Code);
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseOrder.PurchaseDate);
                    cmd.Parameters.AddWithValue("@SupplierID", purchaseOrder.SupplierID);
                    cmd.Parameters.AddWithValue("@Remarks", purchaseOrder.Remarks);

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

        public bool UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePurchaseOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", purchaseOrder.ID);
                    cmd.Parameters.AddWithValue("@Code", purchaseOrder.Code);
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseOrder.PurchaseDate);
                    cmd.Parameters.AddWithValue("@SupplierID", purchaseOrder.SupplierID);
                    cmd.Parameters.AddWithValue("@Remarks", purchaseOrder.Remarks);

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

        public bool DeletePurchaseOrder(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePurchaseOrder", con))
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