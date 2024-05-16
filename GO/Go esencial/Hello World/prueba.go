package main

import "fmt"

var nombre = "Carlos"

func main() {
	// const elefantes = 5

	// for i := 0; i < elefantes; i++ {
	// 	if i == 0 {
	// 		fmt.Printf("Un elefante se balanceaba\n")
	// 	} else {
	// 		fmt.Printf("Los elefantes se balanceaban\n")
	// 	}
	// }

	fmt.Print(ganado(1))

}

func ganado(numero int) (int, string) {

	vacas := func() int {
		return numero * 10
	}

	return vacas() + 1, " vacas"
}
