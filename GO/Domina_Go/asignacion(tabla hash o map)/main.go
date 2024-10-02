package main

import "fmt"

//Es una colección de pares de clave y valor. Todas las claves de una asignación deben ser del mismo tipo,
//como los valores, pero se pueden usar diferentes tipos para las claves y los valores.
// func main() {
// 	studentsAge := map[string]int{
// 		"john": 32,
// 		"bob":  31,
// 	}
// 	fmt.Println(studentsAge)
// }

// func main() {
//     // Usando make para inicializar un mapa vacío
//     studentsAge := make(map[string]int)

//     // Agregando elementos al mapa
//     studentsAge["john"] = 32
//     studentsAge["bob"] = 31

//     // Imprimiendo el mapa
//     fmt.Println("Mapa usando make:", studentsAge)
// }

func main() {
	// Declaración de un mapa sin inicializarlo (se inicializa con nil)
	var studentsAge map[string]int

	// Agregando elementos al mapa (esto resultará en un error de tiempo de ejecución)
	studentsAge["john"] = 32
	studentsAge["bob"] = 31

	// Inicialización del mapa con valores directamente
	// studentsAge = map[string]int{
	//     "john": 32,
	//     "bob":  31,
	// }

	// Imprimiendo el mapa
	fmt.Println("Mapa sin usar make:", studentsAge)
}
