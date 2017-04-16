﻿using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MustDo.Infra.Data.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly MustDo4EntitiesDb _db;

		public RepositoryBase(MustDo4EntitiesDb db)
		{
			_db = db;
		}

		public void Adicionar(T entity)
		{
			_db.Set<T>().Add(entity);
			_db.SaveChanges();
		}

		public void Alterar(T entity)
		{
			_db.Entry(entity).State = EntityState.Modified;
			_db.SaveChanges();
		}


		public virtual T ObterPorId(int? id)
		{
			return _db.Set<T>().Find(id);
		}

		public IEnumerable<T> ObterTodos()
		{
			return _db.Set<T>().ToList();
		}

		public virtual void Remover(int? id)
		{
			var entity = ObterPorId(id);
			Remover(entity);
		}

		public void Remover(T entity)
		{
			_db.Set<T>().Remove(entity);
			_db.SaveChanges();
		}

	}
}
