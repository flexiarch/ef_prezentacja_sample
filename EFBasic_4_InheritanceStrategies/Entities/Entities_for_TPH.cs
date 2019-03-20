namespace EFBasic_4_InheritanceStrategies.Entities.TPH
{
    /// <summary>
    /// abstrakcyjna!
    /// </summary>
    public abstract class Parameter : EntityBase
    {
        public string CodeName { get; set; }

        public Parameter()
        {
        }

        public Parameter(string codeName)
        {
            CodeName = codeName;
        }
    }

    public class ParameterString : Parameter
    {
        public string Value { get; set; }

        public ParameterString()
        {
        }

        public ParameterString(string codeName, string value) : base(codeName)
        {
            Value = value;
        }
    }

    public class ParameterBoolean : Parameter
    {
        public bool? Value { get; set; }

        public ParameterBoolean()
        {
        }

        public ParameterBoolean(string codeName, bool? value) : base(codeName)
        {
            Value = value;
        }
    }

    public class ParameterSpecial : Parameter
    {
        public decimal? RiskSum { get; set; }
        public bool? SelectedOption { get; set; }

        public ParameterSpecial()
        {
        }

        public ParameterSpecial(string codeName, decimal? riskSum, bool? selectedOption) : base(codeName)
        {
            RiskSum = riskSum;
            SelectedOption = selectedOption;
        }
    }
}
