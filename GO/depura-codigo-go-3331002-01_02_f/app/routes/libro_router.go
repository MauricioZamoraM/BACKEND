package routes

import (
	"go_libreria/app/controllers"

	"github.com/gin-gonic/gin"
)

func LibroRouter() {
	router := gin.Default()
	
	router.GET("/",  controllers.ListaLibros)
	router.Run()
}
