using DesafioPratico.AutoGlass.Domain.Notificacoes;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
