package main

import (
	"encoding/json"
	"fmt"
)

// Structs en Go son colecciones de campos de datos. Son tipos de datos compuestos que pueden contener diferentes tipos de datos, incluidos otros structs.
// Los structs proporcionan una forma conveniente de agrupar datos relacionados y modelar objetos del mundo real en programas Go.

// func main() {
// 	type Persona struct {
// 		Nombre string
// 		Edad   int
// 	}

// 	var p Persona
// 	p = Persona{Nombre: "Juan", Edad: 30}
// 	fmt.Println(p.Nombre) // Accede al campo Nombre, imprime "Juan"
// }

// type Employee struct {
// 	ID        int
// 	FirstName string
// 	LastName  string
// 	Address   string
// }

// func main() {
// 	// Crear una instancia de Employee con el apellido "Doe" y el nombre "John"
// 	employee := Employee{LastName: "Doe", FirstName: "John"}
// 	fmt.Println(employee)

// 	// Crear un puntero a la instancia de Employee creada anteriormente
// 	employeeCopy := &employee

// 	// Cambiar el valor del campo FirstName a "David" a través del puntero
// 	employeeCopy.FirstName = "David"

// 	// Imprimir el struct original
// 	fmt.Println(employee)
// }

//Decodificacion

type Person struct {
	ID        int
	FirstName string `json:"name"`
	LastName  string
	Address   string `json:"address,omitempty"`
}

type Employee struct {
	Person
	ManagerID int
}

type Contractor struct {
	Person
	CompanyID int
}

func main() {
	employees := []Employee{
		Employee{
			Person: Person{
				LastName: "Doe", FirstName: "John",
			},
		},
		Employee{
			Person: Person{
				LastName: "Campbell", FirstName: "David",
			},
		},
	}
	//Convierte a formato json
	data, _ := json.Marshal(employees)
	fmt.Printf("%s\n", data)

	//Esta función se utiliza para decodificar datos JSON en tipos de datos Go. Toma una cadena de bytes que representa un objeto JSON
	//y lo convierte en un valor Go del tipo adecuado.
	var decoded []Employee
	json.Unmarshal(data, &decoded)
	fmt.Printf("%v", decoded)
}
