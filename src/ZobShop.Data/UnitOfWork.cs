﻿using System;
using System.Data.Entity;
using ZobShop.Data.Contracts;

namespace ZobShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            this.dbContext = context;
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
