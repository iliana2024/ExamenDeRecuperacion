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
    /// Lógica de interacción para ManejoDeAlumnos.xaml
    /// </summary>
    public partial class ManejoDeAlumnos : Window
    {
        SqlConnection miConexionSql;
        public ManejoDeAlumnos()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.BasedeDatosAlumnosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);

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
                        cboCarreras.Items.Add(row["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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
            muestraDeLosAlumnos();
        }

        private void muestraDeLosAlumnos()
        {
            try
            {
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Id del Usuario: ', IdDelUsuario, '   NombreDelUsuario: ', NombreDelUsuario, '   Carnet: ', Carnet, '   Direccion: ', Direccion, '   Telefono: ', Telefono, '   Carrera: ', Carrera) AS InformacionCompletaDelAlumno FROM Alumno";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeAlumnos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeAlumnos);

                    ListaDeAlumnos.DisplayMemberPath = "InformacionCompletaDelAlumno";

                    ListaDeAlumnos.SelectedValuePath = "Id";

                    ListaDeAlumnos.ItemsSource = tablaDeAlumnos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            ActualizarAlumnos ventanaActualizar = new ActualizarAlumnos((int)ListaDeAlumnos.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre,IdDelUsuario,NombreDelUsuario,Carnet,Direccion,Telefono,Carrera FROM Alumno WHERE Id = @IdAlumno";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdAlumno", ListaDeAlumnos.SelectedValue);
                    DataTable tablaDeAlumnos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeAlumnos);

                    ventanaActualizar.TxtActualizaAlumno.Text = tablaDeAlumnos.Rows[0]["Nombre"].ToString();
                    ventanaActualizar.cboUsuarios.SelectedValue = tablaDeAlumnos.Rows[0]["IdDelUsuario"].ToString();
                    ventanaActualizar.TxtInsertarUsuario.Text = tablaDeAlumnos.Rows[0]["NombreDelUsuario"].ToString();
                    ventanaActualizar.TxtActualizaCarnetAlumno.Text = tablaDeAlumnos.Rows[0]["Carnet"].ToString();
                    ventanaActualizar.TxtActualizaDireccionAlumno.Text = tablaDeAlumnos.Rows[0]["Direccion"].ToString();
                    ventanaActualizar.TxtActualizaTelefonoAlumno.Text = tablaDeAlumnos.Rows[0]["Telefono"].ToString();
                    ventanaActualizar.cboActualizaCarreraAlumno.SelectedValue = tablaDeAlumnos.Rows[0]["Carrera"].ToString();


                    ListaDeAlumnos.SelectedValuePath = "Id";

                    ListaDeAlumnos.ItemsSource = tablaDeAlumnos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ventanaActualizar.ShowDialog();
            muestraDeLosAlumnos();
        }

        private void BtnBorrarAlumno_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar al alumno seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    string consulta = "DELETE FROM Alumno WHERE Id = @IdAlumno";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdAlumno", ListaDeAlumnos.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosAlumnos();
                    MessageBox.Show($"Has borrado un alumno con exito");
                }
            }
        }

        private void BtnInsertarAlumno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "INSERT INTO ALUMNO(Nombre,IdDelUsuario,NombreDelUsuario,Carnet,Direccion,Telefono,Carrera) VALUES(@Nombre,@IdDelUsuario,@NombreDelUsuario,@Carnet,@Direccion,@Telefono,@Carrera)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarAlumno.Text);
                miComandoSql.Parameters.AddWithValue("IdDelUsuario", cboUsuarios.SelectedValue);
                miComandoSql.Parameters.AddWithValue("NombreDelUsuario", TxtInsertarUsuario.Text);
                miComandoSql.Parameters.AddWithValue("Carnet", TxtInsertarCarnetAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Direccion", TxtInsertarDireccionAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Telefono", TxtInsertarTelefonoAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Carrera", cboCarreras.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosAlumnos();
                MessageBox.Show($"Has agregado un alumno con exito");
                TxtInsertarAlumno.Text = "";
                cboUsuarios.SelectedValue = null;
                TxtInsertarUsuario.Text = "";
                TxtInsertarCarnetAlumno.Text = "";
                TxtInsertarDireccionAlumno.Text = "";
                TxtInsertarTelefonoAlumno.Text = "";
                cboCarreras.SelectedValue = null;
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
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
