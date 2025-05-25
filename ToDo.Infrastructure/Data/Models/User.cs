using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models.Interfaces;

namespace ToDo.Infrastructure.Data.Models
{
    public class User : IdentityUser, IEntity
    {

    }
}
