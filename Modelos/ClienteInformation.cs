using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Modelos
{
    public class ClienteInformation
    {

        #region VARIABLES
            private int _codigo;
            private string _nome;
            private string _email;
            private string _telefone;
        #endregion

        #region DECLARATIONS
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        #endregion

    }
}
