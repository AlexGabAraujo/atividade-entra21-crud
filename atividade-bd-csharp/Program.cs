using System;
using System.Diagnostics;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using atividade_bd_csharp.Repository;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;
using static atividade_bd_csharp.Entity.HotelEntity;
using static atividade_bd_csharp.Entity.CamaQuartoEntity;
using System.Security.Cryptography.X509Certificates;

namespace MyFirstCRUD
{
    internal class Program
    {
        private static Connection _connection;
        private static CamaQuartoRepository _camaQuartoRepository;
        private static QuartoRepository _quartoRepository;
        private static HotelRepository _hotelRepository;
        static async Task Main(string[] args)
        {
                    _connection = new Connection();
                    _camaQuartoRepository = new CamaQuartoRepository(_connection);
                    _quartoRepository = new QuartoRepository(_connection);
                    _hotelRepository = new HotelRepository(_connection);

                    int op = 0;

                    do
                    {
                        Console.WriteLine("===Gerenciar===");
                        Console.WriteLine("1 - Hotel");
                        Console.WriteLine("2 - Quarto");
                        Console.WriteLine("3 - Cama do quarto");
                        Console.WriteLine("4 - Sair");

                        switch (op)
                        {
                            case '1':
                                await MenuHotel();
                                break;
                            case '2':
                                MenuQuarto();
                                break;
                            case '3':
                                MenuCamaQuarto();
                                break;
                            case '4':
                                break;

                        }

                    } while (op <= 0);

                    static async Task MenuCamaQuarto(CamaQuartoRepository repo)
                    {
                        int op = 0;
                        do
                        {
                            Console.WriteLine("===Menu Cama do quarto===");
                            Console.WriteLine("1 - Listar Todas as camas");
                            Console.WriteLine("2 - Buscar cama por Id");
                            Console.WriteLine("3 - Cadastrar cama");
                            Console.WriteLine("4 - atualizar cama");
                            Console.WriteLine("5 - Excluir cama");
                            Console.WriteLine("6 - Buscar por tipo de cama");
                            Console.WriteLine("7 - Voltar ao menu principal");
                            Console.WriteLine("8 - Sair");
                            Console.WriteLine("Escolha uma opção:");

                            if (int.TryParse(Console.ReadLine(), out op))
                            {
                                switch (op)
                                {
                                    case '1':
                                        ListarCamas();
                                        break;
                                    case '2':
                                        BuscarCamaPorId();
                                        break;
                                    case '3':
                                        CadastrarCama();
                                        break;
                                    case '4':
                                        AtualizarCama();
                                        break;
                                    case '5':
                                        ExcluirCama();
                                        break;
                                    case '6':
                                        BuscarTipoCama();
                                        break;
                                    case '7':
                                        Console.WriteLine("Voltando...");
                                        break;
                                    default:
                                        Console.WriteLine("Opção inválida.");
                                        Console.ReadKey();
                                        break;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um número valído");
                                Console.ReadKey();
                            }
                        } while (op <= 0);
                    }
                    public static void ExibirDetalhesCama(CamaQuartoEntity cama)
                    {
                        Console.WriteLine($"ID: {cama.Id}");
                        Console.WriteLine($"Tipo: {cama.TipoCama}");
                        Console.WriteLine($"Quantidade: {StatusCama.TipoCama(cama.Quantidade})");
                        Console.WriteLine($"Quarto ID: {cama.QuartoId}");
                    }
                    public string ObterDescricaoTipoCama(CamaQuartoEntity.StatusCama tipo)
                    {
                        return tipo switch
                        {
                            StatusCama.Solteiro => "Solteiro",
                            StatusCama.Casal => "Casal",
                            StatusCama.Beliche => "Beliche",
                            StatusCama.Futon => "Futon"
                        };

                    }

                    static async Task ListarCamas()
                    {
                        try
                        {

                            Console.Clear();
                            Console.WriteLine("===Lista de todas as camas==");

                            var camas = await _camaQuartoRepository.GetAll();

                            if (camas.Any())
                            {
                                Console.WriteLine($"{"ID",-5} {"Tipo",-12} {"Qtd",-5} {"Quarto ID",-10}\n");

                                foreach (var cama in camas)
                                {
                                    Console.WriteLine($"{cama.Id,-5} {cama.TipoCama,-12} {cama.Quantidade,-5} {cama.QuartoId,-10}");
                                }

                                Console.WriteLine($"\n Total: {camas.Count()} configurações de cama");

                            }
                            else
                            {
                                Console.WriteLine("Nenhuma cama encontrada");
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }

        }
    }
}  
