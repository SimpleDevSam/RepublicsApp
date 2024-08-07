using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountContext.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DiscountDbContext _context;

        public StudentRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent != null)
            {
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<Student?> GetAsync(Guid studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}