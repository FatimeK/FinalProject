using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {

        //JWT için - burası managerdeki aspectimle bağlantılı
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //jwt isteği yapıyoz ya , işte her yapılan istek için bi http contexti oluşur.işte bu
        //ıhttpcontext bi interface ve.net ile çözcez

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//metni senin belirttiğin karaktere göre arrayleyip kullanabiliyo
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
