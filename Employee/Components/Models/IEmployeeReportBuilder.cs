namespace Reporter
{
    public interface IEmployeeReportBuilder
    {
        IEmployeeReportBuilder BuildHeader();

        IEmployeeReportBuilder BuildBody();
        IEmployeeReportBuilder BuildExtraPaidBody();
        IEmployeeReportBuilder BuildFooter();
        IEmployeeReportBuilder BuildExtraPaidFooter();

        EmployeeReport GetReport();
    }
}
