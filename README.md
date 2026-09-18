# blueFin

A full-stack stock market app — browse companies, view financials, and build a
personal portfolio. Built as a learning project while following
[Teddy Smith's React + .NET Web API series](https://www.youtube.com/@teddysmithdev).

## Stack

| Layer    | Tech                                                |
| -------- | --------------------------------------------------- |
| Frontend | React 19, TypeScript, Create React App              |
| Backend  | ASP.NET Core Web API (.NET 8) — *not yet scaffolded* |
| Database | SQL Server + EF Core — *planned*                     |
| Auth     | ASP.NET Identity + JWT — *planned*                   |
| Data     | Financial Modeling Prep API — *planned*              |

## Layout

```
blueFin/
├── frontend/          # React + TypeScript client
│   ├── public/
│   └── src/
│       ├── Components/    # Reusable UI (Card, CardList, ...)
│       └── Pages/         # Route-level views
└── backend/           # ASP.NET Core Web API (coming)
```

## Getting started

### Frontend

```bash
cd frontend
npm install
npm start
```

Runs at http://localhost:3000.

### Backend

Not created yet. Once it exists:

```bash
cd backend
dotnet restore
dotnet run
```

## Notes

- `appsettings.Development.json` is gitignored — API keys and connection
  strings live there and stay off GitHub.
- `frontend/` was originally its own git repo; it has been flattened into this
  one so the whole project shares a single history.

## Progress

Tracking along with the series:

- [x] React app scaffolded (CRA + TypeScript)
- [x] `Card` / `CardList` components
- [ ] Search + Financial Modeling Prep API
- [ ] .NET Web API project
- [ ] EF Core + database
- [ ] Auth (Identity + JWT)
- [ ] Portfolio features
