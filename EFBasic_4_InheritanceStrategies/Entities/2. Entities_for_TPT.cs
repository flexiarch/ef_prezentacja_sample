﻿namespace EFBasic_4_InheritanceStrategies.Entities.TPT
{
    /// <summary>
    /// abstrakcyjna!
    /// </summary>
    public abstract class Tpt_Parameter : EntityBase
    {
        public string CodeName { get; set; }

        public Tpt_Parameter()
        {
        }

        public Tpt_Parameter(string codeName)
        {
            CodeName = codeName;
        }
    }

    public class Tpt_ParameterString : Tpt_Parameter
    {
        public string Value { get; set; }

        public Tpt_ParameterString()
        {
        }

        public Tpt_ParameterString(string codeName, string value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tpt_ParameterBoolean : Tpt_Parameter
    {
        public bool Value { get; set; }

        public Tpt_ParameterBoolean()
        {
        }

        public Tpt_ParameterBoolean(string codeName, bool value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tpt_ParameterSpecial : Tpt_Parameter
    {
        public decimal RiskSum { get; set; }
        public bool SelectedOption { get; set; }

        public Tpt_ParameterSpecial()
        {
        }

        public Tpt_ParameterSpecial(string codeName, decimal riskSum, bool selectedOption) : base(codeName)
        {
            RiskSum = riskSum;
            SelectedOption = selectedOption;
        }
    }
}
