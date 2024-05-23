package models

import (
	"time"
)

type Libro struct {
    Id              uint       `json:"id"`
    Titulo          string     `json:"titulo"`
    TotalPaginas    string     `json:"totalPaginas"`
    Puntuacion      string     `json:"puntuacion"`
    Isbn            string     `json:"isbn"`
    FechaPublicacion time.Time  `json:"fechaPublicacion"`
    EditorialId     int        `json:"editorialId"`
    Autor           []*Autor   `json:"autor" gorm:"many2many:libro_autor;"`
	Editorial       Editorial  `json:"editorial" gorm:"foreignKey:EditorialId"`
}

func (libro *Libro) TableName() string {
	return "libro"
}