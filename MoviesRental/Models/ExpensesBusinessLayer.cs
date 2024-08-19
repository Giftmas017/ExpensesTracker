using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MoviesRental.Models
{
    // Business rules and validation / data access code
    // ADO.NET CODE
    public class ExpensesBusinessLayer
    {
        public IEnumerable<Expenses> Expenses
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<Expenses> expenses = new List<Expenses>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllExpenses", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Expenses expenses1 = new Expenses();
                        expenses1.Id = Convert.ToInt32(rdr["Id"]);
                        expenses1.Value = Convert.ToInt32(rdr["Value"]);
                        expenses1.Description = Convert.ToString(rdr["Description"]);

                        expenses.Add(expenses1);
                    }
                }
                return expenses;

            }
        }
        // method to save all expenses data
        public void AddExpenses(Expenses expenses)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramValue = new SqlParameter();
                paramValue.ParameterName = "@Value";
                paramValue.Value = expenses.Value;
                cmd.Parameters.Add(paramValue);

                SqlParameter paramDescription = new SqlParameter();
                paramDescription.ParameterName = "@Description";
                paramDescription.Value = expenses.Description;
                cmd.Parameters.Add(paramDescription);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}