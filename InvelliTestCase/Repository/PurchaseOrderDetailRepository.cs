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
    public class PurchaseOrderDetailRepository
    {
        private string _connectionString;

        public PurchaseOrderDetailRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        }

        public List<PurchaseOrderDetailViewModel> GetAllPurchaseOrderDetails()
        {
            List<PurchaseOrderDetailViewModel> purchaseOrderDetails = new List<PurchaseOrderDetailViewModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllPurchaseOrderDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        purchaseOrderDetails.Add(new PurchaseOrderDetailViewModel
                        {
                            ID = (Guid)dr["ID"],
                            PurchaseOrderCode = Convert.ToString(dr["PurchaseOrderCode"]),
                            ProductCode = Convert.ToString(dr["ProductCode"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            UnitPrice = Convert.ToDecimal(dr["UnitPrice"])
                        });
                    }
                }
            }

            return purchaseOrderDetails;
        }

        public PurchaseOrderDetailViewModel GetPurchaseOrderDetail(Guid id)
        {
            PurchaseOrderDetailViewModel purchaseOrderDetail = new PurchaseOrderDetailViewModel();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPurchaseOrderDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchaseOrderDetail.ID = (Guid)reader["ID"];
                            purchaseOrderDetail.PurchaseOrderCode = Convert.ToString(reader["PurchaseOrderCode"]);
                            purchaseOrderDetail.ProductCode = Convert.ToString(reader["ProductCode"]);
                            purchaseOrderDetail.ProductName = Convert.ToString(reader["ProductName"]);
                            purchaseOrderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                            purchaseOrderDetail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                        }
                    }
                }
            }

            return purchaseOrderDetail;
        }

        public PurchaseOrderDetail GetPurchaseOrderDetailWith(Guid id)
        {
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPurchaseOrderDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchaseOrderDetail.ID = (Guid)reader["ID"];
                            purchaseOrderDetail.PurchaseOrderId = (Guid)reader["PurchaseOrderId"];
                            purchaseOrderDetail.ProductID = (Guid)reader["ProductID"];
                            purchaseOrderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                            purchaseOrderDetail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                        }
                    }
                }
            }

            return purchaseOrderDetail;
        }

        public bool AddPurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddPurchaseOrderDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);
                    cmd.Parameters.AddWithValue("@ProductID", purchaseOrderDetail.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", purchaseOrderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", purchaseOrderDetail.UnitPrice);

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

        public bool UpdatePurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePurchaseOrderDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", purchaseOrderDetail.ID);
                    cmd.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);
                    cmd.Parameters.AddWithValue("@ProductID", purchaseOrderDetail.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", purchaseOrderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", purchaseOrderDetail.UnitPrice);

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

        public bool DeletePurchaseOrderDetail(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePurchaseOrderDetail", con))
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