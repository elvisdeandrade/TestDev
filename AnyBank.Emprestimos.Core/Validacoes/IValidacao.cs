using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public interface IValidacao
    {
        bool Validar(Emprestimo e);

        string Mensagem { get;  }
    }
}
