using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras
{
	public class Carrinho
	{
		private List<Produto> produtos = new List<Produto>();

		public void AdicionarProduto(Produto produto)
		{
			produtos.Add(produto);
		}

		public void RemoverProduto(string nome)
		{
			Produto produto = produtos.FirstOrDefault(p => p.Nome == nome);

			if (produto == null)
			{
				throw new ArgumentException("Produto não encontrado no carrinho.");
			}

			produtos.Remove(produto);
		}

		public decimal CalcularTotal()
		{
			decimal total = 0;

			foreach (Produto produto in produtos)
			{
				total += produto.Preco * produto.Quantidade;
			}

			return total;
		}
	}
}