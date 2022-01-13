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
using Tasks_System.BLL;
using Tasks_System.Entidades;

namespace Tasks_System.UI.Registros
{
    /// <summary>
    /// Interaction logic for rTareas.xaml
    /// </summary>
    public partial class rTareas : Window
    {
        private Tareas tarea = new Tareas(); 
        public rTareas()
        {
            InitializeComponent();
            this.DataContext = tarea;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = tarea;
        }

        private void Limpiar()
        {
            this.tarea = new Tareas();
            this.DataContext = tarea;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (NombreTareaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe de completar el campo 'Nombre de Tarea'", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTareaTextBox.Focus();
            }
            else if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe de completar el campo 'Descripción de la tarea'", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var tareas = TareasBLL.Buscar(Utilidades.ToInt(TareaIdTextBox.Text));
            
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
