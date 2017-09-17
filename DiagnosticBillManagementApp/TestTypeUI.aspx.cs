using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DiagnosticBillManagementApp
{
    public partial class TestTypeUi : System.Web.UI.Page
    {
        string connectionString = "Server=NOBIN;Database=DiagnosticBillManagementDB; Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowTestType();
        }

        private void ShowTestType()
        {
            List<TestType> testTypes = GetAllTestTypes();

            testTypeGridView.DataSource = testTypes;
            testTypeGridView.DataBind();
        }

        private List<TestType> GetAllTestTypes()
        {
            SqlConnection connection = new SqlConnection(connectionString);

           // string query = "SELECT * FROM tbl_TestType";

            string query = "SELECT DISTINCT * FROM tbl_TestType;";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestType> testTypes = new List<TestType>();

            while (reader.Read())
            {
                TestType testType = new TestType();
                testType.ID = (int) reader["ID"];
                testType.TypeName = reader["TypeName"].ToString();
                testTypes.Add(testType);
            }
            reader.Close();
            connection.Close();
            return testTypes;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType testType=new TestType();

            testType.TypeName = testTypeTextBox.Text;

            InsertTestName(testType);
            ShowTestType();

            
        }

        private void InsertTestName(TestType testType)
        {
            try
            {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO tbl_TestType VALUES('" + testType.TypeName + "')";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception exception)
            {
                
                Response.Write("Alredy Exist");
            }
           
        }


        private TestType GetTestTypeName(string TypeName)
        {
            TestType testType=new TestType();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM tbl_TestType WHERE TypeName='"+testType.TypeName+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            testType = null;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                testType.TypeName = reader["TypeName"].ToString();
                reader.Close();
            }
            connection.Close();
            return testType;

        }

       

    }


}