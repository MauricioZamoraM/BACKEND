package main

import (
	"fmt"
)

func main() {
	// Declaración de un segmento
	var s []int

	// Inicialización de un segmento con valores
	s = []int{1, 2, 3, 4, 5}

	// Agregar elementos a un segmento
	s = append(s, 6, 7, 8)

	fmt.Println(s)
	// Cortar un segmento (subsegmento)
	subSlice := s[2:5] // Contendrá [3, 4, 5]

	fmt.Println(subSlice)
}
