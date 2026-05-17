using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repository;
using ConsoleApp2.Services;

namespace ConsoleApp2.ConsoleHelper
{
    public class AutomovelConsole : ICrud<Automovel>
    {
        private readonly AutomovelService _service;

        public AutomovelConsole(AutomovelService service)
        {
            _service = service;
        }

        public void Inserir()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite a Marca = ");
            automovel.Marca = LerValorString();
            Console.Write("Digite o Modelo = ");
            automovel.Modelo = LerValorString();
            Console.Write("Digite o PowerTrain = ");
            automovel.Powertrain = LerValorString();
            Console.Write("Digite a Versão = ");
            automovel.Versao = LerValorString();
            Console.Write("Digite a Cor = ");
            automovel.Cor = LerValorString();
            Console.Write("Digite o Ano = ");
            automovel.Ano = LerAno();
            int ano = automovel.Ano;
            Console.Write("Digite o Ano Modelo = ");
            automovel.AnoModelo = LerAnoModelo(ano);
            Console.Write("Digite a quilometragem desse automóvel = ");
            automovel.Quilometragem = LerValorInt();
            Console.Write("Digite o preço desse automóvel = ");
            automovel.Preco = LerPreco();
            Console.Write("Digite se esse automóvel é blindado (Sim ou Não) = ");
            automovel.Blindado = LerBlindado();  
            Console.Write("Digite quantos donos esse automóvel já teve = ");
            automovel.QuantidadeDonos = LerValorInt();

            _service.Inserir(automovel);

            Console.WriteLine("Veículo cadastrado com sucesso!, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Listar()
        {
            List<Automovel> automoveis = _service.Listar();
            Console.WriteLine("=== LISTA DE AUTOMÓVEIS ===");

            foreach (var automovel in automoveis)
            {
                Console.WriteLine($"ID: {automovel.Id}");
                Console.WriteLine($"Marca: {automovel.Marca}");
                Console.WriteLine($"Modelo: {automovel.Modelo}");
                Console.WriteLine($"Powertrain: {automovel.Powertrain}");
                Console.WriteLine($"Versão: {automovel.Versao}");
                Console.WriteLine($"Cor: {automovel.Cor}");
                Console.WriteLine($"Ano: {automovel.Ano}");
                Console.WriteLine($"Ano Modelo: {automovel.AnoModelo}");
                Console.WriteLine($"Quilometragem: {automovel.Quilometragem}");
                Console.WriteLine($"Preço: {automovel.Preco}");
                Console.WriteLine($"Blindado: " + _service.MostrarBlindagem(automovel));
                Console.WriteLine($"Quantidade de donos: {automovel.QuantidadeDonos}");
                Console.WriteLine("---------------------------");
            }
        }
        public void Alterar()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite o Id do automóvel que você deseja alterar no banco = ");
            int Id = LerValorInt();
            automovel.Id = Id;
            Automovel automovelId = _service.ObterPorId(Id);

            Console.Write("Digite o novo valor para a Marca do automovel (se não quiser alterar pressione Enter) = ");
            string updateMarca = Console.ReadLine();
            string valorAntigoMarca = automovelId.Marca;
            automovel.Marca = _service.VerificarAlteracaoString(updateMarca, valorAntigoMarca);

            Console.Write("Digite o novo valor para o Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string updateModelo = Console.ReadLine();
            string valorAntigoModelo = automovelId.Modelo;
            automovel.Modelo = _service.VerificarAlteracaoString(updateModelo, valorAntigoModelo);

            Console.Write("Digite o novo valor para o Powertrain do automovel (se não quiser alterar pressione Enter) = ");
            string updatePowertrain = Console.ReadLine();
            string valorAntigoPowertrain = automovelId.Powertrain;
            automovel.Powertrain = _service.VerificarAlteracaoString(updatePowertrain, valorAntigoPowertrain);

            Console.Write("Digite o novo valor para a Versão do automovel (se não quiser alterar pressione Enter) = ");
            string updateVersao = Console.ReadLine();
            string valorAntigoVersao = automovelId.Versao;
            automovel.Versao = _service.VerificarAlteracaoString(updateVersao, valorAntigoVersao);

            Console.Write("Digite o novo valor para a Cor do automovel (se não quiser alterar pressione Enter) = ");
            string updateCor = Console.ReadLine();
            string valorAntigoCor = automovelId.Cor;
            automovel.Cor = _service.VerificarAlteracaoString(updateCor, valorAntigoCor);

            Console.Write("Digite o novo valor para o Ano do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoAno = automovelId.Ano;
            automovel.Ano = LerAnoAlteracao(valorAntigoAno);

            Console.Write("Digite o novo valor para o Ano/Modelo do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoAnoModelo = automovelId.AnoModelo;
            int ano = automovel.Ano;
            automovel.AnoModelo = LerAnoModeloAlteracao(valorAntigoAnoModelo, ano);

            Console.Write("Digite o novo valor para a Quilometragem do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoQuilometragem = automovelId.Quilometragem;
            automovel.Quilometragem = LerValorIntAlteracao(valorAntigoQuilometragem);

            Console.Write("Digite o novo valor para o Preço do automovel (se não quiser alterar pressione Enter) = ");
            string updatePreco = Console.ReadLine();
            decimal valorAntigoPreco = automovelId.Preco;
            automovel.Preco = _service.VerificarAlteracaoDecimal(updatePreco, valorAntigoPreco);

            
            Console.Write("Digite se esse automóvel é blindado (Sim ou Não), se não quiser alterar pressione Enter = ");
            bool valorAntigoBlindado = automovelId.Blindado;
            automovel.Blindado = LerBlindadoAlteracao(valorAntigoBlindado);
            

            Console.Write("Digite o novo valor para a quantidade de donos do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoQuantidadeDonos = automovelId.QuantidadeDonos;
            automovel.QuantidadeDonos = LerValorIntAlteracao(valorAntigoQuantidadeDonos);

            _service.Alterar(automovel);

            Console.WriteLine("Veículo alterado com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Deletar()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite o Id do automóvel que você deseja deletar no banco = ");
            automovel.Id = LerValorInt();

            _service.Deletar(automovel);

            Console.WriteLine("Veículo excluido com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public int LerValorIntAlteracao(int valorAntigo)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (_service.VerificarAlteracaoInt(input))
                {
                    return valorAntigo;
                }
                if (_service.VerificarAlteracaoValidaInt(input, out int valor))
                {
                    return valor;
                }

                Console.WriteLine("Valor digitado inválido (o valor deve ser um número inteiro, ou apenas pressione Enter para manter o valor antigo).");
                Console.Write("Digite novamente o valor: ");
            }
        }
        public string LerValorString()
        {
            while(true)
            {
                string input = Console.ReadLine();

                if (_service.ValidacaoValorString(input))
                {
                    return input;
                }

                Console.Write("Valor nulo ou vazio, digite novamente: ");
            }
        }
        public int LerValorInt()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (_service.VerificarValorInt(input, out int valor))
                {
                    return valor;
                }

                Console.WriteLine("O valor deve ser um número inteiro.");
                Console.Write("Digite novamente o valor: ");
            }
        }
        public bool LerBlindado()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if(_service.LerValidacaoBlindado(input, out bool blindado))
                {
                    return blindado;
                }

                Console.Write("Valor Blindado inválido, digite novamente: ");
            }
        }
        public int LerAno()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (_service.VerificarAnoValido(input, out int ano))
                {
                    return ano;
                }

                Console.WriteLine("Ano inválido (o ano deve ser um número inteiro, maior que 1885 e não maior que o ano atual!).");
                Console.Write("Digite novamente o ano: ");
            }
        }
        public decimal LerPreco()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(_service.VerificarPreco(input, out decimal valor))
                {
                    return valor;
                }

