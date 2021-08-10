using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternABSTRACT
{
    /// <summary>
    /// Un producto abstracto
    /// </summary>
    abstract class PlatoPrincipal { }
    /// <summary>
    /// Un producto abstracto
    /// </summary>
    abstract class Postre { }
    /// <summary>
    /// La clase ABSTRACTA FACTORY, la cual define los metodos para crear OBJETOS ABSTRACTOS
    /// </summary>
    abstract class RecetaFactory
    {
        public abstract PlatoPrincipal CrearPlatoPrincipal();
        public abstract Postre CrearPostre();
    }
    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Milanesa : PlatoPrincipal { } 
    
    /// <summary>
    /// Producto en concreto
    /// </summary>
    class PapasFritas : PlatoPrincipal { }
    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Mejicano : PlatoPrincipal { }
    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Asado : PlatoPrincipal { }
    class PatitasDePollo : PlatoPrincipal { }
    class Helado : Postre { }
    class Torta : Postre { }
    class CremaBrulee : Postre { }

    /// <summary>
    /// Un FACTORY CONCRETO que CREA OBJETOS CONCRETOS mediante la implementacion de metodos ABSTRACTOS FACTORY.
    /// </summary>
    class ComidaAdultosFactory : RecetaFactory
    {
        public override PlatoPrincipal CrearPlatoPrincipal()
        {
            return new Asado();
        }

        public override Postre CrearPostre()
        {
            return new CremaBrulee();
        }
    }

    class ComidaParaLasBendis : RecetaFactory
    {
        public override PlatoPrincipal CrearPlatoPrincipal()
        {
            return new PapasFritas();
        }

        public override Postre CrearPostre()
        {
            return new Helado();
        }
    }



}
