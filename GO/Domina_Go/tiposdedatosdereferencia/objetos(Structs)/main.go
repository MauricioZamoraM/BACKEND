package main

import (
	"fmt"
)

func main() {
	type Persona struct {
		Nombre string
		Edad   int
	}

	var p Persona
	p = Persona{Nombre: "Juan", Edad: 30}
	fmt.Println(p.Nombre) // Accede al campo Nombre, imprime "Juan"
}
