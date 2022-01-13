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
using Tasks_System.UI.Consultas;
using Tasks_System.UI.Registros;

namespace Tasks_System
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

        private void rTareaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rTareas registro = new rTareas();
            registro.Show();
        }

        private void cTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTareas consulta = new cTareas();
            consulta.Show();
        }
    }
}
