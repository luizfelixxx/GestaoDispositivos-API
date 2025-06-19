namespace Domain.Entities;

public class Dispositivo
{
    private Dispositivo() { }

    public Dispositivo(string serial, string imei, Guid clienteId)
    {
        if (string.IsNullOrWhiteSpace(serial))
            throw new ArgumentException("Serial é obrigatório.", nameof(serial));
        
        if (string.IsNullOrWhiteSpace(imei))
            throw new ArgumentException("IMEI é obrigatório.", nameof(imei));
        
        Id = Guid.NewGuid();
        Serial = serial;
        IMEI = imei;
        ClienteId = clienteId;
    }

    public Guid Id { get; private set; }
    public string Serial { get; private set; }
    public string IMEI { get; private set; }
    public DateTime? DataAtivacao { get; private set; }
    
    public Guid ClienteId { get; private set; }
    public Cliente Cliente { get; private set; }

    public void Ativar()
    {
        if (DataAtivacao.HasValue)
            throw new InvalidOperationException("Dispositivo já foi ativado.");
        
        DataAtivacao = DateTime.UtcNow;
    }
}