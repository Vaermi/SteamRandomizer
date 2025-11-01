# Projektplan: SteamRandomizer App

## Architektur 

### Frontend
- WPF (.NET 7)
- MVVM-Pattern für saubere Trennung von UI und Logik
- Lokalisierung via ResourceDictionary (Deutsch/Englisch)
- Authentifizierung & Nutzerverwaltung
- Steam OpenID für Login
- Firebase Firestore zur Speicherung von Nutzerdaten (z. B. Steam-ID, Favoriten, Statistiken)
- Keine Speicherung von Passwörtern – Authentifizierung läuft über Steam

### Backend / Services
- Steam Web API für Spieledaten
- Firebase SDK für Datenzugriff und Nutzerverwaltung
- MongoDB Atlas für persistente Speicherung von Spiel- und Nutzerdaten
- Optionale REST-Service-Schicht zur Trennung von Datenzugriff und UI

### Datenmodell
- User: Steam-ID, Anzeigename, Favoritenliste, Filterpräferenzen
- Game: Steam-App-ID, Name, Genre, Spielzeit, Multiplayer-Flag
- SuggestionLog: User-ID, Spiel-ID, Zeitstempel, Filterkriterien

### Sicherheit
- OAuth/OpenID über Steam – keine lokalen Passwörter
- Zugriffsbeschränkung auf Nutzerdaten (nur eigene Favoriten und Logs sichtbar)
- API-Schlüssel und sensible Daten in .env oder Secrets.json ausgelagert

### Persistenz & Caching
- MongoDB für dauerhafte Speicherung
- Lokales Caching (z. B. MemoryCache) für häufig genutzte Spieledaten

### Deployment & Updates
- ClickOnce oder MSIX für einfache Installation
- Automatische Updateprüfung beim Start
- Crash-Reporting optional via AppCenter oder Sentry
	
## Phase 1: Setup
- .gitignore konfigurieren ✅
- Firebase-Projekt erstellen 🔲
- Steam OpenID-Login vorbereiten und testen 🔲
- MongoDB-Datenbank einrichten ✅
- Projektstruktur festlegen 🔲
  
## Phase 2: Grundfunktionen
- Steam-Login mit OpenID implementieren 🔲
- Steam-API anbinden und Spiele abrufen 🔲
- MongoDB-Datenmodell für Spiele und Userdaten definieren 🔲
- Beispielspiele einfügen und testen 🔲
  
## Phase 3: Kernfunktionen
- Zufallsgenerator für Spielauswahl 🔲
- Filterfunktionen (Genre, Spielzeit, Multiplayer) 🔲
- Favoritenverwaltung pro User 🔲
- Statistiken (Vorschläge, Spielhäufigkeit) 🔲
  
## Phase 4: UI & UX
- WPF-Fenster für Login, Hauptansicht, Filter 🔲
- Ladeindikatoren, Fehlermeldungen 🔲
- Lokalisierung (Deutsch/Englisch) 🔲
  
## Phase 5: Veröffentlichung
- Installer erstellen (ClickOnce oder MSIX) 🔲
- Dokumentation schreiben 🔲
- Updates planen 🔲
- API-Schlüssel sichern 🔲

Legende:
- ☐ Aufgabe offen  
- ☑ Aufgabe erledigt  
- ✅ Fertig  
- ❌ Nicht erledigt  
- 🔲 Offen  
- 🟩 Erledigt

