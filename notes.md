# 1975 - Modelando Domínios Ricos

## Linguagem Úbiqua

- Linguagem única entre cliente e desenvolvedor
- Desenolvedor precisa saber de negócio
- Existem muitos termos que repesentam algo nesse domínio e devem ser refletidos no código

---

## Domínios Ricos vs Domínios Anêmicos

- Domínio Anêmico
- Classes só com propriedades - domínio anêmico, sem regras de negócio
- Domínio Anêmico - Data Driven Design - Domínio orientado a dados
- É uma forma de programar - não esta errado
- verificações realizadas no banco de dados - store procedure/function
- Essa forma é ruim para testar - ex.: Não conseguimos testar em um store procedure

- Domínio Rico
- Temos regras de negócio nas classes (no c#) - validações
- C# (é compilada) é mais rico que sql
- OO é mais rico que MER (modelo entidade relacionamento)
- Podemos realizar testes

- Outro ponto importante que devemos nos preocupar - As Condicionais (ifs)
- Um if, aumenta nossos testes - temos duas condições
- Aumenta a complexidade ciclomática - aumenta complexidade do código

---

## Sub Domínios

- Alternativa para sistemas grandes
- Quebramos o domínio em sub domínio - ex.: ERP
- Melhor para desenvolvimento e manutenção
- Bath size - alterações menores

---

## Separação em Contextos Delimitados

- Sistema/subsistemas/dominios/subdominios
- Se ainda sim estiver ruim para entender e realizar manutenção, separamos em constextos delimitados
- Falando ainda do bath size - melhor separar responsabilidades em partes menores
- Criamos em pequenos contextos
- Isso facilita nossa vida no futuro - para modificar/ensinar/etc.
- Faremos um contexto de pagamento
- Depois os contextos se comunicam entre si - não significa um microserviço

---

## Organizando a Solução

- Criando a pasta **PaymentContext** na mão
- Detro dessa pasta iremos criar mais 3 pastas: **PaymentContext.Domain**, **PaymentContext.Shared** e **PaymentContext.Tests**

- Dentro da pasta principal (PaymentContext), vamos usar um comando para criar uma solution: **dotnet new sln**

- Dentro da pasta **PaymentContext.Domain**, vamos criar os projetos usando o comando: **dotnet new classlib** (no final vira uma dll)

- Dentro da pasta **PaymentContext.Shared**, vamos criar os projetos usando o comando: **dotnet new classlib** (no final vira uma dll)

- Dentro da pasta **PaymentContext.Tests**, vamos criar os projetos usando o comando: **dotnet new mstest**

- Agora precisamos add os projetos à solução. Para isso usamos o comando: **dotnet sln add pasta/projeto.csproj** (realizar isso para cada projeto - domain/shared/test)

- Com os projetos referenciados em nossa solution, vamos fazer o restore e build da solução usando os comandos: **dotnet restore** e **dotnet build**

- Cada projeto criado terá uma responsabilidade: Domain - é o dominio rico. Shared - itens que possam ser compartilhados entre os domínios. Test - onde realizamos os testes

- Precisamos add as referencias entre eles.
- Domain vai precisar da referencia do Shared
- Test vai precisar da referencia de Domain e Shared
- Shared não depende de ninguem
- Para criar uma referencia: dentro do pasta de Domain vamos executar o seguinte comando **dotnet add reference ../PaymentContext.Shared/PaymentContext.Shared.csproj**
- Devemos fazer isso para todos os outros projetos que dependem de referencia

---

## Definindo Entidades

- Vamos criar dentro do projeto de Domain
- Temos que criar uma nova pasta - **Entities**
- Criaremos dentro dessa pasta as nossas entidades - **Student.cs**, **Subscription.cs**, **Payment.cs**

- Classe student criamos 4 props. do tipo string - FirstName, LastName, Document e Email
- Classe Subscription criamos 
- continua...

---

## Corrupção no Código

- Após criarmos nossas entidades vamos notar que nosso código não está "bom" (pouco expressivo).
- Se formos criar uma instancia de aluno, não sabemos quais são as informações necessárias
- Vamos ter que definir nos construtores o que for necessário
- Solid - S -> Cada item com responsabilidade unica
- Outro ponto para melhorar - não podemo deixar nossas propriedades acessiveis fora da classe (escrita)
- Podemos deixar o set private - único ponto de entrada é no construtor (open/close principle)
- Se quisermos alterar alguma propriedade, devemos criar algum método

- Resolvendo problemas de acesso à metodos das listas:
- Para resolver o problema das nossas listas, criar uma IReadOnlyCollection.
- Criar um atributo privdo de lista para adicionarmos nossos itens nessa lista
- E o IReadOnlyCollection retorna o atributo de lista em forma de array
- Não esquecer de instanciar a lista no construtor

---

## SOLID e Clean Code

- ler o livro - Clean Code (Robert C. Martin)

---

## Primitive Obssession

- Em nossas propriedades, seus tipos são primitivos
- Em muitas classes repetem a mesma prop.
- Se quisermos validar essas propriedades, vamos ter que repetir o código

- Vamos criar os tipos para representar essas props.
- A Validação fica nesse tipo (Value Object)
- Com isso temos um reuso de código e menos testes

---

## Value Objects

- criamos nossos tipos complexos

---

## Implementando Validações

- criamos o VO para implementarmos validações
- exceção - usamos para algo que não era para acontecer - ex. banco de dados fora
- validação nos esperamos que aconteça
- poderiamos resolver "na mão" - criando uma lista de erros (atributo)
- se tiver erro, add erro na lista
- Mas ja existem algumas libs prontas -> Ex. **Flunt**
- Já possui as notificações preparadas

- instalando o pacote do Flunt dentro de shared e domain - dotnet add package flunt

- As entidades/ValueObjects devem herdar de Notiable 

---

## Design By Contracts

- Reuso de código = menos testes
- SPOF - Single point of failure
- muitos if - devemos evitar - complexidade ciclomática (if = 2 testes (exemplo))
- microsoft havia lançado o code contract - abandonado
- Design By Contract - foi utilizado no flunt - validações comuns já possuem métodos testados
- não iremos precisar testar em nosso código
- Criamos contratos no nosso código

  AddNotifications(new Contract()
    .Requires()
    .IsEmail(Address, "Email.Address", "E-mail inválido")
  );

- criamos esse contrato no VO
- Se for invalido, será add uma notificação em nossa VO
- E na entidade estamos pegando todas essas notificações (de Todo os VOs)

- Temos duas propriedades que verificam se estão validos ou não (valid e invalid)

- Nos VOs temos validações de campo
- não teremos validação de regra de negócio

---

## Testando as Entidades e VOs

- Poderiamos começar com o VO Name, mas ele só tem validação usando o FLUNT
- Com isso não precisamos criar testes para ele
- Email, a mesma coisa
- Document podemos testar - cpf valido e invalido

- Metodologia de teste - RED, GREEN, REFACTOR
- Criamos os testes para falharem (assert.fail())
- Depois fazemos passarem
- e por fim refatoramos

- Em entidade, vamos começar testando o Student.cs
- Valores de VO's que recebemos no construtor não precisa testar
- Vamos testar somente a assinatura do student

- todo
- Perguntar para o balta:
        .IsLowerThan(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
- pq não pode serequals??não entendi essa bagaça
- meu count é 0, não é menor que 0

---

## Commands

- comandos/inputs/entradas de dados
- CQRS 
- Dividir escrita de leitura
- Pode ocorrer bancos de dados distintos - banco para escrita e banco para leitura

- Vamos criar os commands no domínio (nova pasta Commands)
- ex.: CreatePayPalSubscriptionCommand.cs

- Em shared criamos uma interface ICommand.cs dentro de uma nova pasta chamada de Commands

- COmands - junção de todas informações para criar uma classe - ex. subscription (student -> nomes, documento, email; paypalpayment -> etc...)

- É um objeto de trasporte - entre camadas - o que vem da api, por exemplo, via json
- o Newtonsoft converte para gente

---

## Fail Fast Validations

- Criamos as validações direto no Command
- Criamos uma assinatura de um método na interface
- Nossos comandos herdam de Notifiable (Flunt)

- Dentro da implementação do método, criamos nosso contrato de validação

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "O nome deve ter até 40 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName", "O sobrenome deve ter até 40 caracteres")
            );
        }

- Pegamos a mesma validação que tinhamos no VO Name. Com isso, não precisamos mais ter no VO, essa validação

- Ou e as props do command forem os "vos", chammos a validação desses "vos".

---

## Testando os Commands

---

## Repository Pattern

- Abstrai o acesso a dados
- Não podemos depender de banco
- Ex. Ao criar um usuario, precisa de documento, e esse documento não pode ser repetido
- Não importa o banco, orm, etc...

- No Domain, vamos criar uma pasta chamada repositories
- Temos que depender da abstração, e não da implementação
- Vai ter um arquivo - IStudentRepository.cs (interface)
- Só criamos as assinaturas dos métodos na interface