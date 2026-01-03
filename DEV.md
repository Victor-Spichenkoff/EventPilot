# ToDo
- [X] Patch vs Update com relação ao nulls vs {} e como validar no update que veio 100%
- [ ] Como converter, usando mapster + config ou só jogando direto no code? Porque ele usa obj.Value, não só obj
- [ ] Como funcionam os bloqueios extras de nulls (ef, service?, DTO?), quando o campo não pode mesmo ser null


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