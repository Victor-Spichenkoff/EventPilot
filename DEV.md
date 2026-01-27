# ToDo
- [ ] Persist token
- [ ] Not validate the token (JWT) ERROR
  - Bearer error="invalid_token",error_description="The issuer '' is invalid"
  - nunca 
- [ ] 
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
