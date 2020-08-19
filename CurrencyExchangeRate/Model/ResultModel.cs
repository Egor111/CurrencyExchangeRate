namespace CurrencyExchangeRate.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Модель результата сохранения
    /// </summary>
    public class ResultModel<T>
    {
        /// <summary>
        /// Результат сохранения.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<string> ErrorMessages { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public T Model { get; set; }
    }
}
