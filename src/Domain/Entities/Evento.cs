using Domain.Enums;

namespace Domain.Entities;

public class Evento
{
    private Evento() { }

    public Evento(TipoEvento tipo, DateTime dataHora, Guid dispositivoId)
    {
        Id = Guid.NewGuid();
        Tipo = tipo;
        DataHora = dataHora;
        DispositivoId = dispositivoId;
    }

    public Guid Id { get; private set; }
    public TipoEvento Tipo { get; private set; }
    public DateTime DataHora { get; private set; }
    
    public Guid DispositivoId { get; private set; }
    public Dispositivo Dispositivo { get; private set; }
}