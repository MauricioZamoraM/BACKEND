// package main

// import "fmt"

// func main() {
//     // Declaración de un array de longitud fija
//     array := [5]int{1, 2, 3, 4, 5}

//     // Convertir el array a un slice
//     slice := array[:]

//     fmt.Println("Array:", array)
//     fmt.Println("Slice:", slice)
// }

package main

import "fmt"

func main() {
	// Declaración de un slice
	slice := []int{1, 2, 3, 4, 5}

	// Convertir el slice a un array usando copy()
	var array1 [5]int
	copy(array1[:], slice)

	// Convertir el slice a un array especificando la longitud
	array2 := [5]int{}
	copy(array2[:], slice)

	fmt.Println("Slice:", slice)
	fmt.Println("Array 1:", array1)
	fmt.Println("Array 2:", array2)
}
