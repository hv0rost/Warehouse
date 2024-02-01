using System.Windows;

namespace WareHouse.View
{
    public partial class NewProduct : Window
    {
        public NewProduct()
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
