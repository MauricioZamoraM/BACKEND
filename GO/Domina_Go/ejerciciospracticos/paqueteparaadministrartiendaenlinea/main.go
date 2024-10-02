// Creación de un paquete para administrar una tienda en línea
// Escriba un programa que use un paquete personalizado para administrar cuentas para una tienda en línea. 
// El desafío incluye estos cuatro elementos:

// Cree un tipo personalizado denominado Account que incluya el nombre y el apellido del propietario de la 
// cuenta. El tipo también debe incluir la funcionalidad ChangeName.

// Cree otro tipo personalizado denominado Employee que incluya una variable para almacenar el número de créditos
// como tipo float64 y que inserte el objeto Account. El tipo también debe incluir la funcionalidad AddCredits, 
// RemoveCredits y CheckCredits. Debe demostrar que puede cambiar el nombre de la cuenta a través del objeto Employee.

// Escriba un método Stringer en su Account objeto para que el nombre de Employee se pueda imprimir en un formato
// que incluya el nombre y el apellido.

// Por último, escriba un programa que consuma el paquete que ha creado y pruebe toda la funcionalidad que se 
// muestra en este desafío. Es decir, el programa principal debe cambiar el nombre, imprimirlo, agregar el crédito, 
// quitar el crédito y comprobar el saldo.


package main

import (
    "fmt"
	store "modulo/ejerciciospracticos/paqueteparaadministrartiendaenlinea/tienda"
)

func main() {
    bruce, _ := store.CreateEmployee("Bruce", "Lee", 500)
    fmt.Println(bruce.CheckCredits())
    credits, err := bruce.AddCredits(250)
    if err != nil {
        fmt.Println("Error:", err)
    } else {
        fmt.Println("New Credits Balance = ", credits)
    }

    _, err = bruce.RemoveCredits(2500)
    if err != nil {
        fmt.Println("Can't withdraw or overdrawn!", err)
    }

    bruce.ChangeName("Mark")

    fmt.Println(bruce)
}