                Console.WriteLine("Preço inválido (o preço deve ser um número maior que 0!).");
                Console.Write("Digite novamente o preço: ");
            }
        }
        public int LerAnoModelo(int ano)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (_service.VerificarAnoModeloValido(input, out int anoModelo, ano))
                {
                    return anoModelo;
                }

                Console.WriteLine("Ano-Modelo inválido (o Ano-Modelo deve ser um número inteiro, não menor que o ano do automovel e nem 2 anos maior!).");
                Console.Write("Digite novamente o Ano-Modelo: ");
            }
        }
        public int LerAnoAlteracao(int valorAntigo)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return valorAntigo;
                }

                if (_service.VerificarAnoValido(input, out int ano))
                {
                    return ano;
                }

                Console.WriteLine("Ano inválido (o ano deve ser um número inteiro, maior que 1885 e não maior que o ano atual!).");
                Console.Write("Digite novamente (ou pressione Enter para manter o valor antigo): ");
            }
        }
        public int LerAnoModeloAlteracao(int valorAntigo, int ano)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return valorAntigo;
                }

                if (_service.VerificarAnoModeloValido(input, out int anoModelo, ano))
                {
                    return anoModelo;
                }

                Console.Write("Ano-Modelo inválido. Digite novamente(ou pressione Enter para manter o valor antigo): ");
            }
        }
        public bool LerBlindadoAlteracao(bool valorAntigo)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return valorAntigo;
                }
                if(_service.VerificarBlindadoValido(input, out bool blindado))
                {
                    return blindado;
                }

                Console.Write("Valor Blindado inválido, digite novamente (ou pressione Enter para manter o valor antigo): ");
            }
        }
    }
}
