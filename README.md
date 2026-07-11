# 🧬 GenVault C.A. - Nexus ERP

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)

**GenVault Nexus ERP** es un sistema integral de planificación de recursos y control de seguridad diseñado para la gestión operativa e infraestructura de instalaciones de contención biológica. 

Este proyecto simula el entorno de software de alto nivel requerido para manejar accesos corporativos, monitoreo de redes, telemetría ambiental de laboratorios y protocolos críticos de emergencia.

---

## 📂 Arquitectura y Módulos del Sistema

El desarrollo está estructurado en 8 módulos principales, integrados bajo un único contenedor dinámico:

*   **🛡️ Módulo 1: Arquitectura, UI/UX e Integración (Core)**
    *   **Misión:** Contenedor principal (`FormMain`), enrutamiento del menú de navegación lateral dinámico y establecimiento de la paleta institucional corporativa. Actúa como el puente de compilación final para todos los módulos.
*   **🔐 Módulo 2: Ciberseguridad y Accesos (Login)**
    *   **Misión:** Simulación de validación por tarjetas RFID. Define el control de acceso basado en roles (Investigador, TI, Compras) restringiendo y habilitando áreas del sistema.
*   **🧬 Módulo 3: Bioinformática y Base de Datos Maestra**
    *   **Misión:** Núcleo transaccional (CRUD) para la gestión de especímenes de prueba y ejecución simulada del Programación de Algoritmos de Mutación (PAM).
*   **🖥️ Módulo 4: Monitor de Infraestructura TI**
    *   **Misión:** Simulación de telemetría de Zabbix para vigilar el estado del servidor central "Bio-Core Alpha" con alertas automatizadas de sobrecarga de red.
*   **🌡️ Módulo 5: Telemetría y Contención Biológica**
    *   **Misión:** Panel de control SNMP para monitoreo en tiempo real de temperatura, humedad e integridad física (acrílicos/vidrios) de las Unidades de Laboratorio A, B y C.
*   **🚨 Módulo 6: Protocolos de Emergencia**
    *   **Misión:** Sistema correctivo de seguridad ante incidentes críticos (incendios) y anulación manual del estado *Fail-Open* de los electroimanes para garantizar la contención de especímenes.
*   **📦 Módulo 7: Logística e Inventario Inteligente**
    *   **Misión:** Panel transaccional para la gestión de insumos (reactivos, acrílicos) con algoritmos de sugerencia automatizada para órdenes de compra por stock bajo.
*   **🗄️ Módulo 8: Backend y Enlace de Base de Datos**
    *   **Misión:** Soporte estructural estático (`ConexionDB.cs`) para persistencia de datos reales utilizando SQLite.

---

## ⚙️ Requisitos del Entorno

Para compilar y ejecutar este proyecto de forma local, se requiere:
*   Visual Studio 2022 (o superior)
*   .NET Framework / .NET Core (Según configuración del `.sln`)
*   Librería `System.Data.SQLite` instalada vía NuGet Package Manager.

## 🚀 Instrucciones de Ejecución

1. Clonar este repositorio en el entorno local:
   ```bash
   git clone [https://github.com/cvillalbaeng/GenVault_Nexus)


   👨‍💻 Acerca del Proyecto
Desarrollado como proyecto práctico de la materia.

Institución: Universidad de Margarita (UNIMAR)

Carrera: Ingeniería de Sistemas

Líder de Integración / Arquitectura: Christian Moisés Villalba