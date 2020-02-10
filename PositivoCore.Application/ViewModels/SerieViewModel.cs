using System;

namespace PositivoCore.Application.ViewModels
{
    public class SerieViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdNivelEnsino { get; set; }
    }
}
