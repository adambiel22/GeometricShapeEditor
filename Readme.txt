Będą istniały trzy rodzaje akcji aktualizacji:
- Przesunięcie zbioru wierzchołków o wektor
	- ta akcja będzie używana do przesunięcia
		- jednego wierzchołka
		- krawędzi, czyli dwóch sąsiadujących wierzchołków
		- wielokąta
- Zmiana promienia okręgu
- Przesunięcie środka okręgu

Istnieją również następujące relacje (w nawiasach napisane jakich obiektów dotyczy relacja):
1) zadana długość krawędzi (krawędź - długość)
2) zadany promień okręgu (okrąg/promień okręgu - długość)
3) usztywniony środek okręgu (okrąg/środek okręgu - punkt)
4) równe długości dwóch krawędzi (krawędź - krawędź)
5) styczność krawędzi (prostej) i okręgu (krawędź - okrąg)
6) krawędzie równoległe (krawędź - krawędź)

Dla krawędzi może być maksymalnie jedna relacja.
Dla okręgu nie mogą zachodzić na raz dwie relacje 2) i 3)

Dodatkowe założenia dotyczące implementacji:
- łatwe dodawanie nowych relacji 
- łatwe dodawanie nowych obiektów (?)

Algorytmu aktualizacji.

Akcja przesunięcia zbioru wierzchołków(W - zbiór wierzchołków, v - wektor o jaki przesuwamy, Z - zbiór obiektów, które zostały już zmienione):
	Przesuń wszystkie wierzchołki z W o wektor v.
	Do Z dodaj wszystkie wierzchołki z W.
	S - stos krawędzi
	Rozważ wszystkie krawędzie "e", które zawierają pewien wierzchołek ze zbioru W:
		Jeśli relacja krawędzi e nie jest spełniona, to wrzuć krawędź "e" na stos S.
	Dopóki stos S nie jest pusty:
		e = S.Pop(); e.relation.Napraw(Z, S)
		Jeśli relacja e to "zadana długość krawędzi":
			Jeśli istnieje wierzchołek w "e" (oznaczmy go "w"), który nie jest w "Z",
				Napraw "w", aby została spełniona relacja.
				Dodaj "w" do "Z".
				Jeśli istnieje krawędź, która zawiera "w", a dla której nie jest spełniona relacja, to dodaj tę krawędź na stos S.
			W przeciwnym wypadku:
				to przywróć sytuację do początkowej i zwróć, że się nie da wykonać akcji.
		W przeciwnym wypadku, jeśli relacja e to "równa długość krawędzi"
			Jeśli istnieje wierzchołek w "e" lub w krawędzi, która jest w relacji z "e" (oznaczmy go "w"), który nie jest w "Z", to
				Napraw w, aby została spełniona relacja.
				Dodaj "w" do "Z"
				Jeśli istnieje krawędź, która zawiera "w", a dla której nie jest spełniona relacja, to dodaj tę krawędź na stos S.
			W przeciwnym wypadku:
				przywróć sytuację do początkowej i zwróć, że się nie da wykonać akcji.	
		W przeciwnym wypadku, jeśli relacja e to "styczność krawędzi (prostej) do okręgu" (okrąg oznaczmy "o"):
			Jeśli istnieje wierzchołek w "e" (oznaczmy go "w"), który nie jest w "Z",
				to go napraw, aby została spełniona relacja.
				Dodaj "w" do "Z".
				Jeśli istnieje krawędź, która zawiera "w", a dla której nie jest spełniona relacja, to dodaj tę krawędź na stos S.
			W przeciwnym wypadku, jeśli promień "o" nie jest w "Z" i "o" nie ma relacji "zadany promień okręgu", to
				Napraw promień "o", tak aby została spełniona relacja.
				Dodaj promień "o" do "Z".
			W przeciwnym wypadku, jeśli środek "o" nie jest w "Z" i "o" nie ma relacji "usztywniony środek okręgu", to
				Napraw środek "o", tak aby została spełniona relacja.
				Dodaj środek "o" do "Z".
			W przeciwnym wypadku:
				przywróć sytuację do początkowej i zwróć, że się nie da wykonać akcji.	
		W przeciwnym wypadku, jeśli relacja e to "krawędzie równoległe":
			Jeśli istnieje wierzchołek w "e" lub w krawędzi, która jest w relacji z "e" (oznaczmy go "w"), który nie jest w "Z", to
				Napraw w, aby została spełniona relacja.
				Dodaj "w" do "Z".
				Jeśli istnieje krawędź, która zawiera "w", a dla której nie jest spełniona relacja, to dodaj tę krawędź na stos S.
			W przeciwnym wypadku:
				przywróć sytuację do początkowej i zwróć, że się nie da wykonać akcji.	
	Zwróć, że się udało wykonać akcję.
Akcja Zmiany promienia okręgu("o" - okrąg, którego zmieniany jest promień, d - długość o jaką zmienamy promień):
	Jeśli "o" nie ma relacji "zadany promień okręgu", to:
		Zmień promień okręgu "o" o "d".
	W przeciwnym wypadku
		Zwróć, że nie da się wykonać akcji.
	Jeśli "o" jest w relacji "styczność krawędzi (prostej) i okręgu" z krawędzią "e" oraz ta relacja nie jest spełniona, to:
		Popraw krawędź "e" tak, aby została spełniona relacja.
		Wykonaj akcję przesunięcia wierzchołków(W=wierzchołki "e", v - wektor zerowy, Z - zbiór zawierający promień okręgu "o").
		Jeśli nie udało się wykonać powyższej akcji, to przywróć sytuację do początkowej i zwróć, że nie da się wykonać akcji.
	Zwróć, że udało się wykonać akcję.
Akcja Przesunięcia środka okręgu("o" - okrąg, którego przesuwany jest środek, v - wektor o jaki przesuwamy środek):
	Jeśli "o" nie ma relacji "usztywniony środek okręgu", to:
		Przesuń środek "o" o "v";
	W przeciwnym wypadku
		Zwróć, że nie da się wykonać akcji.
	Jeśli "o" jest w relacji "styczność krawędzi (prostej) i okręgu" z krawędzią "e" oraz ta relacja nie jest spełniona, to:
		Popraw krawędź tak, aby została spełniona relacja.
		Wykonaj akcję przesunięcia wierzchołków(W=wierzchołki "e", v - wektor zerowy, Z - zbiór zawierający promień okręgu "o").
		Jeśli nie udało się wykonać powyższej akcji, to przywróć sytuację do początkowej i zwróć, że nie da się wykonać akcji.
	Zwróć, że udało się wykonać akcję.


Wnioski:
- wierzchołek powinien mieć dostęp do krawędzi, do których należy.
- krawędź powinna mieć dostęp do relacji.
- relacja powinna być sprawdzalna, czy jest spełniona.
- relacja powinna być naprawialna - podajemy jej typ relacji, obiekty zaangażowane w relację i wierzchołek, który chcemy naprawić. 