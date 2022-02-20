using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Actions
{
    public static class LocalizationActions
    {
        [InitializeOnLoadMethod]
        public static void InitLanguage()
        {
            UpdateCheckmarks();
        }

        private const string MenuAfrikaans = "View/Scene/Languages/Afrikaans";

        [MenuItem(MenuAfrikaans, false)]
        public static void ChangeToAfrikaans()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Afrikaans;
            UpdateCheckmarks();
        }

        [MenuItem(MenuAfrikaans, true)]
        public static bool ChangeToAfrikaansCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Afrikaans);


        private const string MenuArabic = "View/Scene/Languages/Arabic";

        [MenuItem(MenuArabic, false)]
        public static void ChangeToArabic()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Arabic;
            UpdateCheckmarks();
        }

        [MenuItem(MenuArabic, true)]
        public static bool ChangeToArabicCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Arabic);


        private const string MenuBasque = "View/Scene/Languages/Basque";

        [MenuItem(MenuBasque, false)]
        public static void ChangeToBasque()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Basque;
            UpdateCheckmarks();
        }

        [MenuItem(MenuBasque, true)]
        public static bool ChangeToBasqueCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Basque);


        private const string MenuBelarusian = "View/Scene/Languages/Belarusian";

        [MenuItem(MenuBelarusian, false)]
        public static void ChangeToBelarusian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Belarusian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuBelarusian, true)]
        public static bool ChangeToBelarusianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Belarusian);


        private const string MenuBulgarian = "View/Scene/Languages/Bulgarian";

        [MenuItem(MenuBulgarian, false)]
        public static void ChangeToBulgarian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Bulgarian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuBulgarian, true)]
        public static bool ChangeToBulgarianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Bulgarian);


        private const string MenuCatalan = "View/Scene/Languages/Catalan";

        [MenuItem(MenuCatalan, false)]
        public static void ChangeToCatalan()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Catalan;
            UpdateCheckmarks();
        }

        [MenuItem(MenuCatalan, true)]
        public static bool ChangeToCatalanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Catalan);


        private const string MenuChinese = "View/Scene/Languages/Chinese";

        [MenuItem(MenuChinese, false)]
        public static void ChangeToChinese()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Chinese;
            UpdateCheckmarks();
        }

        [MenuItem(MenuChinese, true)]
        public static bool ChangeToChineseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Chinese);


        private const string MenuCzech = "View/Scene/Languages/Czech";

        [MenuItem(MenuCzech, false)]
        public static void ChangeToCzech()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Czech;
            UpdateCheckmarks();
        }

        [MenuItem(MenuCzech, true)]
        public static bool ChangeToCzechCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Czech);


        private const string MenuDanish = "View/Scene/Languages/Danish";

        [MenuItem(MenuDanish, false)]
        public static void ChangeToDanish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Danish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuDanish, true)]
        public static bool ChangeToDanishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Danish);


        private const string MenuDutch = "View/Scene/Languages/Dutch";

        [MenuItem(MenuDutch, false)]
        public static void ChangeToDutch()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Dutch;
            UpdateCheckmarks();
        }

        [MenuItem(MenuDutch, true)]
        public static bool ChangeToDutchCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Dutch);


        private const string MenuEnglish = "View/Scene/Languages/English";

        [MenuItem(MenuEnglish, false)]
        public static void ChangeToEnglish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.English;
            UpdateCheckmarks();
        }

        [MenuItem(MenuEnglish, true)]
        public static bool ChangeToEnglishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.English);


        private const string MenuEstonian = "View/Scene/Languages/Estonian";

        [MenuItem(MenuEstonian, false)]
        public static void ChangeToEstonian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Estonian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuEstonian, true)]
        public static bool ChangeToEstonianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Estonian);


        private const string MenuFaroese = "View/Scene/Languages/Faroese";

        [MenuItem(MenuFaroese, false)]
        public static void ChangeToFaroese()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Faroese;
            UpdateCheckmarks();
        }

        [MenuItem(MenuFaroese, true)]
        public static bool ChangeToFaroeseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Faroese);


        private const string MenuFinnish = "View/Scene/Languages/Finnish";

        [MenuItem(MenuFinnish, false)]
        public static void ChangeToFinnish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Finnish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuFinnish, true)]
        public static bool ChangeToFinnishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Finnish);


        private const string MenuFrench = "View/Scene/Languages/French";

        [MenuItem(MenuFrench, false)]
        public static void ChangeToFrench()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.French;
            UpdateCheckmarks();
        }

        [MenuItem(MenuFrench, true)]
        public static bool ChangeToFrenchCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.French);


        private const string MenuGerman = "View/Scene/Languages/German";

        [MenuItem(MenuGerman, false)]
        public static void ChangeToGerman()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.German;
            UpdateCheckmarks();
        }

        [MenuItem(MenuGerman, true)]
        public static bool ChangeToGermanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.German);


        private const string MenuGreek = "View/Scene/Languages/Greek";

        [MenuItem(MenuGreek, false)]
        public static void ChangeToGreek()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Greek;
            UpdateCheckmarks();
        }

        [MenuItem(MenuGreek, true)]
        public static bool ChangeToGreekCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Greek);


        private const string MenuHebrew = "View/Scene/Languages/Hebrew";

        [MenuItem(MenuHebrew, false)]
        public static void ChangeToHebrew()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Hebrew;
            UpdateCheckmarks();
        }

        [MenuItem(MenuHebrew, true)]
        public static bool ChangeToHebrewCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Hebrew);


        private const string MenuHungarian = "View/Scene/Languages/Hungarian";

        [MenuItem(MenuHungarian, false)]
        public static void ChangeToHungarian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Hungarian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuHungarian, true)]
        public static bool ChangeToHungarianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Hungarian);


        private const string MenuIcelandic = "View/Scene/Languages/Icelandic";

        [MenuItem(MenuIcelandic, false)]
        public static void ChangeToIcelandic()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Icelandic;
            UpdateCheckmarks();
        }

        [MenuItem(MenuIcelandic, true)]
        public static bool ChangeToIcelandicCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Icelandic);


        private const string MenuIndonesian = "View/Scene/Languages/Indonesian";

        [MenuItem(MenuIndonesian, false)]
        public static void ChangeToIndonesian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Indonesian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuIndonesian, true)]
        public static bool ChangeToIndonesianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Indonesian);


        private const string MenuItalian = "View/Scene/Languages/Italian";

        [MenuItem(MenuItalian, false)]
        public static void ChangeToItalian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Italian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuItalian, true)]
        public static bool ChangeToItalianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Italian);


        private const string MenuJapanese = "View/Scene/Languages/Japanese";

        [MenuItem(MenuJapanese, false)]
        public static void ChangeToJapanese()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Japanese;
            UpdateCheckmarks();
        }

        [MenuItem(MenuJapanese, true)]
        public static bool ChangeToJapaneseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Japanese);


        private const string MenuKorean = "View/Scene/Languages/Korean";

        [MenuItem(MenuKorean, false)]
        public static void ChangeToKorean()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Korean;
            UpdateCheckmarks();
        }

        [MenuItem(MenuKorean, true)]
        public static bool ChangeToKoreanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Korean);


        private const string MenuLatvian = "View/Scene/Languages/Latvian";

        [MenuItem(MenuLatvian, false)]
        public static void ChangeToLatvian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Latvian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuLatvian, true)]
        public static bool ChangeToLatvianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Latvian);


        private const string MenuLithuanian = "View/Scene/Languages/Lithuanian";

        [MenuItem(MenuLithuanian, false)]
        public static void ChangeToLithuanian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Lithuanian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuLithuanian, true)]
        public static bool ChangeToLithuanianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Lithuanian);


        private const string MenuNorwegian = "View/Scene/Languages/Norwegian";

        [MenuItem(MenuNorwegian, false)]
        public static void ChangeToNorwegian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Norwegian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuNorwegian, true)]
        public static bool ChangeToNorwegianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Norwegian);


        private const string MenuPolish = "View/Scene/Languages/Polish";

        [MenuItem(MenuPolish, false)]
        public static void ChangeToPolish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Polish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuPolish, true)]
        public static bool ChangeToPolishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Polish);


        private const string MenuPortuguese = "View/Scene/Languages/Portuguese";

        [MenuItem(MenuPortuguese, false)]
        public static void ChangeToPortuguese()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Portuguese;
            UpdateCheckmarks();
        }

        [MenuItem(MenuPortuguese, true)]
        public static bool ChangeToPortugueseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Portuguese);


        private const string MenuRomanian = "View/Scene/Languages/Romanian";

        [MenuItem(MenuRomanian, false)]
        public static void ChangeToRomanian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Romanian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuRomanian, true)]
        public static bool ChangeToRomanianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Romanian);


        private const string MenuRussian = "View/Scene/Languages/Russian";

        [MenuItem(MenuRussian, false)]
        public static void ChangeToRussian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Russian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuRussian, true)]
        public static bool ChangeToRussianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Russian);


        private const string MenuSerboCroatian = "View/Scene/Languages/SerboCroatian";

        [MenuItem(MenuSerboCroatian, false)]
        public static void ChangeToSerboCroatian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.SerboCroatian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuSerboCroatian, true)]
        public static bool ChangeToSerboCroatianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.SerboCroatian);


        private const string MenuSlovak = "View/Scene/Languages/Slovak";

        [MenuItem(MenuSlovak, false)]
        public static void ChangeToSlovak()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Slovak;
            UpdateCheckmarks();
        }

        [MenuItem(MenuSlovak, true)]
        public static bool ChangeToSlovakCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Slovak);


        private const string MenuSlovenian = "View/Scene/Languages/Slovenian";

        [MenuItem(MenuSlovenian, false)]
        public static void ChangeToSlovenian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Slovenian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuSlovenian, true)]
        public static bool ChangeToSlovenianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Slovenian);


        private const string MenuSpanish = "View/Scene/Languages/Spanish";

        [MenuItem(MenuSpanish, false)]
        public static void ChangeToSpanish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Spanish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuSpanish, true)]
        public static bool ChangeToSpanishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Spanish);


        private const string MenuSwedish = "View/Scene/Languages/Swedish";

        [MenuItem(MenuSwedish, false)]
        public static void ChangeToSwedish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Swedish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuSwedish, true)]
        public static bool ChangeToSwedishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Swedish);


        private const string MenuThai = "View/Scene/Languages/Thai";

        [MenuItem(MenuThai, false)]
        public static void ChangeToThai()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Thai;
            UpdateCheckmarks();
        }

        [MenuItem(MenuThai, true)]
        public static bool ChangeToThaiCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Thai);


        private const string MenuTurkish = "View/Scene/Languages/Turkish";

        [MenuItem(MenuTurkish, false)]
        public static void ChangeToTurkish()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Turkish;
            UpdateCheckmarks();
        }

        [MenuItem(MenuTurkish, true)]
        public static bool ChangeToTurkishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Turkish);


        private const string MenuUkrainian = "View/Scene/Languages/Ukrainian";

        [MenuItem(MenuUkrainian, false)]
        public static void ChangeToUkrainian()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Ukrainian;
            UpdateCheckmarks();
        }

        [MenuItem(MenuUkrainian, true)]
        public static bool ChangeToUkrainianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Ukrainian);


        private const string MenuVietnamese = "View/Scene/Languages/Vietnamese";

        [MenuItem(MenuVietnamese, false)]
        public static void ChangeToVietnamese()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.Vietnamese;
            UpdateCheckmarks();
        }

        [MenuItem(MenuVietnamese, true)]
        public static bool ChangeToVietnameseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Vietnamese);


        private const string MenuChineseSimplified = "View/Scene/Languages/ChineseSimplified";

        [MenuItem(MenuChineseSimplified, false)]
        public static void ChangeToChineseSimplified()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.ChineseSimplified;
            UpdateCheckmarks();
        }

        [MenuItem(MenuChineseSimplified, true)]
        public static bool ChangeToChineseSimplifiedCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.ChineseSimplified);


        private const string MenuChineseTraditional = "View/Scene/Languages/ChineseTraditional";

        [MenuItem(MenuChineseTraditional, false)]
        public static void ChangeToChineseTraditional()
        {
            UnityLocalize.CurrentLanguage = SystemLanguage.ChineseTraditional;
            UpdateCheckmarks();
        }

        [MenuItem(MenuChineseTraditional, true)]
        public static bool ChangeToChineseTraditionalCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.ChineseTraditional);

        private static void UpdateCheckmarks()
        {
            Menu.SetChecked(MenuAfrikaans, UnityLocalize.CurrentLanguage == SystemLanguage.Afrikaans);

            Menu.SetChecked(MenuArabic, UnityLocalize.CurrentLanguage == SystemLanguage.Arabic);

            Menu.SetChecked(MenuBasque, UnityLocalize.CurrentLanguage == SystemLanguage.Basque);

            Menu.SetChecked(MenuBelarusian, UnityLocalize.CurrentLanguage == SystemLanguage.Belarusian);

            Menu.SetChecked(MenuBulgarian, UnityLocalize.CurrentLanguage == SystemLanguage.Bulgarian);

            Menu.SetChecked(MenuCatalan, UnityLocalize.CurrentLanguage == SystemLanguage.Catalan);

            Menu.SetChecked(MenuChinese, UnityLocalize.CurrentLanguage == SystemLanguage.Chinese);

            Menu.SetChecked(MenuCzech, UnityLocalize.CurrentLanguage == SystemLanguage.Czech);

            Menu.SetChecked(MenuDanish, UnityLocalize.CurrentLanguage == SystemLanguage.Danish);

            Menu.SetChecked(MenuDutch, UnityLocalize.CurrentLanguage == SystemLanguage.Dutch);

            Menu.SetChecked(MenuEnglish, UnityLocalize.CurrentLanguage == SystemLanguage.English); // 0x0000000A

            Menu.SetChecked(MenuEstonian, UnityLocalize.CurrentLanguage == SystemLanguage.Estonian); // 0x0000000B

            Menu.SetChecked(MenuFaroese, UnityLocalize.CurrentLanguage == SystemLanguage.Faroese); // 0x0000000C

            Menu.SetChecked(MenuFinnish, UnityLocalize.CurrentLanguage == SystemLanguage.Finnish); // 0x0000000D

            Menu.SetChecked(MenuFrench, UnityLocalize.CurrentLanguage == SystemLanguage.French); // 0x0000000E

            Menu.SetChecked(MenuGerman, UnityLocalize.CurrentLanguage == SystemLanguage.German); // 0x0000000F

            Menu.SetChecked(MenuGreek, UnityLocalize.CurrentLanguage == SystemLanguage.Greek); // 0x00000010

            Menu.SetChecked(MenuHebrew, UnityLocalize.CurrentLanguage == SystemLanguage.Hebrew); // 0x00000011

            Menu.SetChecked(MenuHungarian, UnityLocalize.CurrentLanguage == SystemLanguage.Hungarian); // 0x00000012

            Menu.SetChecked(MenuIcelandic, UnityLocalize.CurrentLanguage == SystemLanguage.Icelandic); // 0x00000013

            Menu.SetChecked(MenuIndonesian, UnityLocalize.CurrentLanguage == SystemLanguage.Indonesian); // 0x00000014

            Menu.SetChecked(MenuItalian, UnityLocalize.CurrentLanguage == SystemLanguage.Italian); // 0x00000015

            Menu.SetChecked(MenuJapanese, UnityLocalize.CurrentLanguage == SystemLanguage.Japanese); // 0x00000016

            Menu.SetChecked(MenuKorean, UnityLocalize.CurrentLanguage == SystemLanguage.Korean); // 0x00000017

            Menu.SetChecked(MenuLatvian, UnityLocalize.CurrentLanguage == SystemLanguage.Latvian); // 0x00000018

            Menu.SetChecked(MenuLithuanian, UnityLocalize.CurrentLanguage == SystemLanguage.Lithuanian); // 0x00000019

            Menu.SetChecked(MenuNorwegian, UnityLocalize.CurrentLanguage == SystemLanguage.Norwegian); // 0x0000001A

            Menu.SetChecked(MenuPolish, UnityLocalize.CurrentLanguage == SystemLanguage.Polish); // 0x0000001B

            Menu.SetChecked(MenuPortuguese, UnityLocalize.CurrentLanguage == SystemLanguage.Portuguese); // 0x0000001C

            Menu.SetChecked(MenuRomanian, UnityLocalize.CurrentLanguage == SystemLanguage.Romanian); // 0x0000001D

            Menu.SetChecked(MenuRussian, UnityLocalize.CurrentLanguage == SystemLanguage.Russian); // 0x0000001E

            Menu.SetChecked(MenuSerboCroatian, UnityLocalize.CurrentLanguage == SystemLanguage.SerboCroatian); // 0x0000001F

            Menu.SetChecked(MenuSlovak, UnityLocalize.CurrentLanguage == SystemLanguage.Slovak); // 0x00000020

            Menu.SetChecked(MenuSlovenian, UnityLocalize.CurrentLanguage == SystemLanguage.Slovenian); // 0x00000021

            Menu.SetChecked(MenuSpanish, UnityLocalize.CurrentLanguage == SystemLanguage.Spanish); // 0x00000022

            Menu.SetChecked(MenuSwedish, UnityLocalize.CurrentLanguage == SystemLanguage.Swedish); // 0x00000023

            Menu.SetChecked(MenuThai, UnityLocalize.CurrentLanguage == SystemLanguage.Thai); // 0x00000024

            Menu.SetChecked(MenuTurkish, UnityLocalize.CurrentLanguage == SystemLanguage.Turkish); // 0x00000025

            Menu.SetChecked(MenuUkrainian, UnityLocalize.CurrentLanguage == SystemLanguage.Ukrainian); // 0x00000026

            Menu.SetChecked(MenuVietnamese, UnityLocalize.CurrentLanguage == SystemLanguage.Vietnamese); // 0x00000027

            Menu.SetChecked(MenuChineseSimplified, UnityLocalize.CurrentLanguage == SystemLanguage.ChineseSimplified); // 0x00000028

            Menu.SetChecked(MenuChineseTraditional, UnityLocalize.CurrentLanguage == SystemLanguage.ChineseTraditional); // 0x00000029
        }
    }
}