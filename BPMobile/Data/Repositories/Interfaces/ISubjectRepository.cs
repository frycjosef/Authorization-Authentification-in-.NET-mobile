using System;
using BPMobile.Entities;

namespace BPMobile.Data.Repositories.Interfaces
{
    public interface ISubjectRepository : IBaseRepository
    {
        public Subject LoadById(int id);
        public IEnumerable<Subject> ListSubjects();
    }
}

