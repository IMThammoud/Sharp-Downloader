# Sharp-Downloader
Dokumentation: Sharp Downloader				Hammoud, Zak, Scholz



# Was ist der Sharpdownloader?
### → Eine WebApp die es ermöglich mit einer URL inhalte runterzuladen.(Videos in diesem Fall)

# Intention/Motivation dahinter?
### → Schon mal versucht etwas runterzuladen (natürlich nur legal) und wurdest zu gespammt von PopUps und Fenstern/Werbung?
### → Unsere App ermöglicht einfache Downloads ohne Kopfschmerzen

# Welchen Techstack haben wir genutzt?
### → C# als Sprache mit DotNetCore (WebAPI Template von Rider)
### → Front end ist eine simple HTML, die wir bearbeitet haben.


# Workflow des Downloaders :

#### 1 Client landet nach eingabe der Server-IP auf der Landing Page
#### 2 Client gibt zumbeispiel URL eines Youtube Videos in das Eingabe feld ein
#### 3 Client drückt auf Submit
#### 4 Post Request wird eingeleitet → URL wird an einen Endpunkt im Server geschickt
#### 5 Objekt für die Vorbereitung des Downloads wird erstellt
#### 6 URL wird als Attribut des Objekts gespeichert
#### 7 Eine Methode eines Objekts wird ausgeführt die einen System-Prozess auf dem startet
#### 8 Eine Binary wird in dem Prozess gestartet, die das Video runter lädt
#### 9 Der Endpunkt gibt das Video zurück an den Client → es erscheint als Download im Browser

## Probleme während der Erstellung:

Der Server hatte ständig gemeckert, dass der Medien-Typ des Inhalts den wir an den Client zurück schicken möchten nicht unterstützt wird.
Am Anfang dachten wir es sei der Browser oder die Art und weise wie der Client einen HTTP-Request an den Server schickt. Es war jedoch ein falsch angegebener Parameter in der Endpunkt-Methode UND der falsche Medien-Typ-Header in der Response.
Ein weiterer Knackpunkt war es lauffähig unter Windows10/11 zu machen. Die Tatsache, dass unser Downloader auf eine Binary basiert die unterschiedlich ausgeführt werden muss (je nach dem welches OS) war es zu Beginn schwierig die richtige Formatierung für Windows zu finden. Dieses Problem wurde umgangen mit einer Methode, die kontrolliert welches OS momentan vorhanden ist (Wahrscheinlich durch Environment Variablen). Wenn Win10/11 installiert war, wurde im Code von der Linux Formatierung auf die Win10/11 Formatierung geschaltet und das Programm lief einwandfrei weiter.

# Limitationen:
### Im aktuellen Stand kann nur ein Video runtergeladen werden. Es muss anschließend vom Server gelöscht werden um ein neues runterladen zu können.
### An einer Funktion, die die Videos löscht oder ihnen auch verschiedene Namen gibt haben wir zwar gearbeitet aber die Zeit war zu knapp, da wir unser erstes Projekt gecancelt haben.
## Featurewünsche:

Eine Funktion für Audio-only war in Bearbeitung aber hat es dann doch wegen der Zeit nicht in den commit geschafft.
Das Frontend ist simpel, aber etwas arm an Interaktionsmöglichkeiten. Hier hätten wir sicherlich mehr Zeit investieren können.
