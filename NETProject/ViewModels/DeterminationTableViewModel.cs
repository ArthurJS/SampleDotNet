using System;
using System.Diagnostics;
using System.Web.Mvc;
using NETProject.Models.Domain;

namespace NETProject.ViewModels
{
    public class DeterminationTableViewModel
    {

        #region Properties
        public Node Determinatietabel { get; set; }
        private int Rows;
        private int Columns;
        private Grade Grade;
        public string[] ClimatogramSolution;
        public string PopupHtml { get; set; }
        public string[,] tableArray { get; set; }

        public string[,] ClimateVegetation { get; set; }
        

        public Boolean[] DeterminatiePad { get; set; }
        #endregion

        #region Constructors
        public DeterminationTableViewModel() { }

        public DeterminationTableViewModel(Node determinatietabel, Boolean[] determinatiePad, Grade grade, string[] climatogramSolution)
        {
            Determinatietabel = determinatietabel;
            Grade = grade;
            
            ClimatogramSolution = climatogramSolution;

            PopupHtml = GetPopupHtml(Grade.Id);
            DeterminatiePad = determinatiePad;
            Rows = 0;
            Columns = 1;
            

            int cols = 1;
            CalculateDimensions(determinatietabel, ref cols);
            Columns++;

            int r = 0;
            int k = 0;
            tableArray = new string[Rows,Columns];
            FillInArray(ref r, ref k, Determinatietabel);
            Debug.WriteLine(tableArray);
        }


        #endregion
        
        # region Methods

        public string getTableHtml() //toon foto +vegetatietyepe 
        {
            string s = "<table>\n";
            for (int i = 0; i < Rows; i++)
            {
                s += "<tr>\n";
                for (int j = 0; j < Columns; j++)
                {
                    s += tableArray[i, j] ?? "<td class=\"enode\"></tds>\n";
                }
                s += "   </tr>\n";
            }
            s += "</table>\n";
            return s;
        }



        private void FillInArray( ref int r, ref int k, AbstractNode abstractNode)
        {
            Leaf leaf = abstractNode as Leaf;
            if (leaf != null)
            {

                tableArray[r, Columns-1] = NodeToHtml(leaf);


            }

            Node node = abstractNode as Node;
            if (node != null)
            {
                
                //html invullen
                tableArray[r, k] = NodeToHtml(node);

                //kolom opschuiven
                //voor de yes node:
                k++; //eentje naar rechts

                FillInArray(ref r, ref k, node.YesNode);
                k--; //terugkeren

                //voor de no node:
                r++; //eentje naar beneden, x blijft gelijk. 
                FillInArray(ref r, ref k, node.NoNode);

            }
           
        }

        private string NodeToHtml(AbstractNode abstractNode)
        {
            string s = "";

            Node node = abstractNode as Node;
            if (node != null)
            {
                string param2 = node.Value==null? node.Par2.Code:Convert.ToString(node.Value);
                
                s +=    "<td class=\"node\" id="+node.Id+">\n" +
                     "\t <p>"+node.Par1.Code+" "+node.Operator.Beschrijving+" "+ param2+"</p>\n" +
                     "\t <button class = \"btnYes\" value=\"yes\" data=\"" + node.YesNode.Id + "\">Ja</button>\n" +
                     "\t <button class = \"btnNo\" value=\"no\" data=\"" + node.NoNode.Id + "\">Nee</button>\n" +
                     "\t <button class = \"btnBack\" value=\"back\">Terug</button>\n" +
                     "</td>\n";
            }
            Leaf leaf = abstractNode as Leaf;
            if (leaf != null)
            {
                s +=    "<td class=\"leaf\" id=\"" + leaf.Id + "\">"+leaf.Klimaattype+"</td>\n";
        }
            return s;
        }

        private string GetPopupHtml(int graad)
        {
            string s = "";
            switch (graad)
            {
                case 3: //toon foto en vraag vegetatietype
                    s += "De determinatie is geslaagd! Het juiste antwoord is:<br>" +
                         "" + ClimatogramSolution[0] + "<br>" +
                         "Wat is het vegetatietypedat hoort bij dit klimaat? " +
                         "<img src=\' " + ClimatogramSolution[2] + "\'>" +
                         GetVegetationSelectHtml() + "<br>" +
                         " <button class = \'btnVegetation\' value=\'confirm\' onclick=\'controleerVegetatie()\'>ok</button>";
                    break;
                case 4: //toon GEEN foto vraag vegetatietype
                    s += "De determinatie is geslaagd! Het juiste antwoord is:<br>" +
                         "" + ClimatogramSolution[0] + "<br>" +
                         "Wat is het vegetatietypedat hoort bij dit klimaat? " +
                         GetVegetationSelectHtml() + "<br>" +
                         " <button class = \'btnVegetation\' value=\'confirm\' onclick=\'controleerVegetatie()\'>ok</button>";
                    break;
                default: //toon foto en geef ook vegetatietype
                    s +=    "De determinatie is geslaagd! Het juiste antwoord is:<br>" +
                            "" + ClimatogramSolution[0] + "<br>" +
                            "Het vegetatietype voor dit klimaattype is" + ClimatogramSolution[1] +"<br>"+
                            "<img src=\'" + ClimatogramSolution[2] + "\'>";
                    break;
            }
            return s;
        }

        private string GetVegetationSelectHtml()
        {
            string[] vegetationStrings = new[]
            {
                "IJswoestijn",
                "Toendra",
                "Woestijn van de middelbreedten",
                "Woestijn van de tropen",
                "Steppe",
                "Taiga",
                "Gemengd Woud",
                "Loofbos",
                "Subtropisch Regenwoud",
                "Hardbladig van de middelbreedten",
                "Hardbladig van de subtropen",
                "Subtropische Savanne",
                "Tropische Savanne",
                "Tropisch Regenwoud",
            };

            string s =  "<select id=\'antwVegetatie\'>";
            foreach (var vegeString in vegetationStrings)
            {
                s +=    "<option value=\'"+vegeString.Replace(" ",String.Empty)+"\'>"+vegeString+"</option>";
            }
            s += "</select>";
            return s;
        }


        private void CalculateDimensions(AbstractNode n, ref int cols)
        {
            Node node = n as Node;
            if (node.YesNode is Node)
            {
                if (cols == Columns)
                {
                    cols++;
                    Columns++;
                }
                else
                {
                    cols++;
                }
                CalculateDimensions(node.YesNode, ref cols);
                cols--;
            }
            else
            {
                Rows++;
            }

            if (node.NoNode is Node)
            {
                CalculateDimensions(node.NoNode, ref cols);
            }
            else
            {
                Rows++;
            }
        }

        #endregion
    }
}