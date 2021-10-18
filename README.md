# GrainChainMatrix
Prueba de lógica GrainChain

El proyecto está desarrollado en .Net Framework 4.7.2

Descargar, restaurar las dependencias Nuget, compilar y ejecutar el proyecto.

En la primera opción del menú, cargar la matriz de la habitación en un archivo .txt, de acuerdo al siguiente ejemplo:

10000111

01000000

01000111

Donde 0 es un espacio en la habitación y 1 es una pared

En la segunda opción, se presenta la distribución de bombillos una vez cargada la matriz de la habitación.

En la clase ResultadoViewModel.cs se encuentra el método DistribucionBombillos que es el encargado de procesar la matriz.

También se incluyó un proyecto de Tests con xUnit para tener pruebas unitarias de los métodos principales.

