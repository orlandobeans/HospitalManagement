﻿using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.PhysicianService
{
    public class PhysicianService : IPhysicianService
    {
        private IRepository<Physician> _physicianRepository;

        public PhysicianService(IRepository<Physician> physicianRepository)
        {
            _physicianRepository = physicianRepository;
        }

        public void DeletePhysician(long id)
        {
            _physicianRepository.Delete(id);
        }

        public Physician GetPhysician(long id)
        {
            return _physicianRepository.GetById(id);
        }

        public IEnumerable<Physician> GetPhysicians()
        {
            return _physicianRepository.GetAll;
        }

        public void InsertPhysician(Physician physician)
        {
            _physicianRepository.Insert(physician);
        }

        public void UpdatePhysician(Physician physician)
        {
            _physicianRepository.Update(physician);
        }
    }
}