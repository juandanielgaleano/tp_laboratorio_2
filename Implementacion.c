#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Prototipos.h"
#define tam 5

/** \brief  Inicializa el estado del vector de estructura en 0(cero) para su utilizacion posterior.
 *
 * \param Estado de la estructura persona.
 * \return no devuelve nada.
 *
 */

void inicializarEstructura(ePersona persona[])
{
    int i=0;
    for(i=0;i<tam;i++)
    {
        persona[i].estado=0;
    }
}

/**
 * Obtiene el primer indice libre del array para cargar datos, luego de cargar rompe la iteracion con  un break.
 * @param lista el array se pasa como parametro.
 * @return el primer indice disponible
 */
void obtenerEspacioLibre(ePersona persona[])
{


    int i=0;
    char auxNombre[100];
    int auxEdad=0;
    int auxDNI=0;

            for(i=0;i<tam;i++)
                {
                        if(persona[i].estado==0)
                        {
                                printf("\nIngrese nombre de la persona: \n");
                                fflush(stdin);
                                gets(auxNombre);
                                while(strlen(auxNombre)>20)
                                    {
                                        printf("\nError, nombre demasiado largo, reingrese: \n");
                                        gets(auxNombre);
                                        fflush(stdin);
                                    }
                                strcpy(persona[i].nombre,auxNombre);
                                printf("\nIngrese edad: \n");
                                scanf("%d",&auxEdad);
                                while(auxEdad<0 || auxEdad>125)
                                {
                                    printf("\nError! Edad fuera de rango, reingrese\n");
                                    scanf("%d",&auxEdad);
                                }
                                persona[i].edad=auxEdad;
                                printf("\nIngres DNI\n");
                                scanf("%d",&auxDNI);
                                while(auxDNI<0 || auxDNI>999999999)
                                {
                                    printf("\nError! DNI invalido, reingrese: \n");
                                    fflush(stdin);
                                    scanf("%d",&auxDNI);

                                }
                                persona[i].dni=auxDNI;

                                persona[i].estado=1;
                                fflush(stdin);
                                break;
                        }

                }
}
/**
 * Obtiene el indice que coincide con el dni pasado por parametro.
 * @param lista el array se pasa como parametro.
 * @param dni el dni a ser buscado en el array.
 * @return el indice en donde se encuentra el elemento que coincide con el parametro dni
 */
int buscarPorDni(ePersona lista[], int dni)
{
    int i=0;
    int indice;
    for(i=0;i<tam;i++)
        {
            if(lista[i].dni==dni)
            {
                indice=i;
            }
            else
            {
                printf("\El DNI no existe\n");
                break;
            }
        }
    return indice;
}
/** \brief Muestra por pantalla los datos del array de manera ordenada alfabeticamente
 *
 * \param persona array se pasa como parametro
 * \param
 */

void mostrarPersona (ePersona persona[])
{
    int i=0;
    int j=0;
    ePersona auxiliar;
    for(i=0;i<tam-1;i++)
    {
        for(j=i+1;j<tam;j++)
        {
            if(stricmp(persona[i].nombre,persona[j].nombre)>0)
            {
                auxiliar=persona[i];
                persona[i]=persona[j];
                persona[j]=auxiliar;
            }

        }

    }
    printf("\n NOMBRE        DNI          EDAD\n");
    for(i=0;i<tam;i++)
    {
        printf("\n %1s %14d %8d\n",persona[i].nombre,persona[i].dni,persona[i].edad);

    }

}
/** \brief Realiza una busqueda del indice en el array de persona y borra sus datos si hay coincidencia.
 *
 * \param indice dado por parametros
 * \param
 * \return no devuelve nada
 *
 */


void borrarPersona(ePersona persona[], int indice)
   {
       int i=0;
        for(i=0;i<tam;i++)
            {
                if(i==indice)
                {
                    persona[i].dni=0;
                    persona[i].edad=0;
                    persona[i].estado=0;
                    strcpy(persona[i].nombre," ");
                    break;
                }
            }

   }
   /** \brief Realiza un grafico valiendose de contadores para mostrar por pantalla el resultado
    *
    * \param array de persona
    * \param contadores inferior a 19
    * \param contadores entre 19 y 35
    * \param contadores superior a 35
    * \return no devuelve nada
    *
    */

void realizaGrafica (ePersona persona [])
{
    int i, inferior19=0, intermedio19y35=0, mayor35=0;
    char me19[tam]={" "}, entre19y35[tam]={" "},ma35[tam]={" "};

    for(i=0; i<tam; i++)
    {
        if(persona[i].edad<19 && persona[i].edad!= -1 && (persona[i].estado==1) )
            {
                inferior19[me19]='*';
                inferior19++;

            }
        else
            {
                if( (persona[i].edad>19) && (persona[i].edad<35) && (persona[i].estado==1) )
                        {
                        intermedio19y35[entre19y35]='*';
                        intermedio19y35++;

                        }
                    else
                        {   if(persona[i].estado==1)
                            {
                                    mayor35[ma35]='*';
                                    mayor35++;

                            }
                        }
            }
    }
    for(i=0;i<tam;i++)
    {

            printf("%10c", me19[i]);
            printf("%15c", entre19y35[i]);
            printf("%16c", ma35[i]);
            if( (me19[i]=='*' ) || (entre19y35[i]=='*') || (ma35[i]=='*') )
            {
                printf("\n");
            }
    }

    printf("\n%10d %15d %15d\n\n", inferior19, intermedio19y35, mayor35);
    printf("      < 18            19 - 35          > 35\n");
}
