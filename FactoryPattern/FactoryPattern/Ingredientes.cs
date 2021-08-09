using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    /// <summary>
    /// Producto
    /// </summary>
    abstract class Ingrediente { }

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

    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Milanesa : Ingrediente { }

    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Huevo : Ingrediente { }

    /// <summary>
    /// Producto en concreto
    /// </summary>
    class Mostaza : Ingrediente { }

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
}
