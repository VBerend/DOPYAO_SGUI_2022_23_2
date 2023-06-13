# DOPYAO_SGUI_2022_23_2

README-t általában telepítési útmutatásra szokták használni, de most ide írom a leírást.

Projekt leírás

Haladó fejlesztés technikán készített projekt állapotát használtam, viszont ebben sajnos a update nincs benne, mert azt régen nem csináltam meg.

Ezeket a metódusokat használtam.

Js clientben a delete működik, viszont a create-nél van valami hiba, hogy requirednek kéri a mezőket(ezt tudom, hogy miért és nem baj), viszont amikor adok meg adatot, beleírom a kivánt szöveget vagy adatot akkor sem fogadja el és nem hozza létre a kért entitást.

Display funkciónal én megjelenítem mind a három táblán Adopter mint örökbefogadó, Shelter mint menhely és Animal mint örökbefogadott/fogadható állatok.

GetData-val mind a három táblából lekérem a kivánt adatokat.

Animal-t nem lehet törölni mert az animalöket használom kapcsoló táblának, ők kötik össze a menhelyeket és az örökbefogadókat.

Találtam még korábban egy hibát, hogy többszöri elindítás után error-t dob a backend, hogy létezik már adopter a Db-ben, ezt kilehet azzal küszöbölni, hogy tovább engeded a programot, és utána egy ráfrissítéssel, megjelennek az adatok.
