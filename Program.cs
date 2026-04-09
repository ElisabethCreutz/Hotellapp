using AutoMapper;
using HotelEC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace HotelEC
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            var app = new App();
            app.Run();

//      Krav för att uppgiften skall bli godkänd(G):
//      Lösningen måste göras objektorienterat. Koden skall fungera och applikationen skall gå att köra utan fel.
//    • Det skall gå att registrera ett rum och rummets uppgifter skall kunna ändras.
//    • Applikationen skall hantera ett antal rum. 
//    • Ett rum ska kunna vara enkelrum eller dubbelrum.
//    • För dubbelrum ska det finnas möjlighet till att sätta in extrasängar(1 eller 2 beroende på rummets storlek).
//    • Det skall gå att registrera en kund och kundens uppgifter skall kunna ändras.
//    • Seed minst 4 rum
//    • Seed minst 4 gäster
//    • Användaren måste välja datum då rummet ska bokas.
//    • Ett rum kan bokas av en kund för en eller flera nätter. 
//    • En bokning ska göras med hjälp av ett datum och kan bokas idag eller någon i framtiden!
//    • Appen ska inte tillåta bokningar på datum som har redan passerat
//    • Man ska inte kunna ”checka ut” innan man har ”checkat in”!
//    • Den skall också se till att det inte går att boka ett rum på ett datum där det redan finns en bokning.

//      Krav för att uppgiften skall bli väl godkänd(VG):
//    • Applikationen måste kontrollera om det finns bokningar innan den tar bort en kund.
//    • Applikationen skall hantera bokningar och visa vilka rum som är lediga under en viss period.
//    • Det skall gå att avboka ett rum eller ändra en bokning.Det skall gå att söka på ett datum eller datumintervall och antal personer och få fram alla lediga rum som motsvarar sökningen.
//    • Till varje bokning skall det kopplas en betalning dvs en faktura.
//    • Applikationen skall kunna registrera en inkommen betalning på en faktura. 
//    • Om inte en betalning registrerats inom 10 dagar efter att bokningen är gjord annulleras bokningen dvs den upphör att gälla.
        }
    }
}
