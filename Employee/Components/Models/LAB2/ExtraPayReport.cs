using MudBlazor;

namespace Employee.Components.Models.LAB2
{
    public class ExtraPayReport : ReportBase
    {
        public ExtraPayReport(IEnumerable<Reporter.Employee> employees, DateRange dateRange) : base(employees, dateRange)
        {

        }

        public override void BuildBody()
        {
            Body =
                string.Join(Environment.NewLine,
                    _employees.Select(e =>
                    $"{e.Name} | <strong>{(e.IsExtraPaid ? "<span style=\"color: green\">Получил премию</span>" : "<span style=\"color: red\">Не получил</span>")}</strong> | {e.Payday.ToString("dd.MM.yyyy")}<br/>"));

        }

        public override void BuildFooter()
        {
            Footer =
                 "\n----------------------------------------------------------------------------------------------------\n<br/>";

            Footer +=
                $"\nВсего сотрудников: {_employees.Count()}, " +
                $"Процент премированых: <strong>{Math.Round(_employees.Where(x => x.IsExtraPaid).Count() / (double)_employees.Count() * 100, 2)}<span style=\"color: blue\">%</strong>";

        }
    }
}
