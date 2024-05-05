using MudBlazor;
using Reporter;

namespace Employee.Components.Models.LAB2
{
    public class SalaryReport : ReportBase
    {
        public SalaryReport(IEnumerable<Reporter.Employee> employees, DateRange dateRange) : base(employees, dateRange)
        {

        }

        public override void BuildBody()
        {
            Body =
                string.Join(Environment.NewLine,
                    _employees.Select(e =>
                    $"{e.Name} | <strong>{e.Salary}<span style=\"color: green\">$</span></strong> | {e.Payday.ToString("dd.MM.yyyy")}<br/>"));

        }

        public override void BuildFooter()
        {
            Footer =
                    "\n----------------------------------------------------------------------------------------------------\n<br/>";

            Footer +=
                $"\nВсего сотрудников: {_employees.Count()}, " +
            $"Итого выплачен: <strong>{_employees.Sum(e => e.Salary)}<span style=\"color: green\">$</span></strong>";
        }
    }
}
