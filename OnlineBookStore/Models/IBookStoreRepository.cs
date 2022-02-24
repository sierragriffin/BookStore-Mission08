using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace OnlineBookStore.Models
{
    public interface IBookStoreRepository
    {
        //class set up specifically for querying data, very efficient
        IQueryable<Book> Books { get; }
    }
}

//an interface is not a class, it's a template for a class
