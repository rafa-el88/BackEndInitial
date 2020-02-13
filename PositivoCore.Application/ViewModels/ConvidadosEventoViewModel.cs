using System;
using PositivoCore.Domain.Enums;

namespace PositivoCore.Application.ViewModels
{
    public class ConvidadosEventoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoPerfil TipoPerfil { get; set; }
        public Guid IdConvidado { get; set; }
    }
}