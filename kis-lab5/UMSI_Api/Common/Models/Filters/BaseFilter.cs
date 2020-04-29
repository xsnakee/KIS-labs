namespace Common.Models.Filters
{ 

    /// <summary>
    /// Базовая модель фильтра
    /// </summary>
    public class BaseFilter
    {
        private int _page;
        private int _pageSize;

        public BaseFilter()
        {
            _page = Constants.DefaultPageNumber;
            _pageSize = Constants.DefaultPageSize;
        }

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber
        {
            get { return _page; }
            set
            {
                _page = value > 0
                    ? value
                    : Constants.DefaultPageNumber;
            }
        }

        /// <summary>
        /// Количество позиций на страницу
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value > 0
                    ? value
                    : Constants.DefaultPageSize;
            }
        }
        /// <summary>
        /// Направление сортировки (ask,desc)
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// Имя поля сортировки
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Ключевые слова 
        /// для каждой сущности, при фильтрации можно использовать различные поля
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// Просмотр удаленых сущностей
        /// </summary>
        public bool WithRemoved { get; set; }
    }
}
