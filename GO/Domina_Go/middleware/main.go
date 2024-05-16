// package main

// import (
// 	"encoding/json"
// 	"fmt"
// 	"net/http"
// )

// type Usuario struct {
// 	Usuario      string
// 	ClaveSecreta string
// }

// func autenticacion(next http.Handler) http.Handler {
// 	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
// 		var nuevoUsuario Usuario
// 		error := json.NewDecoder(r.Body).Decode(&nuevoUsuario)

// 		if error != nil {
// 			fmt.Println(error)
// 		}

// 		if nuevoUsuario.Usuario != "mi_usuario" || nuevoUsuario.ClaveSecreta != "12345" {
// 			http.Error(w, "No autorizado", http.StatusUnauthorized)
// 			return
// 		}

// 		next.ServeHTTP(w, r)
// 	})
// }

// func inicioHandler(w http.ResponseWriter, r *http.Request) {
// 	w.Header().Set("Content-Type", "text/plain")
// 	w.Write([]byte("¡Bienvenido!"))
// }

// func main() {
// 	mux := http.NewServeMux()
// 	middleware := autenticacion(http.HandlerFunc(inicioHandler))
// 	mux.Handle("/inicio", middleware)

// 	fmt.Println("La aplicacion se está ejecutando en 127.0.0.1:8080/inicio")
// 	http.ListenAndServe(":8080", mux)
// }
