# blueFin

A full-stack stock market app — search companies, view financials, and build a
personal portfolio. Built as a learning project while following
[Teddy Smith's React + .NET Web API series](https://www.youtube.com/@teddysmithdev).

## Stack

| Layer    | Tech                                                 |
| -------- | ---------------------------------------------------- |
| Frontend | React 19, TypeScript, Create React App               |
| HTTP     | axios                                                |
| Data     | Financial Modeling Prep API                          |
| Backend  | ASP.NET Core Web API (.NET 8) — *not yet scaffolded* |
| Database | SQL Server + EF Core — *planned*                      |
| Auth     | ASP.NET Identity + JWT — *planned*                    |

## Layout

```
blueFin/
├── frontend/          # React + TypeScript client
│   ├── public/
│   └── src/
│       ├── Components/
│       │   ├── Card/       # Single company result
│       │   ├── CardList/   # Renders search results
│       │   └── Search/     # Search bar
│       ├── Pages/          # Route-level views
│       ├── api.tsx         # FMP API calls
│       └── company.d.ts    # FMP response types
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

Requires a [Financial Modeling Prep](https://site.financialmodelingprep.com/)
API key. Create `frontend/.env`:

```
REACT_APP_API_KEY=your_key_here
```

Restart the dev server after creating it — CRA only reads `.env` at startup.

### Backend

Not created yet. Once it exists:

```bash
cd backend
dotnet restore
dotnet run
```

## Notes

- `.env` is gitignored. The key is currently called from the browser, so it
  ships in the JS bundle — it moves behind the .NET API later in the series.
- `frontend/` was originally its own git repo; it has been flattened into this
  one so the whole project shares a single history.
- `App.test.tsx` still holds CRA's boilerplate test and currently fails. It
  doesn't affect `npm start` or `npm run build`.

## Progress

Tracking along with the series:

- [x] React app scaffolded (CRA + TypeScript)
- [x] `Card` / `CardList` components
- [x] Search bar + company search via FMP API
- [x] Typed API responses (`company.d.ts`)
- [ ] Company profile / details page
- [ ] .NET Web API project
- [ ] EF Core + database
- [ ] Auth (Identity + JWT)
- [ ] Portfolio features
