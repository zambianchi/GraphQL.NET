# GraphQL .NET

GraphQLNet dimostra come implementare un'API GraphQL in ASP.NET Core. 📚✨ Consente query flessibili, scalabili e performanti con **GraphQL.NET**.

## Struttura

- **Models**: Modelli di dominio.
- **Services**: Servizi per dati.
- **QLTypes**: Tipi GraphQL.
- **QLQuery**: Definizioni query.

## Requisiti

- .NET 8.0+
- Database non utilizzato per semplificare l'utilizzo del progetto di test. 🛠️

## Avvio rapido

1. **Clona il repository**: 💻🔧

   ```bash
   git clone https://github.com/zambianchi/GraphQL.NET.git
   cd GraphQLNet
   ```

2. **Installa le dipendenze**: 📂

   ```bash
   dotnet restore
   ```

3. **Avvia l'app**: ▶️

   ```bash
   dotnet run
   ```

4. **Accedi all'endpoint**: 🔗

   [https://localhost:7199/graphql](https://localhost:7199/) in SSL o [http://localhost:5000/graphql](http://localhost:5000/) senza SSL

## Esempi di query

### Libri

#### Richiesta

```graphql
query {
  books {
    id
    title
    author
  }
}
```

#### Risposta

```graphql
{
  "data": {
    "books": [
      {
        "id": "8f7ce1bb-5637-44a2-95fa-505117c266ea",
        "title": "The Catcher in the Rye",
        "author": "J.D. Salinger"
      },
      {
        "id": "5f3b9b4c-d68e-4b6f-b050-e901dc76c888",
        "title": "1984",
        "author": "George Orwell"
      }
    ]
  }
}
```

### Libro con dettagli

#### Richiesta
```graphql
query {
  book(id: "8f7ce1bb-5637-44a2-95fa-505117c266ea") {
    title
    author
    details {
      id
      info
    }
  }
}
```

### Esempio di risposta

```graphql
{
  "data": {
    "book": {
      "title": "The Catcher in the Rye",
      "author": "J.D. Salinger",
      "details": [
        {
          "id": "7c05c197-474a-407b-b77d-5a054cd437d0",
          "info": "Published by ABC Publisher, ISBN: 93a24c6534114b31839a9bf23fc1ecd6"
        },
        {
          "id": "824582b9-ef81-48dc-b101-5111cbf9d19e",
          "info": "Published by XYZ Publisher, ISBN: 54f9f1a32099478988f4bf9b7fda1977"
        }
      ]
    }
  }
}
```
