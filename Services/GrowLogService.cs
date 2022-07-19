﻿using Server.Models;
using Server.Repositories;
using System.Linq.Expressions;

namespace Server.Services
{
    public interface IGrowLogService : IService<GrowLog> { }
    public class GrowLogService : IGrowLogService
    {
        private readonly IGrowLogRepository _repo;

        public GrowLogService(IGrowLogRepository repo)
        {
            _repo = repo;
        }

        public GrowLog Create(GrowLog item) => _repo.Create(item);

        public void Delete(int id) => _repo.Delete(id);

        public IEnumerable<GrowLog> GetAll() => _repo.GetAll();

        public IEnumerable<GrowLog> GetAll(Expression<Func<GrowLog, bool>> filter) => _repo.GetAll(filter);

        public GrowLog? GetOne(int id) => _repo.GetOne(id);

        public GrowLog Update(GrowLog item) => _repo.Update(item);
    }
}
