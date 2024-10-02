package main

import (
	"fmt"
	"time"
)

func main() { // Define la función principal del programa, que es el punto de entrada.
	fmt.Println("Hola desde afuera")
	c := make(chan string) // Crea un canal de tipo string y lo asigna a la variable c. Los canales se utilizan para la comunicación entre goroutines.

	go func() { // Define y lanza una goroutine anónima
		time.Sleep(4 * time.Second)          // Pausa la ejecución de esta goroutine durante 2 segundos.
		c <- "Hello, World! desde goroutine" // Envía el mensaje "Hello, World!" al canal c una vez que han pasado los 2 segundos.
	}()

	msg := <-c       // Espera y recibe un mensaje desde el canal c. Este mensaje será "Hello, World! desde goroutine" después de que la goroutine termine su pausa.
	fmt.Println(msg) // Imprime el mensaje recibido a la consola.

	fmt.Println("Hola desde afuera") // Imprime el mensaje recibido a la consola.

	// Este programa demuestra cómo se puede utilizar la concurrencia en Go para realizar operaciones
	// asíncronas y coordinar la comunicación entre diferentes partes del programa usando canales.

}
