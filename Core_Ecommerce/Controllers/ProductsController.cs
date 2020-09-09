﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Spesification;
using Ecommerce.DTOs;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await productRepo.ListAsync(spec);


            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList < ProductToReturnDto >> (products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await productRepo.GetEntityWithSpec(spec);

            return mapper.Map<Product, ProductToReturnDto>(product); //automapper ve dto kullanarak dataları istediğimiz formatta yazdırıyoruz 
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()  //IReadOnlyList old. için Ok() şeklinde yazılıyor
        {
            return Ok(await productBrandRepo.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()  //IReadOnlyList old. için Ok() şeklinde yazılıyor
        {
            return Ok(await productTypeRepo.ListAllAsync());

        }
    }
}
