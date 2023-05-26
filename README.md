# Autorizace a Autentifikace v .NET (mobilní aplikace) za pomoci Keycloak
Mobilní aplikace k této bakalářské práce má velmi omezenou funkčnost a slouží pouze jako POC (Proof of concept).
Nabízí přihlášení pomocí Keycloak, odhlášení pomocí Keycloak a zobrazení seznamu předmětů (pokud má uživatel dostatečné oprávnění).
Repozitář k rozsáhlejší webové aplikaci najdete [zde](https://github.com/frycjosef/Authorization-Authentification-in-.NET/tree/master)

## Postup
1. Po spuštění aplikace vidíte na obrazovce přihlašovací stránku s tlačítkem Login with Keycloak
2. Klikněte na tlačítko 
3. Budete přesměrováni na webové rozhraní Keycloak
4. Zadejte uživatelské jméno, heslo a přihlaste se
5. Zadejte OTP vygenerované na Vašem mobilním zařízení
6. Po přihlášení mohou nastat dvě varianty
   - Pokud uživatel má dostatečná oprávnění pro čtení předmětů (role "ReadSubjects"), zobrazí se na obrazovce seznam předmětů
   - Pokud uživatel nemá oprávnění, zobrazí se stránka s nápisem Access Denied (Přístup zamítnut)
7. Na obou výše zmíněných stránkách se nachází tlačítkou Logout
8. Pro odhlášení klikněte na tlačítko Logout
