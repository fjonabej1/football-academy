# Architecture – Football Academy System

## 1. Overview

Ky projekt paraqet një sistem për menaxhimin e një akademie futbolli, i cili mundëson administrimin e lojtarëve, pagesave, trajnerëve, orareve të stërvitjeve dhe raporteve të performancës. Sistemi është ndërtuar duke përdorur një arkitekturë të ndarë në shtresa (Layered Architecture), me qëllim që të jetë i organizuar, i mirëmbajtshëm dhe i zgjerueshëm në të ardhmen.

Kodi i plotë i projektit mund të gjendet në:
https://github.com/fjonabej1/football-academy.git

---

## 2. Arkitektura e Përdorur

Projekti përdor kombinimin e:
- Layered Architecture
- Repository Pattern

Këto dy qasje ndihmojnë në ndarjen e përgjegjësive dhe reduktimin e varësive midis pjesëve të sistemit.

---

## 3. Shtresat e Projektit

### 📦 Models Layer

Kjo shtresë përmban klasat që përfaqësojnë strukturën e të dhënave të sistemit.

Shembuj:
- Player
- Coach
- Payment
- TrainingSession
- PerformanceReport
- Notification

**Përgjegjësitë:**
- Ruajtja e të dhënave (properties)
- Përfaqësimi i entiteteve reale

**Karakteristika:**
- Nuk përmban logjikë biznesi
- Ka vetëm të dhëna dhe metoda të thjeshta (p.sh. ToString)

---

### 📦 Data Layer

Kjo shtresë është përgjegjëse për menaxhimin e ruajtjes dhe leximit të të dhënave.

Përmban:
- IRepository (interface)
- FileRepository (implementimi konkret)

**Funksionaliteti:**
- GetAll() → merr të gjitha të dhënat
- GetById() → kërkon një element sipas ID
- Add() → shton një element
- Save() → ruan në file

**Teknologjia:**
- CSV file storage

---

### 📦 Services Layer

Kjo shtresë përmban logjikën e biznesit të sistemit dhe ndërmjetëson komunikimin midis UI dhe Data Layer.

Përmban:
- PlayerService
- PaymentService
- TrainingService
- NotificationService

**Përgjegjësitë:**
- Validimi i të dhënave
- Implementimi i rregullave të biznesit
- Thirrja e repository për ruajtje/lexim

**Shembuj:**
- Regjistrimi i një lojtari të ri
- Regjistrimi i pagesave
- Krijimi i orarit të stërvitjeve
- Dërgimi i njoftimeve

---

### 📦 UI Layer

Kjo shtresë është përgjegjëse për ndërveprimin me përdoruesin.

Përmban:
- Menu
- Input/Output në console

**Përgjegjësitë:**
- Marrja e input nga përdoruesi
- Shfaqja e rezultateve
- Thirrja e Services

**Karakteristika:**
- Nuk përmban logjikë biznesi
- Vepron vetëm si ndërfaqe

---

## 4. Rrjedha e të Dhënave (Data Flow)

Rrjedha e sistemit është si më poshtë:

User → UI → Service → Repository → File (CSV)

Shembull:
1. Përdoruesi shton një lojtar
2. UI thërret PlayerService
3. PlayerService validon të dhënat
4. Repository ruan lojtarin në CSV
5. Sistemi kthen përgjigje te përdoruesi

---

## 5. Vendimet e Dizajnit

### ✔ Layered Architecture
Është përdorur për:
- ndarje të qartë të përgjegjësive
- strukturë më të pastër të kodit
- mirëmbajtje më të lehtë

---

### ✔ Repository Pattern
Është përdorur për:
- ndarjen e logjikës së biznesit nga data access
- fleksibilitet në ndryshimin e storage (CSV → Database)
- testim më të lehtë

---

### ✔ CSV Storage
Është zgjedhur sepse:
- është i thjeshtë për implementim
- nuk kërkon database server
- është i përshtatshëm për projekt akademik

---

### ✔ Services Layer
Është përdorur për:
- centralizimin e logjikës së biznesit
- shmangien e kodit të tepërt në UI
- strukturë më profesionale

---

## 6. Zgjerimi në të Ardhmen

Ky sistem mund të zgjerohet me:

- Integrim me databazë (SQL Server)
- Krijim i API (ASP.NET Web API)
- Frontend me React
- Autentikim dhe autorizim
- Notifikime me email ose SMS
- Dashboard me statistika

---

## 7. Përfundim

Arkitektura e përdorur në këtë projekt siguron një ndarje të qartë të përgjegjësive dhe një strukturë të organizuar të kodit. Kjo qasje e bën sistemin të lehtë për mirëmbajtje dhe zgjerim në të ardhmen.

Përdorimi i Layered Architecture dhe Repository Pattern e bën këtë projekt të ngjashëm me aplikacione reale profesionale dhe përbën një bazë të fortë për zhvillime të mëtejshme.