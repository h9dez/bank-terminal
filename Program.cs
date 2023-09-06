using System;
using System.Security.Cryptography;

public class HelloWorld
{
    static void BankStartMenu(){
        Console.WriteLine("Deseja Criar a sua conta? (1) para Sim e (2) para Não. ");
        char Decision = Convert.ToChar(Console.ReadLine()??"");
        DecisionMenu(Decision);
    }

    static void DecisionMenu(char Decision){
        switch (Decision){
            case '1':
            CreateAccount();
            break;
            
            case '2':
            DeclineMenu();
            break;

            default:
            BankStartMenu();
            break;
        }
        
    }

    static void ExitApp(){
        Console.Write("Você saiu do app.");
    }

    static void ChooseMenu(char choose, string? name, string? cpf, string acc, double cash){
        switch (choose){
            case '1':
            BalanceAccount(name, cpf, acc, cash);
            break;

            case '2':
            WithdrawMenu(name, cpf, acc, cash);
            break;

            case '3':
            DepositMenu(name, cpf, acc, cash);
            break;

            case '4':
            EditMenu(name, cpf, acc, cash);
            break;

            case '5':
            ExitApp();
            break;

            default:
            BankMainMenu(name, cpf, acc, cash);
            break;
        }
    }

    static void BalanceAccount(string? name, string? cpf, string acc, double cash){
        Console.Clear();
        Console.WriteLine("Saldo: R${0},00", cash);
        BankMainMenu(name, cpf, acc, cash);
    }

    static void WithdrawMenu(string? name, string? cpf, string acc, double cash){
        Console.Clear();
        Console.WriteLine("O seu saldo é igual a R${0},00.", cash);
        Console.WriteLine("Quanto você deseja sacar?");
        double withdraw = Convert.ToDouble(Console.ReadLine());

        if (withdraw > cash){
            Console.Clear();
            Console.WriteLine("Não é possível realizar o saque, valor maior que o do saldo da conta.");
            Console.WriteLine("Saldo = R${0},00", cash);
            BankMainMenu(name, cpf, acc, cash);
        }
        else{
            Console.Clear();
            double newcash = cash - withdraw;
            Console.WriteLine("Saque realizado com sucesso.");
            Console.WriteLine("Novo saldo = R${0},00", newcash);
            BankMainMenu(name, cpf, acc, newcash);
        }
    }

    static void DepositMenu(string? name, string? cpf, string acc, double cash){
        Console.Clear();
        Console.WriteLine("Quanto você deseja depositar? ");
        double deposit = Convert.ToDouble(Console.ReadLine());

        if (deposit > 0){
            Console.Clear();
            Console.Write("Depósito realizado com sucesso!");
            double CashAfterDeposit = cash + deposit;
            BankMainMenu(name, cpf, acc, CashAfterDeposit);
        }
        else{
            Console.Clear();
            Console.Write("Não foi possível realizar o depósito. Quantia inválida.");
            BankMainMenu(name, cpf, acc, cash);
        }
    }

    static void EditMenu(string? name, string? cpf, string acc, double cash){
        Console.Clear();
        Console.WriteLine("Nome: {0}.", name);
        Console.WriteLine("Cpf: {0}.", cpf);
        Console.WriteLine("Conta: {0}.", acc);
        Console.WriteLine("Saldo: {0}.", cash);
        Console.Write("Deseja alterar as informações da sua conta? (1) para Sim e (2) para Não.");
        char choose = Convert.ToChar(Console.ReadLine()??"");

        switch (choose){
            case '1':
            ChooseEditMenu(name, cpf, acc, cash);
            break;
            
            case '2':
            BankMainMenu(name, cpf, acc, cash);
            break;

            default:
            EditMenu(name, cpf, acc, cash);
            break;
        }
    }

    static string NameValidator(string? name, string? newname, string? cpf, string acc, double cash){
        string? nameChecked;
        if (name != newname){
            nameChecked = newname;
        }
        else{
            nameChecked = name;
            EditMenu(name, cpf, acc, cash);
        }
        return nameChecked ?? "";
    }

    static string CpfValidator(string? name, string? cpf, string? newcpf, string acc, double cash){
        string? cpfChecked;
        if(cpf != newcpf){
            cpfChecked = newcpf;
        }
        else{
            cpfChecked = cpf;
            EditMenu(name, cpf, acc, cash);
        }
        return cpfChecked ?? "";
    }

