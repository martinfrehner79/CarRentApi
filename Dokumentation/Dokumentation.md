# Arc 42 Dokumentation

![CarRent Logo](./images/logo.png)

# Autovermietung CarRent

Diese Dokumentation wurde auf der Grundlage von arc 42 erstellt.

## Über arc42

arc42, das Template zur Dokumentation von Software- und
Systemarchitekturen.

Erstellt von Dr. Gernot Starke, Dr. Peter Hruschka und Mitwirkenden.

Template Revision: 7.0 DE (asciidoc-based), January 2017

© We acknowledge that this document uses material from the arc 42
architecture template, <http://www.arc42.de>. Created by Dr. Peter
Hruschka & Dr. Gernot Starke.


# Aufgabenstellung

## Big Picture

Es soll ein neues Autovermietungssystem „CarRent“ erstellt werden. Das System soll aus einem Server-Teil und einen Web-Client bestehen.  

* Die Daten sollen mittels Repository Pattern in eine Datenbank gespeichert werden können.
* Die Business Logik soll auf dem Backend laufen und REST APIs anbieten.
* Für Kunden und Mitarbeiter soll ein Web Frontend zur Verfügung stehen.

Die Weblösung soll es Kunden ermöglichen 24/7 Reservationen zu tätigen dadurch sollen neue Kunden gewonnen werden. 
Da sowohl Kunden wie auch Mitarbeiter dasselbe System benutzen sind die Daten jederzeit Konsistent.

## Use Cases

* Use Case 1: Reservationen tätigen:
Kunden können über das Web Frontend Reservationen erfassen.

* Use Case 2: Kundendaten verwalten extern:
Kunden können Ihre Daten über das Web Frontend erfassen und verwalten.

* Use Case 3: Kundendaten verwalten intern:
Mitarbeiter können Kunden suchen und die Daten verwalten.

* Use Case 4: Autos verwalten:
Mitarbeiter können Autos suchen und verwalten.

* Use Case 5: Mietvertrag erstellen:
Mitarbeiter können aus Reservationen Mitverträge erstellen.

* Use Case 6: Tagespreise verwalten:
Mitarbeiter können für Fahrzeugklassen Tagespreise vewalten.

* Use Case 7: Fahrzeugklassen verwalten:
Mitarbeiter können Fahrzeugklassen verwalten und diese Fahrzeugen zuordnen.

* Use Case 8: Hersteller verwlaten:
Mitarbeiter können Fahrzeughersteller verwalten und diese Fahrzeugen zuordnen.

## Qualitätsziele

1. Verfügbarkeit: Das System soll jederzeit für Kunden und Mitarbeit zuer Verfügung stehen. 
2. Usability: Die Bedienung der Software soll intuitiv und einfach sein - auch für neue Kunden.
3. Erweiterbarkeit: Die Software soll einfach erweiterbar sein.
4. Performance: Die Software soll durchwegs schnelle Anwortzeiten aufweisen.

## Stakeholder

Folgende Stakeholder sind definiert:

| Rolle               | Kontakt            | Erwartungshaltung                              |
| ------------------- | ------------------ | ---------------------------------------------- |
| GL CarRent          | M. Yoda            | Stabile und flexible Software, Kostenkontrolle |
| Kunden CarRent      | Kunden             | Schnelle Antwortzeiten, Intuitive Bedienung    |
| Mitarbeiter CarRent | O. Kenobi          | Inutive Bedienung, Erweiterbarkeit             |
| Entwickler          | M. Frehner         | Klare Anforderungen                            |


# Randbedingungen

<dl>
<dt> Implementierung </dt>
<dd> VS2019,...</dd>
<dt> Continuous Integration und Metriken </dt>
<dd> CI/CD (Travis, GitLab, ...), SonarQube, StyleCop, …  </dd>
<dt> Dokumentation </dt>
<dd> Arc42 </dd>
</dl>


# Kontextabrenzung

Die CarRent Applikation ist selbständig es existieren keine Schnittstellen zu Fremdsystemen.
Die Bedieungen der Applikation erfolgt über ein WebFrontend welches sowohl für Kunden als auch für Mitarbeiter zur Verfügung steht.

## Fachlicher Kontext

![alt text](./images/FachlicherKontext.png "Fachlicher Kontext")

Das WebFrontend steht sowohl für Kunden als auch für Mitarbeiter zur Verfügung. 
Die Akteuere haben jeweils eine eigene Ansicht mit verschienden Berechtigungen.

## Technischer Kontext

![alt text](./images/TechnischerKontext.png "Technischer Kontext")

Über das Fronend wird mittels WebBrowser via HTTPS auf das Backend zugegriffen.  
Das Backend leitet die Anfragen mittels EF auf die Datenbank weiter. 
Diese speichert dann die Daten lokal auf der MSSQL Datenbank.

