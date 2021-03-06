﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pet.User.Web.Application.Queries.Command.Tenant;
using Pet.User.Web.Application.Tenant.Commands.Command;
using Shared.Infrastructure.Core;
using Shared.Infrastructure.Core.Extensions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pet.User.Web.Controllers
{
    /// <summary>
    /// 功能描述    ：租户接口
    /// 创 建 者    ：Administrator
    /// 创建日期    ：2020/12/25 13:17:23 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2020/12/25 13:17:23 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class TenantController:BaseController
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Post
        /// <summary>
        /// 创建服务项目
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CreateServiceAsync([FromBody] CreateServiceCategoryCommand command)
        {
            command.TenantId = Guid.Parse(User.GetTeanantId());
            await _mediator.Send(command);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }
        /// <summary>
        /// 更新租户信息
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UpdateTenantInfoAsync([FromBody] UpdateTenantInfoCommand command)
        {
            command.Id = Guid.Parse(User.GetTeanantId());
            await _mediator.Send(command);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取租户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("detail")]
        public async Task<IActionResult> GetTenantInfoAsync()
        {
            var data = await _mediator.Send(new GetTenantInfoCommand(Guid.Parse(User.GetTeanantId())));
            return Ok(new DataResult((int)HttpStatusCode.OK, "Success",data));
        }

        #endregion

    }
}
