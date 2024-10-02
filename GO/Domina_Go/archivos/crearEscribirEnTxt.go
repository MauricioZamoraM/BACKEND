package main

import (
	"fmt"
	"os"
)

func main() {
	archivo := "archivos/texto2.txt"
	f, error := os.Create(archivo)
	if error != nil {
		fmt.Println(error)
		return
	}

	_, error = f.WriteString("La programacion es el arte de crear soluciones con codigo.")

	if error != nil {
		fmt.Println(error)
		return
	}

	defer f.Close()
	fmt.Println("El archivo %s ha sido creado exitosamente", archivo)
}