## Lösungsstrategie

Die folgende Tabelle stellt die Qualitätsziele von CarRent passenden Architekturansätzen gegenüber, und erleichtert so einen Einstieg in die Lösung.

| Qualitätsziel        | Dem Qualitätsziel zuträgliche Ansätze in der Architektur                              |
|----------------------|---------------------------------------------------------------------------------------|
| Performance          | mit den HTTP Requests werden nur einzelne Daten abgefragt, keine komplexen Strukturen |        
| Datenqualität        | Die MSSQL Datenbank übernimmt die persistente Speicherung der Daten.                  |
| Usability            | Das WebFrontend wird mit Agular einach und übersichtlich gestaltet.                   |
| Installierbarkeit    | Das WebFrontend benötigt keine Installation.                                          |
| Erweiterbarkeit      | Objektorientierte Programmierung und stabile Interfaces.                              |


# Bausteinansicht

## Whitebox Gesamtsystem

![alt text](./images/WhiteboxGesamtsystem.png "Komponenten Diagramm")

### Begründung

!Die Implementierung des Frontends muss noch definiert werden.  
In der API wird die Bussinesslogik der Reservierungsplattform für Automarken (CarBrands), Fahrzeugklassen (CarClass), Fahrzeuge (Cars)
Kunden (Customers), Tagespreise (DailyFees), Verträge (Contracts) und Reservierungen (Reservations) implementiert. Für jede Klasse existiert jeweils ein Controller
welcher die Kommunikation zwischen Frontend und Backend steuert.

## Enthaltene Bausteine

<dl>
<dt>CarBrands</dt>
<dd>Enthält Informationen zu den Fahrzeugherstellern. Können von Mitarbeitern verwaltet werden</dd>
<dt>CarClass</dt>
<dd>Enthält Informationen zu den Fahrzeugklassen. Der Kunde reserviert jeweils eine Klasse nicht ein Fahrzeug. Die Fahrzeugklasse</dd>
<dd>ist relevant für den Tagespreis. Diese Date können von den Mitarbeitern verwaltet werden.</dd>
<dt>Cars</dt>
<dd>Fahrzeug enthält die Informationen zu einem jeweiligen Fahrzeug. Ein Fahrzeug ist einer bestimmten Klasse und einem Hersteller zugeordnet</dd>
<dt>Customers</dt>
<dd>Kunde enthält die Infos zu den jeweiligen Kunden. Ein Kunde kann eine Fahrzeugklasse ab einem Datum für eine Anzahl Tage reservieren.</dd>
<dt>DailyFees</dt>
<dd>Die Tagespreise pro Fahrzeugklasse werden historisch gespeichert und gelten jeweils für eine Fahrzeugklasse</dd>
<dt>Contracts</dt>
<dd>Ein Vertrag kommt dann zustande wenn der Kunde sein Fahrzeug abholt. Dabei wird eine Reservation in einen Vertrag umgewandelt. Diese Arbeit</dd>
<dd>muss von einem Mitarbeiter erledigt werden. 
<dt>Reservations</dt>
<dd>Eine Reservation benötigt ein Kunde, eine Autoklasse, das Startdatum und die Mietdauer. Ein entsprechendes Fahrzeug wird dann vom Mitarbeiter</dd>
<dd>bei der Reservation zugeordnet.</dd>
</dl>


# Infrastruktur Ebene

## Begründung

Die Vorgabe des Projekts war für die Infrastruktur entscheidend und musste wie folgt beschrieben umgesetzt werden:  
Das System soll aus einem Server-Teil und einem Web-Client bestehen. Die Daten sollen mittels EF und Repository Pattern in eine relationale Datenbank gespeichert werden können. 
Die Business Logik soll auf einem Application Server laufen und einen RESTFul WebService Schnittstelle (WebAPI) anbieten. Der Web-Client benutzt die WebAPI um die Funktionen auszuführen.

# Domänenmodel

Das Domänenmodel zeigt die Beziehungen der einzelnen Entitäten zu einander auf.

![alt text](./images/Domänenmodel.png "Domänenmodel")

# Entwurfsentscheidungen 

Gemäss Vorgabe wurde das Projekt als .NET Core Api realisiert. Um die Datenanbindung einfach und erweiterbar zu gestalten wurde EF mit Repsitory Pattern implementiert.
Um eine Verfügbarkeit für die verschiedenen Stakeholder zu gewährleisten soll die Applikation auf Azure gehostet werden. Das Frontend wurde noch nicht implementiert 
und somit noch kein definitiver Entscheid für die zu verwendende Technik gefällt.

## Glossar

| Begriff                   | Definition                                   |
|---------------------------|----------------------------------------------|
| EF (Entity Framework)     | Object-Relationship Mapper für MSSQL         |

