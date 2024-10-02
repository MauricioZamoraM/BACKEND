package controllers

import (
	"go_libreria/app/models"
	"go_libreria/app/services"
	"net/http"

	"github.com/gin-gonic/gin"
)

func ListaLibros(c *gin.Context) {
	var libros []models.Libro
	err := services.ListaLibros(&libros)
	if err != nil {
		c.AbortWithStatus(http.StatusNotFound)
	} else {
		c.JSON(http.StatusOK, libros)
	}
}