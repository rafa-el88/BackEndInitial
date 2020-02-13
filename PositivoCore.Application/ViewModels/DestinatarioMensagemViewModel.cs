using PositivoCore.Domain.Enums;
using System;

namespace PositivoCore.Application.ViewModels
{
    public class DestinatarioMensagemViewModel
    {
        public Guid Id { get; set; }
        public ETipoPerfil TipoPerfil { get; set; }
        public Guid IdDestinatario { get; set; }
        public Guid IdMensagem { get; set; }
    }
}
