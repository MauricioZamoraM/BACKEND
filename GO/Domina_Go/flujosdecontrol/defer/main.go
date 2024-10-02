package main

import (
	"fmt"
	"io"
	"os"
)

func main() {
	newfile, error := os.Create("learnGo.txt")
	if error != nil {
		fmt.Println("Error: Could not create file.")
		return
	}
	// Si no se utiliza defer para cerrar el archivo newfile, el archivo no se cerrará automáticamente al finalizar la función main()
	defer newfile.Close()
	// En resumen, el uso de defer newfile.Close() garantiza que el archivo se cierre correctamente al finalizar
	// la función main(), lo que es una práctica común para manejar adecuadamente los recursos en Go y evitar
	// posibles problemas de pérdida de datos o fugas de recursos.

	if _, error = io.WriteString(newfile, "Learning Go!"); error != nil {
		fmt.Println("Error: Could not write to file.")
		return
	}

	newfile.Sync()
}
