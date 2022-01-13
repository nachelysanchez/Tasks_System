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

namespace Tasks_System.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTareas.xaml
    /// </summary>
    public partial class cTareas : Window
    {
        public cTareas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click_2(object sender, RoutedEventArgs e)
        {
            var listado = new List<Tareas>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: // Todos
                        listado = TareasBLL.GetTareas();
                        break;
                    case 1: //Id
                        listado = TareasBLL.GetList(t => t.TareaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2: //Nombres
                        listado = TareasBLL.GetList(t => t.NombreTarea.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3: //Descripcion
                        listado = TareasBLL.GetList(t => t.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = TareasBLL.GetList(t => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