    static void ChooseEditMenu(string? name, string? cpf, string acc, double cash){
       Console.Clear();
       Console.WriteLine("O que você deseja alterar?");
       Console.WriteLine("(1) para alterar o seu Nome.");
       Console.WriteLine("(2) para alterar o seu Cpf");
       char choose = Convert.ToChar(Console.ReadLine()??"");
       
       switch (choose){
        case '1':
        Console.Clear();
        Console.Write("Digite o seu novo nome: ");
        string newname = Console.ReadLine() ?? "";
        string? validatedName = NameValidator(name, newname, cpf, acc, cash);
        if (validatedName != name){
        Console.WriteLine("Deseja alterar mais algum dado? (1) para Sim e (2) para Não."); 
        char choose2 = Convert.ToChar(Console.ReadLine()??"");
        switch (choose2){
            case '1':
            ChooseEditMenu(newname, cpf, acc, cash);
            break;

            case '2':
            BankMainMenu(newname, cpf, acc, cash);
            break;

            default:
            ChooseEditMenu(newname, cpf, acc, cash);
            break;
            }
        }
        else{
            Console.Write("Nomes iguais. Digite um nome diferente.");;
        }
        break;

        case '2':
            Console.Clear();
            Console.Write("Digite o seu novo cpf: ");
            string? newcpf = Console.ReadLine();
            string? validatedCpf = CpfValidator(name, cpf, newcpf, acc, cash);
            if (validatedCpf != cpf){
            Console.WriteLine("Deseja alterar mais algum dado? (1) para Sim e (2) para Não."); 
            char choose2 = Convert.ToChar(Console.ReadLine()??"");
            switch (choose2){
                case '1':
                ChooseEditMenu(name, newcpf, acc, cash);
                break;

                case '2':
                BankMainMenu(name, newcpf, acc, cash);
                break;

                default:
                ChooseEditMenu(name, newcpf, acc, cash);
                break;
            }    
        }
        else{
            Console.Write("Cpf igual. Digite um cpf diferente.");
            EditMenu(name, cpf, acc, cash);
        }
            break;
        default:
        break;
       }
    }

    static string NameNullCheck (string name){
        string NameNullChecked;
        if (name != ""){
            NameNullChecked = name;
        }
        else{
            NameNullChecked = "";
        }
        return NameNullChecked;
    }

    static string CpfNullCheck (string cpf){
        string CpfNullChecked;
        if(cpf != ""){
            CpfNullChecked = cpf;
        }
        else{
            CpfNullChecked = "";
        }
        return CpfNullChecked;
    }

    static string AccNullCheck (string acc){
        string AccNullChecked;
        if(acc != ""){
            AccNullChecked = acc;
        }
        else{
            AccNullChecked = "";
        }
        return AccNullChecked ?? "";
    }

    static void CreateAccMenu(string name, string cpf, double cash){
        Console.Write("Digite a usa conta: ");
        string acc = Console.ReadLine() ?? "";
        string accCheck = AccNullCheck(acc);
        if(accCheck != ""){
            string accChecked = accCheck;
            BankMainMenu(name, cpf, acc, cash);
        }
        else{
            Console.WriteLine("Conta NÃO pode ser vazia.");
            CreateAccMenu(name, cpf, cash);
        }
    }

    static void CreateCpfMenu(string name, double cash){
        Console.WriteLine("Digite o seu cpf: ");
        string cpf = Console.ReadLine() ?? "";
        string cpfcheck = CpfNullCheck(cpf);
        if(cpfcheck != ""){
            string cpfchecked = cpfcheck;
            CreateAccMenu(name, cpf, cash);
        }
        else{
            Console.WriteLine("Cpf NÃO pode ser vazio.");
            CreateCpfMenu(name, cash);
        }
    }

    static void CreateAccount(){
        double cash = 0.0;
        Console.Write("Digite o seu nome: ");
        string name = Console.ReadLine() ?? "";
        string namechecked = NameNullCheck(name) ?? "";
        if (namechecked != ""){
            CreateCpfMenu(name, cash);
        }
        else{
            Console.WriteLine("O nome NÃO pode ser vazio.");
            CreateAccount();
        }
    }

    static void BankMainMenu(string? name, string? cpf, string acc, double cash){
        Console.WriteLine("O que você deseja fazer: ");
        Console.WriteLine("(1) Para Consultar o Seu Saldo");        
        Console.WriteLine("(2) Para Realizar um Saque");
        Console.WriteLine("(3) Para Realizar um Depósito");
        Console.WriteLine("(4) Para Alterar o Cadastro");
        Console.WriteLine("(5) Para Sair da Aplicação");
        char choose = Convert.ToChar(Console.ReadLine()??"");

        ChooseMenu(choose, name, cpf, acc, cash);
    }

    public static void Main(string[] args)
    {
        BankStartMenu();
    }
}