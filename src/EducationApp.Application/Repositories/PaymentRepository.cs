using EducationApp.Application.Repositories.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public class PaymentRepository(EduDbContext context) : Repository<Payment>(context) , IPaymentRepository
{
}
