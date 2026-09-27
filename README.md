# blueFin

A full-stack stock market app — search companies, view financials, and build a
personal portfolio. Built as a learning project while following
[Teddy Smith's React + .NET Web API series](https://www.youtube.com/@teddysmithdev).

## Stack

| Layer    | Tech                                                 |
| -------- | ---------------------------------------------------- |
| Frontend | React 19, TypeScript, Create React App               |
| Routing  | React Router 7                                       |
| Styling  | Tailwind CSS 3                                       |
| HTTP     | axios                                                |
| Data     | Financial Modeling Prep API                          |
| Hosting  | Vercel                                               |
| Backend  | ASP.NET Core Web API (.NET 8) — *not yet scaffolded* |
| Database | SQL Server + EF Core — *planned*                      |
| Auth     | ASP.NET Identity + JWT — *planned*                    |

## Layout

```
blueFin/
├── frontend/               # React + TypeScript client
│   ├── public/
│   ├── vercel.json         # SPA rewrite so deep links don't 404
│   └── src/
│       ├── Components/
│       │   ├── Card/, CardList/, Search/        # Company search results
│       │   ├── Portfolio/                       # Add / list / delete portfolio items
│       │   ├── CompanyProfile/, RatioList/      # Key metrics
│       │   ├── IncomeStatement/, BalanceSheet/,
│       │   │   CashflowStatement/               # Financial statements
│       │   ├── CompFinder/                      # Peer companies
│       │   └── Navbar/, Sidebar/, Table/, ...   # Layout + shared UI
│       ├── Pages/          # HomePage, SearchPage, CompanyPage, DesignGuide
│       ├── Routes/         # React Router config
│       ├── Util/
│       │   ├── api.tsx              # FMP API calls
│       │   ├── freePlan.tsx         # Tickers available on FMP's free plan
│       │   └── numberFormatting.tsx
│       └── company.d.ts    # FMP response types
└── backend/                # ASP.NET Core Web API (coming)
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

## Deployment

The frontend is deployed on [Vercel](https://vercel.com) from this repo.

1. **Add New → Project** in Vercel and import `arshmm/blueFin`.
2. Set **Root Directory** to `frontend` (framework preset: Create React App).
3. Add the environment variable `REACT_APP_API_KEY`.
4. Deploy. Every push to `master` redeploys automatically.

`frontend/vercel.json` rewrites all paths to `index.html`, so client-side routes
like `/company/AAPL/income-statement` survive a refresh. Vercel builds with
`CI=true`, which makes CRA treat ESLint warnings as errors — run
`CI=true npm run build` locally first, or set `CI=false` in Vercel. After changing
an env var in Vercel, redeploy so it's baked into the new build.

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
- [x] Routing (React Router) + company page
- [x] Company profile, income statement, balance sheet, cash flow
- [x] Portfolio add / delete (client-side)
- [x] Tailwind styling
- [x] Deployed to Vercel
- [ ] .NET Web API project
- [ ] EF Core + database
- [ ] Auth (Identity + JWT)
- [ ] Portfolio persisted to the backend
