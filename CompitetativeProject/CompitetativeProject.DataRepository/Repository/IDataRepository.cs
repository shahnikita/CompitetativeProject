﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompitetativeProject.DataRepository.Repository
{
    public interface IDataRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Property gets the Entity count.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Add the new entity into the datacontext
        /// </summary>
        /// <param name="entity"></param>
        T Add(T entity);

        /// <summary>
        /// Attaches the entity into the datacontext.
        /// </summary>
        /// <param name="entity"></param>
        void Attach(T entity);

        /// <summary>
        /// Update the entity into the datacontext.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        ///   Gets objects via optional filter, sort order, and includes
        /// </summary>
        /// <param name="filter"> </param>
        /// <param name="orderBy"> </param>
        /// <param name="includeProperties"> </param>
        /// <returns> </returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        /// <summary>
        ///   Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate"> Specified a filter </param>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Gets objects from database with filting and paging.
        /// </summary>
        /// <param name="filter"> Specified a filter </param>
        /// <param name="total"> Returns the total records count of the filter. </param>
        /// <param name="index"> Specified the page index. </param>
        /// <param name="size"> Specified the page size </param>
        IQueryable<T> Fetch(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        //IQueryable<T> Fetch(Func<T, bool> predicate);

        /// <summary>
        ///   Find object by keys.
        /// </summary>
        /// <param name="keys"> Specified the search keys. </param>
        T Find(params object[] keys);

        /// <summary>
        ///   Gets object by primary key.
        /// </summary>
        /// <param name="id"> primary key </param>
        /// <returns> </returns>
        T GetById(object id);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="predicate"> </param>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T First(Func<T, bool> predicate);

        /// <summary>
        /// Fetches the Single entity based on the function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Single(Func<T, bool> predicate);

        /// <summary>
        /// Fetches all the item from the datacontext.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        ///   Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate"> Specified the filter expression </param>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Save changes into the database.
        /// </summary>
        void SaveChanges();

        /// <summary>
        ///   Deletes the object by primary key
        /// </summary>
        /// <param name="id"> </param>
        void Delete(object id);

        /// <summary>
        ///   Delete the object from database.
        /// </summary>
        /// <param name="entity"> Specified a existing object to delete. </param>
        void Delete(T entity);

        /// <summary>
        ///   Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"> </param>
        void Delete(Expression<Func<T, bool>> predicate);
    }

}
