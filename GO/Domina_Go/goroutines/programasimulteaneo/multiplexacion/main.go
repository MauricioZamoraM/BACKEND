package main

import (
	"fmt"
	"time"
)

// Simula un proceso que tarda 3 segundos
func process(ch chan string) {
	time.Sleep(3 * time.Second)
	ch <- "Done processing!"
}

// Simula una replicación que tarda 1 segundo
func replicate(ch chan string) {
	time.Sleep(1 * time.Second)
	ch <- "Done replicating!"
}

// chan<- int // it's a channel to only send data
// <-chan int // it's a channel to only receive data
func main() {
	ch1 := make(chan string)
	ch2 := make(chan string)

	// Lanza la goroutine process
	go process(ch1)
	// Lanza la goroutine replicate
	go replicate(ch2)

	// Bucle que se ejecuta dos veces para recibir de ambos canales
	for i := 0; i < 2; i++ {
		select {
		// Espera y recibe un mensaje de ch1
		case process := <-ch1:
			fmt.Println(process)
		// Espera y recibe un mensaje de ch2
		case replicate := <-ch2:
			fmt.Println(replicate)
		}
	}
}

//Muestra primero "Done replicating!" debido a las diferencias en los tiempos de espera (time.Sleep) en las goroutines process
