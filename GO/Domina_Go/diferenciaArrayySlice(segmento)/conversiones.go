package main

import "fmt"

func main() {

	// Array: Tamaño fijo, el tamaño es parte del tipo, se pasa por valor a las funciones.
	var arr [3]int = [3]int{1, 2, 3}
	fmt.Println("Array:", arr)
	modifyArray(arr)
	fmt.Println("Array después de modificar:", arr) // No cambia

	// Slice: Tamaño dinámico, el tamaño no es parte del tipo, se pasa por referencia a las funciones, tiene longitud y capacidad.
	var s []int = []int{1, 2, 3}
	fmt.Println("Slice:", s)
	modifySlice(s)
	fmt.Println("Slice después de modificar:", s) // Cambia
}

// En Go, cuando se pasa un array a una función, se pasa una copia del array, no una referencia al array
// original. Esto significa que cualquier modificación realizada al array dentro de la función no afecta
// al array original que se encuentra fuera de la función.

func modifyArray(a [3]int) {
	a[0] = 100
}

func modifySlice(s []int) {
	s[0] = 100
}

// Estas diferencias hacen que los slices sean más flexibles y convenientes para la mayoría de los usos
// en Go, mientras que los arrays se utilizan en situaciones donde se requiere un tamaño fijo y constante.
