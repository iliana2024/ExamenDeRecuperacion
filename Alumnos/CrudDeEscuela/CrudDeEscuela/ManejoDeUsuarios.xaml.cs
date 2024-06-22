using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Lógica de interacción para ManejoDeUsuarios.xaml
    /// </summary>
    public partial class ManejoDeUsuarios : Window
    {
        SqlConnection miConexionSql;
        public ManejoDeUsuarios()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
            muestraDeLosUsuarios();
        }

        private void muestraDeLosUsuarios()
        {
            try
            {
                string consulta = "SELECT *, CONCAT('Id del Usuario: ', Id, '   Nombre: ', Nombre) AS InformacionCompletaDelUsuario FROM Usuario";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeUsuarios = new DataTable();
                    miAdaptadorSql.Fill(tablaDeUsuarios);

                    ListaDeUsuarios.DisplayMemberPath = "InformacionCompletaDelUsuario";

                    ListaDeUsuarios.SelectedValuePath = "Id";

                    ListaDeUsuarios.ItemsSource = tablaDeUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnInsertarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "INSERT INTO USUARIO(Nombre) VALUES(@Nombre)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarUsuario.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosUsuarios();
                MessageBox.Show($"Has agregado un usuario con exito");
                TxtInsertarUsuario.Text = "";
            }
        }

        private void BtnBorrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar al usuario seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = "DELETE FROM Usuario WHERE Id = @IdUsuario";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdUsuario", ListaDeUsuarios.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosUsuarios();
                    MessageBox.Show($"Has borrado un usuario con exito");
                }
            }
        }

        private void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {

            ActualizarUsuarios ventanaActualizar = new ActualizarUsuarios((int)ListaDeUsuarios.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre FROM Usuario WHERE Id = @IdUsuario";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdUsuario", ListaDeUsuarios.SelectedValue);
                    DataTable tablaDeUsuarios = new DataTable();
                    miAdaptadorSql.Fill(tablaDeUsuarios);

                    ventanaActualizar.TxtActualizaUsuario.Text = tablaDeUsuarios.Rows[0]["Nombre"].ToString();

                    ListaDeUsuarios.SelectedValuePath = "Id";

                    ListaDeUsuarios.ItemsSource = tablaDeUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ventanaActualizar.ShowDialog();
            muestraDeLosUsuarios();
        }

        private void BtnRegresarAInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }
    }
}
