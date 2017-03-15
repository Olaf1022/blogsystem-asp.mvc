﻿namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Nav;
    using Services.Data.Pages;
    using Services.Web.Caching;
    using Services.Web.Mapping;

    public class NavController : BaseController
    {
        private readonly IPagesDataService pagesData;
        private readonly ICacheService cacheService;
        private readonly IMappingService mappingService;

        public NavController(IPagesDataService pagesData, ICacheService cacheService, IMappingService mappingService)
        {
            this.pagesData = pagesData;
            this.cacheService = cacheService;
            this.mappingService = mappingService;
        }

        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            var pages = this.pagesData.GetAllForMenu();
            var model = this.cacheService.Get("Menu", () => this.mappingService.Map<MenuItemViewModel>(pages).ToList(), 600);

            return this.PartialView(model);
        }
    }
}