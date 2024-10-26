using Application.DTOs.Requests;
using Application.DTOs;


namespace Application.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectDto> CreateAsync(SubjectCreateRequest user);

        Task<SubjectDto> GetSubjectAsync(int id);

        Task<List<SubjectDto>> GetAllAsync();

        Task<SubjectDto> UpdateAsync(SubjectDto subject, int id);

        Task DeleteAsync(int id);
    }
}
