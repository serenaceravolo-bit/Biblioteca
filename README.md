📚 Biblioteca - Console Application (.NET C#)

Descrizione

Biblioteca è un'applicazione console sviluppata in C#/.NET per la gestione di una biblioteca.

Il progetto permette di gestire utenti, libri e prestiti tramite un sistema di autenticazione con ruoli differenti (Amministratore e Utente). I dati vengono persistiti in file JSON, senza l'utilizzo di un database.

Questo progetto è stato realizzato come esercizio di apprendimento della piattaforma .NET con particolare attenzione ai principi della programmazione orientata agli oggetti e all'organizzazione del codice.

---

Funzionalità

Autenticazione

- Login tramite username e password (verifica password tramite hashing)
- Registrazione con hashing password
- Gestione dei ruoli:
  - Amministratore
  - Utente

Gestione utenti (Amministratore)

- Registrazione nuovi utenti con hashing password
- Visualizzazione utenti registrati

Gestione libri

- Inserimento di nuovi libri
- Visualizzazione catalogo con indicazione di disponibilità
- Ricerca dei libri
- Eliminazione dei libri

Gestione prestiti

- Registrazione di un prestito
- Restituzione di un libro

---

Tecnologie utilizzate

- C#
- .NET 10
- Programmazione orientata agli oggetti (OOP)
- Programmazione generica (Generics)
- LINQ
- Serializzazione e deserializzazione JSON ("System.Text.Json")
- Gestione file
- Console Application

---

Struttura del progetto

Biblioteca
- Models
  - Libro
  - Prestito
  - Utente
- Services
  - BibliotecaService
  - LibriService
  - UtentiService
  - PrestitiService
- UI
  - MenuUtente
  - MenuAdmin
- Controllers
  - MenuController
  - Login
- Utility
  - Utility
  - PasswordHelper
  - GestioneFile
- Documenti
  - libri.json
  - utenti.json
  - prestiti.json
- Avvio.cs

---

Concetti applicati

Durante lo sviluppo sono stati utilizzati diversi concetti della programmazione ad oggetti:

- incapsulamento
- classi e oggetti
- separazione delle responsabilità
- utilizzo di metodi generici
- utilizzo di LINQ per interrogare le collezioni
- persistenza dei dati tramite file JSON
- Sicurezza delle password tramite hashing.

---

Possibili sviluppi futuri

- utilizzo di Entity Framework Core con database relazionale
- validazioni più avanzate
- logging delle operazioni
- interfaccia grafica (WPF o WinForms)
- API REST con ASP.NET Core

---

Obiettivo del progetto

Lo scopo del progetto è stato approfondire lo sviluppo di applicazioni in C# e .NET, consolidando le conoscenze su:

- progettazione orientata agli oggetti
- gestione dei dati
- organizzazione del codice
- utilizzo delle librerie del framework
- sviluppo di un'applicazione completa, dalla progettazione alla persistenza dei dati

---

Note

Questo progetto è stato sviluppato a scopo didattico e rappresenta un esercizio pratico per consolidare l'apprendimento del linguaggio C# e della piattaforma .NET.
