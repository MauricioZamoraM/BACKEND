package main

import "fmt"

func highlow(high int, low int) {
	// Si esta condición no se cumple, es decir, si high es menor que low, se considera un error grave
	// que justifica detener la ejecución del programa.
	if low > high {
		fmt.Println("Panic!")
		// La función panic se usa como un mecanismo para manejar errores graves que ocurren en tiempo de ejecución
		// y que hacen que el programa no pueda continuar su ejecución normal.
		panic("highlow() low mayor que high")
	}
	// El defer se ejecuta cuando la función highlow termina, ya sea normalmente por un retorno explícito o por un pánico,
	// asegurando que el mensaje diferido se imprima justo antes de que la función realmente termine.
	defer fmt.Println("Deferred: highlow(", high, ",", low, ")")
	fmt.Println("Call: highlow(", high, ",", low, ")")
}

func main() {
	var counter = 3
	for i := 0; i <= counter; i++ {
		highlow(2, i)
	}
	fmt.Println("Program finished successfully!")
}

// package main

// import "fmt"

// func highlow(high int, low int) {
// 	if low > high {
// 		fmt.Println("Panic!")
// 		// panic("highlow() low mayor que high")  //El panic detiene la ejecucion y acaba con el problema de recursividad
// 	}

// 	defer fmt.Println("Deferred: highlow(", high, ",", low, ")")
// 	fmt.Println("Call: highlow(", high, ",", low, ")")
// 	highlow(high, low+1)
// 	// Recursión infinita ocurre cuando una función recursiva se llama a sí misma de forma indefinida,
// 	// sin alcanzar nunca un caso base que detenga la recursión. Esta situación conduce a un desbordamiento de la pila
// 	// (stack overflow) debido al agotamiento de la memoria disponible para almacenar las llamadas recursivas en la pila de ejecución.
// 	// Cuando una función recursiva no alcanza un caso base que detenga la recursión, cada llamada recursiva agrega una nueva entrada en
// 	// la pila de ejecución. Con el tiempo, estas llamadas recursivas acumulan tantos marcos de pila que exceden el límite de la memoria
// 	// disponible, provocando un desbordamiento de la pila y terminando con un error en tiempo de ejecución.
// }

// func main() {
// 	highlow(2, 0)
// 	fmt.Println("Program finished successfully!")
// }
