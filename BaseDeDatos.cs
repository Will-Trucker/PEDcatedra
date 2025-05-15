using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEDcatedra
{
    class BaseDeDatos
    {
        private string connectionString = "Server=SW;Database=catedra_ped;Integrated Security=True;";
        private SqlConnection connection;

        //modifica estos metodos c# para adaptarlo a la tabla empresas que tiene los campos id,nombre,descripcion,idUsuario
        public DataTable mostrarUsuarios()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");

                    string query = "SELECT * FROM usuarios";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }

        public void crearUsuario(int id,string nom,string ape,int edad) {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO usuarios (id,nombre, apellidos, edad) VALUES (@id,@nom, @ape, @edad)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@ape", ape);
                        command.Parameters.AddWithValue("@edad", edad);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario insertado correctamente." : "No se pudo insertar el usuario.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }

                    
                }
            }
        }

        public void ActualizarUsuario(int id, string nom, string ape, int edad)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "update usuarios set nombre=@nom,apellidos=@ape,edad=@edad where id=@id ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@ape", ape);
                        command.Parameters.AddWithValue("@edad", edad);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario insertado correctamente." : "No se pudo insertar el usuario.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }


                }
            }
        }

        public void EliminarrUsuario(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "delete from usuarios where id=@id ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario insertado correctamente." : "No se pudo insertar el usuario.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }


                }
            }
        }

        public Dictionary<int, string> ListaUsuarios()
        {
            Dictionary<int, string> usuarios = new Dictionary<int, string> { };
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");
                    int bandera = 0;
                    string query = "SELECT * FROM usuarios";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bandera++;
                            //Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Email: {reader["Email"]}");
                            usuarios.Add(Int32.Parse(reader["id"].ToString()), reader["id"].ToString() + " "+reader["nombre"].ToString()+" "+reader["apellidos"].ToString());
                        }

                        
                    }
                    if (bandera != 0)
                    {
                        return usuarios;

                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }

        }

        //-------------------Empresas-------------------------------------
        public DataTable MostrarEmpresas()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");

                    string query = "SELECT * FROM empresas";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }

        public void CrearEmpresa(int id, string nombre, string descripcion, int idUsuario)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO empresas (id, nombre, descripcion, idUsuario) VALUES (@id, @nombre, @descripcion, @idUsuario)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Empresa insertada correctamente." : "No se pudo insertar la empresa.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void ActualizarEmpresa(int id, string nombre, string descripcion, int idUsuario)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE empresas SET nombre=@nombre, descripcion=@descripcion, idUsuario=@idUsuario WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Empresa actualizada correctamente." : "No se pudo actualizar la empresa.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void EliminarEmpresa(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM empresas WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Empresa eliminada correctamente." : "No se pudo eliminar la empresa.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public Dictionary<int, string> ListaEmpresas()
        {
            Dictionary<int, string> empresas = new Dictionary<int, string>();

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");
                    int bandera = 0;
                    string query = "SELECT * FROM empresas";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            bandera++;
                            empresas.Add(
                                Int32.Parse(reader["id"].ToString()),
                                $"{reader["id"]} {reader["nombre"]} {reader["descripcion"]}"
                            );
                        }
                    }
                    if (bandera != 0)
                    {
                        return empresas;

                    }
                    else
                    {
                      return null;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                    return null;
                }
            }
        }

        //-------------------proyectos-----------------------------
        public DataTable MostrarProyectos()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");

                    string query = "SELECT * FROM proyectos";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
                catch (SqlException ex)
                {
                   
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                    return null;
                }
            }
        }
        public void CrearProyecto(int id, string nombre, string descripcion, int cantMiembros, int id_Empresa)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO proyectos (id, nombre, descripcion, cantMiembros, id_Empresa) VALUES (@id, @nombre, @descripcion, @cantMiembros, @id_Empresa)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@cantMiembros", cantMiembros);
                        command.Parameters.AddWithValue("@id_Empresa", id_Empresa);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Proyecto insertado correctamente." : "No se pudo insertar el proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void ActualizarProyecto(int id, string nombre, string descripcion, int cantMiembros, int id_Empresa)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE proyectos SET nombre=@nombre, descripcion=@descripcion, cantMiembros=@cantMiembros, id_Empresa=@id_Empresa WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@cantMiembros", cantMiembros);
                        command.Parameters.AddWithValue("@id_Empresa", id_Empresa);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Proyecto actualizado correctamente." : "No se pudo actualizar el proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void EliminarProyecto(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM proyectos WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Proyecto eliminado correctamente." : "No se pudo eliminar el proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public Dictionary<int, string> ListaProyectos()
        {
            Dictionary<int, string> proyectos = new Dictionary<int, string>();

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");
                    int bandera = 0;
                    string query = "SELECT * FROM proyectos";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bandera++;
                            proyectos.Add(
                                Int32.Parse(reader["id"].ToString()),
                                $"{reader["id"]} {reader["nombre"]} {reader["descripcion"]}"
                            );
                        }
                    }
                    if (bandera != 0)
                    {
                        return proyectos;

                    }
                    else
                    {
                        return null;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                    return null;
                }
            }
        }

        //----------usuarios proyectos-----------------------------------------------
        public DataTable MostrarUsuariosProyectos()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");

                    string query = "SELECT * FROM usuarios_proyectos";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                    return null;
                }
            }
        }

        public void CrearUsuarioProyecto(int id, int idUsuario, int idProyecto)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO usuarios_proyectos (id, idUsuario, idProyecto) VALUES (@id, @idUsuario, @idProyecto)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.AddWithValue("@idProyecto", idProyecto);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario-proyecto insertado correctamente." : "No se pudo insertar el usuario-proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void ActualizarUsuarioProyecto(int id, int idUsuario, int idProyecto)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE usuarios_proyectos SET idUsuario=@idUsuario, idProyecto=@idProyecto WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.AddWithValue("@idProyecto", idProyecto);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario-proyecto actualizado correctamente." : "No se pudo actualizar el usuario-proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void EliminarUsuarioProyecto(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM usuarios_proyectos WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Usuario-proyecto eliminado correctamente." : "No se pudo eliminar el usuario-proyecto.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }



        //--------------------- Tareas --------------------------------------------
        public DataTable MostrarTareas()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión establecida correctamente.");

                    string query = "SELECT * FROM tareas";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Error por clave duplicada
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                    return null;
                }
            }
        }

        public void CrearTarea(int id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, int id_proyecto, int id_empresa, int id_usuarioRes)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tareas (id, nombre, descripcion, fecha_inicio, fecha_fin, id_proyecto, id_empresa, id_usuarioRes) VALUES (@id, @nombre, @descripcion, @fecha_inicio, @fecha_fin, @id_proyecto, @id_empresa, @id_usuarioRes)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                        command.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        command.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                        command.Parameters.AddWithValue("@id_empresa", id_empresa);
                        command.Parameters.AddWithValue("@id_usuarioRes", id_usuarioRes);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Tarea insertada correctamente." : "No se pudo insertar la tarea.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void ActualizarTarea(int id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, int id_proyecto, int id_empresa, int id_usuarioRes)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tareas SET nombre=@nombre, descripcion=@descripcion, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin, id_proyecto=@id_proyecto, id_empresa=@id_empresa, id_usuarioRes=@id_usuarioRes WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                        command.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        command.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                        command.Parameters.AddWithValue("@id_empresa", id_empresa);
                        command.Parameters.AddWithValue("@id_usuarioRes", id_usuarioRes);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Tarea actualizada correctamente." : "No se pudo actualizar la tarea.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }

        public void EliminarTarea(int id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM tareas WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Tarea eliminada correctamente." : "No se pudo eliminar la tarea.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Console.WriteLine("Error: El ID ya existe en la base de datos.");
                        MessageBox.Show("Error: El ID ya existe en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("Error de SQL: " + ex.Message);
                        MessageBox.Show("Error de SQL: " + ex.Message);
                    }
                }
            }
        }



        /** Lista para tareas **/
        public Dictionary<int, string> ListaTareas()
        {
            Dictionary<int, string> tareas = new Dictionary<int, string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM tareas", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tareas.Add((int)reader["id"], reader["nombre"].ToString());
                }
            }
            return tareas;
        }










    }


}
