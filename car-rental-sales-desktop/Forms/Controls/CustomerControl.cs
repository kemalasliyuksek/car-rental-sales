using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using FontAwesome.Sharp;
using static Syncfusion.Windows.Forms.Tools.NavigationView;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class CustomerControl : UserControl
    {
        private CustomerRepository _customerRepository;
        private List<Customer> _customers;

        public CustomerControl()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();

            // Set up the control
            Load += CustomerControl_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            // Setup buttons
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnInfo.Click += BtnInfo_Click;

            // Setup grid events
            dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            UpdateUI();
        }

        public void LoadCustomers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _customers = _customerRepository.GetAll();
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = _customers;
                FormatDataGrid();
                lblTotalCustomers.Text = $"Total Customers: {_customers.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormatDataGrid()
        {
            if (dgvCustomers.Columns.Count == 0) return;

            // Configure columns to display
            dgvCustomers.Columns["CustomerID"].Visible = false;
            dgvCustomers.Columns["IsAvailable"].Visible = false;
            dgvCustomers.Columns["Rentals"].Visible = false;
            dgvCustomers.Columns["Sales"].Visible = false;
            dgvCustomers.Columns["Payments"].Visible = false;

            // Rename columns for better readability
            dgvCustomers.Columns["FirstName"].HeaderText = "First Name";
            dgvCustomers.Columns["LastName"].HeaderText = "Last Name";
            dgvCustomers.Columns["NationalID"].HeaderText = "National ID";
            dgvCustomers.Columns["DateOfBirth"].HeaderText = "Date of Birth";
            dgvCustomers.Columns["PhoneNumber"].HeaderText = "Phone Number";
            dgvCustomers.Columns["CountryCode"].HeaderText = "Country Code";
            dgvCustomers.Columns["LicenseNumber"].HeaderText = "License Number";
            dgvCustomers.Columns["LicenseClass"].HeaderText = "License Class";
            dgvCustomers.Columns["LicenseDate"].HeaderText = "License Date";
            dgvCustomers.Columns["RegistrationDate"].HeaderText = "Registration Date";
            dgvCustomers.Columns["CustomerType"].HeaderText = "Customer Type";

            // Set column widths
            dgvCustomers.Columns["FirstName"].Width = 100;
            dgvCustomers.Columns["LastName"].Width = 100;
            dgvCustomers.Columns["NationalID"].Width = 120;
            dgvCustomers.Columns["Email"].Width = 150;
            dgvCustomers.Columns["PhoneNumber"].Width = 120;
            dgvCustomers.Columns["Address"].Width = 200;

            // Set date time format
            if (dgvCustomers.Columns["DateOfBirth"] is DataGridViewTextBoxColumn dobColumn)
                dobColumn.DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvCustomers.Columns["LicenseDate"] is DataGridViewTextBoxColumn licenseColumn)
                licenseColumn.DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvCustomers.Columns["RegistrationDate"] is DataGridViewTextBoxColumn regColumn)
                regColumn.DefaultCellStyle.Format = "dd/MM/yyyy";

            // Set other dgv properties
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;

            // Alternate row colors
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvCustomers.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 76, 143);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dgvCustomers.DataSource = _customers;
                lblTotalCustomers.Text = $"Total Customers: {_customers.Count}";
                return;
            }

            var searchTerm = txtSearch.Text.ToLower();
            var filteredCustomers = _customers.Where(c =>
                c.FirstName.ToLower().Contains(searchTerm) ||
                c.LastName.ToLower().Contains(searchTerm) ||
                c.NationalID.ToLower().Contains(searchTerm) ||
                c.PhoneNumber.ToLower().Contains(searchTerm) ||
                (c.Email != null && c.Email.ToLower().Contains(searchTerm)) ||
                (c.Address != null && c.Address.ToLower().Contains(searchTerm))
            ).ToList();

            dgvCustomers.DataSource = filteredCustomers;
            lblTotalCustomers.Text = $"Found: {filteredCustomers.Count} / {_customers.Count}";
        }

        private void UpdateUI()
        {
            bool hasSelection = dgvCustomers.SelectedRows.Count > 0;
            btnDelete.Enabled = hasSelection;
            btnInfo.Enabled = hasSelection;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowCustomerInfo();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // This functionality will be implemented later
            MessageBox.Show("Add Customer functionality will be implemented soon.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // This functionality will be implemented later
            MessageBox.Show("Delete Customer functionality will be implemented soon.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            ShowCustomerInfo();
        }

        private void ShowCustomerInfo()
        {
            // This functionality will be implemented later
            MessageBox.Show("Customer Information functionality will be implemented soon.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomers();
        }
    }
}