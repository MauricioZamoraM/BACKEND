// package main

// import (
// 	"fmt"
// 	"net/http"

// 	"github.com/tealeg/xlsx"
// )

// func generarXLSX() (*xlsx.File, error) {
// 	archivo := xlsx.NewFile()
// 	hoja, err := archivo.AddSheet("Hoja 1")
// 	if err != nil {
// 		return nil, err
// 	}

// 	fila := hoja.AddRow()
// 	celda := fila.AddCell()
// 	celda.Value = "Ana"
// 	celda = fila.AddCell()
// 	celda.Value = "Heredia"
// 	return archivo, nil
// }

// func main() {
// 	http.HandleFunc("/crearxlsx", func(w http.ResponseWriter, r *http.Request) {
// 		if r.Method == http.MethodGet {

// 			archivoXLSX, error := generarXLSX()

// 			if error != nil {
// 				fmt.Println("Error creando el archivo XLSX", http.StatusInternalServerError)
// 			}
// 			// w.WriteHeader(http.StatusOK)
// 			w.Header().Set("Content-Disposition", "attachment; filename=archivo.xlsx")
// 			w.Header().Set("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
// 			error = archivoXLSX.Write(w)

// 			if error != nil {
// 				fmt.Println("Error escribiendo el archivo XLSX", http.StatusInternalServerError)
// 			}

// 		} else {
// 			http.Error(w, "Recurso no encontrado.", http.StatusNotFound)
// 			return
// 		}
// 	})

// 	fmt.Println("La aplicacion se está ejecutando en 127.0.0.1:8080/crearxlsx")
// 	http.ListenAndServe(":8080", nil)
// }
