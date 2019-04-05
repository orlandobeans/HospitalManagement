﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace Service.StayService
{
    public class StayService : IStayService
    {
        private IRepository<Stay> _stayRepository;

        public StayService(IRepository<Stay> stayRepository)
        {
            _stayRepository = stayRepository;
        }

        public void DeleteStay(long id)
        {
            _stayRepository.Delete(id);
        }

        public Stay Find(params object[] keyValues)
        {
           return _stayRepository.Find(keyValues);
        }

        public Stay GetStay(long id)
        {
           return _stayRepository.GetById(id);
        }

        public IEnumerable<Stay> GetStays()
        {
            return _stayRepository.GetAll;
        }

        public void InsertStay(Stay stay)
        {
            _stayRepository.Insert(stay);
        }

        public void UpdateStay(Stay stay)
        {
            _stayRepository.Update(stay);
        }
    }
}