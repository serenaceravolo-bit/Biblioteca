# Biblioteca - Console Application (.NET C#)

## Descrizione

**Biblioteca** è un'applicazione console sviluppata in **C#** con **.NET**, progettata per simulare la gestione di una biblioteca.

L'applicazione consente di amministrare utenti, libri e prestiti attraverso un sistema di autenticazione con ruoli differenti (Amministratore e Utente). La persistenza dei dati è gestita tramite file **JSON**, senza l'utilizzo di un database relazionale.

Il progetto è stato realizzato come esercizio pratico per consolidare le competenze nello sviluppo con **C#** e **.NET**, con particolare attenzione alla programmazione orientata agli oggetti, all'organizzazione del codice e alla separazione delle responsabilità.

---

# Funzionalità

## Autenticazione

* Login tramite username e password.
* Password memorizzate in modo sicuro mediante hashing con salt.
* Registrazione di nuovi utenti.
* Gestione dei ruoli:

  * Amministratore
  * Utente

## Gestione utenti

Funzionalità riservate all'Amministratore:

* Registrazione di nuovi utenti.
* Visualizzazione dell'elenco degli utenti.

## Gestione libri

* Inserimento di nuovi libri.
* Visualizzazione del catalogo.
* Ricerca dei libri.
* Eliminazione dei libri.
* Visualizzazione della disponibilità dei volumi.

## Gestione prestiti

* Registrazione di nuovi prestiti.
* Restituzione dei libri.
* Aggiornamento automatico della disponibilità dei volumi.

---

# Tecnologie utilizzate

* C#
* .NET 10
* Programmazione Orientata agli Oggetti (OOP)
* Generics
* LINQ
* System.Text.Json
* Gestione dei file
* Console Application

---

# Struttura del progetto

```text
Biblioteca
│
├── Models
│   ├── Libro
│   ├── Prestito
│   ├── Utente
│   └── Biblio
│
├── Services
│   ├── BibliotecaService
│   ├── LibriService
│   ├── PrestitiService
│   └── UtentiService
│
├── Controllers
│   ├── Login
│   └── MenuController
│
├── UI
│   ├── MenuAdmin
│   └── MenuUtente
│
├── Utility
│   ├── PasswordHelper
│   ├── FileManager
│   └── Utility
│
├── Documenti
│   ├── libri.json
│   ├── utenti.json
│   └── prestiti.json
│
└── Avvio.cs
```

---

# Concetti applicati

Durante lo sviluppo del progetto sono stati approfonditi diversi concetti fondamentali della programmazione:

* Programmazione orientata agli oggetti (OOP).
* Incapsulamento.
* Separazione delle responsabilità (Separation of Concerns).
* Organizzazione del codice in modelli, servizi, controller e interfaccia utente.
* Utilizzo dei metodi generici.
* Interrogazione delle collezioni tramite LINQ.
* Persistenza dei dati mediante serializzazione e deserializzazione JSON.
* Gestione della sicurezza delle password tramite hashing con salt.

---

# Possibili sviluppi futuri

Il progetto può essere esteso introducendo nuove funzionalità, ad esempio:

* utilizzo di Entity Framework Core con database relazionale;
* validazioni più avanzate;
* logging delle operazioni;
* esportazione dei dati in PDF o Excel;
* interfaccia grafica con WPF o WinForms;
* sviluppo di API REST con ASP.NET Core.

---

# Obiettivo del progetto

L'obiettivo principale è stato realizzare un'applicazione completa che permettesse di consolidare le conoscenze acquisite durante il percorso di apprendimento di C# e .NET.

In particolare, il progetto ha consentito di approfondire:

* progettazione orientata agli oggetti;
* organizzazione del codice;
* gestione delle collezioni;
* persistenza dei dati;
* utilizzo delle librerie del framework .NET;
* sviluppo di un'applicazione completa, dalla progettazione all'implementazione.

---

# Note

Questo progetto è stato sviluppato a scopo didattico come esercizio pratico per consolidare le competenze nello sviluppo di applicazioni con **C#** e **.NET**.

Pur trattandosi di un progetto di apprendimento, è stato progettato seguendo principi di organizzazione del codice e di buona progettazione software, con particolare attenzione alla separazione delle responsabilità e alla manutenibilità dell'applicazione.
