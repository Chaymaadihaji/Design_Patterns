*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    // Interface représentant un appareil électronique avec des méthodes pour l'alimentation et l'affichage
    public interface IElectronicDevice
    {
        void PowerOn();
        void PowerOff();
        void Display();
    }

    // Classe représentant un ordinateur avec des méthodes pour l'alimentation et l'affichage
    public class Computer : IElectronicDevice
    {
        public void PowerOn()
        {
            Console.WriteLine("Computer powered on");
        }

        public void PowerOff()
        {
            Console.WriteLine("Computer powered off");
        }

        public void Display()
        {
            Console.WriteLine("Computer display showing");
        }
    }

    // Classe représentant un téléphone avec des méthodes pour l'alimentation et l'affichage
    public class Phone
    {
        public void TurnOn()
        {
            Console.WriteLine("Phone powered on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Phone powered off");
        }

        public void ShowScreen()
        {
            Console.WriteLine("Phone screen showing");
        }
    }

    // Adaptateur pour rendre compatible l'utilisation du téléphone avec le code existant de l'ordinateur
    public class PhoneAdapter : IElectronicDevice
    {
        private Phone phone;

        public PhoneAdapter(Phone phone)
        {
            this.phone = phone;
        }

        public void PowerOn()
        {
            phone.TurnOn();
        }

        public void PowerOff()
        {
            phone.TurnOff();
        }

        public void Display()
        {
            phone.ShowScreen();
        }
    }

    // Utilisation de l'adaptateur pour utiliser le téléphone avec le code existant de l'ordinateur
    class Program
    {
        static void Main(string[] args)
        {
            // Utilisation de l'ordinateur
            Computer computer = new Computer();
            computer.PowerOn();
            computer.Display();
            computer.PowerOff();

            // Utilisation du téléphone via l'adaptateur
            Phone phone = new Phone();
            PhoneAdapter adapter = new PhoneAdapter(phone);
            adapter.PowerOn();
            adapter.Display();
            adapter.PowerOff();
        }
    }



}
