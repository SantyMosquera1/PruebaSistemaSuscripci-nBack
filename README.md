# SistemaSuscripcion - Backend API (.NET 8)

Proyecto desarrollado como entregable de la **prueba técnica backend** en .NET 8, aplicando **Clean Architecture** y **Domain-Driven Design (DDD)**.

---

## Objetivo de la Prueba

Demostrar la refactorización, estructuración y validación de reglas de negocio para el módulo de suscripciones antes de la implementación del ejercicio principal.

---

## Regla de Negocio Validada

* **Suscripción Única Activa:** Un usuario solo puede tener una suscripción activa. 
  * Si se intenta crear una segunda suscripción activa para el mismo usuario, la API responde con un estado HTTP `400 Bad Request`:
    ```json
    {
      "message": "El usuario ya cuenta con una suscripción activa."
    }
    ```

---

## Ejecución Rápida

1. Abrir la solución `SistemaSuscripcion.sln` en Visual Studio.
2. Ejecutar el proyecto (`F5`).
3. Probar el endpoint `POST /api/suscripciones` desde la interfaz de **Swagger UI**.
