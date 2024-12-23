﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        ICollection<User> GetClientsEnrolledInMySubjects(int professorId);
        Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId);
    }
}
