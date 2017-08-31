Baza se sastoji od 7 tabela.

1).Table Soba sadrzi osnovne informacije o sobi.
Kolona statusSobe je tipa bit i sadrzi inofrmacije o tome da li je soba slobodna ili zauzeta.

2).Tabela TipSobe sadrzi informacije o tipu (jednokrevetna,dvokrevetna..)
Takodje i kolonu opis koju nisam stigao da iskoristim.

3).Tabela SlikaSobe sadrzi sliku u binarnom zapisu koja je vezana za tip sobe.


4).Tabela Gost sadrzi osnovne informacije o gostu
kolona jmbg je vezana Unique contstraint-om


5).Table DodatnaUsluga  sadrzi informacije o tome koju vrstu obroka gost uzima prilikom cekiranja kao i cenu.


6).Tabela Cekiranje sadrzi informacije o cekiranju gosta

Kolona ukupnaCenaPoDanu sadrzi cenu cekiranja po danu tj. zbir cene dodatneUsluge sa cenom sobe, 
a ukupunu cenu boravka racunam u aplikaciji na osnovu kolicine(datuma) i ukupneCenePoDanu

7).Table Rezervacija sadrzi cekirane datume sobe ,jedna soba moze imati vise cekiranja.
Na osnovu ove tabele racunam slobodne termine cekiranja.
