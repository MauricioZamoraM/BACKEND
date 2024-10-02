package config

import (
	"fmt"
	"os"
	"strconv"

	"github.com/jinzhu/gorm"
	"github.com/joho/godotenv"
)

var DB *gorm.DB

type Config struct {
	DB_USER string
	DB_PASSWORD string
	DB_HOST     string
	DB_PORT     int
	DB_NAME     string
}

func CargarConfig() *Config {
	err := godotenv.Load()
    if err != nil {
        fmt.Println("Error al cargar el archivo .env:", err)
        return nil
    }

	port, err := strconv.Atoi(os.Getenv("DB_PORT"))
	if err != nil {
		return nil
	}
	
	config := &Config{
		DB_USER: os.Getenv("DB_USER"),
		DB_PASSWORD: os.Getenv("DB_PASSWORD"),
		DB_HOST:     os.Getenv("DB_HOST"),
		DB_PORT:     port,
		DB_NAME:     os.Getenv("DB_NAME"),
	}

	return config
}

func URLBaseDatos(config *Config) string {
	return fmt.Sprintf(
		"%s:%s@tcp(%s:%d)/%s?charset=utf8&parseTime=True&loc=Local",
		config.DB_USER,
		config.DB_PASSWORD,
		config.DB_HOST,
		config.DB_PORT,
		config.DB_NAME,
	)
}
