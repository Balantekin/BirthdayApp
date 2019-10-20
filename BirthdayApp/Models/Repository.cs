using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayApp.Models
{
    public static class Repository
    {
        static Repository()
        {
            AddResponse(new UserResponse() { Name = "Buğra", Email = "bb@mail.ru", Phone = "5332134567", WillAttend = true });
            AddResponse(new UserResponse() { Name = "Seko", Email = "bb@mail.hu", Phone = "5556668899", WillAttend = false });
            AddResponse(new UserResponse() { Name = "Cino", Email = "bb@mail.de", Phone = "3339997755", WillAttend = true });
        }
        private static List<UserResponse> responses = new List<UserResponse>();
        public static List<UserResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(UserResponse response)
        {
            response.Id = (new Random()).Next(1, 9999);

            responses.Add(response);
        }

        public static void Update(UserResponse userResponse)
        {
           var entity= Responses.Find(x => x.Id == userResponse.Id);
            if (entity != null)
            {
                entity.Name = userResponse.Name;
                entity.Email = userResponse.Email;
                entity.Phone = userResponse.Phone;
                entity.WillAttend = userResponse.WillAttend;
            }
          
        }

        public static void Delete(int id)
        {
            var entity = Repository.Responses.Find(x => x.Id == id);
            if(entity!=null)
            {
                Repository.Responses.Remove(entity);
            }
        }
    }
}