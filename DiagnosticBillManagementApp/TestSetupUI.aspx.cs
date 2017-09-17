using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DiagnosticBillManagementApp
{
    public partial class TestSetupUi : System.Web.UI.Page
    {

        string connectionString = "Server=NOBIN;Database=DiagnosticBillManagementDB; Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            FillDrop();
        }

        private void FillDrop()
        {
            TestTypeDropDownList.DataSource = GetUserData();
            TestTypeDropDownList.DataTextField = "TypeName";
            TestTypeDropDownList.DataValueField = "TypeName";
            TestTypeDropDownList.DataBind();
        }

        private DataTable GetUserData()
        {
            SqlConnection connection=new SqlConnection(connectionString);

            SqlCommand command=new SqlCommand("getTestTypeName",connection);

            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter=new SqlDataAdapter(command);

            DataTable dataTable=new DataTable();

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        private void ShowTestSetup()
        {
            List<TestSetup> testSetups = ShowAllTestSetup();

            testSetupGridView.DataSource = testSetups;
            testSetupGridView.DataBind();
        }

        private List<TestSetup> ShowAllTestSetup()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM tbl_TestSetup";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestSetup> testSetups = new List<TestSetup>();

            while (reader.Read())
            {
                TestSetup testSetup = new TestSetup();
                testSetup.ID = (int) reader["ID"];
                testSetup.TestName = reader["TestName"].ToString();
                testSetup.Fee = reader["Fee"].ToString();
                testSetup.TestType = reader["TestType"].ToString();
                testSetups.Add(testSetup);
            }
            reader.Close();
            connection.Close();
            return testSetups;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestSetup testSetup = new TestSetup();

            testSetup.TestName = testTextBox.Text;
            testSetup.Fee=feeTextBox.Text;
            testSetup.TestType =TestTypeDropDownList.Text;



            int rowAffected = InsertTestSetup(testSetup);

            testTextBox.Text = "";
            feeTextBox.Text = "";
           


            if (rowAffected>0)
            {
                msgLabel.Text = "Save Successfully";
                ShowAllTestSetup();
              
                ShowTestSetup();
            }
            else
            {
                msgLabel.Text = "Save failed";
            }
        }

        private int InsertTestSetup(TestSetup testSetup)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO tbl_TestSetup VALUES('" + testSetup.TestName + "','" + testSetup.Fee + "','" +
                           testSetup.TestType + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }


      
        
    }
}