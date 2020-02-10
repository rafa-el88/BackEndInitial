using System;

namespace PositivoCore.Application.ViewModels
{
    public class TurmaViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdEscola { get; set; }
        public Guid IdSerie { get; set; }
    }
}
