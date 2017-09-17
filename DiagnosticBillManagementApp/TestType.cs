namespace DiagnosticBillManagementApp
{
    public class TestType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
    }

    public class TestSetup
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public string Fee { get; set; }
        public string TestType { get; set; }

    }
}