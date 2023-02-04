using DesafioPratico.AutoGlass.Service.Notificacoes;

namespace DesafioPratico.AutoGlass.Service.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
