# EF Core migration guide

## 1. Configure secrets

The development connection string in `AlshrouqSchool.Api/appsettings.json` targets LocalDB. For a shared or production environment, keep connection and LiveKit credentials out of source control:

```powershell
dotnet user-secrets --project AlshrouqSchool.Api set "ConnectionStrings:DefaultConnection" "Server=.;Database=AlshrouqSchool;Trusted_Connection=True;TrustServerCertificate=True"
dotnet user-secrets --project AlshrouqSchool.Api set "LiveKit:ApiKey" "your-key"
dotnet user-secrets --project AlshrouqSchool.Api set "LiveKit:ApiSecret" "your-secret"
```

In production, set the corresponding environment variables (`ConnectionStrings__DefaultConnection`, `LiveKit__ApiKey`, and `LiveKit__ApiSecret`) in the deployment platform.

## 2. Create the initial schema

Run these commands from the repository root. The DbContext is in Infrastructure and the startup project is the API.

```powershell
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef migrations add InitialSchoolSchema --project AlshrouqSchool.Infrastructure --startup-project AlshrouqSchool.Api --output-dir Data/Migrations
dotnet ef database update --project AlshrouqSchool.Infrastructure --startup-project AlshrouqSchool.Api
```

Review the generated migration before applying it. It includes the ASP.NET Identity tables (`AspNetUsers`, roles, claims, logins, and tokens) as well as the school schema.

## 3. Subsequent changes

```powershell
dotnet ef migrations add MeaningfulChangeName --project AlshrouqSchool.Infrastructure --startup-project AlshrouqSchool.Api --output-dir Data/Migrations
dotnet ef database update --project AlshrouqSchool.Infrastructure --startup-project AlshrouqSchool.Api
```

Do not edit a migration that has reached a shared environment. Create a new migration instead. The SQL Server filtered unique index on `AnswerChoices.QuestionId` permits at most one correct answer; the quiz command handler must also reject publishing a question with zero correct choices.

## CQRS boundaries

Put commands and handlers in `AlshrouqSchool.Application/Commands` and queries in `AlshrouqSchool.Application/Queries`. Handlers should validate that a teacher owns the relevant `TeachingAssignment`, that a student has an active `StudentEnrollment` for the target section, and that LiveKit tokens are issued only after those authorization checks. `ILiveKitService` lives in Application and its implementation lives in Infrastructure, preserving the dependency direction.
