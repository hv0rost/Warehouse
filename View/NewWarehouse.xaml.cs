using System.Windows;

namespace WareHouse.View
{
    public partial class NewWarehouse : Window
    {
        public NewWarehouse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
