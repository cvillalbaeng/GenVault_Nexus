using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ========================================================
            // INICIALIZACIÓN DEL MOTOR DE BASE DE DATOS (MÓDULO 8)
            // Llama a la clase para crear el archivo .sqlite
            // ========================================================
            ConexionDB.InicializarDB();

            // Arrancamos la interfaz gráfica principal
            Application.Run(new FormMain());
        }
    }
}