# Current BUG
- result of GetById is a null full entity, but in the creation it's filled, but in the assertions it's also null for the original entity

# ToDo
- [X] Patch vs Update com relação ao nulls vs {} e como validar no update que veio 100%
- [ ] Test it changes validations on swagger compare with DA 
- [ ] Fluent Validation + Data Annotation, como integrar as formas de lidar com erros

- Testar usando o service:Patch


Nesse cenário, o que fazer no ASP.NET em API:
- DTO de create e put são identicos, mesma validação e no fim também é tudo obrigatório
- DTO de patch é identico a esses, mas com tudo opcional. Porém as valiações base segue (minLengh, Email...)

APIS profissionais, usando arquitetura em camadas


- [ ] Como criar testes para detectar nulls no patch trabalhando bem
- [ ] Como acontece com as validações e como lidam com null na hora de salvar? requiered [Required], ? ...


- [ ] Create Event CRUD
- [ ] Add Login System
- [ ] Add Guard to Event CRUD
- [ ] 
- [ ] 


# Migrations
- Open ./src
- run
```
dotnet ef migrations add [NAME] --project EventPilot.Infrastructure --startup-project EventPilot.Api
dotnet ef database update --project EventPilot.Infrastructure --startup-project EventPilot.Api
 ```