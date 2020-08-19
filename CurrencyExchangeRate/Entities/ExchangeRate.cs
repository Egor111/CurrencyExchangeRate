namespace CurrencyExchangeRate.Entities
{
    using Base.EF.DataAccess;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Курс валют.
    /// </summary>
    [Table("ExchangeRate")]
    public class ExchangeRate : BaseEntity
    {
        /// <summary>
        /// Номинал.
        /// </summary>
        [Display(Name = "Номинал")]
        public virtual uint Nominal { get; set; }

        /// <summary>
        /// Значение курса.
        /// </summary>
        [Display(Name = "Значение курса")]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// Дата курса.
        /// </summary>
        public virtual DateTime Date { get; set; }

        ///// <summary>
        ///// Ссылка на справочник валют.
        ///// </summary>
        //[Display(Name = "Ссылка на справочник валют.")]
        //public virtual CurrencyCodesReference CurrencyCodesReference { get; set; }
    }
}
