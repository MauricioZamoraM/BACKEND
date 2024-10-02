package main

import (
	"fmt"
	"net/http"

	"github.com/gorilla/websocket"
)

var upgrader = websocket.Upgrader{}

func main() {
	http.HandleFunc("/ws", func(w http.ResponseWriter, r *http.Request) {
		conexion, error := upgrader.Upgrade(w, r, nil)
		if error != nil {
			fmt.Println("Error actualizando el WebSocket")
			return
		}
		defer conexion.Close()
		fmt.Println("Cliente conectado")

		mensajeServidor := []byte("¡Hola, cliente!")

		_, mensaje, error := conexion.ReadMessage()
		if error != nil {
			fmt.Println("Error al leer el mensaje")
			return
		}

		fmt.Printf("Mensaje recibido: %s\n", mensaje)

		error = conexion.WriteMessage(websocket.TextMessage, mensajeServidor)
		if error != nil {
			fmt.Println("Error al escribir el mensaje")
			return
		}
	})

	fmt.Println("Servidor WebSoket escuchando en el puerto 8080...")
	http.ListenAndServe(":8080", nil)
}
