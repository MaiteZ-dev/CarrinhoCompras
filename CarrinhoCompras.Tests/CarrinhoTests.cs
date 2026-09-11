using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarrinhoCompras.Tests
{
	[TestClass]
	public class CarrinhoTests
	{
		[TestMethod]
		public void AdicionarProdutoValido_DeveAdicionarProduto()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();
			Produto mouse = new Produto("Mouse", 50, 1);

			// Act 
			carrinho.AdicionarProduto(mouse);

			// Assert 
			Assert.AreEqual(50, carrinho.CalcularTotal());
		}

		[TestMethod]
		public void AdicionarProdutoComQuantidadeMaiorQueUm_DeveCalcularCorretamente()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();
			Produto mouse = new Produto("Mouse", 50, 2);

			// Act 
			carrinho.AdicionarProduto(mouse);

			// Assert 
			Assert.AreEqual(100, carrinho.CalcularTotal());
		}

		[TestMethod]
		public void AdicionarMaisDeUmProduto_DeveCalcularTotalCorretamente()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();

			Produto mouse = new Produto("Mouse", 50, 2);
			Produto teclado = new Produto("Teclado", 100, 1);

			// Act 
			carrinho.AdicionarProduto(mouse);
			carrinho.AdicionarProduto(teclado);

			// Assert 
			Assert.AreEqual(200, carrinho.CalcularTotal());
		}

		[TestMethod]
		public void ProdutoComPrecoNegativo_DeveGerarExcecao()
		{
			Assert.ThrowsException<ArgumentException>(() =>
			{
				Produto produto = new Produto("Teclado", -10, 1);
			});
		}

		[TestMethod]
		public void ProdutoComQuantidadeZero_DeveGerarExcecao()
		{
			Assert.ThrowsException<ArgumentException>(() =>
			{
				Produto produto = new Produto("Monitor", 800, 0);
			});
		}

		[TestMethod]
		public void RemoverProdutoExistente_DeveRetirarDoCarrinho()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();
			Produto mouse = new Produto("Mouse", 50, 2);

			carrinho.AdicionarProduto(mouse);

			// Act 
			carrinho.RemoverProduto("Mouse");

			// Assert 
			Assert.AreEqual(0, carrinho.CalcularTotal());
		}

		[TestMethod]
		public void RemoverProdutoInexistente_DeveGerarExcecao()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();

			Assert.ThrowsException<ArgumentException>(() =>
			{
				carrinho.RemoverProduto("Notebook");
			});
		}

		[TestMethod]
		public void CarrinhoVazio_DeveRetornarZero()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();

			// Act 
			decimal total = carrinho.CalcularTotal();

			// Assert 
			Assert.AreEqual(0, total);
		}

		[TestMethod]
		public void ProdutoComPrecoZero_DeveSerAceito()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();
			Produto produto = new Produto("Brinde", 0, 1);

			// Act 
			carrinho.AdicionarProduto(produto);

			// Assert 
			Assert.AreEqual(0, carrinho.CalcularTotal());
		}

		[TestMethod]
		public void RemoverUmProdutoDepoisDeAdicionarVarios_DeveManterTotalDosOutros()
		{
			// Arrange 
			Carrinho carrinho = new Carrinho();

			Produto mouse = new Produto("Mouse", 50, 2);
			Produto teclado = new Produto("Teclado", 100, 1);

			carrinho.AdicionarProduto(mouse);
			carrinho.AdicionarProduto(teclado);

			// Act 
			carrinho.RemoverProduto("Mouse");

			// Assert 
			Assert.AreEqual(100, carrinho.CalcularTotal());
		}
	}
}