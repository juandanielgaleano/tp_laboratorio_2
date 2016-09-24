#include <stdio.h>
#include <stdlib.h>
#include "Prototipos.h"
#define tam 5

int main()
{
    char seguir='s';
    int opcion=0;
    int DNI=0;
    int auxDni=0;
    int indiceBorrar;
    ePersona persona[tam];
    inicializarEstructura(persona);

    while(seguir=='s')
    {
        system("cls");
        printf("\n----------------------------------------------------------\n");
        printf("            1- Agregar persona\n");
        printf("            2- Borrar persona\n");
        printf("            3- Imprimir lista ordenada por  nombre\n");
        printf("            4- Imprimir grafico de edades\n\n");
        printf("            5- Salir\n");
        printf("\n----------------------------------------------------------\n");

        scanf("%d",&opcion);

        switch(opcion)
        {
            case 1:
                obtenerEspacioLibre(persona);
                system("cls");
                break;
            case 2:
                system("cls");
                printf("\nIngrese DNI de la persona a borrar: \n");
                scanf("%d",&auxDni);
                while(auxDni<0 || auxDni>999999999)
                    {
                        printf("\nError, DNI invalido, reingrese: \n");
                        scanf("%d",&auxDni);
                    }
                DNI=auxDni;
                indiceBorrar=buscarPorDni(persona,DNI);
                borrarPersona(persona,indiceBorrar);
                break;
            case 3:
                system("cls");
                mostrarPersona(persona);
                system("pause");
                break;
            case 4:
                system("cls");
                realizaGrafica(persona);
                system("pause");
                break;
            case 5:
                seguir = 'n';
                break;
        }
    }
    return 0;
}
