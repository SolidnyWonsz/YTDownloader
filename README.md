# YTDownloader

Prosty i szybki menedżer pobierania filmów bądź audio z serwisu Youtube.

# Co to jest?
YTDownloader jest programem umożliwiającym intuicyjne i szybkie pobieranie wybranych filmów z Youtube, w dowolnym obsługiwanym formacie.

## Obsługiwane formaty:
- Wideo:
  - MP4
  - MKV
  - WEBM
- Audio:
  - MP3
  - OGG
  - FLAC
  - WAV
  - M4A

# Instalacja

YTDownloader na razie nie zawiera żadnego instalatora. Program należy wypakować z archiwum .zip i uruchomić poprzez otworzenie `YTDownloader.exe`. Reszta programów .exe jest potrzebna do poprawnego działania programu i należy ich nie uruchamiać. Zalecana ścieżka w której można umieścić program to `C:\Program Files\YTDownloader`, przy czym katalog `YTDownloader` należy utworzyć samemu.

# Obsługa

## Pobieranie
Aby zacząć pobieranie, wybierz na górnym pasku opcję **Plik**, a potem **Dodaj URL**. W przypadku gdy masz już skopiowany link, YTDownloader automatycznie go wklei.  
Wybierz następnie format pliku jaki chcesz. YTDownloader pobiera pliki do folderu wybranego w ustawieniach programu. Możesz to zmienić w **Edycja** -> **Preferencje**.  
W przypadku wyłączonej opcji automatycznego pobierania, musisz pamiętać aby zacząć pobieranie plików poprzez przycisk **Edycja** -> **Zacznij**.

## Składania nazywania plików
> {title} Tytuł filmu  
> {author} Nazwa użytkownika, który przesłał film  
> {id} Numeracja pliku

Numeracja plików odbywa się na zasadzie kolejności dodawania plików do kolejki pobierania.  
Resetuje się ona do zera po ponownym otwarciu programu.

Domyślna składnia to `{title}`, a w przypadku niepodania własnego tytułu, plik zostanie nazwany wg. tej składni `{author} - {title}`.

### Przykłady
Po dodaniu nowego URL i nazwaniu pliku `track{id}`, końcowo zostanie on nazwany `track0`, `track1`, `track5` itd. zależenie od tego, który w kolejce został od dodany.  

Załóżmy, że chcesz pobrać piosenkę [Zvezda](https://www.youtube.com/watch?v=RLgBi6N7JOw). Nazwa `{id} - {author} ({title})` sprawi, że plik zostanie nazwany `0 - Группа Кино (Звезда)`.

# Użyte projekty
- [yt-dlp](https://github.com/yt-dlp/yt-dlp)
- [YoutubeDLSharp](https://github.com/Bluegrams/YoutubeDLSharp)
- [ffmpeg](https://github.com/FFmpeg/FFmpeg)

# Zgłaszanie błędów oraz sugestie
Z chęcią wysłucham waszych sugestii, naprawię problem lub przyjmę wasze Push Requesty.

Jeżeli chcesz złożyć sugestię lub zgłosić błąd, użyj zakładki [Issues](https://github.com/SolidnyWonsz/YTDownloader/issues) i otwórz issue opisującego problem. Opisz jaki błąd występuje, co zamiast błędu miało się wydarzyć oraz kroki do odtworzenia błędu.

# Licencja
YTDownloader udostępniony jest na licencji GNU GPLv3, co oznacza, że program można używać w celach komercyjnych lub prywatnych, możesz go rozpowszechniać oraz modyfikować do własnych potrzeb, ale jesteś zobligowany do publicznego udostępnienia zmodyfikowanego kodu oraz musisz zawrzeć informację o licencji. Odpowiedzialność za pobrane treści spada na użytkownika, a z racji, że program jest całkowicie darmowy to nie ma on gwarancji poprawnego działania.