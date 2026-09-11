using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Carrinho carrinho = new Carrinho();

			Produto mouse = new Produto("Mouse", 50, 2);

			carrinho.AdicionarProduto(mouse);

			Console.WriteLine("Total do carrinho: R$ " + carrinho.CalcularTotal());

			Console.ReadLine();
		}
	}
}