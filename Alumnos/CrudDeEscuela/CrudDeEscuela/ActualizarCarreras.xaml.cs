using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para ActualizarCarreras.xaml
    /// </summary>
    public partial class ActualizarCarreras : Window
    {
        private int IdDeLaCarreraDesdeOtraVentana;
        SqlConnection miConexionSql;
        public ActualizarCarreras(int idCarrera)
        {
            InitializeComponent();
            IdDeLaCarreraDesdeOtraVentana = idCarrera;
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
        }

        private void BtnActualizarCarrera_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion de la carrera?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = $"UPDATE Carrera SET Nombre = @Nombre WHERE Id = {IdDeLaCarreraDesdeOtraVentana}";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaCarrera.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado a la carrera con exito");
                    TxtActualizaCarrera.Text = "";
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaCarrera_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
