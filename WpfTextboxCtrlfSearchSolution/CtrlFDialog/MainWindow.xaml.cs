using System;
using System.Windows;
using System.Windows.Input;

namespace CtrlFDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDialogSearcheable
    {
        private bool _isInSearchMode;
        private string _searchTerm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            _isInSearchMode = _isInSearchMode && e.Key == Key.F3;

            if (_isInSearchMode)
            {
                PerformSearch(_searchTerm);
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.F)
            {
                SearchDialog searchDialog = new SearchDialog(this);
                searchDialog.Show();
            }
        }

        public void PerformSearch(string content)
        {
            _isInSearchMode = true;
            _searchTerm = content.ToLower();

            string originalContent = txtContent.Text.Substring(txtContent.CaretIndex + txtContent.SelectedText.Length).ToLower();

            int indexFound = originalContent.IndexOf(_searchTerm, StringComparison.Ordinal);
            if (indexFound == -1) return;

            txtContent.Select(indexFound + (txtContent.Text.Length - originalContent.Length), _searchTerm.Length);
        }

    }
}
