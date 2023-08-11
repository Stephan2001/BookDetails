using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace BookDetails
{
   
    public partial class frmBook : System.Web.UI.Page
    {
        static string connString = "Data source = lab000000\\SQLEXPRESS; Initial Catalog = BooksDB; " +
            " Integrated Security = true;";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;
        public int updateISBN = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            ddlStatus.Items.Add("Available");
            ddlStatus.Items.Add("out-of-stock");

            GetAuthors();

            if (!IsPostBack)
            {
                GetBooks();
            }
        }

        public void GetAuthors()
        {
            dbConn.Open();

            string sql = "SELECT AuthorID, AuthorName FROM tblAuthor;";

            dbComm = new SqlCommand(sql, dbConn);

            dbAdapter = new SqlDataAdapter(dbComm);

            dt = new DataTable();
            dbAdapter.Fill(dt);

            ddlAuthor.DataSource = dt;
            ddlAuthor.DataTextField = "Name";
            ddlAuthor.DataValueField = "AuthorID";
            ddlAuthor.DataBind();
            dbConn.Close();
        }

        public void GetBooks()
        {
            dbConn.Open();
            string query = "SELECT * FROM tblBook";
            dbComm = new SqlCommand(query, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvDisplay.DataSource = dt;
            dgvDisplay.DataBind();
            dbConn.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            string query = "Insert into tblBook(Title, Edition, Publisher, AuthorID, Price, Status) Values(@Title,@Edition,@Publisher,@AuthorID, @Price, @Status)";
            dbComm = new SqlCommand(query, dbConn);
            dbComm.Parameters.AddWithValue("@Title", txtTitle.Text);
            dbComm.Parameters.AddWithValue("@Edition", txtEdition.Text);
            dbComm.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
            dbComm.Parameters.AddWithValue("@AuthoIDr", ddlAuthor.SelectedIndex+1);
            dbComm.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
            dbComm.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            if (x > 0)
            {
                GetBooks();
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            GetBooks();
        }

        protected void btnID_Click(object sender, EventArgs e)
        {
            Button btnID = (Button)sender;

            int studentID = int.Parse(btnID.CommandArgument.ToString());


            dbConn.Open();

            string query = "SELECT * FROM Student WHERE StudentID = @StudentID; ";

            dbComm = new SqlCommand(query, dbConn);
            dbComm.Parameters.AddWithValue("@StudentID", studentID);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            txtEdition.Enabled = false;
            txtTitle.Enabled = false;
            txtPublisher.Enabled = false;

            txtEdition.Text = dt.Rows[0]["Edition"].ToString();
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            txtPublisher.Text = dt.Rows[0]["Publisher"].ToString();
            updateISBN = int.Parse(dt.Rows[0]["ISBN"].ToString());
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string query = "UPDATE tblBook SET Price = @Price, Status = @Status WHERE " +
                "ISBN = @ISBN;";
            dbComm = new SqlCommand(query, dbConn);

            dbComm.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
            dbComm.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
            dbComm.Parameters.AddWithValue("@ISBN", updateISBN);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            if (x > 0)
            {
                GetBooks();
            }
        }
    }
}