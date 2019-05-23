Aplikacja sluży do przechowywania kontaktów do znajomych i informacji o nich.

Obsługa powinna być dość intuicyjna za pomocą przycisków,
jedyny przypadek gdzie może być inaczej to konieczność kliknięcia na jeden z nagłówków tabeli, aby użyć sortowania.

Jeśli nie jest zainstalowany, należy zainstalować .NET Core ze strony https://dotnet.microsoft.com/download.

Następnie otwieramy w Visual Studio 2017 solution MyFriendsApp.sln.

Wybieramy View->SQL Server Object Explorer, aby obudzić lokalną bazę danych Visual Studio.

Potem wybieramy Tools->NuGet Package Manager->Package Manager Console i w tej konsoli wpisujemy "update-database".

Po tych krokach i po zbudowaniu projektu, aplikacja powinna dać się uruchomić.
