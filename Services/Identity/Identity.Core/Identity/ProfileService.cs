﻿using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Identity.Core.Identity
{
    /// <summary>
    /// 功能描述    ：提供和存储有关用户生成的用户的配置文件信息的服务
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2020/12/25 13:48:53 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2020/12/25 13:48:53 
    /// </summary>
    public class ProfileService : IProfileService
    {
        /// <summary>
        ///  只要有关用户的身份信息单元被请求（例如在令牌创建期间或通过用户信息终点），就会调用此方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                var claims = context.Subject.Claims.ToList();

                //set issued claims to return
                context.IssuedClaims = claims.ToList();
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
