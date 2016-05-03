﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Modelos
{
    public class ProdutoInformation
    {

        #region VARIABLES
        private int _codigo;
        private string _nome;
        private decimal _preco;
        private int _estoque;
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
        public decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        public int Estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }


        #endregion

    }
}
