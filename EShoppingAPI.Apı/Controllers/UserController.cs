using System.Net;
using AutoMapper;
using EShoppingAPI.Apı.Aspect;
using EShoppingAPI.Apı.Validation.FluentValidation;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.Entity.DTO.User;
using EShoppingAPI.Entity.Poco;
using EShoppingAPI.Entity.Result;
using EShoppingAPI.Helper.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.Apı.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuç<List<UserDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            List<UserDTOResponse> userDTOList = new();

            foreach (var user in users)
            {
                userDTOList.Add(_mapper.Map<UserDTOResponse>(user));

            }

            return Ok(Sonuç<List<UserDTOResponse>>.SuccessWithData(userDTOList));
        }

        [HttpGet("/User/{guid}")]
        [ProducesResponseType(typeof(Sonuç<UserDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser(Guid guid)
        {
            var user = await _userService.GetAsync(q => q.GUID == guid);
            if (user != null)
            {
                UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);


                return Ok(Sonuç<UserDTOResponse>.SuccessWithData(userDTOResponse));

            }
            else
            {
                return NotFound(Sonuç<UserDTOResponse>.SuccessNoDataFound());

            }
        }

        [HttpPost("/AddUser")]
        [ProducesResponseType(typeof(Sonuç<UserDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(UserDTORequest userRequestDTO)
        {
            UserRegisterValidator userRegisterValidation = new UserRegisterValidator();

            
            
            User user = _mapper.Map<User>(userRequestDTO);
            
            await _userService.AddAsync(user);
             
            UserDTOResponse userResponseDTO = _mapper.Map<UserDTOResponse>(user);
            
            return Ok(Sonuç<UserDTOResponse>.SuccessWithData(userResponseDTO));

        }
    }


    
}
