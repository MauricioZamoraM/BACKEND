package models

type Autor struct {
	ID   int    `json:"id"`
	Nombre string `json:"nombre"`
	Apellido string `json:"apellido"`
}

func (autor *Autor) TableName() string {
	return "autor"
}