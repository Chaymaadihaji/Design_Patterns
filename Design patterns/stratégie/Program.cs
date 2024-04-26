using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stratégie
{
    using System;
    using System.Collections.Generic;

    // Interface définissant le contrat pour toutes les stratégies de paiement
    public interface IPaiementStrategy
    {
        void Payer(double montant);
    }

    // Implémentation de différentes stratégies de paiement

    public class PaiementCarteCredit : IPaiementStrategy
    {
        private string _numeroCarte;
        private string _dateExpiration;
        private string _codeSecurite;

        public PaiementCarteCredit(string numeroCarte, string dateExpiration, string codeSecurite)
        {
            _numeroCarte = numeroCarte;
            _dateExpiration = dateExpiration;
            _codeSecurite = codeSecurite;
        }

        public void Payer(double montant)
        {
            // Implémentation de la logique de paiement par carte de crédit
            Console.WriteLine($"Paiement de {montant}$ avec la carte de crédit {_numeroCarte}.");
            Console.ReadKey();
        }
    }

    public class PaiementPayPal : IPaiementStrategy
    {
        private string _adresseEmail;
        private string _motDePasse;

        public PaiementPayPal(string adresseEmail, string motDePasse)
        {
            _adresseEmail = adresseEmail;
            _motDePasse = motDePasse;
        }

        public void Payer(double montant)
        {
            // Implémentation de la logique de paiement par PayPal
            Console.WriteLine($"Paiement de {montant}$ avec PayPal (adresse email : {_adresseEmail}).");
            Console.ReadKey();
        }
    }

    // Classe de contexte qui utilise la stratégie sélectionnée pour effectuer le paiement
    public class Panier
    {
        private List<IPaiementStrategy> _paiementStrategies = new List<IPaiementStrategy>();

        public void AjouterPaiementStrategy(IPaiementStrategy paiementStrategy)
        {
            _paiementStrategies.Add(paiementStrategy);
        }

        public void Payer(double montant)
        {
            foreach (var paiementStrategy in _paiementStrategies)
            {
                paiementStrategy.Payer(montant);
            }
        }
    }

    // Exemple d'utilisation
    class Program
    {
        static void Main(string[] args)
        {
            Panier panier = new Panier();

            // Ajout de différentes stratégies de paiement
            panier.AjouterPaiementStrategy(new PaiementCarteCredit("1234567890123456", "12/25", "123"));
            panier.AjouterPaiementStrategy(new PaiementPayPal("exemple@example.com", "monmotdepasse"));

            // Paiement du panier
            double montantTotal = 100.00;
            panier.Payer(montantTotal);
        }
    }

}
