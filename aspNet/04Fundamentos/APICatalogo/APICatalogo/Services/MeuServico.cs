namespace APICatalogo.Services;

public class MeuServico : IMeuServico //implementa o meu serviço
{
    public string Saudacao(string nome)
    {
        return $"Bem-vindo, {nome} \n\n{DateTime.Now}";
    }
}
