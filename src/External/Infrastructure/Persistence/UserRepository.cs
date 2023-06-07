﻿using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADDD.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{
    private readonly static List<User> _users = new List<User>();

    public User? GetUserByEmail(string email) { 
        return _users.SingleOrDefault(x => x.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}