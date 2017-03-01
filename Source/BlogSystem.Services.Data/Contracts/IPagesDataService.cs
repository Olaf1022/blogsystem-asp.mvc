﻿namespace BlogSystem.Services.Data.Contracts
{
    using System.Linq;
    using BlogSystem.Data.Models;

    public interface IPagesDataService
    {
        IQueryable<Page> GetAll();

        Page GetPage(string permalink);
    }
}