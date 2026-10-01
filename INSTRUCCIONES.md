# 🏗️ Prueba Técnica: Refactorización, Arquitectura & Uso de IA (.NET)

**Rol:** Backend Developer Senior / Semi-Senior
**Tiempo límite:** 50 Minutos

---

## 1. El Contexto 🚩

Has recibido el código fuente de un módulo de **Suscripciones**. Actualmente, el sistema funciona y pasa las pruebas funcionales básicas, pero ha sido identificado como **deuda técnica** debido a su bajo nivel de mantenibilidad y alto acoplamiento.

La solución ya cuenta con una estructura de proyectos segregada (`Domain`, `Application`, `Infrastructure`, `WebApi`), pero **el código no respeta esta arquitectura**.

### Regla de Negocio Principal

> **Un usuario solo puede tener una suscripción activa a la vez.**

---

## 2. El Desafío 🎯

Esta prueba se divide en dos fases prácticas. Tu objetivo es **refactorizar el flujo de creación de suscripciones** (`POST /api/suscripciones`) para que cumpla con los principios de **Clean Architecture** y **Domain-Driven Design (DDD)**, y posteriormente utilizar Inteligencia Artificial para implementar un nuevo requerimiento.

### Fase A: Refactorización y DDD (30 Minutos)

1.  **Redistribución de Responsabilidades:** Mueve la lógica existente a las capas correspondientes (Domain, Application, Infrastructure) según tu criterio arquitectónico.
2.  **Protección del Dominio:** Asegura que las reglas de negocio no puedan ser violadas desde capas externas.
3.  **Desacoplamiento:** Elimina las dependencias directas a infraestructura (EF Core) desde el controlador.

_Nota: Puedes modificar, mover o eliminar cualquier archivo existente, así como crear nuevas abstracciones si lo consideras necesario para una solución robusta._

### Fase B: Resolución Asistida por IA (20 Minutos)

Utiliza la herramienta de Inteligencia Artificial de tu preferencia (modelos locales, asistentes en la nube, Copilot, ChatGPT, etc.) para implementar el siguiente requerimiento sobre el código que acabas de refactorizar:

- **Nuevo Requerimiento:** _Se debe simular el envío de un correo de confirmación de suscripción utilizando un servicio externo falso. Utiliza la IA para generar un `HttpClient` que consuma este servicio, implementando una política de reintentos (Retry Policy) en caso de fallos._

---

## 3. Qué evaluamos 🔍

No buscamos una sobre-ingeniería masiva, sino **decisiones de diseño inteligentes** y eficiencia en el uso de herramientas modernas:

- **Diseño del Dominio:** ¿Dónde ubicas las validaciones de negocio?
- **Abstracción:** ¿Cómo separas la intención de la implementación?
- **Limpieza de Código:** Uso de principios SOLID y características modernas de C# / .NET.

---

## 4. Reglas de la Dinámica e Información de Ejecución ⚙️

⚠️ Reglas Obligatorias:

- 📷 **Cámara encendida:** Tu cámara debe permanecer activa durante toda la sesión.

- 💻 **Pantalla compartida:** Debes compartir tu pantalla en todo momento, incluyendo la fase de lectura de código, refactorización y cuando utilices tu herramienta de IA o busques documentación.

- **Base de Datos:** In-Memory (se reinicia con la aplicación).
- **Usuario de Prueba (Seed):**
  - ID: `d79203a5-108a-493e-a690-642100863004`

**Estado ACTUAL (Antes de refactorizar):**
El código legacy funciona enviando parámetros por URL:
`POST /api/suscripciones?userId=...&planId=...`

**Estado ESPERADO (Tu objetivo):**
Al finalizar, la API debe aceptar un JSON Body:

```json
POST /api/suscripciones
Content-Type: application/json

{
  "userId": "d79203a5-108a-493e-a690-642100863004",
  "planId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
