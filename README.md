# Mãos Voluntárias

Plataforma web para organização de eventos de trabalho voluntário e inscrição de voluntários. Desenvolvida como TCC do curso Técnico em Informática para Internet integrado ao Ensino Médio da ETEC Aristóteles Ferreira, durante o ano letivo de 2023.

> Esta é a versão original do projeto escolar, que não recebe mais manutenção.

## Funcionalidades

O sistema tem dois fluxos de uso:

**Voluntários**
- Pesquisa de vagas em eventos de voluntariado, com filtros
- Inscrição nas vagas dos eventos
- Avaliação do evento e da organização após participarem (depois de aprovados)

**Organizações**
- Criação de eventos de trabalho voluntário
- Definição das vagas de cada evento
- Aprovação ou reprovação dos voluntários inscritos
- Avaliação dos voluntários ao final do evento

O sistema também envia e-mails aos usuários por meio de um cliente SMTP.

## Tecnologias

- C# com ASP.NET Core
- MySQL (modelo de dados e procedures generalizadas)
- HTML no front-end
- Git e GitHub para versionamento

## Minha atuação

Fui Lead Developer e desenvolvedora full-stack, coordenando uma equipe de 6 pessoas. Fui responsável principal por:

- Pesquisa de eventos com filtros complexos
- Sistema de inscrição de voluntários
- Sistema de avaliação
- Envio de e-mails via cliente SMTP

Também atuei, em conjunto com o restante da equipe, na modelagem do banco de dados, na elaboração de procedures generalizadas, e na criação e correção de páginas HTML.

## Como executar

### Pré-requisitos
- .NET SDK [versão]
- MySQL

### Passos
```bash
git clone https://github.com/jymasuda/prjMaosVoluntariasold.git
cd prjMaosVoluntariasold
# Crie o banco de dados MySQL com o script Maos Voluntarias Tables FINAL.sql e Maos Voluntarias Procedures FINAL.sql e ajuste a string de conexão
dotnet run
```

## Autores

* **Jade Masuda** – *Lead Developer, Full-stack* – [jymasuda](https://github.com/jymasuda)
* **Gabriel Barros** – *Full-stack*
* **Giulia Santos** – *Design, Front-end, Documentação*
* **Julliano Angelotti** – *Back-end* – [LinkedIn](https://www.linkedin.com/in/julliano-angelotti-0a654b2b9/)
* **Victor Murilo Castro** – *Design, Wireframe*
* **Victor Medeiros** – *Design, Wireframe*
