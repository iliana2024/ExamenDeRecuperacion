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
    /// Lógica de interacción para ActualizarAlumnos.xaml
    /// </summary>
    public partial class ActualizarAlumnos : Window
    {
        private int IdDelAlumnoDesdeOtraVentana;
        SqlConnection miConexionSql;
        public ActualizarAlumnos(int idAlumno)
        {
            InitializeComponent();

            IdDelAlumnoDesdeOtraVentana = idAlumno;

            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);


            try
            {
                string consulta = "SELECT Id FROM Usuario";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                DataTable dtUsuarios = new DataTable();

                using (miAdaptadorSql)
                {
                    miAdaptadorSql.Fill(dtUsuarios);

                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        cboUsuarios.Items.Add(row["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                string consulta = "SELECT Nombre FROM Carrera";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                DataTable dtCarreras = new DataTable();

                using (miAdaptadorSql)
                {
                    miAdaptadorSql.Fill(dtCarreras);

                    foreach (DataRow row in dtCarreras.Rows)
                    {
                        cboActualizaCarreraAlumno.Items.Add(row["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion del alumno?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = $"UPDATE Alumno SET Nombre = @Nombre, IdDelUsuario = @IdDelUsuario, NombreDelUsuario = @NombreDelUsuario, Carnet = @Carnet, Direccion = @Direccion, Telefono = @Telefono, Carrera = @Carrera WHERE Id = {IdDelAlumnoDesdeOtraVentana}";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@IdDelUsuario", cboUsuarios.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@NombreDelUsuario", TxtInsertarUsuario.Text);
                    miComandoSql.Parameters.AddWithValue("@Carnet", TxtActualizaCarnetAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Direccion", TxtActualizaDireccionAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Telefono", TxtActualizaTelefonoAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Carrera", cboActualizaCarreraAlumno.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado al alumno con exito");
                    TxtActualizaAlumno.Text = "";
                    cboUsuarios.SelectedValue = null;
                    TxtInsertarUsuario.Text = "";
                    TxtActualizaCarnetAlumno.Text = "";
                    TxtActualizaDireccionAlumno.Text = "";
                    TxtActualizaTelefonoAlumno.Text = "";
                    cboActualizaCarreraAlumno.SelectedValue = null;
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaAlumno_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string IdDelUsuarioSeleccionado = cboUsuarios.SelectedItem.ToString();

            try
            {
                string consulta = $"SELECT Nombre FROM Usuario WHERE Id = '{IdDelUsuarioSeleccionado}'";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtUsuarios = new DataTable();
                miAdaptadorSql.Fill(dtUsuarios);

                if (dtUsuarios.Rows.Count > 0)
                {
                    TxtInsertarUsuario.Text = dtUsuarios.Rows[0]["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
