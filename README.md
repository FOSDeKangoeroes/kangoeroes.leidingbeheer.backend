# Backend Kangoeroeplatform

Dit is de backend voor het volledige Kangoeroeplatform: totems, poef en schulden.
De backend bestaat uit een REST-api, geschreven in .NET 5.

## How to run

### 0. Prerequisites

- .NET 5 SDK
- SQL Server

### 1. Download

Dit commando gaat er van uit dat je een SSH key hebt toegevoegd (met voldoende rechten) aan je GitHub account. Niet aanwezig? Google is your friend.

``` git
git clone git@github.com:FOSDeKangoeroes/kangoeroes.backend.git
```

### 2. Settings

Om de applicatie aan de praat te krijgen, dien je een appsettings.development.json aan te maken. appsettings.json bevat reeds alle properties die nodig zijn. Je vindt deze in kangoeroes.webUI.

## Branching en deployments

Werk gebeurt op feature branches die eender welke naam mogen hebben. Deze worden dmv Pull Requests gemerged naar master. PRs triggeren een build en test flow. Bij mergen naar master wordt een deploy uitgevoerd naar staging. Als deze succesvol is, wordt hetzelfde gedeployed naar production. De deploy naar production gaat alleen door als er approval gegeven wordt.