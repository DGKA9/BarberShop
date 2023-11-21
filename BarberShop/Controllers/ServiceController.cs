using BarberShop.DTO;
using BarberShop.Entity;
using BarberShop.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ServiceController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetService()
        {
            var service = _unitOfWork.ServiceRepository.GetAll<ServiceDto>();
            return Ok(service);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _unitOfWork.ServiceRepository.GetById<ServiceDto>(id);

            if (service == null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(ServiceDto serviceModel)
        {
            if (serviceModel == null)
                return BadRequest();

            var serviceEntity = _unitOfWork.Mapper.Map<Service>(serviceModel);
            _unitOfWork.ServiceRepository.Add(serviceEntity);
            _unitOfWork.Commit();

            var serviceDto = _unitOfWork.Mapper.Map<ServiceDto>(serviceEntity);

            return CreatedAtAction(nameof(GetService), new { id = serviceDto.serID }, serviceDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, ServiceDto updatedServiceModel)
        {
            var existingServiceEntity = _unitOfWork.ServiceRepository.GetById<ServiceDto>(id);

            if (existingServiceEntity == null)
                return NotFound();

            _unitOfWork.ServiceRepository.UpdateProperties(id, entity =>
            {
                entity.serName = updatedServiceModel.serName;
                entity.serDescription = updatedServiceModel.serDescription;
                entity.serPrice = updatedServiceModel.serPrice;
                entity.ServiceCategory.serCateID = updatedServiceModel.serCateID;

            });

            _unitOfWork.Commit();

            return Ok(new { message = "Cập nhật thành công" });
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var serviceEntity = _unitOfWork.ServiceRepository.GetById<ServiceDto>(id);

            if (serviceEntity == null)
                return NotFound();

            _unitOfWork.ServiceRepository.Delete(id);
            _unitOfWork.Commit();

            return Ok(new { message = "Xóa thành công" });
        }


        [HttpGet("search")]
        public IActionResult SearchServices([FromQuery] string servicekey)
        {
            var servicees = _unitOfWork.ServiceRepository.Search<ServiceDto>(service =>
                            service.serName != null &&
                            service.serName.Contains(servicekey));
            return Ok(servicees);
        }
    }
}
