using System;

namespace PositivoCore.Application.ViewModels
{
    public class NivelEnsinoViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}
