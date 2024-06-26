# Inventory Application

## Descripción

Inventory es una aplicación diseñada para gestionar el inventario de una empresa de manera eficiente. Este proyecto utiliza una arquitectura modular para garantizar su escalabilidad y facilidad de mantenimiento.

## Estructura del Proyecto

El proyecto está organizado en los siguientes módulos:

- **Api**: Provee las API para la interacción con otros sistemas.
- **Application**: Contiene la lógica de negocio principal.
- **Domain**: Define las entidades y reglas de dominio.
- **Infrastructure**: Maneja la comunicación con la base de datos y otros servicios externos.
- **Libraries**: Contiene librerías compartidas utilizadas en diferentes módulos del proyecto.

## Tecnologías Utilizadas

- **Lenguaje de programación**: C#
- **Contenedores**: Docker

## Configuración

Para configurar y ejecutar la aplicación localmente:

1. Clonar el repositorio:
    ```sh
    git clone https://github.com/juanpavasgarzon/Inventory.git
    ```
2. Navegar al directorio del proyecto:
    ```sh
    cd Inventory
    ```
3. Configurar y levantar los contenedores de Docker:
    ```sh
    docker-compose up
    ```

## Contribuciones

Las contribuciones son bienvenidas. Para contribuir, sigue estos pasos:

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-feature`).
3. Realiza los cambios necesarios y haz commits (`git commit -m 'Agrega nueva feature'`).
4. Sube tus cambios a tu fork (`git push origin feature/nueva-feature`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Para preguntas o comentarios, contacta al autor del proyecto a través de su perfil de GitHub: [juanpavasgarzon](https://github.com/juanpavasgarzon).
