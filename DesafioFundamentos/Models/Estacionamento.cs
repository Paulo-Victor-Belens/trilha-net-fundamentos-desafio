namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaDoVeiculo = Console.ReadLine();
            if (placaDoVeiculo.Length == 0 || placaDoVeiculo.Length > 8)
            {
                Console.WriteLine("Placa inválida, digite uma placa com pelo menos 1 caractere e no máximo 7 caracteres");
                AdicionarVeiculo();
            }

            veiculos.Add(placaDoVeiculo);
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("Digite a placa do veículo para remover: \n");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Digite uma hora correta, apenas valores numéricos são aceitos:");
                }

                decimal valorTotal = 0;

                valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos) {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
