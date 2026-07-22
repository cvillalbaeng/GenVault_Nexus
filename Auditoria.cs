using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public static class Auditoria
    {
        private static string rutaArchivoAuditoria = Path.Combine(Application.StartupPath, "base_datos_auditoria.xml");

        // Método centralizado para registrar cualquier evento del sistema
        public static void Registrar(string modulo, string accion, string detalle)
        {
            try
            {
                DataTable tablaAuditoria = new DataTable("Auditoria");

                // Definir estructura si no existe el archivo
                tablaAuditoria.Columns.Add("Fecha", typeof(string));
                tablaAuditoria.Columns.Add("Hora", typeof(string));
                tablaAuditoria.Columns.Add("Usuario", typeof(string));
                tablaAuditoria.Columns.Add("Cargo", typeof(string));
                tablaAuditoria.Columns.Add("Modulo", typeof(string));
                tablaAuditoria.Columns.Add("Accion", typeof(string));
                tablaAuditoria.Columns.Add("Detalle", typeof(string));

                if (File.Exists(rutaArchivoAuditoria))
                {
                    tablaAuditoria.ReadXml(rutaArchivoAuditoria);
                }

                // Capturar datos contextuales del usuario actual de forma automática
                string usuarioActual = !string.IsNullOrEmpty(SesionGlobal.Documento) ? SesionGlobal.Documento : "Sistema / Anónimo";
                string cargoActual = !string.IsNullOrEmpty(SesionGlobal.Cargo) ? SesionGlobal.Cargo : "N/A";
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
                string horaActual = DateTime.Now.ToString("HH:mm:ss");

                // Agregar la nueva línea de auditoría
                tablaAuditoria.Rows.Add(fechaActual, horaActual, usuarioActual, cargoActual, modulo, accion, detalle);

                // Guardar en disco con esquema
                tablaAuditoria.WriteXml(rutaArchivoAuditoria, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                // Un fallo en el log no debe tumbar el sistema principal, pero se advierte en consola
                Console.WriteLine("Error al registrar auditoría: " + ex.Message);
            }
        }
    }
}