package main

import "fmt"

func main() {
	// Los 3 puntos nos evita tener que indicar cuantas posiciones debe tener nuestra matriz
	cities := [...]string{"New York", "Paris", "Berlin", "Madrid"}
	fmt.Println("Cities:", cities)

	// cities := [5]string{"New York", "Paris", "Berlin", "Madrid"}
	// fmt.Println("Cities:", cities)
}
