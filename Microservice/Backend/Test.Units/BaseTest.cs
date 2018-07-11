using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Units.Stubs;

namespace Test.Units
{
    [TestClass]
    public class BaseTest
    {
        /// <summary>
        /// Método responsável por criar um banco em memória para ser utilizado nos testes.
        /// </summary>
        /// <returns>Instância do banco em memória</returns>
        public ContextStub InicializarBancoEmMemoria(string nomeBanco)
        {
            return new ContextStub(DbConnectionFactory.CreatePersistent(nomeBanco));
        }
    }
}
