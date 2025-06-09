namespace Teste_Tecnico.Aplication.Communs
{
    public class Utilitarios
    {
        private static int saltGenerate = 10;

        public static string HashSenhaUsuario(string senha)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(saltGenerate);

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha, salt);

            return senhaHash;
        }
    }
}
