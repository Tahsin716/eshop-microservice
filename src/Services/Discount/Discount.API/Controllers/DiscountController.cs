using Discount.API.Entities;
using Discount.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productName}", Name = "GetCoupon")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetCoupon(string productName)
        {
            var coupon = await _repository.GetCoupon(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateCoupon([FromBody] Coupon coupon)
        {
            await _repository.CreateCoupon(coupon);
            return CreatedAtRoute("GetCoupon", new { productName = coupon.productname }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateCoupon([FromBody] Coupon coupon)
        {
            await _repository.UpdateCoupon(coupon);
            return Ok();
        }

        [HttpDelete("{productName}", Name = "DeleteCoupon")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteCoupon(string productName)
        {
            await _repository.DeleteCoupon(productName);
            return Ok();
        }
    }
}
