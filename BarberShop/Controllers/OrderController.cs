using BarberShop.DTO;
using BarberShop.Entity;
using BarberShop.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var order = _unitOfWork.OrderRepository.GetAll<OrderDto>();
            return Ok(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _unitOfWork.OrderRepository.GetById<OrderDto>(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDto orderModel)
        {
            if (orderModel == null)
                return BadRequest();

            var orderEntity = _unitOfWork.Mapper.Map<Order>(orderModel);
            _unitOfWork.OrderRepository.Add(orderEntity);
            _unitOfWork.Commit();

            var orderDto = _unitOfWork.Mapper.Map<OrderDto>(orderEntity);

            return CreatedAtAction(nameof(GetOrder), new { id = orderDto.orderID }, orderDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, OrderDto updatedOrderModel)
        {
            var existingOrderEntity = _unitOfWork.OrderRepository.GetById<OrderDto>(id);

            if (existingOrderEntity == null)
                return NotFound();

            _unitOfWork.OrderRepository.UpdateProperties(id, entity =>
            {
                entity.orderDate = updatedOrderModel.orderDate;
                entity.orderStatus = updatedOrderModel.orderStatus;
                entity.customerID = updatedOrderModel.customerID;
                entity.Payment.payID = updatedOrderModel.payID;

            });

            _unitOfWork.Commit();

            return Ok(new { message = "Cập nhật thành công" });
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var orderEntity = _unitOfWork.OrderRepository.GetById<OrderDto>(id);

            if (orderEntity == null)
                return NotFound();

            _unitOfWork.OrderRepository.Delete(id);
            _unitOfWork.Commit();

            return Ok(new { message = "Xóa thành công" });
        }


        [HttpGet("search")]
        public IActionResult SearchOrders([FromQuery] string orderkey)
        {
            var orderes = _unitOfWork.OrderRepository.Search<OrderDto>(order =>
                            order.orderDate.ToString().Contains(orderkey));
            return Ok(orderes);
        }
    }
}
