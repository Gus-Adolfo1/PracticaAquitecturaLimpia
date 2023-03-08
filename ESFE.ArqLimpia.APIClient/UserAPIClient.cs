using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using System.Text.Json;
using ESFE.ArqLimpia.BL.DTOs.UserDTOs;
using ESFE.ArqLimpia.BL.Interfaces;

namespace ESFE.ArqLimpia.APIClient
{
    public class UserAPIClient : IUserBL
    {
        readonly HttpClient httpClient;
        public UserAPIClient(HttpClient pHttpClient)
        {
            httpClient = pHttpClient;
        }
        public async Task<CreateUserOutputDTO> Create(CreateUserInputDTO pUser)
        {
            CreateUserOutputDTO userResult = new CreateUserOutputDTO();
            var response = await httpClient.PostAsJsonAsync("user/create", pUser);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<CreateUserOutputDTO>(responseBody,
                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (user != null)
                    userResult = user;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(message: "Unauthorized:" + System.Net.HttpStatusCode.Unauthorized.ToString());
            return userResult;
        }

        public async Task<int> Delete(DeleteUserDTO pUser)
        {
            var response = await httpClient.PostAsJsonAsync("user/delete", pUser);
            if (response.IsSuccessStatusCode)
                return 1;
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(message: "Unauthorized:" + System.Net.HttpStatusCode.Unauthorized.ToString());
            return 0;
        }

        public async Task<GetByIdUserOutputDTO> GetById(GetByIdUserInputDTO pUser)
        {
            GetByIdUserOutputDTO userResult = new GetByIdUserOutputDTO();
            var response = await httpClient.PostAsJsonAsync("user/getbyid", pUser);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<GetByIdUserOutputDTO>(responseBody,
                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (user != null)
                    userResult = user;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(message: "Unauthorized:" + System.Net.HttpStatusCode.Unauthorized.ToString());
            return userResult;
        }

        public async Task<List<SearchUserOutputDTO>> Search(SearchUserInputDTO pUser)
        {
            List<SearchUserOutputDTO> usersResult = new List<SearchUserOutputDTO>();
            var response = await httpClient.PostAsJsonAsync("user/search", pUser);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<SearchUserOutputDTO>>(responseBody,
                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (users != null)
                    usersResult = users;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(message: "Unauthorized:" + System.Net.HttpStatusCode.Unauthorized.ToString());
            return usersResult;
        }

        public async Task<int> Update(UpdateUserDTO pUser)
        {
            var response = await httpClient.PostAsJsonAsync("user/edit", pUser);
            if (response.IsSuccessStatusCode)
                return 1;
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(message: "Unauthorized:" + System.Net.HttpStatusCode.Unauthorized.ToString());
            return 0;
        }
    }
}
