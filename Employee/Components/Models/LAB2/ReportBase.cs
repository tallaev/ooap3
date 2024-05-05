using MudBlazor;
using Reporter;
using System.Text;

namespace Employee.Components.Models.LAB2
{
    public abstract class ReportBase
    {
        public string Header { get; set; }

        public string Body { get; set; }

        public string Footer { get; set; }

        protected DateRange _dateRange;
        protected readonly IEnumerable<Reporter.Employee> _employees;

        public ReportBase(IEnumerable<Reporter.Employee> employees, DateRange dateRange)
        {
            _employees = employees.Where(x => x.Payday >= dateRange.Start.Value && x.Payday <= dateRange.End.Value);
            _dateRange = dateRange;
        }

        public virtual void BuildHeader()
        {
            Header =
                $"Отчет за период: <strong>{_dateRange.Start.Value.ToString("dd.MM.yyyy")} ---- {_dateRange.End.Value.ToString("dd.MM.yyyy")}</strong>\n <br/>";

            Header +=
                "\n----------------------------------------------------------------------------------------------------<br/>";
        }

        public virtual void BuildBody()
        {
            Body = "************************************************************************\n";
        }

        public virtual void BuildFooter()
        {
            Footer = "************************************************************************\n";
        }

        public void BuildCompletedReport()
        {
            BuildHeader();
            BuildBody();
            BuildFooter();
        }

        public override string ToString() =>
            new StringBuilder()
            .Append(Header)
            .Append(Body)
            .Append(Footer)
            .ToString();
    }
}
