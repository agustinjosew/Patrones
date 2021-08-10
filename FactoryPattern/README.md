# Factory

"The Factory Method" es un patrón de los que denominamos **CREACIONALES** debido que se ocupan de la **creación** de objetos e **instancias** de estos objetos.

En este caso en puntual , con el Factory, lo que podemos definir son ciertos métodos y propiedades de un objeto que va a estar presente de manera común en los objetos creados usando este patrón pero dejando que los métodos " individuales " del Factory definan que objetos específicos instanciarán.

| Tipo       | Utilidad         | Bueno para                        |
|:----------:|:----------------:|:---------------------------------:|
| Creacional | 5 / 5 (MUY Útil) | Crear objetos de la misma familia |

## Los participantes de este patrón 



El **Product** define la interface de los objetos que el método Factory crearía.

El objeto **ConcreteProduct** IMPLEMENTA la interface **Product**.

El **Creator** declara el método Factory, el cual devuelve un **OBJETO** del **TIPO PRODUCTO**. El "creator" también puede definir una implementación por defecto/predeterminada del método Factory pero no vamos a verlo en este ejemplo en especifico . 

El objeto **ConcreteCreator** *sobre escribe* el método Factory para devolver una *instancia de un Producto en Concreto*. 

## Ejemplo
Lo mas gráfico para poder experimentar con este patrón es por ejemplo un sándwich, se compone de ciertos ingredientes simples, por lo menos de manera inicial.

1. Teniendo en cuenta los componentes indicados en la imagen vemos que podemos sobrescribir algunas cosas por lo tanto necesitamos una clase **abstract** Ingredientes y a su vez Ingrediente es nuestro **Producto**

```csharp
/// <summary>
/// Producto
/// </summary>
abstract class Ingrediente { }
```

2. Ahora vamos a instanciar algunas clases que representen ingredientes en el contexto del ejemplo sandwich, estos serian nuestros "Productos en Concreto" (**ConcreteProduct**)

```csharp
/// <summary>
/// Producto en concreto
/// </summary>
class Pan : Ingrediente { }

/// <summary>
/// Producto en concreto
/// </summary>
class Jamon : Ingrediente { }

/// <summary>
/// Producto en concreto
/// </summary>
class Lechuga : Ingrediente { }

/// <summary>
/// Producto en concreto
/// </summary>
class Mayonesa : Ingrediente { }
```

Ahora con esto en mente pensemos... lo que queremos es poder hacer/elaborar un " Factory " que nos permita diversas variedades usando LOS MISMOS ingredientes. Lo que difiere de una variedad u otra en algunos casos son las cantidades que se utilizan, el orden de los ingredientes, etc.

Siguiendo con la misma lógica que podemos **sobrescribir** creo otra clase **abstract** pero esta vez es para Sándwich, en donde me interesa poder definir las variedades que podría hacer y para eso tengo que tener "a mano" los ingredientes que necesito, para eso puedo meter en una lista a todos ellos y según el tipo de sándwich traer la lista de ingredientes y luego poder indicar el orden en el que necesito que sean dispuestos para la elaboración final.

```csharp
// Posibilidades a la hora de poder crear distintos tipos de Cheguzas (?)
abstract class Sandwich
{
    private List<Ingrediente> _ingredientes = new List<Ingrediente>();

    public Sandwich()
    {
        CrearIngredientes();
    }

    /// <summary>
    /// Factory metodo propiamente
    /// </summary>
    public abstract void CrearIngredientes();

    public List<Ingrediente> Ingredientes
    {
        get
        {
            return _ingredientes;
        }
    }
}
```
Ahora tengamos en cuenta lo siguiente : 
```csharp
CrearIngredientes();
```
 este método es propiamente el **METODO FACTORY** y es el que le da el nombre a este patrón. Ahora.... no lo implemantamos en este segmento de código porque recordemos que tenemos algo que se llama **ConcreteCreator** Y ES AHI DONDE VAMOS A IMPLEMENTARLO y como viene con el accesor <a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract" target="_blank">**ABSTRACT**</a> :link: podemos hacer uso de <a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override" target="_blank">**OVERRIDE**</a> :link: sin problemas.
 
3. Ahora usamos entonces el concepto de **creador en concreto** y para ello una nueva clase derivada de Sándwich donde *sobrescribimos CrearIngredientes()* con lo necesario para poder crear esta variedad en especifico:
 
 ```csharp
/// <summary>
/// Creador CONCRETO
/// </summary>
class JamonSandwich : Sandwich
{
    public override void CrearIngredientes()
    {
        Ingredientes.Add(new Pan());
        Ingredientes.Add(new Mayonesa());
        Ingredientes.Add(new Lechuga());
        Ingredientes.Add(new Jamon());
        Ingredientes.Add(new Jamon());
        Ingredientes.Add(new Lechuga());
        Ingredientes.Add(new Mayonesa());
        Ingredientes.Add(new Pan());
    }
}


/// <summary>
/// Creador CONCRETO
/// </summary>
class MilanesaSandwich : Sandwich
{
    public override void CrearIngredientes()
    {
        Ingredientes.Add(new Pan());
        Ingredientes.Add(new Mayonesa());
        Ingredientes.Add(new Lechuga());
        Ingredientes.Add(new Milanesa());
        Ingredientes.Add(new Huevo());
        Ingredientes.Add(new Milanesa());
        Ingredientes.Add(new Lechuga());
        Ingredientes.Add(new Mostaza());
        Ingredientes.Add(new Pan());
    }
}
```

Viendo esto entonces siempre que necesitemos crear alguna nueva variedad de Sándwich podemos invocar a CrearIngredientes() para especificar la cantidad y el orden de los ingredientes para el caso en especifico.

4. Hasta ahora todo muy lindo (?) pero como vamos a poder usar todo lo realizado hasta ahora, hasta el momento solo tenemos las declaraciones de lo que "debería ser o tener el sándwich" pero no hay en concreto todavía, para ello vamos a crear los objetos segun los distintos tipos de sándwich que hemos instanciado y los "llamamos" de la siguiente manera:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sandwich> Sandwiches = new List<Sandwich>();
            Sandwiches.Add(new MilanesaSandwich());
            Sandwiches.Add(new JamonSandwich());

            foreach(var sandwich in Sandwiches)
            {
                Console.WriteLine("\nSandwich : " + sandwich.GetType().Name + " ");
                foreach(var ingrediente in sandwich.Ingredientes)
                {
                    Console.WriteLine("ingrediente: " + ingrediente.GetType().Name);
                }
            }
            Console.ReadKey();
        }   
    }
}
```
Y el resultado es algo así:



## Voy a usar alguna vez este patrón? :unamused:
Absolutamente :smiley:. El patrón Factory Method es muy común en el mundo actual del diseño de software. Siempre que necesitemos crear grupos de objetos relacionados, el método Factory es una de las formas más limpias de hacerlo. 

El patrón Factory Method proporciona una manera en la que podemos crear instancias de objetos, pero los detalles de la creación de esas instancias quedan para que los definan las propias clases de instancias.