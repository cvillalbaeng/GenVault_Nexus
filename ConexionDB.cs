using System;
using System.Data.SQLite;
using System.IO;

namespace GenVault_Nexus
{
    public static class ConexionDB
    {
        // Ruta del archivo físico de la base de datos local
        private static string cadenaConexion = "Data Source=GenVaultDB.sqlite;Version=3;";

        // Método público para que los otros módulos abran la puerta a los datos
        public static SQLiteConnection ObtenerConexion()
        {
            return new SQLiteConnection(cadenaConexion);
        }

        // Método para construir la infraestructura desde cero
        public static void InicializarDB()
        {
            // Si el archivo no existe, lo creamos y armamos las tablas
            if (!File.Exists("GenVaultDB.sqlite"))
            {
                SQLiteConnection.CreateFile("GenVaultDB.sqlite");

                using (SQLiteConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    // 1. Tabla para el Módulo 2 (Login)
                    string tablaUsuarios = "CREATE TABLE Usuarios (Id INTEGER PRIMARY KEY AUTOINCREMENT, NombreUsuario TEXT, Password TEXT, Rol TEXT)";
                    new SQLiteCommand(tablaUsuarios, conexion).ExecuteNonQuery();

                    // 2. Tabla para el Módulo 3 (Bioinformática)
                    string tablaSujetos = "CREATE TABLE Especimenes (Id INTEGER PRIMARY KEY AUTOINCREMENT, CodigoSujeto TEXT, Especie TEXT, NivelMutacion TEXT, UnidadAsignada TEXT)";
                    new SQLiteCommand(tablaSujetos, conexion).ExecuteNonQuery();

                    // Insertamos un usuario administrador "semilla" para que Luís pueda probar su Login
                    string insertAdmin = "INSERT INTO Usuarios (NombreUsuario, Password, Rol) VALUES ('investigador', 'genvault123', 'Investigador Jefe')";
                    new SQLiteCommand(insertAdmin, conexion).ExecuteNonQuery();
                }
            }
        }
    }
