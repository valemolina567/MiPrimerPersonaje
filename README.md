# Haru - Animación de Personaje 2D en Unity

## Descripción

Haru es una animación 2D realizado en Unity. El personaje principal es una conejita llamada **Haru**, diseñada originalmente en Figma, exportada a Photoshop y guardada como archivo `.psb` para poder importarla a Unity utilizando el sistema de rigging 2D.

Dentro de Unity, se le añadieron huesos y dependencias de huesos para crear una animación simple de movimiento.

Actualmente, Haru puede:

* Permanecer en estado Idle.
* Caminar hacia la izquierda y la derecha.
* Cambiar de orientación automáticamente según la dirección.
* Reproducir la animación correspondiente al caminar.

El escenario contiene:

* Un fondo azul.
* Dos pedestales laterales.
* Una plataforma inferior donde se encuentra Haru.

---

## Herramientas Utilizadas

* Figma
* Adobe Photoshop
* Unity
* Visual Studio Code

---

## Proceso de Creación

### 1. Diseño del personaje

El personaje fue creado en Figma separando cada parte del cuerpo en capas:

* Cabeza
* Brazos
* Piernas
* Torzo

### 2. Exportación a Photoshop

El diseño se exportó a Photoshop para conservar las capas y posteriormente se guardó como archivo `.psb`.

### 3. Importación en Unity

El archivo `.psb` se importó a Unity. Después se utilizó el Sprite Editor y el Skinning Editor para:

* Crear huesos.
* Asignar huesos a cada parte del cuerpo.
* Configurar las dependencias de movimiento.

### 4. Animaciones

Se crearon dos estados de animación:

* `Idle`: Haru permanece quieta.
* `Walk`: Haru reproduce una animación de caminar.

Las transiciones entre ambos estados dependen de un parámetro booleano del Animator llamado:

```text
Estacaminando
```

---

## Script de Movimiento

El personaje utiliza un script llamado `PlayerController.cs`.

### Funcionalidades del script

* Detecta el movimiento horizontal usando las flechas del teclado.
* Mueve al personaje con `Rigidbody2D`.
* Invierte el sprite cuando cambia de dirección.
* Cambia entre las animaciones de caminar e idle.

---

## Configuración del Animator

El Animator debe contener:

### Parámetros

* `Estacaminando` (Bool)

### Estados

* `Idle`
* `Walk`

### Transiciones

* `Idle -> Walk` cuando `Estacaminando == true`
* `Walk -> Idle` cuando `Estacaminando == false`

---

## Controles

| Tecla            | Acción                          |
| ---------------- | ------------------------------- |
| Flecha Izquierda | Mover a Haru hacia la izquierda |
| Flecha Derecha   | Mover a Haru hacia la derecha   |

---
