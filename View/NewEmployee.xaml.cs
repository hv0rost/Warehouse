using System.Windows;

namespace WareHouse.View
{

    public partial class NewEmployee : Window
    {
        public NewEmployee()
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
