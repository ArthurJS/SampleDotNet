using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL
{
    //CreateDatabaseIfNotExists
    public class InitDb : CreateDatabaseIfNotExists<Context>
    {

        protected override void Seed(Context context)
        {
            try
            {
                Location location = new Location();
                //Grades
                Grade grade1 = new Grade(1);
                Grade grade2 = new Grade(2);
                Grade grade3 = new Grade(3);
                Grade grade4 = new Grade(4);
                Grade grade5 = new Grade(5);
                Grade grade6 = new Grade(6);

                //Continenten
                Continent africa = new Continent("Afrika");
                Continent antarctica = new Continent("Antarctica");
                Continent asia = new Continent("Azië");
                Continent europe = new Continent("Europa");
                Continent latAm = new Continent("Latijns Amerika");
                Continent northAm = new Continent("Noord Amerika");
                Continent oceania = new Continent("Oceanië");
                List<Continent> contList = new List<Continent>() { africa, antarctica, asia, europe, latAm, northAm, oceania };

                //Land
                Country belgium = new Country("België");
                Country canada = new Country("Canada");

                //Locatie
                Location gent = new Location("Gent", "6434", 0.0666134, 0.889536142, 15);
                Location toronto = new Location("Toronto", "71624", 1.389863861, 0.762127107, 173);

                double[] percGent = { 51, 42, 46, 50, 59, 65, 72, 74, 72, 72, 64, 59 };
                double[] tempGent = { 2.5, 3.0, 5.2, 8.4, 12.1, 15.1, 16.8, 16.6, 14.3, 10.3, 6.2, 3.2 };
                double[] percToronto = { 46, 46, 57, 64, 66, 69, 77, 84, 74, 63, 70, 66 };
                double[] tempToronto = { -6.6, -5.8, -0.7, 6.1, 12.5, 17.7, 20.8, 19.6, 15.3, 9.0, 3.3, -3.2 };
                Climatogram climatogramGent = new Climatogram(setValues(percGent, tempGent), "1961 - 1990");
                Climatogram climatogramToronto = new Climatogram(setValues(percToronto, tempToronto), "1953 - 1991");

                //-------------------
                europe.Countries.Add(belgium);
                belgium.Locations.Add(gent);
                gent.Climatogram = climatogramGent;

                northAm.Countries.Add(canada);
                canada.Locations.Add(toronto);
                toronto.Climatogram = climatogramToronto;
                //-------------------

                //Bij elke graad meegeven welke continenten ze moeten behandelen
                foreach (Continent cont in contList)
                {
                    grade3.Continents.Add(cont);
                    grade4.Continents.Add(cont);
                    grade5.Continents.Add(cont);
                    grade6.Continents.Add(cont);
                }
                grade1.Continents.Add(europe);
                grade2.Continents.Add(europe);

                

                // determinatietabellen
                // eerste graad
                Node g1rootNode= new Node(new Tw(), 10, new Smaller());
                Node g1yesNode = new Node(new Tw(), 0, new Smaller());
                AbstractNode g1yes2Leaf = new Leaf("Koud zonder dooiseizoen", "IJswoestijn", "/Content/images/ijswoestijn.jpg");
                AbstractNode g1yesNoLeaf = new Leaf("Koud met dooiseizoen", "Toendra", "/Content/images/toendra.jpg");
                Node g1noNode = new Node(new TmBiggerOrEqualThan10(), 4, new Smaller());
                AbstractNode g1noYesLeaf = new Leaf("Koudgematigd, strenge winter", "Taiga", "/Content/images/taiga.jpg");
                Node g1no2Node = new Node(new Tk(), 18, new Smaller());
                AbstractNode g1no2NoLeaf = new Leaf("Warm, altijd droog","Woestijn van de tropen","/Content/images/woestijn.jpg");
                Node g1no2YesNode = new Node(new Nj(), 400, new Bigger());
                AbstractNode g1no2YesNoLeaf = new Leaf("Gematigd, altijd droog", "Woestijn van de middelbreedten", "/Content/images/woestijn.jpg");
                Node g1no2Yes2Node = new Node(new Tk(), -3, new Smaller());
                AbstractNode g1no2YesLeaf = new Leaf("Koelgematigd, strenge winter", "Taiga", "/Content/images/taiga.jpg");
                Node g1no2Yes2NoNode = new Node(new Tw(), 22, new Smaller());
                AbstractNode g1no2Yes2NoYesLeaf = new Leaf("Koelgematigd, zachte winter", "Loofbos", "/Content/images/loofwoud.jpg");
                AbstractNode g1no2Yes2NoNoLeaf = new Leaf("Warmgematigd, natte winter", "Hardbladig van de subtropen", "/Content/images/hardbladig.jpg");

                g1no2Yes2NoNode.YesNode = g1no2Yes2NoYesLeaf;
                g1no2Yes2NoNode.NoNode = g1no2Yes2NoNoLeaf;
                g1no2Yes2Node.YesNode = g1no2YesLeaf;
                g1no2Yes2Node.NoNode = g1no2Yes2NoNode;
                g1no2YesNode.NoNode = g1no2YesNoLeaf;
                g1no2YesNode.YesNode = g1no2Yes2Node;
                g1no2Node.NoNode = g1no2NoLeaf;
                g1no2Node.YesNode =g1no2YesNode;
                g1noNode.YesNode = g1noYesLeaf;
                g1noNode.NoNode = g1no2Node;
                g1yesNode.YesNode = g1yes2Leaf;
                g1yesNode.NoNode = g1noNode;
                g1yesNode.NoNode = g1yesNoLeaf;
                g1rootNode.YesNode = g1yesNode;
                g1rootNode.NoNode = g1noNode;

                // alle andere  graden = grade2
                Node g2rootNode = new Node(new Tw(), 10, new SmallerOrEqual());
                Node g2yesNode = new Node(new Tw(), 0, new SmallerOrEqual());
                Leaf g2yes2Leaf = new Leaf("Koud zonder dooiseizoen", "IJswoestijn", "/Content/images/ijswoestijn.jpg");
                Leaf g2yesNoLeaf = new Leaf("Koud met dooiseizoen", "Toendra", "/Content/images/toendra.jpg");
                Node g2noNode = new Node(new Tj(), 0, new SmallerOrEqual());
                Leaf g2noYesLeaf = new Leaf("Koudgematigd, strenge winter", "Taiga", "/Content/images/taiga.jpg");
                Node g2no2Node = new Node(new Nj(), 200, new SmallerOrEqual());
                Node g2no2YesNode = new Node(new Tk(), 15, new SmallerOrEqual());
                AbstractNode g2no2Yes2Leaf = new Leaf("Gematigd, altijd droog", "Woestijn van de middelbreedten", "/Content/images/woestijn.jpg");
                Leaf g2no2YesNoLeaf = new Leaf("Warm, altijd droog", "Woestijn van de tropen", "/Content/images/woestijn.jpg");
                Node g2no3Node = new Node(new Tk(), 18, new SmallerOrEqual());
                Node g2no3YesNode = new Node(new Nj(), 400, new SmallerOrEqual());
                AbstractNode g2no3Yes2Leaf = new Leaf("Gematigd, droog klimaat", "Steppe", "/Content/images/steppe.jpg");
                Node g2no3YesNoNode = new Node(new Tk(), -10, new SmallerOrEqual());
                AbstractNode g2no3YesNoYesLeaf = new Leaf("Koelgematigd, strenge winter", "Taiga", "/Content/images/taiga.jpg");
                Node g2no3YesNo2Node = new Node(new DryMonths(), 1, new SmallerOrEqual());
                Node g2no3YesNo2YesNode = new Node(new Tk(), -3, new SmallerOrEqual());
                AbstractNode g2no3YesNo2Yes2Leaf = new Leaf("Koelgematigd, koude winter", "Gemengd Woud", "/Content/images/gemengd_woud.jpg");
                Node g2no3YesNo2YesNoNode = new Node(new Tw(), 22, new SmallerOrEqual());
                AbstractNode g2no3YesNo2YesNoYesLeaf = new Leaf("Koelgematigd, zachte winter", "Loofbos", "/Content/images/loofwoud.jpg");
                AbstractNode g2no3YesNo2YesNo2Leaf = new Leaf("Warmgematigd, altijd nat", "Subtropisch Regenwoud", "/Content/images/regenwoud.jpg");
                Node g2no3YesNo3Node = new Node(new PrecipitationSummer(), new PrecipitationWinter(),new SmallerOrEqual());
                Node g2no3YesNo3YesNode = new Node(new Tw(), 22, new SmallerOrEqual());
                AbstractNode g2no3YesNo3Yes2Leaf = new Leaf("Koelgematigd, natte winter", "Hardbladig van de middelbreedten", "/Content/images/hardbladig.jpg");
                AbstractNode g2no3YesNo3YesNoLeaf = new Leaf("Warmgematigd, natte winter", "Hardbladig van de subtropen", "/Content/images/hardbladig.jpg");
                AbstractNode g2no3YesNo4Leaf = new Leaf("Warmgematigd, natte zomer", "Subtropische Savanne", "/Content/images/subtropische_savanne.jpg");
                Node g2no4Node = new Node(new DryMonths(), 1, new SmallerOrEqual());
                AbstractNode g2no4YesLeaf = new Leaf("Warm, nat seizoen", "Tropische Savanne", "/Content/images/savanne.jpg");
                AbstractNode g2no5Leaf = new Leaf("Warm, altijd nat, nat seizoen", "Tropisch Regenwoud", "/Content/images/tropisch_regenwoud.jpg");

                g2no4Node.YesNode = g2no4YesLeaf;
                g2no4Node.NoNode = g2no5Leaf;
                g2no3YesNo3YesNode.YesNode = g2no3YesNo3Yes2Leaf;
                g2no3YesNo3YesNode.NoNode = g2no3YesNo3YesNoLeaf;
                g2no3YesNo3Node.YesNode = g2no3YesNo3YesNode;
                g2no3YesNo3Node.NoNode = g2no3YesNo4Leaf;
                g2no3YesNo2YesNoNode.YesNode = g2no3YesNo2YesNoYesLeaf;
                g2no3YesNo2YesNoNode.NoNode = g2no3YesNo2YesNo2Leaf;
                g2no3YesNo2YesNode.YesNode = g2no3YesNo2Yes2Leaf;
                g2no3YesNo2YesNode.NoNode = g2no3YesNo2YesNoNode;
                g2no3YesNo2Node.YesNode = g2no3YesNo2YesNode;
                g2no3YesNo2Node.NoNode = g2no3YesNo3Node;
                g2no3YesNoNode.YesNode = g2no3YesNoYesLeaf;
                g2no3YesNoNode.NoNode = g2no3YesNo2Node;
                g2no3YesNode.YesNode = g2no3Yes2Leaf;
                g2no3YesNode.NoNode = g2no3YesNoNode;
                g2no3Node.YesNode = g2no3YesNode;
                g2no3Node.NoNode = g2no4Node;
                g2no2YesNode.YesNode = g2no2Yes2Leaf;
                g2no2YesNode.NoNode = g2no2YesNoLeaf;
                g2no2Node.YesNode = g2no2YesNode;
                g2no2Node.NoNode = g2no3Node;
                g2noNode.YesNode = g2noYesLeaf;
                g2noNode.NoNode = g2no2Node;
                g2yesNode.YesNode = g2yes2Leaf;
                g2yesNode.NoNode = g2yesNoLeaf;
                g2rootNode.YesNode = g2yesNode;
                g2rootNode.NoNode = g2noNode;

                grade1.DeterminationTable = g1rootNode;
                grade2.DeterminationTable = g2rootNode;
                grade3.DeterminationTable = g2rootNode;
                grade4.DeterminationTable = g2rootNode;
                grade5.DeterminationTable = g2rootNode;
                grade6.DeterminationTable = g2rootNode;

                //SaveChanges : Add -> INSERT statement | wijzigingen -> UPDATE instructie | Remove -> DELETE instructie
                //--> CRUD methoden van Context -> Voegt de Grades toe samen met alle continenten en bijbehorende countries/locations voor die graad
                // Context doet aan ChangeTracking -> Houdt alle wijzigingen bij tot je SaveChanges aanroept
                // en zal dan voor alle wijzigingen INSERT,UPDATE of DELETE instructies creëren => Transactie

                context.Grades.Add(grade1);
                context.Grades.Add(grade2);
                context.Grades.Add(grade3);
                context.Grades.Add(grade4);
                context.Grades.Add(grade5);
                context.Grades.Add(grade6);

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        private ICollection<MonthlyData> setValues(double[] percipitation, double[] temperature)
        {
            ICollection<MonthlyData> list = new List<MonthlyData>();
            for (int i = 0; i < 12; i++)
            {
                list.Add(new MonthlyData(i, percipitation[i], temperature[i], idToMonth(i)));
            }
            return list;
        }

        private string idToMonth(int id)
        {
            switch (id)
            {
                case 0: return "Jan";

                case 1: return "Feb";

                case 2: return "Maa";

                case 3: return "Apr";

                case 4: return "Mei";

                case 5: return "Jun";

                case 6: return "Jul";

                case 7: return "Aug";

                case 8: return "Sept";

                case 9: return "Okt";

                case 10: return "Nov";

                case 11: return "Dec";
                    
                default:
                    return "Jan";
            }
        }
    }
}