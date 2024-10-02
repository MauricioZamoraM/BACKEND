// No le colocamos la ruta porque ya viene instalado en el cor de node, se debe trabajar de forma asincrona para no bloquear el hilo de ejecucion principal.
const fs = require('fs');

function leer(ruta, cb) {
  fs.readFile(ruta, (err, data) => {
    console.log(data.toString());
  })
}

function escribir(ruta, contenido, cb) {
  fs.writeFile(ruta, contenido, function (err) {
    if (err) {
      console.error('No he podido escribirlo', err)
    } else {
      console.log('se ha escrito correctamente!')
    }
  })
}

function borrar(ruta, cb) {
  fs.unlink(ruta, cb);
}

// escribir(__dirname + '/archivo1.txt', 'Soy un archivo nuevo', console.log)
// leer(__dirname + '/archivo.txt', console.log);
// borrar(__dirname + '/archivo1.txt', console.log)