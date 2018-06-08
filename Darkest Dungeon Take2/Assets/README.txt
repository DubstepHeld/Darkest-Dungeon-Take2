Zum Spielen auf File>Build Settings und Reihenfolge der Szenen prüfen:
0 AlwaysLoad...
1 MainMenu
2 PopUpMenu
Build für Windows x86_64 getestet, andere Platformen funktionieren wahrscheinlich auch.
Anschließend "Build" und einen Speicherort wählen. Der Build lässt sich nun unabhängig verschieben. 

Wenn Sie das Spiel aus dem Editor starten, zuerst File>Open Scene und im Ordner Scenes "AlwasyL...Scene.unity" laden. Sonst fehlt ein wichtiges Objekt und das Spiel funktioniert nicht. 
Bei Testläufen hat das Spiel über den Editor Probleme bereitet, daher sicherheitshalber lieber als Build spielen. 
Consolenoutputs durch Debug.Log(""); sind nicht weiter relevant und haben nur als Hilfestellung beim Programmieren gedient.