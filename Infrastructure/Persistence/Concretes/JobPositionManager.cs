﻿using Application.Abstractions;
using Application.Aspects;
using Application.Constants;
using Application.CrossCuttingConcerns.Validation.Validators.Common;
using Application.CrossCuttingConcerns.Validation.Validators.JobPositions;
using Application.Repositories;
using Application.Results;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence.Concretes
{
    public class JobPositionManager : IJobPositionService
    {
        IJobPositionReadRepository _jobPositionReadRepository;
        IJobPositionWriteRepository _jobPositionWriteRepository;
        IJobPositionDeleteRepository _jobPositionDeleteRepository;
        string roles;
        private readonly ILogger<JobPositionManager> _logger;

        public JobPositionManager(IJobPositionReadRepository jobPositionReadRepository, IJobPositionWriteRepository jobPositionWriteRepository, IJobPositionDeleteRepository jobPositionDeleteRepository, ILogger<JobPositionManager> logger)
        {
            _jobPositionReadRepository = jobPositionReadRepository;
            _jobPositionWriteRepository = jobPositionWriteRepository;
            _jobPositionDeleteRepository = jobPositionDeleteRepository;
            roles = "";
            _logger = logger;
        }


        [ValidationAspect(typeof(JobPositionValidator))]
        [SecuredOperation("employer")]
        [LogAspect()]
        public async Task<IResult> Add(JobPosition jobPosition)
        {
            await _jobPositionWriteRepository.AddAsync(jobPosition);
            return new SuccessResult(Messages.JobPositionAdded);
        }

        [ValidationAspect(typeof(ObjectIdValidator))]
        public async Task<IResult> Delete(string id)
        {
            await _jobPositionDeleteRepository.Delete(id);
            return new SuccessResult(Messages.JobPositionDeleted);
        }

        public IDataResult<IQueryable<JobPosition>> GetAll()
        {
            return new SuccessDataResult<IQueryable<JobPosition>>(_jobPositionReadRepository.GetAll());
        }

        [ValidationAspect(typeof(ObjectIdValidator))]
        public IDataResult<JobPosition> GetById(string id)
        {
            return new SuccessDataResult<JobPosition>(_jobPositionReadRepository.GetById(id));
        }

        public IResult JobPositionExists(string jobPosition)
        {
            if (_jobPositionReadRepository.Get(jp => jp.PositionName == jobPosition) != null)
            {
                return new ErrorResult(Messages.JobPositionExists);
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(JobPositionValidator))]
        public async Task<IResult> Update(JobPosition jobPosition)
        {
            await _jobPositionWriteRepository.UpdateAsync(jobPosition);
            return new SuccessResult(Messages.JobPositionUpdated);
        }
    }
}