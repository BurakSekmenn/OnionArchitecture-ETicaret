using EticaretApi.Application.Exceptions;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = EticaretApi.Domain.Entities;

namespace EticaretApi.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<P.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<P.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(new P.Identity.AppUser
            {
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
            }, request.Password);


            CreateUserCommandResponse response = new CreateUserCommandResponse() { IsSuccess = result.Succeeded };

            if(result.Succeeded)
                response.Message = "User created successfully";
            else
                foreach(var error in result.Errors)
                    response.Message += $"{error.Code} -- {error.Description} \n ";
            return response;


            
              
             
            //throw new UserCreateException(result.Errors.Select(x => x.Description).FirstOrDefault());
            
        }
    }
}
