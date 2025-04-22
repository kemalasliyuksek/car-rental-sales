using System;
using System.Windows.Forms;

namespace car_rental_sales_desktop
{
    public static class MainMethods
    {
        /// <summary>
        /// Loads a UserControl into the specified panel
        /// </summary>
        /// <param name="panel">The panel to load the control into</param>
        /// <param name="userControl">The UserControl to load</param>
        public static void LoadUserControl(Panel panel, UserControl userControl)
        {
            // Clear existing controls
            panel.Controls.Clear();

            // Configure the user control to fill the panel
            userControl.Dock = DockStyle.Fill;

            // Add the control to the panel
            panel.Controls.Add(userControl);

            // Make sure the control is visible
            userControl.BringToFront();
        }

        /// <summary>
        /// Shows a success message
        /// </summary>
        /// <param name="message">The message to show</param>
        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows an error message
        /// </summary>
        /// <param name="message">The message to show</param>
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a confirmation dialog
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <returns>True if the user confirmed, otherwise false</returns>
        public static bool ShowConfirmationDialog(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}