package models

type Editorial struct {
	ID   int    `json:"id"`
	Nombre string `json:"nombre"`
}

func (editorial *Editorial) TableName() string {
	return "editorial"
}