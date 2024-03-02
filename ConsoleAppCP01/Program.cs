
using ClassLibraryCP01.Models;
using System.Globalization;

//Listas que vão armazenar os dados do sitema
var hoteis = new List<Hotel>();
var clientes = new List<Cliente>();

//Instanciando clientes
Cliente cliente = new Cliente("Ana", "ana@email.com", "senha123", new List<Reserva>());
clientes.Add(cliente);

//Instanciando hoteis
var hotel = new Hotel(1, "Hotel Praia", "Copacabana", "5", "Hotel de frente pro mar", new List<Quarto>());
var hotel2 = new Hotel(2, "Hotel Serra", "Serra", "4", "Hotel de frente pro mar", new List<Quarto>());
hoteis.Add(hotel);
hoteis.Add(hotel2);


//Instanciando quartos
var quarto1 = new Quarto(1, 40, true);
var quarto2 = new Quarto(2, 40, false);
var quarto3 = new Suite(3, 40, true, 2);
var quarto4 = new Quarto(4, 40, true);


hotel.Quartos.Add(quarto1);
hotel.Quartos.Add(quarto2);
hotel.Quartos.Add(quarto3);
hotel.Quartos.Add(quarto4);


var quarto5 = new Quarto(1, 40, true);
var quarto6 = new Quarto(2, 40, false);
var quarto7 = new Suite(3, 40, true, 2);
var quarto8 = new Quarto(4, 40, true);

hotel2.Quartos.Add(quarto5);
hotel2.Quartos.Add(quarto6);
hotel2.Quartos.Add(quarto7);
hotel2.Quartos.Add(quarto8);

bool continuar = true;
while (continuar)
{
    // Exibição do menu de opções para login ou cadastro de cliente
    Console.WriteLine("Bem vindo ao sistema de reservas de quartos de hoteis");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1 - Já sou cliente");
    Console.WriteLine("2 - Quero me cadastrar");
    Console.WriteLine("3 - Sair");

    Console.WriteLine("Digite a opção desejada: ");
    int opcao = Convert.ToInt32(Console.ReadLine());

    if (opcao == 1)
    {
        //Login usuario
        Console.WriteLine();
        Console.WriteLine("Informe o seu email");
        string email = Console.ReadLine();
        Console.WriteLine("Informe o seu senha");
        string senha = Console.ReadLine();
        

        foreach(var cli in clientes)
        {

            //verificação se os dados informados no login bate com algum dos clientes salvos na minha lista
            if(cli.Email == email && cli.Senha == senha)
            {
                bool continuarMenuCliente = true;

                while (continuarMenuCliente)
                {
                    Console.WriteLine();
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"Bem vindo(a) {cli.Nome}");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine();



                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Fazer uma reserva");
                    Console.WriteLine("2 - Consultar minhas reserva");
                    Console.WriteLine("3 - sair");

                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch (opcao)
                    {
                        //Opção para realizar reserva
                        case 1:

                            //listagem de hosteis disponiveis na minha aplicação
                            foreach (var h in hoteis)
                            {
                                Console.WriteLine();
                                Console.WriteLine(h.DetalharHotel());
                                Console.WriteLine();
                            }

                            //escolha do hotel
                            Console.WriteLine();
                            Console.WriteLine("Digite o id do hotel escolhido: ");
                            int idHotel = Convert.ToInt32(Console.ReadLine());

                            var hotelEscolhido = hoteis.Find(h => h.Id == idHotel);

                            if(hotelEscolhido != null)
                            {

                                Reserva reserva = new Reserva();
                                reserva.Cliente = cli;

                                Console.WriteLine("Digite a data de checkin(dd/MM/yyyy): ");
                                string dataCheckinStr = Console.ReadLine();

                                reserva.DataCheckin = conversorDeData(dataCheckinStr);

                                Console.WriteLine("Digite a data de checkout(dd/MM/yyyy): ");
                                string dataCheckoutStr = Console.ReadLine();

                                reserva.DataCheckout = conversorDeData(dataCheckoutStr);

                                //listando quartos disponíveis do hotel
                                foreach (var hospedagem in hotelEscolhido.Quartos)
                                {
                                    if (hospedagem.Disponibilidade)
                                    {
                                        Console.WriteLine(hospedagem.ObterDescricao());
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine("Digite o id o numero do quarto escolhido: ");
                                int numeroQuarto = Convert.ToInt32(Console.ReadLine());

                                var quartoEscolhido = hotel.Quartos.Find(q => q.Numero == numeroQuarto);

                                if(quartoEscolhido != null)
                                {
                                    Console.WriteLine();
                                    double precoTotalReserva = reserva.SimulacaoPrecoTotalReserva(reserva.DataCheckin, reserva.DataCheckout, quartoEscolhido.PrecoPorNoite);
                                    Console.WriteLine($"O valor total da reserva ficará R$ {precoTotalReserva}");

                                    Console.WriteLine();
                                    Console.WriteLine($"Deseja prosseguir com a reserva(S/N): ");
                                    string prosseguirReserva = Console.ReadLine();

                                    if (prosseguirReserva == "S") //Concluindo reserva
                                    {
                                        reserva.Quarto = quartoEscolhido;
                                        reserva.PrecoTotal = precoTotalReserva;

                                        cli.Reservas.Add(reserva);

                                        Console.WriteLine("Reserva realizada com sucesso! Te vemos em breve :)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Que pena que não vai se hospedar com a gente mas te esperamos em um próxima ;)");
                                    }

                                }

                            }
                            else //Caso escolha um hotel que não está na lista
                            {
                                Console.WriteLine("Opção inválida!");
                            }
                    
                            break;

                        case 2:
                            foreach(var reserva in cli.Reservas)
                            {
                                Console.WriteLine();
                                Console.WriteLine(reserva.DetalhesReserva());
                                Console.WriteLine();
                            }
                            break;

                        case 3:
                            Console.WriteLine("Saindo do menu de cliente");
                            continuarMenuCliente = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            continuarMenuCliente = false;
                            break;

                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Usuário inválido");
            }
        }        
    }else if(opcao == 2) // Cadastro de clientes
    {
        Console.WriteLine();
        Console.WriteLine("----- Cadastro de usuário -----");
        Console.WriteLine();

        Cliente novoCliente = new Cliente();

        Console.WriteLine("Digite seu nome: ");
        cliente.Nome = Console.ReadLine();
        Console.WriteLine("Digite seu email: ");
        cliente.Email = Console.ReadLine();
        Console.WriteLine("Digite uma senha: ");
        cliente.Senha = Console.ReadLine();

        cliente.Reservas = new List<Reserva>();

        clientes.Add(cliente);
        Console.WriteLine();
        Console.WriteLine("Cliente cadastrado com sucesso");
    }
    else //encerrando programa
    {
        continuar = false; 
        
    }
}

DateTime conversorDeData(string dataStr)
{
    return DateTime.ParseExact(dataStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
}