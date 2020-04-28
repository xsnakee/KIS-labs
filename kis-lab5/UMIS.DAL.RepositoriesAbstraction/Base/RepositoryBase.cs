using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Common;
using Common.Models.Filters;
using Common.Models.Results;
using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.Domain.Models.Helpers;
using Common.Exceptions;
using Common.Resources.Messages;

namespace UMIS.DAL.RepositoriesAbstraction.Base
{
    public class RepositoryBase<TContext, TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
        where TContext : DbContext
    {
        public RepositoryBase(TContext context)
        {
            DbContext = context;
            _entitySet = DbContext.Set<TEntity>();
        }

        public TContext DbContext { get; set; }
        protected virtual DbSet<TEntity> _entitySet { get; set; }

        public virtual TEntity Add(TEntity entity)
        {
            EntityPropertyFillHelper.FillCreateDate(entity);
            _entitySet.Add(entity);

            return entity;
        }
        public virtual TEntity AddAndSave(TEntity entity)
        {
            Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            EntityPropertyFillHelper.FillCreateDate(entity);
            await _entitySet.AddAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> AddAndSaveAsync(TEntity entity)
        {
            await AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public virtual void DeleteAndSave(TEntity entity)
        {
            _entitySet.Remove(entity);
            DbContext.SaveChanges();
        }

        public virtual TEntity Get(TKey id)
        {
            return _entitySet
                .Find(id);
        }

        public virtual IEnumerable<TEntity> GetByIds(IEnumerable<TKey> ids)
        {
            return _entitySet
                .Where(x => ids.Contains(x.Id))
                .ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> ids)
        {
            return await _entitySet
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _entitySet
                .FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll(bool trackable = true)
        {
            return trackable
                ? _entitySet
                : _entitySet.AsNoTracking();
        }

        // TODO: использовать при крайней необходимости
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entitySet.ToListAsync();
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public virtual void UpdateAndSave(TEntity entity)
        {
            try
            {
                EntityPropertyFillHelper.FillModificationDate(entity);
                _entitySet.Update(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

        public virtual async Task UpdateAndSaveAsync(TEntity entity)
        {
            EntityPropertyFillHelper.FillModificationDate(entity);
            _entitySet.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                EntityPropertyFillHelper.FillCreateDate(entity);
            }

            await _entitySet.AddRangeAsync(entities);
        }

        public virtual async Task AddRangeAndSaveAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                EntityPropertyFillHelper.FillCreateDate(entity);
            }

            await _entitySet.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            EntityPropertyFillHelper.FillModificationDate(entity);
            _entitySet.Update(entity);
        }

        public virtual Task AddOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> GetAllForOwner<T>(int ownerId)
            where T : class, TEntity, IBaseCustomizeEntity
        {
            return DbContext.Set<T>()
                .Where(x => !x.IsRemoved
                    && (!x.AllowedOnlyForOwner
                        || x.OwnerId == ownerId
                        || x.OwnerId == 0));
        }

        /// <inheritdoc />
        public virtual async Task<List<T>> GetAllForOwnerList<T>(int ownerId)
            where T : class, TEntity, IBaseCustomizeEntity
        {
            return await DbContext.Set<T>()
                .Where(x => !x.IsRemoved
                    && (!x.AllowedOnlyForOwner
                        || x.OwnerId == ownerId
                        || x.OwnerId == 0))
                .ToListAsync();
        }

        /// <summary>
        /// Добавляет сущность к текущему DBContext
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Присоеденённую сущность</returns>
        public virtual TEntity Attach(TEntity entity)
        {
            return DbContext.Set<TEntity>().Local.Any(e => e.Id.Equals(entity.Id))
                ? Get(entity.Id)
                : DbContext.Set<TEntity>().Attach(entity).Entity;
        }

        /// <summary>
        /// Очищает локальный db контекст по сущности <see cref="T"/>
        /// </summary>
        public virtual void ClearContext()
        {
            foreach (var entity in _entitySet.Local.ToList())
            {
                DbContext.Entry(entity).State = EntityState.Detached;
            }
        }

        /// <summary>
        /// Вычисляет количество страниц
        /// </summary>
        /// <param name="totalItems">Количество элементов</param>
        /// <param name="itemsPerPage">Количество элементов на одной странице</param>
        /// <returns>Количество страниц</returns>
        protected virtual int CalcTotalPagesCount(int totalItems, int itemsPerPage)
        {
            var totalPages = ((totalItems % itemsPerPage) == 0
                ? (totalItems / itemsPerPage)
                : ((totalItems / itemsPerPage)) + 1);

            return totalPages;
        }

        /// <summary>
        /// Возвращает элементы запрашиваемой страницы
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="page">Номер страницы</param>
        /// <param name="itemsPerPage">Количество элементов на страницук</param>
        /// <param name="data">Данные</param>
        /// <param name="totalItemsCount">Количество элементов</param>
        /// <returns>Элементы запрашиваемой страницы</returns>
        protected virtual IQueryable<T> Paginate<T>(IQueryable<T> data,
            int page, int itemsPerPage,
            out int totalItemsCount)
        {
            totalItemsCount = data.Count();

            if (page == 0)
            {
                page = Constants.DefaultPageNumber;
            }

            if (itemsPerPage == 0)
            {
                itemsPerPage = Constants.DefaultPageSize;
            }
            // Если запрашиваемой страницы не существует, то выводим последнюю непустую страницу
            var skipForEmptyPage = totalItemsCount -
                       (totalItemsCount % itemsPerPage != 0 ? totalItemsCount % itemsPerPage : itemsPerPage);
            return totalItemsCount / (page * itemsPerPage) > 0
                ? data.Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                : data.Skip(skipForEmptyPage >= 0 ? skipForEmptyPage : 0).Take(itemsPerPage);
        }

        /// <summary>
        /// Возвращает элементы запрашиваемой страницы
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="page">Номер страницы</param>
        /// <param name="itemsPerPage">Количество элементов на страницук</param>
        /// <param name="data">Данные</param>
        /// <param name="totalItemsCount">Количество элементов</param>
        /// <returns>Элементы запрашиваемой страницы</returns>
        protected virtual IGrouping<TPKey, TValue> Paginate<TPKey, TValue>(IGrouping<TPKey,
            TValue> data,
            int page,
            int itemsPerPage,
            out int totalItemsCount)
        {
            totalItemsCount = data.Count();

            if (page == 0)
            {
                page = Constants.DefaultPageNumber;
            }

            if (itemsPerPage == 0)
            {
                itemsPerPage = Constants.DefaultPageSize;
            }
            // Если запрашиваемой страницы не существует, то выводим последнюю непустую страницу
            var skipForEmptyPage = totalItemsCount -
                       (totalItemsCount % itemsPerPage != 0 ? totalItemsCount % itemsPerPage : itemsPerPage);
            return totalItemsCount / (page * itemsPerPage) > 0
                ? data.Skip((page - 1) * itemsPerPage).Take(itemsPerPage) as IGrouping<TPKey, TValue>
                : data.Skip(skipForEmptyPage >= 0 ? skipForEmptyPage : 0).Take(itemsPerPage) as IGrouping<TPKey, TValue>;
        }

        /// <summary>
        /// Сортировка запроса по строковым параметрам поля и направления базового фильтра
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="filter">Фильтр</param>
        protected virtual IQueryable<TEntity> GetQueryByFilterBasic(IQueryable<TEntity> query,
            BaseFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter?.SortField)
                && IsValidSortFieldAndDirection(typeof(TEntity), filter.SortField, filter.SortDirection))
            {
                query = query.OrderBy
                (
                    string.Format("{0} {1}", filter.SortField, filter.SortDirection)
                );
            }
            else
            {
                query = query.OrderByDescending(o => o.Id);
            }

            return query;
        }

        /// <summary>
        /// Проверка поля и направления сортировки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">Тип сущности typeof()</param>
        /// <param name="field">Поле сортировки</param>
        /// <param name="direction">Направление сортировки</param>
        protected bool IsValidSortFieldAndDirection(Type type, string field, string direction)
        {
            bool isContainsSortedField = type
                .GetProperties()
                .Select(x => x.Name.ToLower())
                .ToList()
                .Contains(field.ToLower());

            bool isValidDirection =
                direction.Equals("asc", StringComparison.OrdinalIgnoreCase)
                || direction.Equals("desc", StringComparison.OrdinalIgnoreCase);

            return isContainsSortedField && isValidDirection;
        }

        /// <inheritdoc />
        public virtual bool ExecuteInTransaction(Action action)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                action.Invoke();
                SaveChanges();
                transaction.Commit();
                return true;
            }
        }

