#ifndef IMPLEMENTACION_H_INCLUDED
#define IMPLEMENTACION_H_INCLUDED
typedef struct
{
    char nombre[50];
    int edad;
    int estado;
    int dni;
}ePersona;
void inicializarEstructura(ePersona persona[]);
void obtenerEspacioLibre(ePersona persona[]);
int buscarPorDni(ePersona lista[], int dni);
void mostrarPersona (ePersona persona[]);
void validarDni (ePersona persona[]);
void borrarPersona(ePersona persona[], int i);
void realizaGrafica (ePersona persona []);
#endif // IMPLEMENTACION_H_INCLUDED
