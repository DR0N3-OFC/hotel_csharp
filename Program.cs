using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Quantas pessoas serão hospedadas?");
int quantidadeDePessoas = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < quantidadeDePessoas; i++)
{
    Console.WriteLine($"Digite o nome do {i+1}º hóspede.");
    string nome = Console.ReadLine();
    hospedes.Add(new Pessoa(nome));
}

try
{
	// Cria a suíte
	Suite suite = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 30);
	
	// Cria uma nova reserva, passando a suíte e os hóspedes
    Console.WriteLine("Determine a quantidade de dias para a reserva: ");
	Reserva reserva = new Reserva(diasReservados: Convert.ToInt32(Console.ReadLine()));
	reserva.CadastrarSuite(suite);
	reserva.CadastrarHospedes(hospedes);
	
	// Exibe a quantidade de hóspedes e o valor da diária
	Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
	Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}");
}
catch (Exception ex) // Captura a exceção e mostra a mensagem do erro
{
	Console.WriteLine($"Erro ao finalizar reserva: {ex.Message}");
}