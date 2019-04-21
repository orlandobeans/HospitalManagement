﻿using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.PresrcibeService
{
    public class PrescribeService : IPrescribeService
    {
        private IRepository<Prescribe> _prescribeRepository;

        public PrescribeService(IRepository<Prescribe> prescribeRepository)
        {
            _prescribeRepository = prescribeRepository;
        }

        public void DeletePrescribe(long id)
        {
            _prescribeRepository.Delete(id);
        }

        public Prescribe Find(params object[] keyValues)
        {
            return _prescribeRepository.Find(keyValues);
        }

        public Prescribe GetPrescribe(long id)
        {
            return _prescribeRepository.GetById(id);
        }

        public IEnumerable<Prescribe> GetPrescribes()
        {
            return _prescribeRepository.GetAll;
        }

        public void InsertPrescribe(Prescribe prescribe)
        {
            _prescribeRepository.Insert(prescribe);
        }

        public void UpdatePrescribe(Prescribe prescribe)
        {
            _prescribeRepository.Update(prescribe);
        }
    }
}