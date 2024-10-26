using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        public EnrollmentService(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<EnrollmentDto> CreateAsync(EnrollmentCreateRequest request)
        {
            var enrollment = new Enrollment();
            enrollment.ClientId = request.ClientId;
            enrollment.SubjectId = request.SubjectId;

            _ = await _repository.CreateAsync(enrollment);

            var dto = new EnrollmentDto();
            dto.SubjectId = enrollment.SubjectId;
            dto.ClientId = enrollment.ClientId;
            dto.EnrollmentId = enrollment.SubjectId;

            return dto;
        }

        public async Task<EnrollmentDto> GetEnrollmentAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Enrollment not Found");

            var enrollmentDto = new EnrollmentDto()
            {
                EnrollmentId = result.EnrollmentId,
                SubjectId = result.SubjectId,
                ClientId = result.ClientId
            };
            return enrollmentDto;
        }
        public async Task<List<EnrollmentDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var resultDto = new List<EnrollmentDto>();
            foreach (var enrollment in result)
            {
                var enrollmentDto = new EnrollmentDto()
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    SubjectId = enrollment.SubjectId,
                    ClientId = enrollment.ClientId,
                };
                resultDto.Add(enrollmentDto);
            }
            return resultDto;
        }

        public async Task<EnrollmentDto> UpdateAsync(EnrollmentDto enrollmentDto, int id)
        {
            var enrollment = await _repository.GetByIdAsync(id);
            if (enrollment == null)
                throw new Exception("Enrollment not Found");

            enrollment.ClientId = enrollmentDto.ClientId;
            enrollment.SubjectId = enrollmentDto.SubjectId;

            await _repository.UpdateAsync(enrollment);

            var dto = new EnrollmentDto()
            {
                EnrollmentId = enrollment.EnrollmentId,
                SubjectId = enrollment.SubjectId,
                ClientId = enrollment.ClientId,
            };
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var enrollment = await _repository.GetByIdAsync(id);
            if (enrollment == null)
                throw new Exception("Enrollment not Found");

            await _repository.DeleteAsync(enrollment);
        }
    }
}
