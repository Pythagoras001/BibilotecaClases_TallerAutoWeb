# 📚 Biblioteca de Clases — Taller Mecánico 14 de Noviembre del 2025

La **Biblioteca de Clases del Taller Mecánico** es el núcleo lógico del sistema.  
Aquí se encuentra **toda la lógica del dominio**, incluyendo modelos, reglas de negocio, eventos del proceso de reparación y aspectos responsables del manejo de datos mediante **archivos JSON**.

Este proyecto está diseñado para ser **modular, desacoplado y reutilizable**, siguiendo Programación Orientada a Objetos, Programación Orientada a Eventos, Programación Orientada a Aspectos y el principio de **Inversión de Dependencias (DIP)**.

---

## 🧩 Objetivo de la biblioteca

El propósito principal de esta biblioteca es encapsular:

- El *modelo completo del taller mecánico*  
- Las reglas del negocio (estado de órdenes, cálculos de costos, repuestos, etc.)  
- La persistencia con **archivos JSON**  
- El sistema de eventos que reacciona a cada fase del proceso de reparación  
- La modularidad mediante aspectos transversales  
- Interfaces y servicios desacoplados para la capa MVC  

---

## 🧠 Paradigmas implementados

| Paradigma | Descripción |
|----------|-------------|
| **POO (Programación Orientada a Objetos)** | Entidades del dominio con comportamiento propio. |
| **Eventos** | El sistema reacciona a cada fase del ciclo del taller. |
| **AOP (Programación Orientada a Aspectos)** | Gestión de datos JSON, validación y reglas transversales. |
| **DIP (Inversión de Dependencias)** | Todos los servicios están desacoplados mediante interfaces. |

---

## 🔄 Eventos del proceso del taller

El sistema implementa eventos que representan **todas las fases del proceso de reparación**, permitiendo que el sistema MVC reciba notificaciones o ejecute acciones adicionales.

Los eventos implementados son:

| Evento | Momento en que ocurre |
|--------|-------------------------|
| **Ingreso del vehículo** | Cuando una orden es creada y registrada. |
| **Inicio de reparación** | Cuando un mecánico comienza los trabajos asignados. |
| **Actualización / cambio de estado** | Estado modificado (Pendiente, En reparación, Listo, etc.). |
| **Pago** | Cuando el cliente cancela el valor total. |
| **Entrega** | Cuando el vehículo es entregado al cliente. |
| **Salida del taller** | Cierre final del proceso. |

Cada evento puede:

- Disparar cálculos  
- Activar validaciones  
- Registrar movimientos  
- Notificar al sistema MVC  

---

## 📦 Aspectos (AOP)

Los aspectos están enfocados principalmente en el **manejo de la Base de Datos mediante archivos JSON** y tareas transversales.

| Aspecto | Función |
|---------|---------|
| **Persistencia JSON** | Lectura, escritura, actualización y eliminación de datos en archivos JSON. |
| **Validaciones** | Reglas transversales previas a cualquier operación. |
| **Auditoría** | Registro de cambios, movimientos y acciones. |
| **Reglas de costo** | Cálculo automático del costo total según repuestos y estados. |

Esto permite que la lógica de datos esté completamente separada de los servicios del dominio.

---

## 🔍 Principales componentes

### **🧠 Servicios del negocio**
Implementan funciones como:

- Registrar entidades  
- Actualizar órdenes  
- Asignar mecánicos  
- Asignar repuestos  
- Calcular costos  
- Cambiar estados  

Todos mediante **interfaces (DIP)**.

---

## 🗄️ Persistencia con Archivos JSON

Los aspectos de persistencia permiten:

- Guardar datos del taller sin usar una base de datos SQL  
- Mantener independencia entre capas  
- Serializar y deserializar entidades automáticamente  

Funciones principales:

- `Guardar()`  
- `Actualizar()`  
- `Eliminar()`  
- `LeerTodo()`  

---

## 🔐 Principios SOLID aplicados

| Principio | Aplicación |
|-----------|------------|
| **OCP** | Nuevas funciones se pueden agregar sin modificar las existentes. |
| **LSP** | Intercambio correcto entre clases hijas e interfaces. |
| **ISP** | Interfaces pequeñas y específicas para cada entidad. |
| **DIP** | MVC depende de interfaces, no de implementaciones. |

---

## 🎯 Resumen final

La **Biblioteca de Clases** es el corazón del sistema del Taller Mecánico.  
Contiene:

- El modelo del dominio  
- Las reglas del negocio  
- La lógica de eventos del proceso de reparación  
- El sistema de persistencia con archivos JSON  
- Los aspectos transversales  
- Servicios completamente desacoplados  

Gracias a su arquitectura modular, el proyecto web puede crecer sin comprometer la integridad de la lógica interna.

