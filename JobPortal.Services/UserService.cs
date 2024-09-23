using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserDTO> CreateUserAsync(CreateUserDTO user)
        {
            try
            {
                // Map CreateUserDTO to User entity
                var newUser = new User { EmailAddress = user.EmailAddress, Password = user.Password };

                var addedUser = await _userRepository.CreateAsync(newUser);
                // Map User entity to GetUserDTO
                var userDTO = new GetUserDTO(addedUser.Id, addedUser.EmailAddress, addedUser.Password);

                return userDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(long Id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(Id);
                return await _userRepository.DeleteAsync(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var usersDTO = users.Select(user => (new GetUserDTO(user.Id, user.EmailAddress, user.Password)));

                return usersDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetUserDTO> GetUserByIdAsync(long userId)
        {
            try
            {
                // Retrieve user from repository
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"User with ID {userId} not found.");
                }

                var userDTO = new GetUserDTO(user.Id, user.EmailAddress, user.Password);

                return userDTO; // Replace null with the mapped DTO
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersByConditionAsync(Expression<Func<GetUserDTO, bool>> expression)
        {
            // Retrieve users from repository based on the condition
            // You may need to map the expression from GetUser DTO to User entity
            // Example:
            // var userEntities = await _userRepository.GetByConditionAsync(u => expression.Compile().Invoke(new User(u.Id, u.EmailAddress, u.Password)));

            // Map User entities to GetUser DTOs if needed
            // Example:
            // var userDTOs = userEntities.Select(u => new GetUser(u.Id, u.EmailAddress, u.Password));

            // Return the list of user DTOs
            return null; // Replace null with the mapped DTOs
        }

        public async Task<GetUserDTO> UpdateUserAsync(long Id, UpdateUserDTO updateUser)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(Id);
                // Check if user exists
                if (user == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"User with ID {Id} not found.");
                }


                user.Password = updateUser.Password;
                user.EmailAddress = updateUser.EmailAddress;
                user.UpdatedDate = DateTime.Now;
               // user.UpdatedUserId = 1;

                await _userRepository.UpdateAsync(user);
                var updatedUserDto = new GetUserDTO(user.Id, user.EmailAddress, user.Password);

                return updatedUserDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
