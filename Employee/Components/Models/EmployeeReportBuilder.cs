using MudBlazor;

namespace Reporter
{
    public class EmployeeReportBuilder : IEmployeeReportBuilder
    {
        private EmployeeReport _employeeReport;
        private DateRange _dateRange;
        private readonly IEnumerable<Employee> _employees;

        public EmployeeReportBuilder(IEnumerable<Employee> employees, DateRange dateRange)
        {
            _employees = employees.Where(x => x.Payday >= dateRange.Start.Value && x.Payday <= dateRange.End.Value);
            _dateRange = dateRange;
            _employeeReport = new();
        }

        public IEmployeeReportBuilder BuildHeader()
        {
            _employeeReport.Header =
                $"Отчет за период: <strong>{_dateRange.Start.Value.ToString("dd.MM.yyyy")} ---- {_dateRange.End.Value.ToString("dd.MM.yyyy")}</strong>\n <br/>";

            _employeeReport.Header +=
                "\n----------------------------------------------------------------------------------------------------\n";

            return this;
        }

        public IEmployeeReportBuilder BuildBody()
        {
            _employeeReport.Body =
                string.Join(Environment.NewLine,
                    _employees.Select(e =>
                    $"{e.Name} | <strong>{e.Salary}<span style=\"color: green\">$</span></strong> | {e.Payday.ToString("dd.MM.yyyy")}<br/>"));

            return this;
        }
        public IEmployeeReportBuilder BuildExtraPaidBody()
        {
            _employeeReport.Body =
                string.Join(Environment.NewLine,
                    _employees.Select(e =>
                    $"{e.Name} | <strong>{(e.IsExtraPaid ? "<span style=\"color: green\">Получил премию</span>" : "<span style=\"color: red\">Не получил</span>")}</strong> | {e.Payday.ToString("dd.MM.yyyy")}<br/>"));

            return this;
        }

        public IEmployeeReportBuilder BuildFooter()
        {
            _employeeReport.Footer =
                "\n----------------------------------------------------------------------------------------------------\n<br/>";

            _employeeReport.Footer +=
                $"\nВсего сотрудников: {_employees.Count()}, " +
                $"Итого выплачен: <strong>{_employees.Sum(e => e.Salary)}<span style=\"color: green\">$</span></strong>";

            return this;
        }

        public IEmployeeReportBuilder BuildExtraPaidFooter()
        {
            _employeeReport.Footer =
                "\n----------------------------------------------------------------------------------------------------\n<br/>";

            _employeeReport.Footer +=
                $"\nВсего сотрудников: {_employees.Count()}, " +
                $"Процент премированых: <strong>{Math.Round((double)_employees.Where(x => x.IsExtraPaid).Count() / (double)_employees.Count() * 100, 2)}<span style=\"color: blue\">%</strong>";

            return this;
        }

        public EmployeeReport GetReport()
        {
            EmployeeReport employeeReport = _employeeReport;

            _employeeReport = new();

            return employeeReport;
        }        
    }
}
