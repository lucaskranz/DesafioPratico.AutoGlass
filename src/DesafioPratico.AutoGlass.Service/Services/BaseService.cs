using DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes;
using DesafioPratico.AutoGlass.Domain.Notificacoes;

namespace DesafioPratico.AutoGlass.Service.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
