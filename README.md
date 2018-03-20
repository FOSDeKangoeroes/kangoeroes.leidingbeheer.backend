# kangoeroes.backend [![Build Status](https://travis-ci.org/FOSDeKangoeroes/kangoeroes.backend.svg?branch=master)](https://travis-ci.org/FOSDeKangoeroes/kangoeroes.backend)
Backend voor leidingbeheer, poef, schulden en totems

# Structuur

## kangoeroes.core

Class library die alle domein logica bevat en alle herbruikbare klassen over de verschillende api's heen. Wordt opgenomen in andere projecten als reference

## kangoeroes.leidingbeheer

REST-api voor het beheren van leiding en takken

# How to run

## Database
Alle api's maken gebruik van 1 MySQL databank. Deze kan je aanmaken door `createSchema.sql` uit te voeren op een MySQL databank.

De naam van de databank kan vrij gekozen worden.
Noteer zeker volgende zaken, deze moeten aangevuld worden in de `appsettings.json` van alle api projecten. (Zie hieronder)

- Server (meestal `localhost`)
- Database naam
- Poort
- Gebruiker
- Wachtwoord

## Api (eender welke)

Om de api te kunnen starten moet er een appsettings.development.json file aanwezig zijn. Deze bevat waarden om de authenticatie werkzaam te krijgen. Ook de database connectie string moet hier ingevuld worden.
Deze json file moet aangevraagd worden.
