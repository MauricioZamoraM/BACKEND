package services

import (
	"go_libreria/app/config"
	"go_libreria/app/models"

	_ "github.com/go-sql-driver/mysql"
)

func ListaLibros(libro *[]models.Libro) (err error) {
	if err = config.DB.Preload("Autor").Preload("Editorial").Find(libro).Error; err != nil {
		return err
	}
	return nil
}