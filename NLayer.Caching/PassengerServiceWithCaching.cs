using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Caching
{
    public class PassengerServiceWithCaching : IService<Passenger>
    {
        private const string CacheProductKey = "passengersCache";       
        private readonly IMemoryCache _memoryCache;
        private readonly IGenericRepository<Passenger> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PassengerServiceWithCaching(IUnitOfWork unitOfWork, IGenericRepository<Passenger> repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Passenger> AddAsync(Passenger entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Passenger>> AddRangeAsync(IEnumerable<Passenger> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Passenger, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Passenger>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Passenger>>(CacheProductKey));
        }

        public Task<Passenger> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Passenger>>(CacheProductKey).FirstOrDefault(x => x.UniquePassengerId == id);
            if (product == null)
            {
                throw new NotFoundException($"{typeof(Passenger).Name}({id}) not found");
            }

            return Task.FromResult(product);
        }

        public async Task RemoveAsync(Passenger entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Passenger> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task<Passenger> UpdateAsync(Passenger entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public IQueryable<Passenger> Where(Expression<Func<Passenger, bool>> expression)
        {
            return _memoryCache.Get<List<Passenger>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());
        }
    }
}
