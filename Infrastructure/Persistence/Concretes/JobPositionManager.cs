﻿using Application.Abstractions;
using Application.Constants;
using Application.Repositories;
using Application.Results;
using Domain.Entities;

namespace Persistence.Concretes
{
    public class JobPositionManager : IJobPositionService
    {
        IJobPositionReadRepository _jobPositionReadRepository;
        IJobPositionWriteRepository _jobPositionWriteRepository;
        IJobPositionDeleteRepository _jobPositionDeleteRepository;

        public JobPositionManager(IJobPositionReadRepository jobPositionReadRepository, IJobPositionWriteRepository jobPositionWriteRepository, IJobPositionDeleteRepository jobPositionDeleteRepository)
        {
            _jobPositionReadRepository = jobPositionReadRepository;
            _jobPositionWriteRepository = jobPositionWriteRepository;
            _jobPositionDeleteRepository = jobPositionDeleteRepository;
        }

        public IResult Add(JobPosition jobPosition)
        {
            _jobPositionWriteRepository.Add(jobPosition);
            return new SuccessResult(Messages.JobPositionAdded);
        }

        public IResult Delete(string id)
        {
            _jobPositionDeleteRepository.Delete(id);
            return new SuccessResult(Messages.JobPositionDeleted);
        }

        public IDataResult<IQueryable<JobPosition>> GetAll()
        {
            return new SuccessDataResult<IQueryable<JobPosition>>(_jobPositionReadRepository.GetAll());
        }

        public IDataResult<JobPosition> GetById(string id)
        {
            return new SuccessDataResult<JobPosition>(_jobPositionReadRepository.GetById(id));
        }

        public IResult Update(JobPosition jobPosition)
        {
            _jobPositionWriteRepository.Update(jobPosition);
            return new SuccessResult(Messages.JobPositionUpdated);
        }
    }
}