using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    using System;

    public class Singleton
    {
        // Champ statique privé pour stocker l'instance unique
        private static Singleton instance;

        // Constructeur privé pour empêcher l'instanciation directe de la classe
        private Singleton() { }

        // Méthode statique pour obtenir l'instance unique de Singleton
        public static Singleton GetInstance()
        {
            // Implémentation de l'initialisation paresseuse si il n existe pas il la creer sino il retourne
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        // Méthode pour afficher un message de test
        public void PrintMessage()
        {
            Console.WriteLine("Je suis une instance unique de Singleton !");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Obtention de l'instance unique de Singleton
            Singleton singletonInstance = Singleton.GetInstance();

            // Appel d'une méthode de l'instance Singleton
            singletonInstance.PrintMessage();
        }
    }

}
