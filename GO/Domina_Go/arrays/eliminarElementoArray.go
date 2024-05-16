// package main

// import (
// 	"fmt"
// )

// func encontrarPosicion(diasSemana []string, dia string) int {
// 	for i := 0; i < len(diasSemana); i++ {
// 		if diasSemana[i] == dia {
// 			return i
// 		}
// 	}
// 	return -1
// }

// func main() {
// 	diasSemana := []string{"Lunes", "Martes", "Miercoles", "Jueves", "Viernes"}
// 	fmt.Println(diasSemana)

// 	var posicion int = encontrarPosicion(diasSemana, "Jueves")

// 	diasSemana = append(diasSemana[:posicion], diasSemana[posicion+1:]...)

// 	fmt.Println(diasSemana)

// }
