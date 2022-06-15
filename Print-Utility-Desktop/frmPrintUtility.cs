using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Print_Utility_Core.Architecture.Data_Layer.Repositories;
using Print_Utility_Core.Architecture.Domain_Layer.Aggregates;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Print_Utility_Core.Architecture.Service_Layer.Utilities;
using Serilog;

namespace Print_Utility_Desktop
{
    public partial class frmPrintUtility : Form
    {
        private readonly ILogger logger;
        private readonly IDeviceRepository repository;
        private readonly IPrintManagerUtility utility;
        private readonly IOptions<ConfigurationModel> configuration;

        private IEnumerable<PrinterAggregate> printers;

        #region Constructor:

        public frmPrintUtility(IDeviceRepository repository, IPrintManagerUtility utility, IOptions<ConfigurationModel> configuration, ILogger logger)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.repository = repository;
            this.utility = utility;

            InitializeComponent();

            cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
            cmbFloor.SelectedIndexChanged += cmbFloor_SelectedIndexChanged;
            cmbPrinters.SelectedIndexChanged += cmbPrinters_SelectedIndexChanged;
        }

        #endregion

        private async void frmPrintUtility_Load(object sender, EventArgs e) => BindForm();

        private async Task<IEnumerable<PrinterAggregate>> GetDataSource() => await repository.GetAllPrinters();

        #region Populate Controls:

        private void PopulatePrintManager(IEnumerable<PrinterAggregate> printers)
        {
            var printer = printers.Where(printer => String.Compare(printer.Name, $"{cmbPrinters.SelectedItem}", true) == 0).FirstOrDefault();

            txtName.Text = printer?.Name;
            txtShare.Text = printer?.Share;
            txtDescription.Text = printer?.Description;
        }

        private void PopulateCmbPrinters(IEnumerable<PrinterAggregate> printers) => cmbPrinters.DataSource = printers
                .Where(properties => String.Compare(properties.Building, $"{cmbLocation.SelectedItem}", true) == 0 && String.Compare(properties.Floor, $"{cmbFloor.SelectedItem}", true) == 0)
                .Select(properties => $"{properties.Name}")
                .OrderBy(name => name)
                .ToList();

        #endregion

        private async void BindForm()
        {
            printers = await GetDataSource();

            cmbLocation.DataSource = printers.Select(properties => properties.Building).Distinct().OrderBy(name => name).ToList();
            cmbFloor.DataSource = printers.Select(properties => properties.Floor).Distinct().OrderBy(floor => floor).ToList();

            PopulateCmbPrinters(printers);
            PopulatePrintManager(printers);
        }

        private void RebindForm()
        {
            PopulateCmbPrinters(printers);
            PopulatePrintManager(printers);
        }

        #region Event Handlers:

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e) => RebindForm();

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e) => RebindForm();

        private void cmbPrinters_SelectedIndexChanged(object sender, EventArgs e) => PopulatePrintManager(printers);

        private void btnInstall_Click(object sender, EventArgs e)
        {
            var printer = printers.Where(printer => String.Compare(printer.Name, $"{cmbPrinters.SelectedItem}", true) == 0).First();
            var output = utility.AddPrinter(printer) == true ?
                MessageBox.Show("Successfully Added Printer...", "Information:", MessageBoxButtons.OK, MessageBoxIcon.Information) :
                MessageBox.Show("Failed To Add Printer...", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }   

        #endregion
    }
}