namespace DefaultNamespace;

namespace Domain.Entities;

public class Cliente
{
    private readonly List<Dispositivo> _dispositivos = new();
    
    private Cliente() { }

    public Cliente(string nome, string email, string? telefone)
    {
        // Validações de domínio garantem a consistência do objeto
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do cliente é obrigatório.", nameof(nome));
        
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email do cliente é obrigatório.", nameof(email));

        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Status = true; // Um novo cliente sempre começa como ativo
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string? Telefone { get; private set; }
    public bool Status { get; private set; }
    
    public IReadOnlyCollection<Dispositivo> Dispositivos => _dispositivos.AsReadOnly();
    
    public void Desativar()
    {
        if (!Status)
            throw new InvalidOperationException("Cliente já está inativo.");

        Status = false;
    }

    public void Ativar()
    {
        if (Status)
            throw new InvalidOperationException("Cliente já está ativo.");

        Status = true;
    }

    public void AtualizarDados(string nome, string? telefone)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.", nameof(nome));
        
        Nome = nome;
        Telefone = telefone;
    }
}