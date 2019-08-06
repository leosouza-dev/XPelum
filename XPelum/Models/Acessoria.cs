using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.ViewModel;

namespace XPelum.Models
{
    public class Acessoria
    {
        public Acessoria()
        {

        }

        public Acessoria(CreateAcessoriaViewModel acessoriaVM, string uniqueFileName)
        {
            Nome = acessoriaVM.Nome;
            Imagem = uniqueFileName;
            Investimento = acessoriaVM.investimento;
            Descricao = acessoriaVM.Descricao;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Imagem { get; private set; }
        public string Investimento { get; private set; }
        public string Descricao { get; private set; }

    }
}
