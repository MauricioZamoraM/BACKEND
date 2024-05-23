package database

import (
	"fmt"
	"go_libreria/app/config"
	"go_libreria/app/models"

	"github.com/jinzhu/gorm"
)

var err error

func ConectarBaseDeDatos() error {
    config.DB, err = gorm.Open("mysql", config.URLBaseDatos(config.CargarConfig()))

    if err != nil {
		fmt.Println("Error:", err)
	}

    return nil
}


func ConfigurarBaseDeDatos() error {
	config.DB.AutoMigrate(&models.Libro{}, &models.Autor{}, &models.Editorial{})
	return nil
}
