# Store Inventory and Transaction Management App

Este proyecto es una aplicación completa que incluye una API RESTful desarrollada en ASP.NET Core y una interfaz de usuario (UI) para gestionar productos, inventario, clientes, transacciones y entregas. 
El sistema sigue un flujo de compra de 5 pasos que permite mostrar productos, ingresar información de pago, confirmar la compra y mostrar el estado final de la transacción.

---

## 🧩 Características principales

- **Diseño robusto de la API**: arquitectura limpia basada en principios SOLID.
- **Endpoints seguros y validados**: prevención de errores y manejo de datos sensibles.
- **Resiliencia**: recuperación de estado del cliente tras recarga.
- **UI amigable**: muestra productos disponibles en stock.
- **Proceso de compra en 5 pasos.**

---

## 🗂 Estructura del proyecto

/StoreApp.API
</br>
/Controllers
/Models
/DTOs
/Services
/Data
/Helpers
/StoreApp.UI
/Pages
/Components
/wwwroot
/database
schema.sql
README.md

---

## 🔐 Validaciones implementadas

- Validación de stock antes de permitir una compra.
- Verificación de datos de tarjeta de crédito (formato, expiración).
- Validación de campos requeridos para clientes y entregas.
- Control de errores con respuestas claras (400/404/500).
- Middleware para manejo centralizado de excepciones.

---

## 🔒 Manejo de datos sensibles

- Uso de `appsettings.json` y `User Secrets` para configuración segura.
- Cifrado de datos sensibles (como tarjetas) usando `Data Protection API`.
- Acceso restringido mediante `Authorization` y `Authentication`.
- Protección contra ataques comunes (SQL Injection, XSS, CSRF).

---
