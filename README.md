# Backend Kangoeroeplatform

Dit is de backend voor het volledige Kangoeroeplatform: totems, poef en schulden.
De backend bestaat uit een REST-api, geschreven in .NET Core 2.0

## How to run

### 0. Prerequisites

- Docker
- Docker compose (zit inbegrepen bij Docker)

### Download

Dit commando gaat er van uit dat je een SSH key hebt toegevoegd (met voldoende rechten) aan je GitHub account. Niet aanwezig? Google is your friend.

`git@github.com:FOSDeKangoeroes/kangoeroes.backend.git`

### 1. Environment variabelen

Alle omgevingsvariabelen dienen zich in de root van het project, in een .env bestand te bevinden.

`cp env.example .env`

De gegevens voor de database moeten niet gewijzigd worden, deze worden gebruikt bij het aanmaken van de MySQL container.

Voor de Auth0 variabelen dien je contact op te nemen met een persoon die over de gegevens beschikt.

### Initiële data

Wanneer de database container voor de eerste keer wordt aangemaakt, worden .sh, .sql en .sql.gz bestanden in de map `services/data/mariadb/initial-data` in alfabetische volgorde uitgevoerd. De applicatie voert bij het opstarten steeds de nodige migraties uit.


### Docker starten

In de root folder van het project voer je volgend commando uit:

`docker-compose up`

De applicatie zal draaien op localhost:500
De database zal draaien op localhost:3306
