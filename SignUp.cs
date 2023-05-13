using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Login_BD_Jaime_Janer_2023
{
    public partial class SignUp : Form
    {
        

        public SignUp()
        {
            InitializeComponent();
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            //Este botón, abre nuevamente el form principal y cierra el actual.
            Form1 principal = new Form1();
            principal.Show();
            Hide();
        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            //Al presionar el boton de registro, verificamos que no hayan cadenas vacías en el registro.

            if (txt_User.Text.Trim() != "" && txt_Password.Text.Trim() != "" && txt_Confirmar.Text.Trim() !="")
            {
                //Para registrarse, debes confirmar la contraseña.

                if(txt_Confirmar.Text == txt_Password.Text)
                {
                    //Una vez se cumplen las validaciones, procedemos a intentar las conexiones a la base de datos.
                    try
                    {
                        //Creamos un objeto de conexion, uno de comando y uno de lectura.
                        SQLiteConnection conexion_sqlite;
                        SQLiteCommand cmd_sqlite;
                        SQLiteDataReader datareader_sqlite;

                        //Crear una nueva conexión de la base de datos
                        conexion_sqlite = new SQLiteConnection("Data Source=DB_Login_Jaime_Janer.db;Version=3;Compress=True;");

                        //Abriremos la conexión
                        conexion_sqlite.Open();

                        //Creando el comando SQL
                        cmd_sqlite = conexion_sqlite.CreateCommand();
                        //Verificamos que el nombre que estamos usando para registrarnos, no exista en la base de datos.

                        cmd_sqlite.CommandText = string.Format("SELECT COUNT(*) FROM tbl_login WHERE usuario='{0}'", txt_User.Text.ToLower());
                        int usuarioRepetido = Convert.ToInt32(cmd_sqlite.ExecuteScalar());
                        //En caso de no existir, llenamos la base de datos con la información almacenada en los txtBox de nombre y contraseña.

                        if(usuarioRepetido==0)
                        {
                            cmd_sqlite.CommandText = string.Format("INSERT INTO tbl_login values('{0}','{1}')", txt_User.Text.ToLower(), txt_Password.Text);
                            //Actualizamos la lectura de la base de datos.
                            datareader_sqlite = cmd_sqlite.ExecuteReader();

                           //Cerramos la base de datos.
                            conexion_sqlite.Close();

                            MessageBox.Show("Te has registrado correctamente.");

                            // Limpiamos los campos de registro y redirigimos al usuario al inicio de sesion.
                            txt_User.Clear();
                            txt_Password.Clear();
                            txt_Confirmar.Clear();
                            SignIn si = new SignIn();
                            si.Show();
                            Hide();

                        }
                        else
                        {
                            MessageBox.Show("Nombre de usuario no disponible.");
                            txt_User.Clear();
                            txt_User.Focus();
                        }

                        
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show("Error al registrar al usuario " + err);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas deben coincidir");
                }
            }
            else
            {
                MessageBox.Show("Por favor, rellene todos los campos para registrarse.");
            }
        }
    }
}


