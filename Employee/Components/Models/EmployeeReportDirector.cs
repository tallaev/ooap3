namespace Reporter
{
    public class EmployeeReportDirector
    {
        private readonly IEmployeeReportBuilder _builder;

        public EmployeeReportDirector(IEmployeeReportBuilder builder)
        {
            _builder = builder;
        }

        public void Build()
        {
            _builder
                .BuildHeader()
                .BuildBody()
                .BuildFooter();
        }

        public void BuildExtraPaid()
        {
            _builder
                .BuildHeader()
                .BuildExtraPaidBody()
                .BuildExtraPaidFooter();
        }
    }
}
