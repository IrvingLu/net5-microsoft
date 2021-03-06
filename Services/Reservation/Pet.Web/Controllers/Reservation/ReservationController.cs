﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pet.Reservation.Web.Application.Commands.Command;
using Shared.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Shared.Infrastructure.Core.Extensions;
using Shared.Infrastructure.Core.Tools;
using System.Text;

namespace Pet.Reservation.Web.Controllers.Reservation
{
    /// <summary>
    /// 预约接口
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : BaseController
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync([FromBody] CreateReservationCommand command)
        {
            command.UserId= Guid.Parse(User.GetUserId());
            var aa = RSA2Helper.Encrypt("123456", Encoding.Default, RSAConfig.PublicKey, RSAConfig.PrivateKey);
            //var bb = RSA2Helper.Encrypt("wechat", Encoding.Default, RSAConfig.PublicKey, RSAConfig.PrivateKey);
            await _mediator.Send(command);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

    }
}
