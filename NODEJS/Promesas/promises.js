// PROCESO SINCRONO
//SE VALIDA SI EL USUARIO EXISTE EN LA BASE DE DATOS
function validarUsuario(usuario) {
    return new Promise((resolve, reject) => {
        console.log(`Este el el usuario recibido: ${usuario}`)
        setTimeout(() => {
            if (usuario === 'Mauricio') {
                console.log('Usuario confirmado!')
                resolve(usuario);
            } else {
                reject('Usuario inválido!');
            }
        }, 2000);
    })
}
//SE AGREGA EL USUARIO COMO ADMINISTRADOR
function agregarUsuarioAdmin(respuesta) {
    return new Promise((resolve) => {
        console.log('Procesando usuario...')
        console.log(`El usuario es: ${respuesta}`)
        setTimeout(() => {
            resolve('Usuario agregado correctamente!')
        }, 4000)
    })
}

// Encadenamos las promesas
validarUsuario('Mauricio')
    .then(respuesta => {
        console.log(respuesta)
        return agregarUsuarioAdmin(respuesta)
    })
    .then(respuesta => {
        console.log(respuesta)
    })
    .catch(error => {
        console.log(error)
    })

// // PROCESO ASINCRONO
// async function mostrarUsuario(usuario) {
//     try {
//         const respuesta = await validarUsuario(usuario)
//         console.log(respuesta);
//         const respuestaProcesada = await agregarUsuarioAdmin(respuesta)
//         console.log(respuestaProcesada);
//     } catch (error) {
//         console.log(error)
//     }
// }

// mostrarUsuario('Mauricio')
