package main

import (
	"fmt"
	suma "modulo/funciones/operaciones"
)

func aplicarOperacion(numero1, numero2 int, operacion func(int, int) int) int {
	return operacion(numero1, numero2)
}

func main() {
	var resultado int

	resultado = aplicarOperacion(3, 4, suma.Sumar)
	fmt.Println("El resultado de la suma es:", resultado)
}
