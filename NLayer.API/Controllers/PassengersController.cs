using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Repository.Builders;
using NLayer.Service.Builders;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Passenger> _service;

        public PassengersController(IMapper mapper, IService<Passenger> passengerService)
        {
            _mapper = mapper;
            _service = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {                    
            var passengers = await _service.GetAllAsync();
            foreach (var item in passengers)
            {
                if (item.DocumentType.ToString() == "Pasaport")
                {
                    PasaportBuilder builder = new PasaportBuilder();
                    PassengerConstructor passengerConstructor = new PassengerConstructor();
                    passengerConstructor.Passenger(builder);
                    item.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
                }
                else if (item.DocumentType.ToString() == "Visa")
                {
                    VisaBuilder builder = new VisaBuilder();
                    PassengerConstructor passengerConstructor = new PassengerConstructor();
                    passengerConstructor.Passenger(builder);
                    item.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
                }
                else if(item.DocumentType.ToString() == "TravelDocument")
                {
                    TravelDocumentBuilder builder = new TravelDocumentBuilder();
                    PassengerConstructor passengerConstructor = new PassengerConstructor();
                    passengerConstructor.Passenger(builder);
                    item.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
                }               
            }

            var passengersDtos = _mapper.Map<List<PassengerDto>>(passengers.ToList());
            return CreateActionResult(CustomResponseDto<List<PassengerDto>>.Success(200, passengersDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Passenger>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {          
            var passenger = await _service.GetByIdAsync(id);          
            if (passenger.DocumentType.ToString() == "Pasaport")
            {
                PasaportBuilder builder = new PasaportBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "Visa")
            {
                VisaBuilder builder = new VisaBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "TravelDocument")
            {
                TravelDocumentBuilder builder = new TravelDocumentBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }

            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return CreateActionResult(CustomResponseDto<PassengerDto>.Success(200, passengerDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PassengerDto passengerDto)
        {            
            var passenger = await _service.AddAsync(_mapper.Map<Passenger>(passengerDto));
            if (passenger.DocumentType.ToString() == "Pasaport")
            {
                PasaportBuilder builder = new PasaportBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "Visa")
            {
                VisaBuilder builder = new VisaBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "TravelDocument")
            {
                TravelDocumentBuilder builder = new TravelDocumentBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            var passengersDto = _mapper.Map<PassengerDto>(passenger);
            return CreateActionResult(CustomResponseDto<PassengerDto>.Success(201, passengersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PassengerDto passengerDto)
        {
            var passenger = await _service.UpdateAsync(_mapper.Map<Passenger>(passengerDto));
            if (passenger.DocumentType.ToString() == "Pasaport")
            {
                PasaportBuilder builder = new PasaportBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "Visa")
            {
                VisaBuilder builder = new VisaBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            else if (passenger.DocumentType.ToString() == "TravelDocument")
            {
                TravelDocumentBuilder builder = new TravelDocumentBuilder();
                PassengerConstructor passengerConstructor = new PassengerConstructor();
                passengerConstructor.Passenger(builder);
                passenger.DocumentType = passengerConstructor._builder.Passenger.DocumentType;
            }
            var passengersDto = _mapper.Map<PassengerDto>(passenger);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var passenger = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(passenger);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
