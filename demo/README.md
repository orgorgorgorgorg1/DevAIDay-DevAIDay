# Demo: ADO → GitHub security journey

This folder contains **intentionally outdated / vulnerable** dependencies used
to demonstrate GitHub's supply-chain security features at DevAI Day for KPN.

## What lights up

| Ecosystem      | File                                  | Sample advisory                          |
|----------------|---------------------------------------|------------------------------------------|
| NuGet          | `LegacyDemo/LegacyDemo.csproj`        | Newtonsoft.Json GHSA-5crp-9r3c-p9vr      |
| NuGet          | `LegacyDemo/LegacyDemo.csproj`        | Azure.Identity CVE-2024-35255            |
| NuGet          | `LegacyDemo/LegacyDemo.csproj`        | System.Drawing.Common CVE-2021-24112     |
| npm            | `legacy-web/package.json`             | lodash prototype pollution               |
| npm            | `legacy-web/package.json`             | axios SSRF CVE-2020-28168                |
| npm            | `legacy-web/package.json`             | minimist prototype pollution             |
| GitHub Actions | `.github/workflows/legacy-pipeline.yml` | old `actions/checkout@v2`, `setup-dotnet@v1` |
| Docker         | `demo/Dockerfile.legacy`              | `dotnet/aspnet:6.0` outdated tag         |

## Build safety

`LegacyDemo.csproj` is **not** included in `eShopOnWeb.sln`, and
`legacy-web/package.json` has no install step wired into CI, so the main app
still builds and runs normally. The files exist purely so Dependabot, the
Dependency graph, secret scanning, and CodeQL can surface real alerts during
the talk.
