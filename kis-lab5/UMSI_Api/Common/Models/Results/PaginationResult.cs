using System.Collections.Generic;

namespace Common.Models.Results
{
    /// <summary>
    /// Постраничный результат
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationResult<T>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PaginationResult()
        {
            Items = new List<T>();
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
        public List<T> Items { get; set; }
    }
}
