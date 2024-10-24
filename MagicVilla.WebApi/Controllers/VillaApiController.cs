﻿using AutoMapper;
using MagicVilla.DatabaseConfig.Data;
using MagicVilla.Models.ResponseModels.ApiResponse;
using MagicVilla.Models.VillaDbModels;
using MagicVilla.Models.VillaDtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla.WebApi.Controllers
{
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly MagicVillaDbContext _magicVillaDbContext;
        private readonly ApiResponse response;
        private readonly IMapper _mapper;
        public VillaApiController(MagicVillaDbContext magicVillaDbContext,IMapper mapper)
        {
            _magicVillaDbContext = magicVillaDbContext;
            this.response = new ApiResponse();
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllVilla")]
        public async Task<ApiResponse> GetAllVilla(int PageNumber, int PageSize)
        {
            //Getting villa from db
            var villa =await _magicVillaDbContext
                .Villas
                .ToListAsync();
            // implementing pagination
            var paginatedData = villa
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            if (villa != null)
            {
                var model = _mapper.Map<List<VillaDto>>(paginatedData);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK; 
                response.Message = "Successful";
                response.PageNumber = PageNumber;
                response.PageSize = PageSize;
                response.TotalRecords = villa.Count;
                response.Results = model;
            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Unsuccessful";
            }
            return response;
        }

        [HttpGet]
        [Route("GetVilla")]
        public async Task<ApiResponse> GetVilla(int id)
        {
            if(id == 0)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Unsuccessful - search with valid id.";
                return response;
            }
            var villa = await _magicVillaDbContext.Villas.FirstOrDefaultAsync(x=>x.VillaId == id);
            if (villa != null)
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Successful";
                response.Results = villa;
            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Unsuccessful";
            }
            return response;
        }

        [HttpPost]
        [Route("CreateVilla")]
        public async Task<ApiResponse> CreateVilla([FromBody] VillaCreateDto createDto)
        {
            if (createDto != null)
            {
                Villa model = _mapper.Map<Villa>(createDto);
                await _magicVillaDbContext.Villas.AddAsync(model);
                int result = await _magicVillaDbContext.SaveChangesAsync();
                if(result > 0)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Successful - Villa created.";
                    response.Results = model;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Unsuccessful";
            }

            return response;
        }

        [HttpPost]
        [Route("UpdateVilla")]
        public async Task<ApiResponse> UpdateVilla([FromBody] VillaUpdateDto updateDto)
        {
            var response = new ApiResponse();
            if(updateDto != null)
            {
                var model = _mapper.Map<Villa>(updateDto);
                _magicVillaDbContext.Villas.UpdateRange(model);
                int result = await _magicVillaDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;

                }

            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Unsuccessful";
            }
            return response;
        }
    }
}