// Importar Express
const express = require('express');

// Crear una instancia de Express
const app = express();

// Ruta de ejemplo
app.get('/Api_Core', (req, res) => {
  res.send('¡Hola desde la API!');
});

// Iniciar el servidor
app.listen(5288, () => {
  console.log('La API está funcionando en http://localhost:5288/Api_Core');
});
