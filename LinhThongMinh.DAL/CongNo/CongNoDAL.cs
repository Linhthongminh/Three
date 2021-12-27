using LinhThongMinh.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhThongMinh.DAL.CongNo
{
    public class CongNoDAL : DBConnection
    {
        public List<CongNoDTO> ReadCongNo()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CongNo", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<CongNoDTO> congNos = new List<CongNoDTO>();
            while (reader.Read())
            {
                CongNoDTO customer = new CongNoDTO();
                customer.ID = int.Parse(reader["code"].ToString());
                customer.Name = reader["name"].ToString();
                customer.PhoneNumber = reader["phone_number"].ToString();
                customer.AmountOwed = decimal.Parse(reader["amount_owed"].ToString());
                congNos.Add(customer);
            }
            conn.Close();
            return congNos;
        }

        public void Save(CongNoDTO congNo)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update CongNo set name = @name where code = @code", conn);
            cmd.Parameters.Add(new SqlParameter("@code", congNo.ID));
            cmd.Parameters.Add(new SqlParameter("@name", congNo.Name));
            cmd.Parameters.Add(new SqlParameter("@phone_number", congNo.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@amount_owed", congNo.AmountOwed));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(CongNoDTO congNo)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sqDeleteStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@code", congNo.ID));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something was wrong!" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Edit(CongNoDTO congNo)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sqUpdateStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@code", congNo.ID));
                cmd.Parameters.Add(new SqlParameter("@name", congNo.Name));
                cmd.Parameters.Add(new SqlParameter("@phone_number", congNo.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@amount_owed", congNo.AmountOwed));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something was wrong!" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void New(CongNoDTO congNo)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sqInsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@code", congNo.ID));
                cmd.Parameters.Add(new SqlParameter("@name", congNo.Name));
                cmd.Parameters.Add(new SqlParameter("@phone_number", congNo.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@amount_owed", congNo.AmountOwed));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something was wrong!" + e);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
