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
    /// Lógica de interacción para ManejoDeCarreras.xaml
    /// </summary>
    public partial class ManejoDeCarreras : Window
    {
        SqlConnection miConexionSql;
        public ManejoDeCarreras()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);

            muestraDeLasCarreras();
        }

        private void muestraDeLasCarreras()
        {
            try
            {
                string consulta = "SELECT *, CONCAT('Id de la Carrera: ', Id, '   Nombre: ', Nombre) AS InformacionCompletaDeLaCarrera FROM Carrera";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeCarreras = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCarreras);

                    ListaDeCarreras.DisplayMemberPath = "InformacionCompletaDeLaCarrera";

                    ListaDeCarreras.SelectedValuePath = "Id";

                    ListaDeCarreras.ItemsSource = tablaDeCarreras.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnInsertarCarrera_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "INSERT INTO CARRERA(Nombre) VALUES(@Nombre)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarCarrera.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasCarreras();
                MessageBox.Show($"Has agregado una carrera con exito");
                TxtInsertarCarrera.Text = "";
            }
        }

        private void BtnBorrarCarrera_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar la carrera seleccionada?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = "DELETE FROM Carrera WHERE Id = @IdCarrera";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdCarrera", ListaDeCarreras.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLasCarreras();
                    MessageBox.Show($"Has borrado una carrera con exito");
                }
            }
        }

        private void BtnActualizarCarrera_Click(object sender, RoutedEventArgs e)
        {
            ActualizarCarreras ventanaActualizar = new ActualizarCarreras((int)ListaDeCarreras.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre FROM Carrera WHERE Id = @IdCarrera";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdCarrera", ListaDeCarreras.SelectedValue);
                    DataTable tablaDeCarreras = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCarreras);

                    ventanaActualizar.TxtActualizaCarrera.Text = tablaDeCarreras.Rows[0]["Nombre"].ToString();
                    ListaDeCarreras.SelectedValuePath = "Id";

                    ListaDeCarreras.ItemsSource = tablaDeCarreras.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ventanaActualizar.ShowDialog();
            muestraDeLasCarreras();
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }
    }
}
