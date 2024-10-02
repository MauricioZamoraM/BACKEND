// package main

// import (
// 	"fmt"
// 	"strconv"
// )

// func main() {
// 	var numeroEntero int
// 	var numeroFlotante float64
// 	var numeroString string

// 	//Convertir de int a float
// 	numeroEntero = 12
// 	numeroFlotante = float64(numeroEntero)
// 	fmt.Printf("El tipo de dato de numeroFlotante es: %T\n", numeroFlotante)
// 	fmt.Println("Número Flotante: ", numeroFlotante, "\n")

// 	//Convertir de float a int
// 	numeroFlotante = 32.9
// 	numeroEntero = int(numeroFlotante)
// 	fmt.Printf("El tipo de dato de numeroEntero es: %T\n", numeroEntero)
// 	fmt.Println("Número Entero", numeroEntero, "\n")

// 	//Convertir de int a string
// 	numeroEntero = 39
// 	numeroString = strconv.Itoa(numeroEntero)
// 	fmt.Printf("El tipo de dato de numeroString es: %T\n", numeroString)
// 	fmt.Println("Número String", numeroString, "\n")

// 	//Convertir de string a int
// 	numeroString = "50"
// 	numeroEntero, err := strconv.Atoi(numeroString)
// 	if err != nil {
// 		fmt.Println(err)
// 	} else {
// 		fmt.Printf("El tipo de dato de numeroEntero es: %T\n", numeroEntero)
// 		fmt.Println("Número Entero ", numeroEntero)
// 	}
// }
