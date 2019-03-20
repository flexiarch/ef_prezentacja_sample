namespace EFBasic_4_InheritanceStrategies.Entities.TPH
{
    /// <summary>
    /// abstrakcyjna!
    /// </summary>
    public abstract class TphParameter : EntityBase
    {
        public string CodeName { get; set; }

        public TphParameter()
        {
        }

        public TphParameter(string codeName)
        {
            CodeName = codeName;
        }
    }

    public class Tph_ParameterString : TphParameter
    {
        public string Value { get; set; }

        public Tph_ParameterString()
        {
        }

        public Tph_ParameterString(string codeName, string value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tph_ParameterBoolean : TphParameter
    {
        public bool? Value { get; set; }

        public Tph_ParameterBoolean()
        {
        }

        public Tph_ParameterBoolean(string codeName, bool? value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tph_ParameterSpecial : TphParameter
    {
        public decimal? RiskSum { get; set; }
        public bool? SelectedOption { get; set; }

        public Tph_ParameterSpecial()
        {
        }

        public Tph_ParameterSpecial(string codeName, decimal? riskSum, bool? selectedOption) : base(codeName)
        {
            RiskSum = riskSum;
            SelectedOption = selectedOption;
        }
    }
}
