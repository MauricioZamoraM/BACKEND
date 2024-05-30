package main

import (
	"fmt"
	"math"
)

// Definición de la interfaz Shape
// El contrato garantiza que cualquier objeto que implemente la interfaz Shape tendrá un método area()
type Shape interface {
	area() float64
}

// Definición de la estructura Circle
type Circle struct {
	radius float64
}

// Implementación del método area para Circle
// El tipo Circle tiene un método area() que devuelve un valor de tipo float64, cumpliendo así con el contrato de la
// interfaz Shape.
func (c Circle) area() float64 {
	return math.Pi * c.radius * c.radius
}

// Definición de la estructura Square
type Square struct {
	sideLength float64
}

// Implementación del método area para Square
// El tipo Square tiene un método area() que devuelve un valor de tipo float64, cumpliendo así con el contrato de la
// interfaz Shape.
func (s Square) area() float64 {
	return s.sideLength * s.sideLength
}

// Sí, ambas funciones tienen el mismo nombre: area(). En Go, los métodos se definen con la sintaxis
// func (receiver) methodName() returnType, donde receiver es el parametro que recibe el metodo, methodName es el nombre del método. En este caso, ambas funciones
// se definen como métodos con el nombre area() para los tipos Circle y Square, respectivamente. A pesar de que tienen
// el mismo nombre, están asociadas con tipos diferentes (Circle y Square) y pueden ser llamadas en instancias de esos
// tipos. Esto se conoce como sobreescritura de método en el contexto de la programación orientada a objetos, donde una
// clase puede tener varios métodos con el mismo nombre, pero su comportamiento difiere según el tipo de objeto en el
// que se llama. En este caso, area() calcula el área de un círculo en el método asociado con Circle y el área de un
// cuadrado en el método asociado con Square.

func printArea(shape Shape) {
	fmt.Printf("Area of the shape: %.2f\n", shape.area())
}

func main() {
	// Crear una instancia de Circle
	circle := Circle{radius: 5}
	// Imprimir el área del círculo
	printArea(circle)

	// Crear una instancia de Square
	square := Square{sideLength: 4}
	// Imprimir el área del cuadrado
	printArea(square)
}

// Se aplica el polimorfismo a través del uso de la interfaz Shape. Esta interfaz define un contrato común para todos
// los tipos que implementan un método area(), permitiendo que objetos de diferentes tipos (en este caso, Circle y Square)
// sean tratados de manera uniforme cuando se pasan como argumentos a la función printArea()
