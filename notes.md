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

##

