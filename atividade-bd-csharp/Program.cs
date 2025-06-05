using System.Globalization;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using atividade_bd_csharp.Repository;
using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace MyFirstCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            char op = '0';

            try
            {
                do
                {
                    Console.WriteLine("""
                ----------------- MENU ------------------
                --TABELAS: 
                1 - Especialidade
                2 - Aviao
                3 - Assento
                4 - Voo
                0 - Sair

                Escolha qual tabela você deseja editar: 
                """);

                    op = Console.ReadLine().ToUpper()[0];

                    Console.Clear();

                    switch (op)
                    {
                        case '1':
                            await CRUDEspecialidade();
                            break;
                        case '2':
                            await CRUDAviao();
                            break;
                        case '3':
                            await CRUDAssento();
                            break;
                        case '4':
                            await CRUDPassagem();
                            break;
                        case '0':
                            Console.WriteLine("Finalizando...");
                            break;
                    }

                } while (op != '0');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static async Task CRUDEspecialidade()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Especialidade --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await EspecialidadeCreate();
                        break;
                    case '2':
                        await EspecialidadeRead();
                        break;
                    case '3':
                        await EspecialidadeUpdate();
                        break;
                    case '4':
                        await EspecialidadeDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task EspecialidadeRead()
        {
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            IEnumerable<EspecialidadeEntity> especialidadeList = await especialidadeRepository.GetAll();
            foreach (EspecialidadeEntity especialidade in especialidadeList)
            {
                Console.WriteLine($"Id: {especialidade.Id}");
                Console.WriteLine($"Nome: {especialidade.Nome}\n");
            }

        }

        static async Task EspecialidadeCreate()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task EspecialidadeDelete()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task EspecialidadeUpdate()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                especialidade.Nome = newName;
                await especialidadeRepository.Update(especialidade);
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }

        /* ----------------------------- TABELA AVIAO ------------------------------ */

        static async Task CRUDAviao()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Avião --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await AviaoCreate();
                        break;
                    case '2':
                        await AviaoRead();
                        break;
                    case '3':
                        await AviaoUpdate();
                        break;
                    case '4':
                        await AviaoDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task AviaoRead()
        {
            IAviaoRepository aviaoRepository = new AviaoRepository();
            IEnumerable<AviaoEntity> aviaoList = await aviaoRepository.GetAll();
            foreach (var aviao in aviaoList)
            {
                Console.WriteLine($"Id: {aviao.Id}");
                Console.WriteLine($"Quantidade de Vagas: {aviao.QuantidadeVaga}");
                Console.WriteLine($"Código de Registro: {aviao.CodigoRegistro}");
                Console.WriteLine($"Companhia: {aviao.Companhia}");
                Console.WriteLine($"Modelo: {aviao.Modelo}");
                Console.WriteLine($"Fabricante: {aviao.Fabricante}\n");

            }

        }

        static async Task AviaoCreate()
        {
            AviaoInsertDTO aviao = new AviaoInsertDTO();

            Console.WriteLine("Digite a quantidade de vagas: ");
            aviao.QuantidadeVaga = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código de registro: ");
            aviao.CodigoRegistro = Console.ReadLine();

            Console.WriteLine("Digite a companhia: ");
            aviao.Companhia = Console.ReadLine();

            Console.WriteLine("Digite o modelo: ");
            aviao.Modelo = Console.ReadLine();

            Console.WriteLine("Digite o fabricante: ");
            aviao.Fabricante = Console.ReadLine();

            IAviaoRepository aviaoRepository = new AviaoRepository();
            await aviaoRepository.Insert(aviao);

            Console.WriteLine("Avião cadastrado com sucesso.");
        }

        static async Task AviaoDelete()
        {
            await AviaoRead();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IAviaoRepository aviaoRepository = new AviaoRepository();
            await aviaoRepository.Delete(id);

            Console.WriteLine("Avião deletado com sucesso.");
        }

        static async Task AviaoUpdate()
        {
            await AviaoRead();

            Console.WriteLine("Digite o Id do avião que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IAviaoRepository aviaoRepository = new AviaoRepository();
            AviaoEntity aviao = await aviaoRepository.GetById(id);

            Console.WriteLine($"Digite nova quantidade de vagas ({aviao.QuantidadeVaga}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                aviao.QuantidadeVaga = int.Parse(input);

            Console.WriteLine($"Digite novo código de registro ({aviao.CodigoRegistro}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.CodigoRegistro = input;

            Console.WriteLine($"Digite nova companhia ({aviao.Companhia}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Companhia = input;

            Console.WriteLine($"Digite novo modelo ({aviao.Modelo}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Modelo = input;

            Console.WriteLine($"Digite novo fabricante ({aviao.Fabricante}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Fabricante = input;

            await aviaoRepository.Update(aviao);
            Console.WriteLine("Avião atualizado com sucesso.");
        }

        /* ----------------------------- TABELA ASSENTO ------------------------------ */

        static async Task CRUDAssento()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Assento --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await AssentoCreate();
                        break;
                    case '2':
                        await AssentoRead();
                        break;
                    case '3':
                        await AssentoUpdate();
                        break;
                    case '4':
                        await AssentoDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task AssentoRead()
        {
            IAssentoRepository assentoRepository = new AssentoRepository();
            IEnumerable<AssentoEntity> assentoList = await assentoRepository.GetAll();

            foreach (var assento in assentoList)
            {
                Console.WriteLine($"Id: {assento.Id}");
                Console.WriteLine($"Número: {assento.Numero}");
                Console.WriteLine($"Tipo: {assento.Tipo}");
                Console.WriteLine($"Avião Id: {assento.Aviao_Id}\n");
            }
        }

        static async Task AssentoCreate()
        {
            AssentoInsertDTO assento = new AssentoInsertDTO();

            Console.WriteLine("Digite o número do assento: ");
            assento.Numero = Console.ReadLine();

            Console.WriteLine("Digite o número do tipo do assento (1 - ECONOMICO, 2 - EXECUTIVO, 3 - PRIMEIRA CLASSE): ");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                assento.Tipo = "Economico";
            }
            else if (opc == 2)
            {
                assento.Tipo = "Executivo";
            }
            else if (opc == 3)
            {
                assento.Tipo = "Primeira Classe";
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                return;
            }

            Console.WriteLine("Digite o ID do avião vinculado: ");
            assento.Aviao_Id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            await assentoRepository.Insert(assento);

            Console.WriteLine("Assento cadastrado com sucesso.");
        }

        static async Task AssentoDelete()
        {
            await AssentoRead();

            Console.WriteLine("Digite o Id do assento que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            await assentoRepository.Delete(id);

            Console.WriteLine("Assento deletado com sucesso.");
        }

        static async Task AssentoUpdate()
        {
            await AssentoRead();

            Console.WriteLine("Digite o Id do assento que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            AssentoEntity assento = await assentoRepository.GetById(id);

            Console.WriteLine($"Digite novo número ({assento.Numero}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                assento.Numero = input;

            Console.WriteLine($"Digite novo tipo ({assento.Tipo}) ou aperte 'Enter' para manter: (1 - ECONOMICO, 2 - EXECUTIVO, 3 - PRIMEIRA CLASSE): ");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                assento.Tipo = "Economico";
            }
            else if (opc == 2)
            {
                assento.Tipo = "Executivo";
            }
            else if (opc == 3)
            {
                assento.Tipo = "Primeira Classe";
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                return;
            }

            Console.WriteLine($"Digite novo Avião Id ({assento.Aviao_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                assento.Aviao_Id = int.Parse(input);

            await assentoRepository.Update(assento);
            Console.WriteLine("Assento atualizado com sucesso.");
        }

        /* ----------------------------- TABELA VOO ------------------------------ */

        static async Task CRUDVoo()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Voo --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await VooCreate();
                        break;
                    case '2':
                        await VooRead();
                        break;
                    case '3':
                        await VooUpdate();
                        break;
                    case '4':
                        await VooDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task VooRead()
        {
            IVooRepository vooRepository = new VooRepository();
            IEnumerable<VooEntity> vooList = await vooRepository.GetAll();

            foreach (var voo in vooList)
            {
                Console.WriteLine($"Id: {voo.Id}");
                Console.WriteLine($"Codigo voo: {voo.CodigoVoo}");
                Console.WriteLine($"Data e Hora de Partida: {voo.DataHoraPartida}");
                Console.WriteLine($"Data e Hora de Chegada: {voo.DataHoraChegada}");
                Console.WriteLine($"Origem id: {voo.Origem_Id}");
                Console.WriteLine($"Destino id: {voo.Destino_Id}");
                Console.WriteLine($"Aviao id: {voo.Aviao_Id}");
            }
        }

        static async Task VooCreate()
        {
            VooInsertDTO voo = new VooInsertDTO();

            Console.WriteLine("Digite o código do voo: ");
            voo.CodigoVoo = Console.ReadLine();

            Console.WriteLine("Digite a data de partida do voo (ex: dd/mm/yyyy HH:mm:ss):");
            string dataTexto = Console.ReadLine();
            voo.DataHoraPartida = DateTime.ParseExact(dataTexto, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            Console.WriteLine("Digite a data de chegada do voo (ex: dd/mm/yyyy HH:mm:ss):");
            dataTexto = Console.ReadLine();
            voo.DataHoraChegada = DateTime.ParseExact(dataTexto, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine("Digite o ID de origem vinculado: ");
            voo.Origem_Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID de destino vinculado: ");
            voo.Destino_Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID do avião vinculado: ");
            voo.Aviao_Id = int.Parse(Console.ReadLine());

            IVooRepository vooRepository = new VooRepository();
            await vooRepository.Insert(voo);

            Console.WriteLine("Voo cadastrado com sucesso.");
        }

        static async Task VooDelete()
        {
            await VooRead();

            Console.WriteLine("Digite o Id do voo que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IVooRepository vooRepository = new VooRepository();
            await vooRepository.Delete(id);

            Console.WriteLine("Voo deletado com sucesso.");
        }

        static async Task VooUpdate()
        {
            await VooRead();

            Console.WriteLine("Digite o Id do voo que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IVooRepository vooRepository = new VooRepository();
            VooEntity voo = await vooRepository.GetById(id);

            Console.WriteLine($"Digite novo codigo de voo ({voo.CodigoVoo}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                voo.CodigoVoo = input;

            Console.WriteLine($"Digite uma nova Data e horário de partida (atual: {voo.DataHoraPartida}) (ex: dd/mm/yyyy HH:mm:ss) ou aperte 'Enter' para manter:");
            string dataTexto = Console.ReadLine();
            if (input != string.Empty)
                voo.DataHoraPartida = DateTime.ParseExact(dataTexto, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine($"Digite uma nova Data e horário de chegada (atual: {voo.DataHoraChegada}) (ex: dd/mm/yyyy HH:mm:ss) ou aperte 'Enter' para manter:");
            dataTexto = Console.ReadLine();
            if (input != string.Empty)
                voo.DataHoraChegada = DateTime.ParseExact(dataTexto, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine($"Digite um novo origem Id ({voo.Origem_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                voo.Origem_Id = int.Parse(input);

            Console.WriteLine($"Digite um novo destino Id ({voo.Destino_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                voo.Destino_Id = int.Parse(input);

            Console.WriteLine($"Digite novo Avião Id ({voo.Aviao_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                voo.Aviao_Id = int.Parse(input);

            await vooRepository.Update(voo);
            Console.WriteLine("Voo atualizado com sucesso.");
        }

        /* ----------------------------- TABELA PASSAGEM ------------------------------ */

        static async Task CRUDPassagem()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Passagem --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await PassagemCreate();
                        break;
                    case '2':
                        await PassagemRead();
                        break;
                    case '3':
                        await PassagemUpdate();
                        break;
                    case '4':
                        await PassagemDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task PassagemRead()
        {
            IPassagemRepository passagemRepository = new PassagemRepository();
            IEnumerable<PassagemEntity> passagemList = await passagemRepository.GetAll();

            foreach (var passagem in passagemList)
            {
                Console.WriteLine($"Id: {passagem.Id}");
                Console.WriteLine($"Preço: {passagem.Preco}");
                Console.WriteLine($"Assento Id: {passagem.Assento_Id}");
                Console.WriteLine($"Voo Id: {passagem.Voo_ID}");
                Console.WriteLine($"Ordem Servico Id: {passagem.OrdemServico_Id}");
            }
        }

        static async Task PassagemCreate()
        {
            PassagemInsertDTO passagem = new PassagemInsertDTO();

            Console.WriteLine("Digite o Preco da Passagem: ");
            passagem.Preco = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID do assento: ");
            passagem.Assento_Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID de voo vinculado: ");
            passagem.Voo_ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID da ordem de serviço vinculada: ");
            passagem.OrdemServico_Id = int.Parse(Console.ReadLine());

            IPassagemRepository passagemRepository = new PassagemRepository();
            await passagemRepository.Insert(passagem);

            Console.WriteLine("Voo cadastrado com sucesso.");
        }

        static async Task PassagemDelete()
        {
            await PassagemRead();

            Console.WriteLine("Digite o Id da passagem que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IPassagemRepository passagemRepository = new PassagemRepository();
            await passagemRepository.Delete(id);

            Console.WriteLine("Voo deletado com sucesso.");
        }

        static async Task PassagemUpdate()
        {
            await PassagemRead();

            Console.WriteLine("Digite o Id da passagem que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IPassagemRepository passagemRepository = new PassagemRepository();
            PassagemEntity passagem = await passagemRepository.GetById(id);

            Console.WriteLine($"Digite um novo preço da passagem ({passagem.Preco}) ou aperte 'Enter' para manter:");
            decimal preco = decimal.Parse(Console.ReadLine());
            if (preco != null)
                passagem.Preco = preco;

            Console.WriteLine($"Digite um novo assento Id ({passagem.Assento_Id}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                passagem.Assento_Id = int.Parse(input);

            Console.WriteLine($"Digite um novo destino Id ({passagem.Voo_ID}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                passagem.Voo_ID = int.Parse(input);

            Console.WriteLine($"Digite a nova Ordem de Servico Id ({passagem.OrdemServico_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                passagem.OrdemServico_Id = int.Parse(input);

            await passagemRepository.Update(passagem);
            Console.WriteLine("Passagem atualizado com sucesso.");
        }

    }
}