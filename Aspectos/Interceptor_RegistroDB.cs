using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;//NuGet:Microsoft.AspNetCore.Http
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BibTaller.Aspectos
{
    public class Interceptor_RegistroDB : IInterceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        // Constructor
        public Interceptor_RegistroDB(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public void Intercept(IInvocation invocation)
        {
            var httpContext = _contextAccessor.HttpContext;
            string operacion = invocation.Method.Name;
            string ubiOperacion = invocation.TargetType.Name;

            ubiOperacion = invocation.TargetType.Name == "OrdenRecorder" ? "Base De Datos Reparacion" : "Base De Datos Usuarios";

            try
            {
                // Guerdamos el contexto en HttpContext.Items
                if (httpContext != null)
                {
                    httpContext.Items["Tipo_Registro"] = operacion;
                    httpContext.Items["Ubicacion_Registro"] = ubiOperacion;
                }

                // Ejecutar el método original
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                // Capturar el error del envío
                if (httpContext != null)
                {
                    httpContext.Items["MensajeEnviado"] = ex.Message;
                    httpContext.Items["MensajeTipo"] = "info";
                }

                throw;
            }
        }

    }
}


