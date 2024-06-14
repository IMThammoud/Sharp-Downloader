# Sharp-Downloader
Dokumentation: Sharp Downloader				



# Was ist der Sharpdownloader?
### → Eine WebApp die es ermöglich mit einer URL inhalte runterzuladen.(Videos, Audio etc. in diesem Fall)

# Intention/Motivation dahinter?
### → Schon mal versucht etwas runterzuladen (natürlich nur legal) und wurdest zu gespammt von PopUps und Fenstern/Werbung?
### → Unsere App ermöglicht einfache Downloads ohne Kopfschmerzen ( Wenn sie gehostet werden würde)

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
#### 7 Eine Methode eines Objekts wird ausgeführt die einen System-Prozess startet
#### 8 Eine Binary wird in dem Prozess gestartet, die das Medium runter lädt
#### 9 Der Endpunkt gibt das Video zurück an den Client → es erscheint als Download im Browser

# Limitationen:

## Featurewünsche:

