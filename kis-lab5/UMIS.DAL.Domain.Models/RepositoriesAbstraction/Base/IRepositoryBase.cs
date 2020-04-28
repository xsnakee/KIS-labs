using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Contracts.RepositoriesAbstraction.Base
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        TEntity Get(TKey id);

        IEnumerable<TEntity> GetByIds(IEnumerable<TKey> ids);

        Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> ids);

        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetWithRelationshipAsync (TKey id);
        TEntity Add(TEntity entity);
        
        TEntity AddAndSave(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        
        Task<TEntity> AddAndSaveAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task AddRangeAndSaveAsync(IEnumerable<TEntity> entities);

        IQueryable<TEntity> GetAll(bool trackable);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void Update(TEntity entity);

        void UpdateAndSave(TEntity entity);

        Task UpdateAndSaveAsync(TEntity entity);

        void DeleteAndSave(TEntity entity);

        Task AddOrUpdateAsync(TEntity entity);

        /// <summary>
        /// Пометка/снятие флага удаления сущности
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        bool DeleteToggleMark(TKey id, bool delete);

        /// <summary>
        /// Ассинхронная пометка/снятие флага удаления сущности
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        Task<bool> DeleteToggleMarkAsync(TKey id, bool delete);

        /// <summary>
        /// Коллекция сущностей для пользователя
        /// </summary>
        /// <param name="ownerId">Идентификатор владельца</param>
        /// <returns>IQuertyable коллекция</returns>
        IQueryable<TEntity> GetAllForOwner<T>(int ownerId)
            where T : class, TEntity, IBaseCustomizeEntity;

        /// <summary>
        /// Материализованная коллекция сущностей для пользователя
        /// </summary>
        /// <param name="ownerId">Идентификатор владельца</param>
        /// <returns>IQuertyable коллекция</returns>
        Task<List<T>> GetAllForOwnerList<T>(int ownerId)
            where T : class, TEntity, IBaseCustomizeEntity;

        /// <summary>
        /// Добавляет сущность к текущему DBContext
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Присоеденённую сущность</returns>
        TEntity Attach(TEntity entity);

        /// <summary>
        /// Очищает локальный db контекст от сущностей <see cref="T"/>
        /// </summary>
        void ClearContext();

        /// <summary>
        /// Выполняет действие  c сохранением контекста, в рамках транзации
        /// </summary>
        /// <param name="action">Действие</param>
        /// <returns>Возвращает <b>true</b> если транзакция завершена успешно</returns>
        bool ExecuteInTransaction(Action action);

        /// <summary>
        /// Выполняет асинхронное действие  c сохранением контекста, в рамках транзации
        /// </summary>
        /// <param name="func">Действие</param>
        Task ExecuteInTransactionAsync(Func<Task> func);

        /// <summary>
        /// Добавляет полу сущности к текущему DBContext, чтобы использовать уже имеющееся значение
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Присоеденённую сущность</returns>
        void AttachEntity<TField>(TField entity) where TField : class, TEntity;

        /// <summary>
        /// Получить постраничный результат по базовому фильтру
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PaginationResult<TEntity>> GetPaginationByBaseFilterAsync(BaseFilter filter);
    }
}
