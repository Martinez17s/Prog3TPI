using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Diagnostics;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectDto> CreateAsync(SubjectCreateRequest request)
        {
            var subject = new Subject();
            subject.Title = request.Title;
            subject.Description = request.Description;
            subject.ProfessorId = request.ProfessorId;


            _ = await _subjectRepository.CreateAsync(subject);

            var dto = new SubjectDto();
            dto.SubjectId = subject.SubjectId;
            dto.Title = subject.Title;
            dto.Description = subject.Description;
            dto.ProfessorId = subject.ProfessorId;


            return dto;
        }

        public async Task<SubjectDto> GetSubjectAsync(int id)
        {
            var result = await _subjectRepository.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Subject not found");

            var subjectDto = new SubjectDto();
            subjectDto.SubjectId = result.SubjectId;
            subjectDto.Title = result.Title;
            subjectDto.Description = result.Description;
            subjectDto.ProfessorId = result.ProfessorId;


            return subjectDto;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var result = await _subjectRepository.GetAllAsync();
            var resultDto = new List<SubjectDto>();
            foreach (var subject in result)
            {
                var subjectDto = new SubjectDto()
                {
                    SubjectId = subject.SubjectId,
                    Title = subject.Title,
                    Description = subject.Description,
                    ProfessorId = subject.ProfessorId,
                };
                resultDto.Add(subjectDto);
            }
            return resultDto;
        }

        public async Task<SubjectDto> UpdateAsync(SubjectDto subjectDto, int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Subject not found");

            subject.Title = subjectDto.Title;
            subject.Description = subjectDto.Description;
            subject.ProfessorId = subjectDto.ProfessorId;

            await _subjectRepository.UpdateAsync(subject);

            var dto = new SubjectDto()
            {
                SubjectId = subject.SubjectId,
                Title = subject.Title,
                Description = subject.Description,
                ProfessorId = subject.ProfessorId,
            };

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Subject not found");

            await _subjectRepository.DeleteAsync(subject);
        }
    }
}
