// package main

// import (
// 	"encoding/json"
// 	"fmt"
// 	"net/http"
// )

// type Cliente struct {
// 	Nombre string `json:"Nombre"`
// 	Edad   int    `json:"Edad"`
// 	Nacionalidad string `json:"Nacionalidad"`
// }

// func main() {
// 	http.HandleFunc("/cliente", func(w http.ResponseWriter, r *http.Request) {

// 		if r.Method == http.MethodPost {
// 			nuevoCliente := Cliente{
// 				Nombre: "Ana Rojas",
// 				Edad:   20,
// 				Nacionalidad: "Costarricense",
// 			}
// 			//Convertir a json
// 			clienteJson, error := json.Marshal(nuevoCliente)
// 			if error != nil{
// 				http.Error(w,"Error interno del servidor",http.StatusInternalServerError)
// 			}

// 			w.Header().Set("Content-Type", "application/json")
// 			w.Write(clienteJson)
// 		} else {
// 			http.Error(w, "Recurso no encontrado", http.StatusNotFound)
// 			return
// 		}
// 	})

// 	fmt.Println("La aplicacion se esta ejecutando en http://127.0.0.1:8080/cliente")
// 	http.ListenAndServe(":8080", nil)
// }
