﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;



namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int productPage = 1)
            => View(repository.Products
                .OrderBy(x => x.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
    }
}