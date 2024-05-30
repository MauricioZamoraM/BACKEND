package main

import (
	"fmt"
	"net/http"
	"time"
)

func send(ch chan string, message string) {
	ch <- message
}

// func main() {
// 	size := 4
// 	ch := make(chan string, size)
// 	send(ch, "one")
// 	send(ch, "two")
// 	send(ch, "three")
// 	send(ch, "four")
// 	fmt.Println("All data sent to the channel ...")

// 	for i := 0; i < size; i++ {
// 		fmt.Println(<-ch)
// 	}

// 	fmt.Println("Done!")
// }

// Error provocado intencionalmente
// La razón es que las llamadas a la función send son secuenciales. No está creando una goroutine. Por lo tanto,
// no hay nada que poner en cola.

// func main() {
// 	size := 2
// 	ch := make(chan string, size)
// 	send(ch, "one")
// 	send(ch, "two")
// 	send(ch, "three")
// 	send(ch, "four")
// 	fmt.Println("All data sent to the channel ...")

// 	for i := 0; i < size; i++ {
// 		fmt.Println(<-ch)
// 	}

// 	fmt.Println("Done!")
// }

func main() {
	start := time.Now()

	apis := []string{
		"https://management.azure.com",
		"https://dev.azure.com",
		"https://api.github.com",
		"https://outlook.office.com/",
		"https://api.somewhereintheinternet.com/",
		"https://graph.microsoft.com",
	}
	// Crear un canal en búfer con un tamaño de 10
	ch := make(chan string, 10)

	// chan<- int // it's a channel to only send data
	// <-chan int // it's a channel to only receive data

	for _, api := range apis {
		go checkAPI(api, ch)
	}

	for i := 0; i < len(apis); i++ {
		fmt.Print(<-ch)
	}

	elapsed := time.Since(start)
	fmt.Printf("Done! It took %v seconds!\n", elapsed.Seconds())
}

func checkAPI(api string, ch chan string) {
	_, err := http.Get(api)
	if err != nil {
		ch <- fmt.Sprintf("ERROR: %s is down!\n", api)
		return
	}

	ch <- fmt.Sprintf("SUCCESS: %s is up and running!\n", api)
}
