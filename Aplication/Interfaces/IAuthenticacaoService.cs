namespace Teste_Tecnico.Aplication.Interfaces
{
    public interface IAuthenticacaoService
    {
        string Authenticacao(string email, string senha, string hash);
    }
}
