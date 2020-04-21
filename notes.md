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