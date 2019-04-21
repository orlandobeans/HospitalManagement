using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.TrainedInService
{
    public interface ITrainedInService
    {
        IEnumerable<Trained_In> GetTrainedIns();
        Trained_In GetTrainedIn(long id);
        void InsertTrainedIn(Trained_In stay);
        void UpdateTrainedIn(Trained_In stay);
        void DeleteTrainedIn(long id);
        Trained_In Find(params object[] keyValues);
    }
}
