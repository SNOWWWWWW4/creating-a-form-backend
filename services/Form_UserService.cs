using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using creating_a_form_backend.Models;
using creating_a_form_backend.Models.DTO;
using creating_a_form_backend.Services.Context;

namespace creating_a_form_backend.Services
{
    public class Form_UserService : ControllerBase
    {
        private readonly DataContext _context;

        public Form_UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Email_Username)
        {
            return _context.Form_UserInfo.SingleOrDefault(user => user.Email_Username == Email_Username) != null;
        }

        public bool AddUser(Form_CreateAccountDTO UserToAdd)
        {
            bool result = false;

            if (!DoesUserExist(UserToAdd.Email_Username))
            {
                Form_UserModels newUser = new Form_UserModels();

                var hashPassword = HashPassword(UserToAdd.Password);

                newUser.ID = UserToAdd.ID;
                newUser.Email_Username = UserToAdd.Email_Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Form_UserInfo.Add(newUser);

                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public Form_PasswordDTO HashPassword(string password)
        {
            Form_PasswordDTO newHashPassword = new Form_PasswordDTO();

            byte[] SaltByte = new byte[64];

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltByte);

            string salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashPassword.Salt = salt;
            newHashPassword.Hash = hash;

            return newHashPassword;
        }

        public bool VerifyUsersPassword(string? password, string? storedHash, string? storedSalt)
        {
            byte[] SaltBytes = Convert.FromBase64String(storedSalt);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);

            string newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }

        public IActionResult Login(Form_LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if (DoesUserExist(User.Email_Username))
            {
                Form_UserModels foundUser = GetUserByUsername(User.Email_Username);

                if (VerifyUsersPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30), 
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public Form_UserModels GetUserByUsername(string username)
        {
            return _context.Form_UserInfo.SingleOrDefault(user => user.Email_Username == username);
        }

        public bool UpdateUserPassword(string username, string newPassword)
        {
            Form_UserModels foundUser = _context.Form_UserInfo.SingleOrDefault(user => user.Email_Username == username); ;

            var hashPassword = HashPassword(newPassword);

            foundUser.Salt = hashPassword.Salt;
            foundUser.Hash = hashPassword.Hash;

            _context.Update<Form_UserModels>(foundUser);
            return _context.SaveChanges() != 0;
        }
    }
}