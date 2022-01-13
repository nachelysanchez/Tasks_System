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
            var tarea = TareasBLL.Buscar(Utilidades.ToInt(TareaIdTextBox.Text));
            if (tarea != null)
            {
                this.tarea = tarea;
            }
            else
            {
                this.tarea = new Tareas();
                MessageBox.Show("No se ha encontrado la Tarea", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.tarea;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            if (TareasBLL.ExisteNombre(NombreTareaTextBox.Text))
            {
                MessageBox.Show("Ya existe esta tarea. Ingrese otra", "Informacion",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var paso = TareasBLL.Guardar(this.tarea);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("La tarea se guardo correctamente", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("La tarea no se guardo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (TareasBLL.Eliminar(Utilidades.ToInt(TareaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Tarea eliminada", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("La tarea no se logro eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
