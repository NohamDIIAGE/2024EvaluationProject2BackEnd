using _2024Evaluation.Models;
using _2024Evaluation.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using _2024Evaluation.Services.Contracts.DTO.Up;



namespace _2024Evaluation.Azure
{
    public class EventFunctions
    {
        private readonly ILogger<EventFunctions> _logger;
        private readonly IEventService _eventService;

        public EventFunctions(ILogger<EventFunctions> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        
        [Function("GetAllEvents")]
        public async Task<HttpResponseData> GetAllEvents(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Events")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request to get all events.");
            string errorMessage = "Error getting all events:";

            var response = req.CreateResponse();

            try
            {
                var events = await this._eventService.GetAllEvents();
                await response.WriteAsJsonAsync(events);
            }
            catch (Exception ex)
            {
                _logger.LogError("{errorMessage} {ex.Message}", errorMessage, ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.WriteString($"{errorMessage} {ex.Message}");
            }

            return response;
        }

        [Function("DeleteEvents")]
        public async Task<HttpResponseData> DeleteProfile([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Events/{id}")] HttpRequestData req, int id)
        {
            this._logger.LogInformation("Starting of DeleteEvent method");
            string errorMessage = "Error deleting event :";

            var response = req.CreateResponse(HttpStatusCode.NoContent);

            try
            {
                await this._eventService.DeleteEvent(id);
            }

            catch (Exception ex)
            {
                this._logger.LogError("{errorMessage} {ex.Message}", errorMessage, ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.WriteString($"{errorMessage} {ex.Message}");
            }

            return response;
        }

        [Function("GetEventById")]
        public async Task<HttpResponseData> GetEventById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Events/{id}")] HttpRequestData req, int id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request for event with id: {id}.", id);
            string errorMessage = "Error retriving event by id:";

            var response = req.CreateResponse();
            try
            {
                var myEvent = await this._eventService.GetEventById(id);

                if (myEvent == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    await response.WriteAsJsonAsync(myEvent);
                }
            }

            catch (Exception ex)
            {
                this._logger.LogError("{errorMessage} {ex.Message}", errorMessage, ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.WriteString($"{errorMessage} {ex.Message}");
            }

            return response;
        }


        [Function("CreateEvent")]
        public async Task<HttpResponseData> CreateEvents([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Events")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            string errorMessage = "Error saving event:";

            string requestBody;
            using (var reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            try
            {
                var myEvent = JsonSerializer.Deserialize<EventUpDetailedDTO>(requestBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var savedProfile = await this._eventService.SaveProfile(myEvent!);
                await response.WriteAsJsonAsync(savedProfile);
                response.StatusCode = HttpStatusCode.Created;
            }

            catch (JsonException ex)
            {
                this._logger.LogError("{errorMessage} {ex.Message}", errorMessage, ex.Message);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                response.Body = new MemoryStream(Encoding.UTF8.GetBytes($"Bad input in argument {errorMessage} {ex.Message}"));
            }

            catch (Exception ex)
            {
                this._logger.LogError("{errorMessage} {ex.Message}", errorMessage, ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                response.Body = new MemoryStream(Encoding.UTF8.GetBytes($"{errorMessage} {ex.Message}"));
            }

            return response;
        }
    }
}
