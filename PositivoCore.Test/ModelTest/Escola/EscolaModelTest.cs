using System;

namespace PositivoCore.Test.ModelTest.Escola
{
    public class EscolaModelTest
    {
        public string sucesso { get; set; }
        public string mensagem { get; set; }

        public Dados dados { get; set; }

    }

    public class Dados
    {
        public string id { get; set; }

        public string nome { get; set; }

        public string cnpj { get; set; }

        public bool status { get; set; }

        public DateTime create { get; set; }
    }
}