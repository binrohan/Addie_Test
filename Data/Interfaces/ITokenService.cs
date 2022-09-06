using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addie.Models;

namespace Addie.Data.Interfaces
{
    public interface ITokenService
    {
        string Create(User user);
    }
}