using Intelliponics.Data.Request;
using Intelliponics.Models.Entities;
using Intelliponics.Services.Interfaces;
using Intelliponics.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Intelliponics.Controllers
{
    [Route("v1/admin")]
    public class AdminController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IPaymentService _paymentService;
        private readonly IShippingService _shippingService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ILoadSheddingService _loadSheddingService;
        public AdminController(ICustomerService customerService, IPaymentService paymentService, IShippingService shippingService,
            IOrderService orderService, IProductService productService, ILoadSheddingService loadSheddingService)
        {
            _customerService = customerService;
            _paymentService = paymentService;
            _shippingService = shippingService;
            _orderService = orderService;
            _productService = productService;
            _loadSheddingService = loadSheddingService;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<ActionResult> GetPersonnels()
        {
            try
            {
                var users = await _customerService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("getUsers/{id}")]
        public async Task<ActionResult> GetPersonnel(int id)
        {
            try
            {
                var user = await _customerService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> CreatePersonnel([FromBody] Customer customer)
        {

            await _customerService.CreateAsync(customer);
            return View();
        }

        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<ActionResult> UpdatePersonnel(int id, [FromBody] Customer customer)
        {
            try
            {
                await _customerService.UpdateAsync(id, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<ActionResult> RemovePersonnel(int id)
        {
            try
            {
                await _customerService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("getOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("getOrders/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [HttpPost]
        [Route("makeOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            
            /// This is a temporary solution to get the customer, payment and shipping details
            var customer = await _customerService.GetCustomerByEmail("johndoe@example.com");
            var payment = await _paymentService.GetPaymentByCustomerIDAsync(customer.CustomerID);
            var shipping = await _shippingService.GetByIdAsync(customer.CustomerID);
            ///The real solution create a repository for in either order or customer repo. Then gets the customer, payment and shipping details all in one query.
            ///

            order.Customer = customer;
            order.Payment = payment;
            order.ShippingDetails = shipping;

            await _orderService.CreateAsync(order);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("updateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            await _orderService.UpdateAsync(id, order);
            return View();
        }

        [HttpGet]
        [Route("getPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var users = await _paymentService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("getPayments/{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var user = await _paymentService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("makePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            await _paymentService.CreateAsync(payment);
            return Ok();
        }

        [HttpDelete]
        [Route("deletePayments/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("updatePayment/{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
        {
            await _paymentService.UpdateAsync(id, payment);
            return View();
        }

        [HttpGet]
        [Route("getShipments")]
        public async Task<IActionResult> GetAllShipments()
        {
            var shipment = await _shippingService.GetAllAsync();
            return Ok(shipment);
        }

        [HttpGet]
        [Route("getShipments/{id}")]
        public async Task<IActionResult> GetShipment(int id)
        {
            var shipment = await _shippingService.GetByIdAsync(id);
            return Ok(shipment);
        }

        [HttpPost]
        [Route("makeShipment")]
        public async Task<IActionResult> CreateShipment([FromBody] ShippingDetail shipping)
        {
            await _shippingService.CreateAsync(shipping);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteShipment/{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            await _shippingService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("updateShipment/{id}")]
        public async Task<IActionResult> UpdateShipment(int id, [FromBody] ShippingDetail shipping)
        {
            await _shippingService.UpdateAsync(id, shipping);
            return View();
        }


        [HttpPost]
        [Route("handleInventory")]
        public async Task<JsonResult> InventoryAction([FromBody] InventoryActionRequest request)
        {
            try
            {
                switch (request.Action)
                {
                    case "view":
                        var products = await _productService.GetAllAsync();
                        var productViewModels = products.Select(ProductMapper.ToViewModel).ToList();
                        var paginatedProducts = productViewModels
                            .Skip((request.Page - 1) * request.ItemsPerPage)
                            .Take(request.ItemsPerPage)
                            .ToList();
                    return Json(new { totalItems = productViewModels.Count, products = paginatedProducts });
                    //  return Json(new { totalItems = 5, products = new List<Product>() });
                    case "update":
                        await _productService.UpdateAsync(request.Product.ProductID, request.Product);
                        return Json(true);

                    case "delete":
                        await _productService.DeleteAsync(request.Product.ProductID);
                        return Json(true);

                    case "create":
                        await _productService.CreateAsync(request.Product);
                        return Json(true);

                    default:
                        return Json("Invalid action");
                }
            }
            catch (Exception ex)
            {
                return Json(500, "Internal server error");
            }
        }


        [HttpPost]
        [Route("handleHydroponics")]
        public async Task<JsonResult> HydroponicsAction([FromBody] InventoryActionRequest request)
        {
            try
            {
                switch (request.Action)
                {
                    case "view":
                        var response = await _loadSheddingService.GetApiAllowanceAsync();
                        return Json(new { totalItems = 5, products = new List<string>() });
                    case "update":

                    case "delete":

                    case "create":

                    default:
                        return Json("Invalid action");
                }
            }
            catch (Exception ex)
            {
                return Json(500, "Internal server error");
            }
        }

        // public IActionResult Inventory()
        // {
        //     return View();
        // }
        public IActionResult Hydroponics()
        {
           return View();
        }

        //public IActionResult Analytics()
        //{
        //    return View();
        //}
    }
}
