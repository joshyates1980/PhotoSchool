using System;
using System.Collections.Generic;
using System.Linq;
namespace PhotoSchool.Data.Contracts.Models
{
    public interface IOrderable
    {
        int OrderBy { get; set; }
    }
}
