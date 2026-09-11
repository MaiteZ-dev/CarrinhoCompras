using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras
{
	public class Produto
	{
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public int Quantidade { get; set; }

		public Produto(string nome, decimal preco, int quantidade)
		{
			if (string.IsNullOrWhiteSpace(nome))
			{
				throw new ArgumentException("O nome do produto não pode ser vazio.");
			}

			if (preco < 0)
			{
				throw new ArgumentException("O preço não pode ser negativo.");
			}

			if (quantidade <= 0)
			{
				throw new ArgumentException("A quantidade deve ser maior que zero.");
			}

			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
		}
	}
}