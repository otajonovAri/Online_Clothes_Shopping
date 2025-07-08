using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationApp.Application.Helpers.GenerateJwt;
using EducationApp.Application.Helpers.PasswordHasher;
using EducationApp.Application.Models;
using EducationApp.Application.Models.Dtos;
using EducationApp.Application.Services.Interfaces;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Services
{
    public class AuthService(
        EduDbContext context,
        IPasswordHasher passwordHasher,
        IJwtTokenHandler jwtTokenHandler
        ) : IAuthService
    {
        public async Task<ApiResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto)
        {
            var user = await context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(r => r.Email == loginDto.Email);

            if(user == null)
            {
                return ApiResult<LoginResponseDto>.Failure(new[] { "Foydalanuvchi topilmadi" });
            }

            if (!passwordHasher.Verify(user.PasswordHasher, loginDto.Password, user.PasswordSalt))
                return ApiResult<LoginResponseDto>.Failure(new[] { "Parol noto‘g‘ri" });

            //if (!user.IsVerified)
            //    return ApiResult<LoginResponseDto>.Failure(new[] { "Email tasdiqlanmagan" });

            var accessToken = jwtTokenHandler.GenerateAccessToken(user, Guid.NewGuid().ToString());
            var refreshToken = jwtTokenHandler.GenerateRefreshToken();

            return ApiResult<LoginResponseDto>.Success(new LoginResponseDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList(),
                Permissions = user.UserRoles
                     .SelectMany(ur => ur.Role.RolePermissions)
                     .Select(p => p.Permission.Description)
                     .Distinct()
                     .ToList()
            });
        }

        public async Task<ApiResult<string>> RegisterAsync(string firstname, string lastname, string email, string password, bool isAdminSite)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
                return ApiResult<string>.Failure(new[] { "Email allaqachon mavjud" });

            var salt = Guid.NewGuid().ToString();
            var hash = passwordHasher.Encrypt(password, salt);

            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                PasswordHasher = hash,
                PasswordSalt = salt,
                //CreatedAt = DateTime.Now,
                //IsVerified = false // Yangi foydalanuvchilar odatda tasdiqlanmagan holda boshlanadi
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            // --- Rolni isAdminSite ga qarab belgilash ---
            string roleName = isAdminSite ? "Admin" : "User";
            var defaultRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

            if (defaultRole == null)
            {
                // Agar kerakli rol topilmasa, xato qaytaramiz
                return ApiResult<string>.Failure(new[] { $"Tizimda '{roleName}' roli topilmadi. Admin bilan bog'laning." });
            }

            context.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = defaultRole.Id
            });
            await context.SaveChangesAsync();
            //// --- Rolni belgilash qismi tugadi ---

            //var otp = await _otpService.GenerateAndSaveOtpAsync(user.Id);
            //await _emailService.SendOtpAsync(email, otp);

            return ApiResult<string>.Success("Ro'yxatdan o'tdingiz. Email orqali tasdiqlang.");
        }
    }
}
