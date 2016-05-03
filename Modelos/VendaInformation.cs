using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Modelos
{
    public class VendaInformation
    {

        #region VARIABLES
        private int _codigo;
        private DateTime _data;
        private int _quantidade;
        private bool _faturado;
        private int _codigoCliente;
        private int _codigoProduto;
        private string _nomeCliente;

        #endregion

        #region DECLARATIONS

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public bool Faturado
        {
            get { return _faturado; }
            set { _faturado = value; }
        }
        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        public int CodigoProduto
        {
            get { return _codigoProduto; }
            set { _codigoProduto = value; }
        }
        public string NomeCliente
        {
            get { return _nomeCliente; }
            set { _nomeCliente = value; }
        }

        #endregion

    }
}