        /// <inheritdoc />
        public virtual async Task ExecuteInTransactionAsync(Func<Task> func)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                await func.Invoke();
                await SaveChangesAsync();
                transaction.Commit();
            }
        }

        /// <inheritdoc />
        public virtual void AttachEntity<T>(T entity) where T : class, TEntity
        {
            DbContext.Attach(entity);
        }

        /// <inheritdoc />
        public virtual async Task<PaginationResult<TEntity>> GetPaginationByBaseFilterAsync(BaseFilter filter)
        {
            if (filter == null)
            {
                return new PaginationResult<TEntity>();
            }

            IQueryable<TEntity> query = GetAll(false);

            int totalItemsCount;
            query = GetQueryByFilterBasic(query,
                    new BaseFilter
                    {
                        SortDirection = filter.SortDirection,
                        SortField = filter.SortField
                    });
            query = Paginate(query, filter.PageNumber, filter.PageSize, out totalItemsCount);

            return new PaginationResult<TEntity>
            {
                Items = await query.ToListAsync(),
                TotalPages = CalcTotalPagesCount(totalItemsCount, filter.PageSize),
                TotalRecords = totalItemsCount,
                CurrentPage = filter.PageNumber
            };
        }

        /// <inheritdoc />
        public bool DeleteToggleMark(TKey id, bool delete)
        {
            IBaseCustomizeEntity domainEntity = Get(id)
                as IBaseCustomizeEntity;

            if (domainEntity != null)
            {
                domainEntity.IsRemoved = delete;
                return delete;
            }

            throw new CustomException(string.Format(Messages.Exception_EntityNotFoundTemplate, string.Empty, id));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteToggleMarkAsync(TKey id, bool delete)
        {
            IBaseCustomizeEntity domainEntity = (await GetAsync(id))
                as IBaseCustomizeEntity;

            if (domainEntity != null)
            {
                domainEntity.IsRemoved = delete;
                await SaveChangesAsync();
                return delete;
            }

            throw new CustomException(string.Format(Messages.Exception_EntityNotFoundTemplate, string.Empty, id));
        }

        public virtual async Task<TEntity> GetWithRelationshipAsync(TKey id)
        {
            return await GetAsync(id);
        }
    }
}
