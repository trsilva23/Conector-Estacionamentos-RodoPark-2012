using System;
using System.Web.Http;
using ParkConnect.Models;
using System.Net;
using System.Net.Http;

namespace ParkConnect.Api.Controllers
{
    public class IntegracaoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Sincronizar([FromBody] Condomino dados)
        {
            try 
            {
                if (dados == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

                bool sucesso = SalvarNoBancoEstacionamento(dados);

                if (sucesso)
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Sincronizado com sucesso" });
                
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult ValidarAcesso(string placa)
        {
            if (placa == "ABC1234") 
            {
                return Ok(new { acessoAutorizado = true, motivo = "Condômino Regularizado" });
            }
            return Ok(new { acessoAutorizado = false, motivo = "Pendência Financeira ou Não Cadastrado" });
        }

        private bool SalvarNoBancoEstacionamento(Condomino c)
        {
            return true; 
        }
    }
}
