# ToDo
- ORganizar o fluxo de validações do DTO

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