using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace Service.TrainedInService
{
    public class TrainedInService : ITrainedInService
    {
        private IRepository<Trained_In> _trainedInRepository;

        public TrainedInService(IRepository<Trained_In> trainedInRepository)
        {
            _trainedInRepository = trainedInRepository;
        }

        public void DeleteTrainedIn(long id)
        {
            _trainedInRepository.Delete(id);
        }

        public Trained_In Find(params object[] keyValues)
        {
           return _trainedInRepository.Find(keyValues);
        }

        public Trained_In GetTrainedIn(long id)
        {
           return _trainedInRepository.GetById(id);
        }

        public IEnumerable<Trained_In> GetTrainedIns()
        {
            return _trainedInRepository.GetAll;
        }

        public void InsertTrainedIn(Trained_In trainedIn)
        {
            _trainedInRepository.Insert(trainedIn);
        }

        public void UpdateTrainedIn(Trained_In trainedIn)
        {
            _trainedInRepository.Update(trainedIn);
        }
    }
}
