namespace EFBasic_4_InheritanceStrategies.Entities.TPC
{
    /// <summary>
    /// abstrakcyjna!
    /// </summary>
    public abstract class Tpc_Parameter : EntityBase
    {
        public string CodeName { get; set; }

        public Tpc_Parameter()
        {
        }

        public Tpc_Parameter(string codeName)
        {
            CodeName = codeName;
        }
    }

    public class Tpc_ParameterString : Tpc_Parameter
    {
        public string Value { get; set; }

        public Tpc_ParameterString()
        {
        }

        public Tpc_ParameterString(string codeName, string value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tpc_ParameterBoolean : Tpc_Parameter
    {
        public bool Value { get; set; }

        public Tpc_ParameterBoolean()
        {
        }

        public Tpc_ParameterBoolean(string codeName, bool value) : base(codeName)
        {
            Value = value;
        }
    }

    public class Tpc_ParameterSpecial : Tpc_Parameter
    {
        public decimal RiskSum { get; set; }
        public bool SelectedOption { get; set; }

        public Tpc_ParameterSpecial()
        {
        }

        public Tpc_ParameterSpecial(string codeName, decimal riskSum, bool selectedOption) : base(codeName)
        {
            RiskSum = riskSum;
            SelectedOption = selectedOption;
        }
    }
}
