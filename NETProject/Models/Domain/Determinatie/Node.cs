using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace NETProject.Models.Domain
{
    public class Node : AbstractNode
    {
        public virtual AbstractParameter Par1 { get; set; }
        public virtual  AbstractParameter Par2 { get; set; }
        public virtual double? Value { get; set; }
        public virtual AbstractNode YesNode { get; set; }
        public virtual AbstractNode NoNode { get; set; }
        public virtual AbstractOperator Operator { get; set; }

        //alles virtual

        public Node()
        {
        }

        public Boolean HasValue
        {
            get { return Value.HasValue; }
        }
        public Node(AbstractParameter par1, AbstractParameter par2, AbstractOperator op)
        {
            Par1 = par1;
            Par2 = par2;
            Operator = op;
        }

        public Node(AbstractParameter par1, double val, AbstractOperator op)
        {
            Par1 = par1;
            Value = val;
            Operator = op;
        }

        public override String getText()
        {
            return Par1.Code + " " + Operator.Beschrijving + (HasValue ? Value.ToString() : Par2.Code);
        }

        public override string[] Determineer(Climatogram climatogram)
        {
            double valPar1 = Par1.Execute(climatogram);

            if (HasValue)
            {
                if (Operator.Execute(valPar1, (double)Value))
                {
                    return YesNode.Determineer(climatogram);
                }
                else
                {
                    return NoNode.Determineer(climatogram);
                }
            }
            else
            {
                double valPar2 = Par2.Execute(climatogram);
                if (Operator.Execute(valPar1, valPar2))
                {
                    return YesNode.Determineer(climatogram);
                }
                else
                {
                    return NoNode.Determineer(climatogram);
                }
            }
        }

        public override List<Boolean> GetDeterminationPath(Climatogram climatogram, List<Boolean> blist)
        {
            double valPar1 = Par1.Execute(climatogram);

            if (HasValue)
            {
                if (Operator.Execute(valPar1, (double) Value))
                {
                    blist.Add(true);
                    return YesNode.GetDeterminationPath(climatogram, blist);
                }
                else
                {
                    blist.Add(false);
                    return NoNode.GetDeterminationPath(climatogram, blist);
                }
            }
            else
            {
                double valPar2 = Par2.Execute(climatogram);
                if (Operator.Execute(valPar1, valPar2))
                {
                    blist.Add(true);
                    return YesNode.GetDeterminationPath(climatogram, blist);
                }
                else
                {
                    blist.Add(false);
                    return NoNode.GetDeterminationPath(climatogram, blist);
                }
            }
        }
    }
}