using LabaWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class OrderController : Controller
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAll();
        return View(orders);
    }
}