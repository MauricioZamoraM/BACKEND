package main

import "fmt"

func main() {
    x := 42
    p := &x        // p es un puntero a x

    fmt.Println(*p)  // Imprime 42

    *p = 21         // Cambia el valor de x a través del puntero
    fmt.Println(x)  // Imprime 21
}
