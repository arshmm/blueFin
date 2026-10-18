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
| Forms    | react-hook-form + yup                                |
| HTTP     | axios, react-toastify for notifications              |
| Data     | Financial Modeling Prep API                          |
| Hosting  | Vercel (frontend)                                    |
| Backend  | ASP.NET Core Web API (.NET 8), Swagger               |
| Database | SQL Server + EF Core 8 (code-first migrations)       |
| Auth     | ASP.NET Identity + JWT bearer tokens                 |

## Layout

```
blueFin/
├── frontend/               # React + TypeScript client
│   ├── public/
│   ├── vercel.json         # SPA rewrite so deep links don't 404
│   └── src/
│       ├── Components/
│       │   ├── Card/, CardList/, Search/        # Company search results
│       │   ├── Portfolio/                       # Add / delete portfolio buttons
│       │   ├── CompanyProfile/, RatioList/      # Key metrics
│       │   ├── IncomeStatement/, BalanceSheet/,
│       │   │   CashflowStatement/               # Financial statements
│       │   ├── CompFinder/                      # Peer companies
│       │   ├── StockComment/, StockCommentList/,
│       │   │   StockCommentListItem/            # Discussion tab: comment form + list
│       │   └── Navbar/, Sidebar/, Table/, ...   # Layout + shared UI
│       ├── Context/        # useAuth: user + JWT, login / register / logout
│       ├── Helpers/        # ErrorHandler (API errors → toasts)
│       ├── Models/         # User, Comment, Portfolio types for the .NET API
│       ├── Pages/          # Home, Search, Company, Portfolio, Login, Register, DesignGuide
│       ├── Routes/         # React Router config + ProtectedRoute
│       ├── Services/       # AuthService, CommentService, PortfolioService (.NET API calls)
│       ├── Util/
│       │   ├── api.tsx              # FMP API calls
│       │   ├── freePlan.tsx         # Tickers available on FMP's free plan
│       │   └── numberFormatting.tsx
│       └── company.d.ts    # FMP response types
└── backend/                # ASP.NET Core Web API
    ├── Controllers/        # Account, Stock, Comment, Portfolio
    ├── Data/               # ApplicationDBContext (Identity + EF Core)
    ├── Dtos/, Mappers/     # Request/response shapes + mapping
    ├── Helpers/            # QueryObject / CommentQueryObject (filter, sort, paginate)
    ├── Interfaces/, Repository/  # Repository pattern
    ├── Service/            # TokenService (JWT), FMPService (stock lookup)
    ├── Migrations/         # EF Core migrations, incl. seeded users + portfolios
    └── Program.cs          # DI, auth, CORS, Swagger
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

Requires the .NET 8 SDK and SQL Server (LocalDB or SQL Express is fine).
Secrets live in `backend/appsettings.Development.json`, which is gitignored:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=blueFin;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Issuer": "http://localhost:5137",
    "Audience": "http://localhost:5137",
    "Key": "a-long-random-signing-key-at-least-64-characters"
  },
  "FMPKey": "your_fmp_key_here"
}
```

Then create the database and run the API:

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```

The API runs at http://localhost:5137, with Swagger at `/swagger`. The frontend
services point at that port.

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

- `.env` is gitignored. The FMP key is still called from the browser for the
  financial statements, so it ships in the JS bundle. The backend uses its own
  `FMPKey` to look up stocks when they're added to a portfolio.
- The .NET API isn't deployed. The frontend services call
  `http://localhost:5137`, so on Vercel, login, comments and portfolio only work
  with the API running locally.
- CORS currently allows any origin (`SetIsOriginAllowed(origin => true)`) for
  local development.
- Teddy's 10-K Finder and Historical Dividend lessons are skipped. Both use FMP
  endpoints that need a paid plan.
- `frontend/` was originally its own git repo; it has been flattened into this
  one so the whole project shares a single history.
- `App.test.tsx` still holds CRA's boilerplate test and currently fails. It
  doesn't affect `npm start` or `npm run build`.

## Progress

Tracking along with the series:

**Frontend**

- [x] React app scaffolded (CRA + TypeScript)
- [x] `Card` / `CardList` components
- [x] Search bar + company search via FMP API
- [x] Typed API responses (`company.d.ts`)
- [x] Routing (React Router) + company page
- [x] Company profile, income statement, balance sheet, cash flow
- [x] Portfolio add / delete (client-side)
- [x] Tailwind styling
- [x] Deployed to Vercel
- [x] Peer companies (CompFinder), loading spinner, number formatting
- [ ] ~~10-K Finder, Historical Dividend~~ (skipped, FMP paid plan)

**Backend**

- [x] .NET Web API project, models, controllers, DTOs
- [x] EF Core + SQL Server, async, repository pattern + DI
- [x] Stock CRUD with filtering, sorting and pagination
- [x] Comments (one-to-many) with create / update / delete and validation
- [x] ASP.NET Identity, register / login, JWT token service
- [x] Portfolios (many-to-many) get / create / delete
- [x] Comment authors (user-generated content), FMP stock lookup
- [x] Data seeding, CORS

**Frontend ↔ backend**

- [x] Auth context with JWT (login, register, protected routes, logout)
- [x] Stock comments: discussion tab with post + list
- [x] Portfolio persisted to the backend
- [x] Dedicated portfolio page with a stock table (beyond the series)

The series is complete, apart from the two skipped paid-API lessons.
