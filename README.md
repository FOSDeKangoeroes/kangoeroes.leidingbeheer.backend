# Backend Kangoeroeplatform

Dit is de backend voor het volledige Kangoeroeplatform: totems, poef en schulden.
De backend bestaat uit een REST-api, geschreven in .NET Core 2.0

## How to run

### 0. Prerequisites

- Docker
- Docker compose (zit inbegrepen bij Docker)

### 1. Download

Dit commando gaat er van uit dat je een SSH key hebt toegevoegd (met voldoende rechten) aan je GitHub account. Niet aanwezig? Google is your friend.

``` git
git clone git@github.com:FOSDeKangoeroes/kangoeroes.backend.git
```

### 2. Environment variabelen

Alle omgevingsvariabelen dienen zich in de root van het project, in een .env bestand te bevinden.

``` shell
cp env.example .env
```

De gegevens voor de database moeten niet gewijzigd worden, deze worden gebruikt bij het aanmaken van de MySQL container.

### 3. Initiële data

Wanneer de database container voor de eerste keer wordt aangemaakt, worden .sh, .sql en .sql.gz bestanden in de map `services/data/mariadb/initial-data` in alfabetische volgorde uitgevoerd. De applicatie voert bij het opstarten steeds de nodige migraties uit.

### 4. Docker starten

In de root folder van het project voer je volgend commando uit:

``` shell
sudo docker-compose up
```

De eerste keer zal de backend falen om te starten. Dit omdat de database nog opgezet wordt. Nogmaals opstarten should fix it.

De applicatie zal draaien op localhost:5000

De database zal draaien op localhost:3306
