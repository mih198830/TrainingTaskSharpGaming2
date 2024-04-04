﻿using TestProject.Models;
using RestSharp;
using System.Text.Json;

namespace TestProject.Utils
{
    internal class PetStoreApiUtils
    {
        private static readonly string PetEndpoint = "pet/";

        public static Pet GetPetById(long id)
        {
            return DeserializePetResponse(
                ApiUtils.SendGetRequest(PetEndpoint + id));
        }

        public static RestResponse PostPet(Pet pet)
        {
            return ApiUtils.SendPostRequest(PetEndpoint, pet);
        }

        public static RestResponse PutPet(Pet pet)
        {
            return ApiUtils.SendPostRequest(PetEndpoint, pet);
        }

        public static RestResponse DeletePetById(string id)
        {
            return ApiUtils.SendDeleteRequest(PetEndpoint + id);
            //added delete request for PetStore
        }

        private static Pet DeserializePetResponse(RestResponse petResponse)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
           return JsonSerializer.Deserialize<Pet>(petResponse.Content!, options)!;
        }
    }
}
