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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) && !lstToDo.Items.Contains(nameBox.Text))
                lstToDo.Items.Add(nameBox.Text);
                nameBox.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var index = lstToDo.SelectedIndex;
            var tarefa = lstEndedTaks.SelectedIndex;
            if (index >= 0) {
                lstToDo.Items.RemoveAt(index);
            }            
            if (tarefa >= 0)
            {
                lstEndedTaks.Items.RemoveAt(tarefa);
            }

        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void window_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente sair? ", "Terminar app", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) {
                e.Cancel = true;
            }
        }

        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnConcluido(object sender, RoutedEventArgs e)
        {
            var index = lstToDo.SelectedIndex;
            if (index >= 0)
            {
                var tarefa = lstToDo.Items[index];
                lstEndedTaks.Items.Add(tarefa);
                lstToDo.Items.RemoveAt(index);
            }

        }
    }
}
