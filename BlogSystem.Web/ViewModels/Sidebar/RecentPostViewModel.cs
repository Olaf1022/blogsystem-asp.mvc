﻿namespace BlogSystem.Web.ViewModels.Sidebar
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class RecentPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}