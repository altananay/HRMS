﻿using Application.Dtos;
using Application.Results;
using Application.Utilities.JWT;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IAuthService
    {
        IDataResult<JobSeeker> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<JobSeeker> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(JobSeeker user);
    }
}