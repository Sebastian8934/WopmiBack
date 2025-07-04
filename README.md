# 🧾 Aplicación de Gestión de Inventario y Transacciones – Documentación Técnica (Backend)

## 📌 Descripción del Proyecto

Este proyecto es una aplicación completa que incluye una **API RESTful desarrollada en .NET 8** para gestionar:

- Productos
- Inventario
- Clientes
- Transacciones
- Entregas

La aplicación implementa un **flujo de compra en 5 pasos**, que permite:
1. Visualizar productos
2. Ingresar información de pago
3. Confirmar la compra
4. Mostrar estado de la transacción
5. Gestionar la entrega

El sistema también incluye autenticación mediante inicio de sesión seguro.

---

## 🛠️ Tecnologías Utilizadas

- **Lenguaje:** C#  
- **Framework:** ASP.NET Core 8  
- **Base de datos:** SQL Server  
- **ORM:** Entity Framework Core  
- **Autenticación:** JWT + ASP.NET Identity + OAuth 2.0  
- **Arquitectura:** Hexagonal (Ports and Adapters)  
- **Despliegue:** Microsoft Azure  
- **Documentación de API:** Swagger

---

## 🧱 Arquitectura del Proyecto

El backend utiliza una **arquitectura hexagonal**, que promueve la separación clara entre el dominio, los casos de uso y los mecanismos externos (API, base de datos, autenticación).

### Capas principales:

- **Domain**
  - Entidades de negocio
  - Interfaces
- **Application**
  - Casos de uso
  - DTOs
- **Infrastructure**
  - Persistencia de datos
  - Autenticación
- **API**
  - Controladores
  - Middlewares
  - Documentación Swagger

---

## 📁 Estructura del Proyecto

```
/src
  /Api
    - Controllers
    - Middlewares
    - Program.cs
  /Application
    - UseCases
    - DTOs
    - Interfaces
  /Domain
    - Entities
    - Interfaces
    - Services
  /Infrastructure
    - Persistence
    - Identity
    - OAuth
    - Configurations
/tests
  /UnitTests
  /IntegrationTests
```

---

## 🔐 Seguridad y Autenticación

El sistema implementa autenticación robusta para proteger los recursos de la API:

- **JWT** para el manejo de sesiones
- **ASP.NET Identity** para gestión de usuarios y contraseñas
- **OAuth 2.0** para posibles integraciones externas
- **Middleware personalizado** para validación de tokens y manejo de errores

---

## 🧪 Pruebas

Se contemplan pruebas para asegurar el correcto funcionamiento del sistema:

- **Pruebas Unitarias** – Validan la lógica interna de cada componente
- **Pruebas de Integración** – Verifican la comunicación entre capas (API ↔ DB)

### Herramientas recomendadas:
- xUnit o NUnit
- Moq
- FluentAssertions

---

## 🚀 Despliegue

La aplicación está desplegada en **Azure App Service**. Se recomienda el uso de CI/CD mediante GitHub Actions o Azure DevOps.

---

## ✅ Estado Actual

- [x] API RESTful funcional
- [x] Arquitectura hexagonal implementada
- [x] Seguridad con JWT, Identity y OAuth
- [x] Flujo de compra en 5 pasos implementado
- [x] Documentación Swagger habilitada
- [ ] Pruebas unitarias e integración en desarrollo
- [x] Despliegue en Azure

---
