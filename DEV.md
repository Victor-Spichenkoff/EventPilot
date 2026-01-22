# ToDo
- [ ]  "detail": "Something went wrong", -> DEPLOY, ao fazer login
  - Pode ser string de conexão com db

- [ ] Secret no env, como?
- [ ] Testar em prod se ainda funciona

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
