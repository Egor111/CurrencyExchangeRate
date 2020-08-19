namespace CurrencyExchangeRate.Serializations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    public class CurrencyCodesReferenceSerialization
    {
        public string @ID { get; set; }

        public  string Name { get; set; }

        public  string EngName { get; set; }
        
        public  string ParentCode { get; set; }

        public int Nominal { get; set; }

        public  string ISO_Num_Code { get; set; }

        public  string ISO_Char_Code { get; set; }
    }
}
