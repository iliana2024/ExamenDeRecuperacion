using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para ActualizarUsuarios.xaml
    /// </summary>
    public partial class ActualizarUsuarios : Window
    {
        private int IdDelUsuarioDesdeOtraVentana;
        SqlConnection miConexionSql;
        public ActualizarUsuarios(int idUsuario)
        {
            InitializeComponent();
            IdDelUsuarioDesdeOtraVentana = idUsuario;

            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
        }

        private void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion del usuario?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = $"UPDATE Usuario SET Nombre = @Nombre WHERE Id = {IdDelUsuarioDesdeOtraVentana}";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaUsuario.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado al usuario con exito");
                    TxtActualizaUsuario.Text = "";
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaUsuario_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
