using AutoMapper;
using MagicVilla.Models.ResponseModels.ApiResponse;
using MagicVilla.Models.VillaDbModels;
using MagicVilla.Models.VillaDtoModels;
using MagicVilla.RepositoryConfig.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;

namespace MagicVilla.WebApi.Controllers
{
    [Route("api/VillaNumber")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VillaNumberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ApiResponse> GetAllVillaNumber(int PageNumber, int PageSize, CancellationToken cancellationToken)
        {
            var response = new ApiResponse();
            try
            {
                var villaNumbers = await _unitOfWork.VillaNumber.GetAllAsync(cancellationToken: cancellationToken);
                if (villaNumbers != null)
                {
                    var model = _mapper.Map<VillaNumberDto>(villaNumbers);

                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Successful";
                    response.PageNumber = PageNumber;
                    response.PageSize = PageSize;
                    response.Results = model;

                }
                else
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Unsuccessful";
                }
            }
            catch(TaskCanceledException ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.RequestTimeout;
                response.Message = $"Unsuccessful - {ex.Message}";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Unsuccessful - {ex.Message}";
            }
            
            return response;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ApiResponse> GetVillaNumber(int id,CancellationToken cancellationToken)
        {
            var response = new ApiResponse();
            if (id == 0)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Unsuccessful - valid id needed.";
                return response;
            }
            try
            {
                var villaNumber = await _unitOfWork.VillaNumber.GetAsync(x => x.VillaNo == id, cancellationToken: cancellationToken);

                if (villaNumber != null)
                {
                    var model = _mapper.Map<VillaNumberDto>(villaNumber);
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Successful";
                    response.Results = model;
                }
                else
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Unsuccessful";
                }
            }
            catch (TaskCanceledException ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.RequestTimeout;
                response.Message = $"Request canceled - {ex.Message}";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Unsuccessful - {ex.Message}";
            }


            return response;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ApiResponse> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberCreateDto)
        {
            var response = new ApiResponse();
            try
            {
                if (villaNumberCreateDto != null)
                {
                    var model = _mapper.Map<VillaNumber>(villaNumberCreateDto);
                    await _unitOfWork.VillaNumber.AddAsync(model);
                    int result = await _unitOfWork.Save();
                    if (result > 0)
                    {
                        var modelTodisplay = _mapper.Map<VillaNumberDto>(model);
                        response.IsSuccess = true;
                        response.StatusCode = HttpStatusCode.OK;
                        response.Message = "Successful - villa number created";
                        response.Results = modelTodisplay;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Message = "Unsuccessful - unable to create data";
                    }

                }
                else
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Unsuccessful - valid data needed.";
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Unsuccessful - {ex.Message}";
            }
            
            return response;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ApiResponse> UpdateVillaNumber(int id ,[FromBody] VillaNumberUpdateDto villaNumberUpdateDto)
        {
            var response = new ApiResponse();
            if(id == 0)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Unsuccessful - valid data needed.";
                return response;
            }
            try
            {
                if (villaNumberUpdateDto != null)
                {
                    var villaNumber = await _unitOfWork.VillaNumber.GetAsync(x => x.VillaNo == id);

                    if (villaNumber != null)
                    {
                        var modelToUpdate = _mapper.Map<VillaNumber>(villaNumberUpdateDto);
                        _unitOfWork.VillaNumber.Update(modelToUpdate);
                        int result = await _unitOfWork.Save();
                        if (result > 0)
                        {
                            var model = _mapper.Map<VillaNumberUpdateDto>(modelToUpdate);

                            response.IsSuccess = true;
                            response.StatusCode = HttpStatusCode.OK;
                            response.Message = "Successful - villa number updated";
                            response.Results = model;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.StatusCode = HttpStatusCode.InternalServerError;
                            response.Message = "Unsuccessful - unable to update data";
                        }
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Unsuccessful - valid data needed.";
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Unsuccessful - {ex.Message}";
            }
            
            return response;
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<ApiResponse> RemoveVillaNumber(int id)
        {
            var response = new ApiResponse();
            if (id != 0)
            {
                try
                {
                    var villaNumber = await _unitOfWork.VillaNumber.GetAsync(x => x.VillaNo == id);
                    if (villaNumber != null)
                    {
                        _unitOfWork.VillaNumber.Remove(villaNumber);
                        int result = await _unitOfWork.Save();
                        if (result > 0)
                        {
                            response.IsSuccess = true;
                            response.StatusCode = HttpStatusCode.OK;
                            response.Message = "Successful - villa number removed";

                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.StatusCode = HttpStatusCode.InternalServerError;
                            response.Message = "Unsuccessful - unable to remove data";
                        }
                    }
                }
                catch(Exception ex)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Message = $"Unsuccessful - {ex.Message}";
                }

            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Unsuccessful - valid id needed.";
            }
            return response;
        }
    }
}
