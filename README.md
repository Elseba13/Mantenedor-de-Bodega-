# Sistema de abastecimiento 

Api Rest desarrollada en .Net haciendo uso de entity framework, que sus principales funcionalidades son: 

1.Aumentar y dismuniur stock de un articulo almacenado en bodega.

2.Asignar articulo en bodega.

3.Trasladar una cantidad del stock de un articulo a otra bodega.

4.Realizar ajuste de inventario. 

Tambien cuenta con el respectivo CRUD de las clases asociadas en el codigo. 

Para ejecutar la api hay que ir a la consola y agregar el siguiente comando: 
dotnet run 

Para hacer la conexion con la base de datos hay que ir al archivo appsettings.json y en la linea numero 12 en MantenedorConnection en la variable server colacar el nombre del server de sqlserver correspondiente. 
