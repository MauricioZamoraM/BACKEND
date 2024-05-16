// package main

// import (
// 	"encoding/xml"
// 	"fmt"
// 	"net/http"
// )

// type Cliente struct {
// 	XMLName xml.Name `xml:"cliente"`
// 	Nombre  string   `xml:"Nombre"`
// 	Edad    int      `xml:"Edad"`
// }

// func main() {
// 	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {

// 		if r.Method == http.MethodGet {
// 			nuevoCliente := Cliente{
// 				Nombre: "Ana Rojas",
// 				Edad:   20,
// 			}

// 			clienteXML, error := xml.MarshalIndent(nuevoCliente, "", " ")

// 			if error != nil {
// 				http.Error(w, "Error interno del servidor", http.StatusInternalServerError)
// 			}

// 			w.Header().Set("Content-Type", "application/xml")
// 			w.Write(clienteXML)
// 		} else {
// 			http.Error(w, "Recurso no encontrado", http.StatusNotFound)
// 			return
// 		}
// 	})

// 	fmt.Println("La aplicacion se esta ejecutando en http://127.0.0.1:8080")
// 	http.ListenAndServe(":8080", nil)
// }
