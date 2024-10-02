// package main

// import (
// 	"fmt"
// 	"net/http"
// )

// func main() {
// 	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {

// 		if r.Method == http.MethodGet {
// 			nombre := r.URL.Query().Get("nombre")

// 			w.Header().Set("Content-Type", "text/plain")
// 			w.Write([]byte(nombre))
// 		} else {
// 			http.Error(w, "Recurso no encontrado", http.StatusNotFound)
// 			return
// 		}
// 	})

// 	fmt.Println("La aplicacion se esta ejecutando en http://127.0.0.1:8080")
// 	http.ListenAndServe(":8080", nil)
// }
