﻿namespace BlogSystem.Web.Infrastructure.Attributes
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Data.Models;
    using BlogSystem.Data.Repositories;
    using BlogSystem.Services.Web.Caching;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PassSettingsToViewDataAttribute : ActionFilterAttribute, IDisposable
    {
        public IDbRepository<Setting> Settings { get; set; }
        public ICacheService Cache { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var settings = this.Cache.Get("Settings", () =>
            {
                return this.Settings.All().ToList();
            }, 600);

            var viewData = filterContext.Controller.ViewData;

            foreach(var setting in settings)
            {
                viewData.Add(setting.Key, setting.Value);
            }
        }

        public void Dispose()
        {
            this.Settings.Dispose();
        }
    }
}