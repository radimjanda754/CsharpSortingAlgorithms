using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiciAlgoritmy
{
    public class GetInfo
    {
        private int a;

        public GetInfo(int ax)
        {
            a = ax;
        }

        public string GetAlgInfo()
            // obsahuje podrobné informace o algoritmech
        {
            // ------------------------------------INSERTION SORT ----------------------------------------------
            if (a == 1)
                return (@"Algoritmus - Insertion Sort (Řazení vkládáním)

OBECNĚ: 
Řazení vkládáním je jeden z nejjednodušších algoritmů pracujících na principu porovnávání.
Je také velmi rychlý, zejména při řazení jíž téměř seřazených řad.

PRINCIP: 
Algoritmus postupně projíždí celou řadu hodnot a každou hodnotu bude přesunovat do leva 
tak dlouho, dokud nenarazí na hodnotu nižší než je právě přesunovaná hodnota.
Následně se vrátí na místo poslední neseřazené hodnoty, děj se opakuje, dokud se neseřadí 
všechny hodnoty.
V tomto případě budou tedy hodnoty nakonec seřazeny z leva (od nejmenší) do prava (největší).

ZOBRAZENÍ:
Uvidíte zde 2 ukazatele s tím, že červený ukazatel vám bude znázorňovat právě přesouvaný sloupec
a zelený ukazatel vám bude ukazovat místo, kde původně ležel právě přesunovaný sloupec. Šipka
nad sloupci poukazuje na právě prohazované sloupce.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je meřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------SELECTION SORT ----------------------------------------------
            if (a == 2)
                return (@"Algoritmus - Selection Sort (Řazení výběrem)

OBECNĚ: 
Řazení výběrem je velmi jednoduchý řadící algoritmus, pracující na principu projetí celé
řady hodnot a vybrání nejmenší hodnoty. Jeho nejvíce efektivní použití je u zcela neseřazených
hodnot malého počtu.

PRINCIP: 
Algoritmus postupně projíždí celou řadu hodnot vždy od první neseřazené hodnoty (z leva) 
a hledá jinou nejvhodnější hodnoty (v tomto případě co nejmenší).
Pakli, že není nalezena menší hodnota, tak se počáteční hodnota stane seřazenou.
Pakli, že je nalezeno více menších hodnot, vybere se ta nejmenší a prohodí se.
S takto seřazenými hodnoty se již dále nijak nezachází a algoritmus opět pokračuje od další první
neseřazené hodnoty, dokud nejsou všechny hodnoty seřazeny.

ZOBRAZENÍ:
Uvidíte zde 2 až 3 ukazatele s tím, že první červený ukazatel vám ukazuje hodnotu, která je
porovnávána. Druhé červený ukazatel projíždí hodnoty a hledá nejmenší vhodnou hodnotu pro
prohození s prvním ukazatelem. Zelený ukazatel vám zobrazuje nejmenší vhodnou hodnotu pro
prohození. V případě, že vidíte zelený ukazatel místo prvního červeného, znamená to, že zatím
nebyla nalezena žádná hodnota pro prohození. Šipka nad sloupci poukazuje na právě prohazované 
sloupce.

Dole v tabulce si také mužete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------BUBBLE SORT ----------------------------------------------
            if (a == 3)
                return (@"Algoritmus - Bubble Sort (Bublinkové řazení)

OBECNĚ: 
Řazení výběrem je velmi jednoduchý řadící algoritmus, pracující podobně jako Řazení výberem.
Algoritmus projede celou řadu hodnot tolikrát, kolik je zde použitých hodnot a při každém projetí 
přesouvá nejmenší hodnoty na začátek. Jeho nejvíce efektivní použití je u zcela neseřazených
hodnot malého počtu.

PRINCIP: 
Algoritmus postupně projíždí celou řadu hodnot od konce (vpravo) až do poslední neseřazené
hodnoty (vlevo). Při projíždění přesouvá nejnížší hodnotu na kterou narazil (v případě, že narazí
na nižší hodnotu tak pustí tu současnou a bude přesouvat tu nejnižší).
Jakmile se dostane na konec či k již seřazené hodnotě, seřadí přesouvanou hodnotu a jede opět od konce.
Je tedy zřejmé, že algoritmus celou řadu projede tolikrát, kolik je zde hodnot.

ZOBRAZENÍ:
Uvidíte zde červený ukazatel, který vám bude znázorňovat projíždění a přesouvání hodnot. Všechny
zelené sloupce budou znázorňovat již seřazené hodnoty. Šipka nad sloupci poukazuje na právě 
prohazované sloupce.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------SHELL SORT ----------------------------------------------
            if (a == 4)
                return (@"Algoritmus - Shell Sort (Shellovo řazení)

OBECNĚ: 
Shellovo řazení je známý algoritmus, který byl pojmenován po svém vynálezci. Základem 
algoritmu jsou dva procházející ukazatelé, kteří si mezi sebou prohazují hodnoty a posouvají se 
společně s určitým rozestupem (inkrement) jenž se v průběhu zmenšuje.

PRINCIP: 
Celou řadu hodnot prochází z leva doprava dva ukazatelé s tím, že jeden ukazatel je posunut
doprava o jistý inkrement (=počet sloupců / 2,2). 
Ukazatelé si mezi sebou neustále porovnávají sloupce a přesunují se doprava. Pokud je hodnota 
v pravém ukazateli menší než hodnota v levém ukazateli, hodnoty se prohodí a je-li to možné 
pravý ukazatel se přesune o inkrement do leva k levému ukazateli, kde opět porovnává hodnoty 
s pravím sloupcem - Takto se bude postupovat dokud se hodnota nepřesune co nejvíce do leva, 
poté se ukazatelé vrátí na místa, kde byla hodnota poprvé přesunuta.

Následně se ukazatelé opět přesunují doprava, dokud praví ukazatel nedojde na konec. Jakmile se
tak stane je inkrement opět vydělen číslem 2,2 a celá situace se opakuje s nižším inkrementem
dokud není inkrement nulový. 


ZOBRAZENÍ:
Jak už bylo řečeno uvidíte zde dva ukazatele s tím, že pravý bude zvýrazněn červeně a levý
zeleně.  Šipka se nad sloupci objeví v případě jejich prohazování.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------QUICK SORT ----------------------------------------------
            if (a == 5)
                return (@"Algoritmus - QUICK SORT (Rychlé řazení)

OBECNĚ: 
Rychlé řazení je jeden z nejrychlejších řadicích algoritmů. Základem jsou dva přibližující
se ukazatelé, kteří si mezi sebou prohazují hodnoty a tam kde se střetnou, bude hodnota
zcela jistě seřazena.

PRINCIP: 
Celou řadu hodnot prochází dva ukazatelé. Levý ukazatel začíná co nejvíce vlevo (buď na okraji 
nebo zprava od seřazené hodnoty) a pravý ukazatel začíná zleva od nejblíže seřazené hodnoty 
(tam kde je to možné) případně na pravém okraji.
Děj začíná tak, že se pravý ukazatel přibližuje k levému a porovnávají si mezi sebou hodnoty.
Jakmile je hodnota v pravém ukazateli nižší než ta v levém, hodnoty jsou prohozeny a místo
pravého ukazatele se bude přibližovat ten levý.
Po dalším prohození hodnot se zase přibližuje ten druhý ukazatel a takto algoritmus postupuje
dokud se ukazatelé nestřetnou.
Tam kde se ukazatelé střetnou, bude seřazené hodnota a ukazatelé jedou od znova, dokud nebudou
seřazeny všechny hodnoty. 

ZOBRAZENÍ:
Jak už bylo řečeno, uvidíte zde dva ukazatele znázorněné červeně a již seřazené sloupce budou
znázorněny zeleně. Šipka se nad sloupci objeví v případě jejich prohazování.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------HEAP SORT ----------------------------------------------
            if (a == 6)
                return (@"Algoritmus - Heap sort (Řazení haldou)

OBECNĚ: 
Řazení haldou je známý řadící algoritmus, který si dané hodnoty roztřídí do jakési haldy ve které
pak probíhá řazení

HALDA:
Pro pochopení algoritmu je nutné si nejprve představit danou haldu.
Zkratka S.číslo představuje hodnoty (sloupce) podle toho jak jsou seřazeny (z leva do prava).

                              (S.1)
                              /       \
                        (S.2)       (S.3)
                         /      \        \       \
                   (S.4)  (S.5)  (S.6) (S.7)
                    /      \        \
              (S.8)  (S.9)   (S.10)

PRINCIP: 
Když se podíváme na haldu, vidíme, že čísla sloupců přiřazená k vyššímu sloupci lze spočítat
velmi snadno:
 - Sloupec vlevo dole = 2*čislo vyššího sloupce
 - Sloupec vpravo dole = 2*čislo vyššího sloupce + 1
Samotné řazení pak probíhá v těchto spojích tak, že se hodnoty porovnávají a největší se přesouvají
co nejvíce nahoru. Jakmile se v této haldě uspořádají všechny hodnoty, prohodí se poslední sloupec
s prvním. Sloupec, který byl dán na poslední místo (= sloupec s největší hodnotou) je pak seřazen a
z celé haldy mizí.
Takto řazení postupuje nadále, dokud nebudou seřazeny všechny hodnoty.


ZOBRAZENÍ:
Uvidíte zde dva červené ukazatele, jenž znázorňují porovnávání v haldě. V případě prohození sloupců
se nad nimi zobrazí šipka.
Seřazené sloupce, s kterými halda již nadále nepracuje se zobrazí zeleně.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            // ------------------------------------MERGE SORT ----------------------------------------------
            if (a == 7)
                return (@"Algoritmus - Merge Sort (Řazení slučováním)

OBECNĚ:
Řazení slučováním je známý řadicí algoritmus, který nefunguje na principu prohazování hodnot, ale
využívá pomocného pole, do kterého jsou hodnoty seřazovány a následně vráceny do hlavního pole.

PRINCIP: 
Algoritmus si nejprve hodnoty neustále rozděluje na půlky, dokud není každá hodnota samostatně
rozdělena a následně začíná od hodnot, které byli rozděleny jako poslední.
V každé rozdělené částí pak mezi sebou porovná hodnoty a uloží je seřazené do pomocného pole.
Z tohoto pomocného pole je po seřazení vrátí do pole hlavního (vykreslí tedy danou část již
seřazenou).
Takto postupuje do dalších rozdělených částí, dokud neseřadí všechny.

ZOBRAZENÍ:
Jako první zde uvidíte barevně znázorněné rozdělení hodnot do daných částí. Poté začíná 
algoritmus pracovat.
Jelikož algoritmus neprohazuje hodnoty, ale ukládá do nového pole, zobrazení je trochu jiné 
než u algoritmů předchozích a to zejména u šipek. Ty zde zobrazují, jako kolikátá hodnota bude
uložena do pomocného pole, z kterého pak bude vykreslena.
Takže červeně se nám zde zobrazí část, která bude porovnávána, následně uvidíme šipky jak
seřazují hodnoty do pomocného pole. Poté se budou vykreslovat zelené sloupce, což budou dané
hodnoty, které sme si seřadili do pole pomocného.

Dole v tabulce si také můžete všimnout informací jako je počet porovnání sloupců, přesunů sloupců
či čas, který je měřen s nulovou časovou prodlevou ještě před spuštěním grafického zobrazení.");

            return("Error");
        }

        public string GetAlgTxt()
            // obsahuje pouze názvy oken
        {
            if (a == 1)
                return ("Zobrazeni: Algoritmus - Insertion Sort");
            if (a == 2)
                return ("Zobrazeni: Algoritmus - Selection Sort");
            if (a == 3)
                return ("Zobrazeni: Algoritmus - Bubble Sort");
            if (a == 4)
                return ("Zobrazeni: Algoritmus - Shell Sort");
            if (a == 5)
                return ("Zobrazeni: Algoritmus - Quick Sort");
            if (a == 6)
                return ("Zobrazeni: Algoritmus - Heap Sort");
            if (a == 7)
                return ("Zobrazeni: Algoritmus - Merge Sort");
            return ("Zobrazeni");
        }

        public string GetProgramInfo(int b)
        // obsahuje texty pro levou horni nabidku informaci
        {
            if (b == 1)
                return (@"Program slouží jako výuková pomůcka k pochopení řadicích algoritmů a byl vytvořen jako maturitní projekt v letech 2012/2013.

Použití programu je velmi jednoduché - nejprve si zadáte hodnoty s kterými bude algoritmus pracovat, následně vyberete algoritmus a kliknete na pokračovat.
Nejprve se vám v textovém okně vypíši teoretické informace o algoritmu a následně i grafické znázornění průběhu.
Program také může ukládat statistiky jednotlivých algoritmů, které slouží především k porovnání z hlediska času, počtu přesunu sloupců či počtu porovnání sloupců. Tyto statistiky můžete najít v horním menu pod položkou Statistiky - porovnání algoritmů.

Podrobnější informace jsou obsaženy v přiložené dokumentaci.
");
            if (b == 2)
                return (@"Program vytvořil: Radim Janda
Kontakt: tnqm754@gmail.com");
            return ("error");
        }

    }
}
