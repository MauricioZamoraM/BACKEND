package main

import (
	"go_libreria/app/database"
	"go_libreria/app/routes"
)

func main() {
	database.ConectarBaseDeDatos()
	database.ConfigurarBaseDeDatos()

	routes.LibroRouter()
}
