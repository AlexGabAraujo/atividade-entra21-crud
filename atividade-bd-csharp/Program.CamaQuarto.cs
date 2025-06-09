using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using atividade_bd_csharp.Entity;
using atividade_bd_csharp.Repository;
using MyFirstCRUD.infrastructure;
using atividade_bd_csharp.DTO;

using static atividade_bd_csharp.Entity.CamaQuartoEntity;
using static atividade_bd_csharp.DTO.HotelInsertDTO;

namespace atividade_bd_csharp
{
    public class Program
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

            int op;

            do
            {
                Console.WriteLine("=== Gerenciar ===");
                Console.WriteLine("1 - Hotel");
                Console.WriteLine("2 - Quarto");
                Console.WriteLine("3 - Cama do quarto");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (op)
                {
                    case 1:
                        await MenuHotel(); 
                        break;
                    case 2:
                        await MenuQuarto(); 
                        break;
                    case 3:
                        await MenuCamaQuarto(_camaQuartoRepository);
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (op != 4);
        }
        static async Task MenuHotel()
        {
            int op = 0;

            do
            {
                Console.WriteLine("=== Menu Hotel ===");
                Console.WriteLine("1 - Listar hotéis");
                Console.WriteLine("2 - Buscar hotel por cidade");
                Console.WriteLine("3 - Buscar hotel por ID");
                Console.WriteLine("4 - Cadastrar novo hotel");
                Console.WriteLine("5 - Atualizar hotel");
                Console.WriteLine("6 - Excluir hotel");
                Console.WriteLine("7 - Voltar ao menu principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    switch (op)
                    {
                        case 1:
                            await ListaHoteis();
                            break;
                        case 2:
                            await CadastrarHotel();
                            break;
                        case 3:
                            await AtualizarHotel();
                            break;
                        case 4:
                            await ExcluirHotel();
                            break;
                        case 5:
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido.");
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();

            } while (op != 7);
        }

        public static async Task ListaHoteis()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===Lista de Hotéis===");

                var hoteis = await _hotelRepository.GetAll();

                if (hoteis.Any())
                {
                    foreach (var hotel in hoteis)
                    {
                        Console.WriteLine($"ID: {hotel.Id}, Nome: {hotel.Nome}, Cidade: {hotel.Cidade_Id}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum hotel encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar hotéis: {ex.Message}");
            }
        }

        public static async Task CadastrarHotel()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Hotel ===");

            try
            {
                var dto = new HotelInsertDTO();

                Console.Write("CNPJ: ");
                dto.Cnpj = Console.ReadLine();

                Console.Write("Nome: ");
                dto.Nome = Console.ReadLine();

                Console.Write("Email: ");
                dto.Email = Console.ReadLine();

                Console.Write("Telefone: ");
                dto.Telefone = Console.ReadLine();

                Console.Write("Endereço da Foto: ");
                dto.EnderecoFoto = Console.ReadLine();

                Console.Write("Site: ");
                dto.Site = Console.ReadLine();

                Console.Write("Acessibilidade: ");
                dto.Acessibilidade = Console.ReadLine();

                Console.Write("CEP: ");
                dto.Cep = Console.ReadLine();

                Console.Write("Bairro: ");
                dto.Bairro = Console.ReadLine();

                Console.Write("Rua: ");
                dto.Rua = Console.ReadLine();

                Console.Write("Número do Endereço: ");
                dto.NumeroEndereco = Console.ReadLine();

                Console.Write("ID da Cidade: ");
                dto.Cidade_Id = Console.ReadLine();

                Console.Write("Tipo (1 - Hotel,\n 2 - Apto,\n 3 - Casa,\n 4 - Hostel,\n 5 - Pousada): ");
                int.TryParse(Console.ReadLine(), out int tipo);
                dto.Tipo = (StatusTipo)tipo;

                await _hotelRepository.Insert(dto);
                Console.WriteLine("Hotel cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar hotel: {ex.Message}");
            }
        }

        public static async Task AtualizarHotel()
        {
            Console.Clear();
            Console.WriteLine("=== Atualizar Hotel ===");

            public static async Task AtualizarHotel()
        {
            try
            {
                Console.Write("Digite o ID do hotel a ser atualizado: ");
                int.TryParse(Console.ReadLine(), out int id);

                var dto = new HotelInsertDTO();

                Console.Write("CNPJ: ");
                dto.Cnpj = Console.ReadLine();

                Console.Write("Nome: ");
                dto.Nome = Console.ReadLine();

                Console.Write("Email: ");
                dto.Email = Console.ReadLine();

                Console.Write("Telefone: ");
                dto.Telefone = Console.ReadLine();

                Console.Write("Foto do Endereço: ");
                dto.EnderecoFoto = Console.ReadLine();

                Console.Write("Site: ");
                dto.Site = Console.ReadLine();

                Console.Write("Acessibilidade: ");
                dto.Acessibilidade = Console.ReadLine();

                Console.Write("CEP: ");
                dto.Cep = Console.ReadLine();

                Console.Write("Bairro: ");
                dto.Bairro = Console.ReadLine();

                Console.Write("Rua: ");
                dto.Rua = Console.ReadLine();

                Console.Write("Número do Endereço: ");
                dto.NumeroEndereco = Console.ReadLine();

                Console.Write("ID da Cidade: ");
                dto.Cidade_id = Console.ReadLine();

                var hotel = new HotelEntity
                {
                    Cnpj = dto.Cnpj,
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Telefone = dto.Telefone,
                    EnderecoFoto = dto.EnderecoFoto,
                    Site = dto.Site,
                    Acessibilidade = dto.Acessibilidade,
                    Cep = dto.Cep,
                    
                };

                await _hotelRepository.Update(id, hotel, dto);

                Console.WriteLine("✅ Hotel atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o hotel: {ex.Message}");
            }
        }

        }

        public static async Task ExcluirHotel()
        {
            Console.Clear();
            Console.WriteLine("=== Excluir Hotel ===");

            try
            {
                Console.Write("Digite o ID do hotel a excluir: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var hotel = await _hotelRepository.GetById(id);
                if (hotel == null)
                {
                    Console.WriteLine("Hotel não encontrado.");
                    return;
                }

                await _hotelRepository.Delete(id);
                Console.WriteLine("Hotel excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir hotel: {ex.Message}");
            }
        }

        static async Task MenuQuarto()
        {
            int op = 0;

            do
            {
                Console.WriteLine("=== Menu Quarto ===");
                Console.WriteLine("1 - Listar quartos");
                Console.WriteLine("2 - Buscar quarto por ID");
                Console.WriteLine("3 - Cadastrar quarto");
                Console.WriteLine("4 - Atualizar quarto");
                Console.WriteLine("5 - Excluir quarto");
                Console.WriteLine("6 - Voltar ao menu principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    switch (op)
                    {
                        case 1:
                            await ListaQuartos();
                            break;
                        case 2:
                            await BuscarQuartoPorId();
                            break;
                        case 3:
                            await CadastrarQuarto();
                            break;
                        case 4:
                            await AtualizarQuarto();
                            break;
                        case 5:
                            await ExcluirQuarto();
                            break;
                        case 6:
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido.");
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();

            } while (op != 6);
        }

        public static async Task ListaQuartos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===Lista de Quartos===");

                var quartos = await _quartoRepository.GetAll();

                if (quartos.Any())
                {
                    foreach (var quarto in quartos)
                    {
                        Console.WriteLine($"ID: {quarto.Id}, Número: {quarto.Numero}, Hotel ID: {quarto.Hotel_id}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum quarto encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar quartos: " + ex.Message);
            }
        }

        public static async Task BuscarQuartoPorId()
        {
            Console.Clear();
            Console.WriteLine("===Buscar Quarto por ID===");

            Console.Write("Digite o ID do quarto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var quarto = await _quartoRepository.GetById(id);
                if (quarto != null)
                {
                    Console.WriteLine($"ID: {quarto.Id}, Número: {quarto.Numero}, Hotel ID: {quarto.Hotel_id}");
                }
                else
                {
                    Console.WriteLine("Quarto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
        }

        public static async Task CadastrarQuarto()
        {
            Console.Clear();
            Console.WriteLine("===Cadastro de Quarto===");

            var quarto = new QuartoEntity();

            Console.Write("Número do quarto: ");
            quarto.Numero = Console.ReadLine();

            Console.Write("Andar: ");
            quarto.Andar = Console.ReadLine();

            Console.Write("Aceita animal (S/N): ");
            var aceita = Console.ReadLine()?.ToUpper() == "S";
            quarto.AceitaAnimal = aceita;

            Console.Write("Observação: ");
            quarto.Observacao = Console.ReadLine();

            Console.Write("Preço: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
                quarto.Preco = preco;
            else
                quarto.Preco = 0;

            Console.Write("Endereço da foto: ");
            quarto.EnderecoFoto = Console.ReadLine();

            Console.Write("Limite de pessoas: ");
            if (int.TryParse(Console.ReadLine(), out int limitePessoas))
                quarto.LimitePessoa = limitePessoas;
            else
                quarto.LimitePessoa = 1;

            Console.Write("ID do hotel: ");
            if (int.TryParse(Console.ReadLine(), out int hotel_id))
            {
                var hotelExiste = await _hotelRepository.GetById(hotel_id);
                if (hotelExiste != null)
                {
                    quarto.Hotel_id = hotel_id;

                    await _quartoRepository.Insert(quarto);
                    Console.WriteLine("Quarto cadastrado!");
                }
                else
                {
                    Console.WriteLine("Hotel não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID do hotel inválido.");
            }
        }

        public static async Task AtualizarQuarto()
        {
            Console.Clear();
            Console.WriteLine("===Atualizar Quarto===");

            Console.Write("ID do quarto a ser atualizado: ");
            int.TryParse(Console.ReadLine(), out int idAtualizar);

            var dto = new QuartoInsertDTO();

            Console.Write("Número do Quarto: ");
            dto.Numero = Console.ReadLine();

            Console.Write("Andar: ");
            dto.Andar = Console.ReadLine();

            var quartoEntity = new QuartoEntity
            {
                Numero = dto.Numero,
                Andar = dto.Andar,
                
            };

            await _quartoRepository.Update(idAtualizar, quartoEntity, dto);

        }

        public static async Task ExcluirQuarto()
        {
            Console.Clear();
            Console.WriteLine("===Excluir Quarto===");

            Console.Write("Digite o ID do quarto que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var quartoExistente = await _quartoRepository.GetById(id);
            if (quartoExistente == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                return;
            }

            await _quartoRepository.Delete(id);
            Console.WriteLine("Quarto excluído com sucesso!");
        }


        static async Task MenuCamaQuarto(CamaQuartoRepository repo)
        {
            int op = 0;

            do
            {
                Console.WriteLine("=== Menu Cama do Quarto ===");
                Console.WriteLine("1 - Listar todas as camas");
                Console.WriteLine("2 - Buscar cama por Id");
                Console.WriteLine("3 - Cadastrar cama");
                Console.WriteLine("4 - Atualizar cama");
                Console.WriteLine("5 - Excluir cama");
                Console.WriteLine("6 - Buscar por tipo de cama");
                Console.WriteLine("7 - Voltar ao menu principal");
                Console.WriteLine("Escolha uma opção:");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    switch (op)
                    {
                        case 1:
                            await ListarCamas();
                            break;
                        case 2:
                            BuscarCamaPorId(); 
                            break;
                        case 3:
                            CadastrarCama(); 
                            break;
                        case 4:
                            AtualizarCama();
                            break;
                        case 5:
                            ExcluirCama();
                            break;
                        case 6:
                            Console.WriteLine("Voltando...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido.");
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();

            } while (op != 7);
        }

        public static void ExibirDetalhesCama(CamaQuartoEntity cama)
        {
            Console.WriteLine($"ID: {cama.Id}");
            Console.WriteLine($"Tipo: {cama.TipoCama}");
            Console.WriteLine($"Quantidade: {cama.Quantidade}");
            Console.WriteLine($"Quarto ID: {cama.QuartoId}");
        }

        public static string ObterDescricaoTipoCama(CamaQuartoEntity.EnumCama tipo)
        {
            return tipo switch
            {
                EnumCama.Solteiro => "Solteiro",
                EnumCama.Casal => "Casal",
                EnumCama.Beliche => "Beliche",
                EnumCama.Futon => "Futon",
                _ => "Desconhecido"
            };
        }

        public static async Task ListarCamas()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Lista de todas as camas ===");

                var camas = await _camaQuartoRepository.GetAll();

                if (camas.Any())
                {
                    Console.WriteLine($"{"ID",-5} {"Tipo",-12} {"Qtd",-5} {"Quarto ID",-10}\n");

                    foreach (var cama in camas)
                    {
                        Console.WriteLine($"{cama.Id,-5} {cama.TipoCama,-12} {cama.Quantidade,-5} {cama.QuartoId,-10}");
                    }

                    Console.WriteLine($"\nTotal: {camas.Count()} configurações de cama");
                }
                else
                {
                    Console.WriteLine("Nenhuma cama encontrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar camas: " + ex.Message);
            }
        }

        public static async Task BuscarCamaPorId()
        {

            Console.Clear();
            Console.WriteLine("===Buscar Cama por Id===");

            Console.WriteLine("Digite o Id da cama:");
            if (int.TryParse(Console.ReadLine(), out int Id))
            {
                var cama = await _camaQuartoRepository.GetById(Id); 

                if (cama != null)
                {
                    Console.WriteLine("Cama encontrada.");
                    ExibirDetalhesCama(cama);
                } else
                {
                    Console.WriteLine("Cama não encontrada.");
                }
            }
        
        }

        public static async Task CadastrarCama()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===Cadastro de camas===");

                var cama = new CamaQuartoEntity();

                Console.WriteLine("Tipo de Cama:");
                TiposCama();
                Console.WriteLine("Escolha o tipo de cama 1-4");

                if (int.TryParse(Console.ReadLine(),out int tipoInt) && tipoInt >= 1 && tipoInt <= 4)
                {
                    cama.TipoCama = (CamaQuartoEntity.EnumCama)(tipoInt - 1);
                    Console.WriteLine($"Tipo Selecionado: {cama.TipoCama}");
                } else
                {
                    Console.WriteLine("Opção Invalida, Casal como padrão.");
                    cama.TipoCama = CamaQuartoEntity.EnumCama.Casal;
                }

                Console.WriteLine("Quantidade de pessoas no quarto:");
                if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
                {
                    cama.Quantidade = quantidade;
                }
                else
                {
                    Console.WriteLine("❌ Quantidade inválida! Usando 2 como padrão.");
                    cama.Quantidade = 2;
                }

                Console.WriteLine("\nRESUMO");
                Console.WriteLine($"Tipo: {cama.TipoCama}");
                Console.WriteLine($"Quantidade: {cama.Quantidade}");
                Console.WriteLine($"Quarto ID: {cama.QuartoId}");

                Console.Write("Confirma o cadastro? (S/N): ");
                if (Console.ReadLine()?.ToUpper() == "S")
                {
                    await _camaQuartoRepository.Insert(cama);
                   
                    Console.WriteLine("Cama cadastrada!");
                }
                else
                {
                    Console.WriteLine("Cadastro cancelado.");
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async Task AtualizarCama()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Atualizar cama===\n");

                Console.WriteLine("Camas disponíveis:");
                var todasCamas = await _camaQuartoRepository.GetAll();
                var camasList = todasCamas.Take(10).ToList();

                foreach (var c in camasList)
                {
                    Console.WriteLine($"ID: {c.Id} - {ObterDescricaoTipoCama(c.TipoCama)} (Qtd: {c.Quantidade}) - Quarto: {c.QuartoId}");
                }
                Console.WriteLine();

                Console.Write("Digite o ID da cama a ser atualizada: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var camaExistente = await _camaQuartoRepository.GetById(id);

                    if (camaExistente != null)
                    {
                        Console.WriteLine($"\nCama atual: {ObterDescricaoTipoCama(camaExistente.TipoCama)} (Qtd: {camaExistente.Quantidade})");
                        Console.WriteLine("Digite novos dados :\n");

                        Console.WriteLine($"Tipo atual: {ObterDescricaoTipoCama(camaExistente.TipoCama)}");
                        Console.WriteLine("Deseja alterar o tipo? (S/N): ");
                        string alterarTipo = Console.ReadLine()?.ToUpper();
                        if (alterarTipo == "S")
                        {
                            Console.WriteLine("\nTipos disponíveis:");
                            TiposCama();
                            Console.Write("Escolha o novo tipo (1-4): ");
                            if (int.TryParse(Console.ReadLine(), out int novoTipoInt) &&
                                Enum.IsDefined(typeof(EnumCama), novoTipoInt))
                            {
                                camaExistente.TipoCama = (EnumCama)novoTipoInt;
                                Console.WriteLine($" Novo tipo: {ObterDescricaoTipoCama(camaExistente.TipoCama)}");
                            }
                        }

                        Console.Write($"Quantidade de pessoas [{camaExistente.Quantidade}]: ");
                        string quantidade = Console.ReadLine();
                        if (int.TryParse(quantidade, out int novaQuantidade) && novaQuantidade > 0)
                            camaExistente.Quantidade = novaQuantidade;

                        Console.Write($"ID do Quarto [{camaExistente.QuartoId}]: ");
                        string quartoStr = Console.ReadLine();
                        if (int.TryParse(quartoStr, out int novoQuartoId))
                        {
                            var quartoExiste = await _quartoRepository.GetById(novoQuartoId);
                            if (quartoExiste != null)
                            {
                                camaExistente.QuartoId = novoQuartoId;
                                Console.WriteLine($"Novo quarto: {quartoExiste.Numero}");
                            }
                            else
                            {
                                Console.WriteLine("Quarto não encontrado! Mantem atual.");
                            }
                        }

                        Console.Write("\nConfirmar  atualização? (S/N): ");
                        string confirmacao = Console.ReadLine()?.ToUpper();

                        if (confirmacao == "S")
                        {
                            await _camaQuartoRepository.Update(camaExistente);
                            Console.WriteLine("\nCama atualizada !");
                        }
                        else
                        {
                            Console.WriteLine("\nAtualização cancelada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cama não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
            

                public static async Task ExcluirCama()
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Excluir cama");

                        Console.WriteLine("Camas cadastradas:");
                        var todasCamas = await _camaQuartoRepository.GetAll();
                        var camasLista = todasCamas.Take(15).ToList();

                        foreach(var cama in camasLista)
                        {
                            Console.WriteLine($"ID: {cama.Id} - {ObterDescricaoTipoCama(cama.TipoCama)} (Qtd: {cama.Quantidade}) - Quarto: {cama.QuartoId}");
                        }
                        Console.WriteLine();

                        Console.WriteLine("Digite p Id da cama para excluir.");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var cama = await _camaQuartoRepository.GetById(id);

                            if (cama != null)
                            {
                                ExibirDetalhesCama(cama);

                                Console.Write("Tem certeza que deseja excluir esta cama? (S/N): ");
                                string confirmacao = Console.ReadLine()?.ToUpper();

                                if (confirmacao == "S")
                                {
                                    await _camaQuartoRepository.Delete(id);
                                    Console.WriteLine("\nCama excluída.");
                                }
                                else
                                {
                                    Console.WriteLine("\n Operação cancelada.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cama não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                static void TiposCama()
                {
                    Console.WriteLine("1 - Solteiro ");
                    Console.WriteLine("2 - Casal");
                    Console.WriteLine("3 - Beliche");
                    Console.WriteLine("4 - futon");

                }
        
    }
}
