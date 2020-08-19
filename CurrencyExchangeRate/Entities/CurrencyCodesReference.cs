namespace CurrencyExchangeRate.Entities
{
    using Base.EF.DataAccess;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Справочник по кодам валют.
    /// </summary>
    [Table("CurrencyCodesReference")]
    public class CurrencyCodesReference : BaseEntity
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        [Display(Name = "Название валюты")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Название валюты на английском.
        /// </summary>
        [Display(Name = "Название валюты на английском")]
        public virtual string EngName { get; set; }

        /// <summary>
        /// Идентификатор предшеструющей валюты.
        /// </summary>
        [Display(Name = "Идентификатор предшеструющей валюты")]
        public virtual string ParentCode { get; set; }

        /// <summary>
        /// Номер валюты по международной классификации.
        /// </summary>
        [Display(Name = "Номер валюты по международной классификации.")]
        public virtual string IsoNumCode { get; set; }

        /// <summary>
        /// Код валюты по международной классификации.
        /// </summary>
        [Display(Name = "Код валюты по международной классификации.")]
        public virtual string IsoCharCode { get; set; }
    }
}
