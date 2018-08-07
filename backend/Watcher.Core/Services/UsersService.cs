﻿namespace Watcher.Core.Services
{
    using System.Threading.Tasks;
    using AutoMapper;

    using Watcher.Core.Interfaces;
    using Watcher.Common.Requests;
    using Watcher.DataAccess.Interfaces;
    using Watcher.DataAccess.Entities;

    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> UpdateEntityByIdAsync(UserRequest request, int id)
        {
            var entity = _mapper.Map<UserRequest, User>(request);
            entity.Id = id;

            // In returns updated entity, you could do smth with it or just leave as it is
            var updated = _uow.UsersRepository.Update(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
