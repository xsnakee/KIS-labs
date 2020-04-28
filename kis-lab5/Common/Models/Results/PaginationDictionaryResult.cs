using System.Collections.Generic;

namespace Common.Models.Results
{
    /// <summary>
    /// Постраничный результат словарь
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class PaginationDictionaryResult<T1, T2>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PaginationDictionaryResult()
        {
            Items = new Dictionary<T1, T2>();
            TotalPages = 0;
            CurrentPage = 1;
            TotalRecords = 0;
        }

        /// <summary>
        /// Общее кол-во страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Общее кол-во записей
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        public Dictionary<T1, T2> Items { get; set; }
    }
}
