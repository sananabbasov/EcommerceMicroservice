﻿using CorePackage.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityService.Entities.DTOs.UserDTO;

namespace IdentityService.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<UserByEmailDTO> GetUserByEmail(string email);
    }
}
