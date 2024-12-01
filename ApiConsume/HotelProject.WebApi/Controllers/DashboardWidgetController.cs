﻿using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;

        public DashboardWidgetController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount() {
            var value = _staffService.TGetStaffCount();
            return Ok(value);

        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount(); 
            return Ok(value);

        }
    }
}