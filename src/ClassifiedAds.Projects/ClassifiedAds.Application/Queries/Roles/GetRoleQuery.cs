﻿using ClassifiedAds.Domain.Entities;
using ClassifiedAds.Domain.Repositories;
using System;
using System.Linq;

namespace ClassifiedAds.Application.Queries.Roles
{
    public class GetRoleQuery : IQuery<Role>
    {
        public Guid Id { get; set; }
        public bool IncludeClaims { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool IncludeUsers { get; set; }
        public bool AsNoTracking { get; set; }
    }

    internal class GetRoleQueryHandler : IQueryHandler<GetRoleQuery, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Handle(GetRoleQuery query)
        {
            var db = _roleRepository.Get(new RoleQueryOptions
            {
                IncludeClaims = query.IncludeClaims,
                IncludeUserRoles = query.IncludeUserRoles,
                IncludeUsers = query.IncludeUsers,
                AsNoTracking = query.AsNoTracking,
            });

            return db.FirstOrDefault(x => x.Id == query.Id);
        }
    }
}
