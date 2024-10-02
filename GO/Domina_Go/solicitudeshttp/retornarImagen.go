// package main

// import (
// 	"fmt"
// 	"net/http"
// 	"os"
// )

// func main() {
// 	http.HandleFunc("/imagen", func(w http.ResponseWriter, r *http.Request) {
// 		if r.Method == http.MethodGet {
// 			archivo := "firma.png"
// 			imagen, error := os.ReadFile(archivo)

// 			if error != nil {
// 				fmt.Println(error)
// 			}
// 			w.WriteHeader(http.StatusOK)
// 			w.Header().Set("Content-Type", "application/octet-stream")
// 			w.Write(imagen)
// 		} else {
// 			http.Error(w, "Recurso no encontrado.", http.StatusNotFound)
// 			return
// 		}
// 	})

// 	fmt.Println("La aplicacion se está ejecutando en 127.0.0.1:8080/imagen")
// 	http.ListenAndServe(":8080", nil)
// }
