﻿using ClassifiedAds.Domain.Entities;
using ClassifiedAds.Domain.Repositories;
using ClassifiedAds.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ClassifiedAds.Application.Queries.Users
{
    public class GetUsersQuery : IQuery<List<User>>
    {
        public bool IncludeClaims { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool IncludeRoles { get; set; }
        public bool AsNoTracking { get; set; }
    }

    internal class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> Handle(GetUsersQuery query)
        {
            var db = _userRepository.Get(new UserQueryOptions
            {
                IncludeClaims = query.IncludeClaims,
                IncludeUserRoles = query.IncludeUserRoles,
                IncludeRoles = query.IncludeRoles,
                AsNoTracking = query.AsNoTracking,
            });

            return db.ToList();
        }
    }
}
