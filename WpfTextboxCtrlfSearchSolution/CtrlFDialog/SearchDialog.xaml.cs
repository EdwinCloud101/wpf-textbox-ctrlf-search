using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CtrlFDialog
{
    /// <summary>
    /// Interaction logic for SearchDialog.xaml
    /// </summary>
    public partial class SearchDialog : Window
    {
        private readonly IDialogSearcheable _mainWindow;

        public SearchDialog(IDialogSearcheable mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void SearchDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            txtSearch.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            this.Close();
            _mainWindow.PerformSearch(txtSearch.Text.Trim());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }
    }
}
