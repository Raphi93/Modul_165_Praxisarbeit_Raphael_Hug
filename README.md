# Modul_165_Praxisarbeit_Raphael_Hug

## Hintergrund
Die Firma Jetstream-Service führt als KMU in der Wintersaison Skiservicearbeiten durch und hat in den letzten Jahren grosse Investitionen in eine durchgängige digitale Auftragsanmeldung und Verwaltung getätigt. Das bestehende System besteht aus einer datenbankbasierten Web-Anmeldung und Auftragsverwaltung. Die gute Auftragslage hat dazu geführt, dass sich die Geschäftsführung für eine Diversifizierung mit Neueröffnungen an verschiedenen Standorten entschieden hat. Die bislang eingesetzte relationale Datenbank genügt den damit verbundenen Anforderungen an Datenverteilung und Skalierung nicht mehr.

## Ziel
Um den neuen Anforderungen gerecht zu werden und Lizenzkosten einzusparen, soll die Datenbank im Backend der Anwendung auf ein NoSQL-Datenbanksystem migriert werden.

## Vorgehen
Das Vorgehen bei der Migration wird wie folgt aussehen:
1. Auswahl eines geeigneten NoSQL-Systems, das den Anforderungen entspricht
2. Analyse der Datenbankstruktur und Daten
3. Konzeption und Implementierung eines Migrationsplans
4. Migration der Daten
5. Überprüfung und Test der Datenintegrität
6. Anpassung der Anwendung an das neue Datenbanksystem

## Risiken
Bei der Migration auf ein neues Datenbanksystem können verschiedene Risiken auftreten, wie beispielsweise Datenverlust oder -beschädigung, Systeminstabilität oder eine schlechte Performance. Um diese Risiken zu minimieren, werden folgende Massnahmen ergriffen:
- Backup der Datenbank und regelmässige Sicherungen während der Migration
- Tests der Migration in einer Testumgebung vor der Durchführung auf dem Produktivsystem
- Überwachung der Systemleistung während und nach der Migration

## Fazit
Die Migration der Jetstream-Service-Datenbank auf ein NoSQL-Datenbanksystem ist eine notwendige Massnahme, um den Anforderungen der Diversifizierung gerecht zu werden und Lizenzkosten einzusparen. Durch eine sorgfältige Planung und Umsetzung der Migration können Risiken minimiert und eine reibungslose Integration des neuen Datenbanksystems in die bestehende Anwendung erreicht werden.
