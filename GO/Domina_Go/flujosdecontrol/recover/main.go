package main

import "fmt"

func highlow(high int, low int) {
	if low > high {
		fmt.Println("Panic!")
		//Este es el error de seguimiento de pila
		panic("highlow() low mayor que high") //El panic detiene la ejecucion y acaba con el problema de recursividad
	}

	defer fmt.Println("Deferred: highlow(", high, ",", low, ")")
	fmt.Println("Call: highlow(", high, ",", low, ")")
	highlow(high, low+1)
}

func main() {
	// defer intenta recuperar cualquier pánico que ocurra dentro de la función main(), imprimiendo un mensaje
	// informativo si se recupera un pánico. Esto permite que el programa pueda continuar su ejecución en lugar
	// de terminar abruptamente.
	defer func() {
		handler := recover()
		if handler != nil {
			fmt.Println("main(): recover", handler)
		}
	}()

	highlow(2, 0)
	fmt.Println("Program finished successfully!")
}
