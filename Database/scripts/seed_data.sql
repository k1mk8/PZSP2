BEGIN;

-- CLINICAL_DIAGNOSES --
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('stan po zabiegu kardiochirurgicznym');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('sepsa');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('uraz wielonarządowy');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('HUS');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('Układowe zapalenie naczyń');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('niewydolność wielonarządowa (o innej przyczynie)');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('zespoł lizy guza');
--

-- PROCEDURES_COMPLETIONS_REASONS --
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('narastanie TMP');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('wykrzepienie ukladu');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('zapowietrzenie ukladu');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('bład maszyny');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('niesprawny cewnik');
--

-- TYPES --
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('P', 'Cytryniany');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Cytryniany - ustawienia początkowe');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Cytryniany - ustawienia po 6h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Cytryniany - ustawienia po 24h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Cytryniany - ustawienia po 48h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Cytryniany - ustawienia końcowe');

INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('P', 'Heparyna niefrakcjonowana');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna niefrakcjonowana - ustawienia początkowe');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna niefrakcjonowana - ustawienia po 6h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna niefrakcjonowana - ustawienia po 24h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna niefrakcjonowana - ustawienia po 48h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna niefrakcjonowana - ustawienia końcowe');

INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('P', 'Heparyna drobnocząsteczkowa');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna drobnocząsteczkowa - ustawienia początkowe');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna drobnocząsteczkowa - ustawienia po 6h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna drobnocząsteczkowa - ustawienia po 24h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna drobnocząsteczkowa - ustawienia po 48h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Heparyna drobnocząsteczkowa - ustawienia końcowe');

INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('P', 'Bez antykoagulacji');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Bez antykoagulacji - ustawienia początkowe');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Bez antykoagulacji - ustawienia po 6h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Bez antykoagulacji - ustawienia po 24h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Bez antykoagulacji - ustawienia po 48h');
INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('S', 'Bez antykoagulacji - ustawienia końcowe');

INSERT INTO database."TYPES" ("TYPE_DISCRIMINATOR", "NAME") VALUES ('C', 'Bezpośrednie wskazanie do CKRT');
--

-- PARAMETERS --
-- Cytryniany - ustawienia zabiegu
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'ECMO', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Koncentrat cytrynianów', 0);
-- Cytryniany - ustawienia sesji poczatkowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Stężenie cytrynianów [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'UF [ml / h]', 1);
-- Cytryniany - ustawienia sesji po 6 h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'Wapń zjonizowany [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'Wapń całkowity [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'HCO3 [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'Wapń za filtrem [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'Cytrynian [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (3, 'S', 'TMP [mmhg]', 1);
-- Cytryniany - ustawienia sesji po 24 h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'Wapń zjonizowany [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'Wapń całkowity [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'HCO3 [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'Wapń za filtrem [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'Cytrynian [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (4, 'S', 'TMP [mmhg]', 1);
-- Cytryniany - ustawienia sesji po 48 h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'Wapń zjonizowany [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'Wapń całkowity [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'HCO3 [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'Wapń za filtrem [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'Cytrynian [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (5, 'S', 'TMP [mmhg]', 1);
-- Cytryniany - ustawienia sesji koncowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'Wapń zjonizowany [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'Wapń całkowity [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'HCO3 [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'Wapń za filtrem [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'Cytrynian [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (6, 'S', 'TMP [mmhg]', 1);

-- Heparyna niefrakcjonowana - ustawienia zabiegu
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (7, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (7, 'P', 'ECMO', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (7, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (7, 'P', 'Metoda oczyszczenia pozaustrojowego', 0);
-- Heparyna niefrakcjonowana - ustawienia sesji poczatkowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'Heparyna - bolus początkowy [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'Dawka heparyny [mg / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (8, 'S', 'UF [ml / h]', 1);
-- Heparyna niefrakcjonowana - ustawienia sesji po 6h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'Dawka heparyny [mg / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'ACT [s]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (9, 'S', 'TMP [mmhg]', 1);
-- Heparyna niefrakcjonowana - ustawienia sesji po 24h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'Dawka heparyny [mg / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'ACT [s]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (10, 'S', 'TMP [mmhg]', 1);
-- Heparyna niefrakcjonowana - ustawienia sesji po 48h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'Dawka heparyny [mg / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'ACT [s]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (11, 'S', 'TMP [mmhg]', 1);
-- Heparyna niefrakcjonowana - ustawienia sesji końcowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'Dawka heparyny [mg / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'ACT [s]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (12, 'S', 'TMP [mmhg]', 1);

-- Heparyna drobnocząsteczkowa - ustawienia zabiegu
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (13, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (13, 'P', 'ECMO', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (13, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (13, 'P', 'Metoda oczyszczenia pozaustrojowego', 0);
-- Heparyna drobnocząsteczkowa - ustawienia sesji poczatkowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'Dawka fraxaparyny [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'Interwał czasowy podawania fraxaparyny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (14, 'S', 'UF [ml / h]', 1);
-- Heparyna drobnocząsteczkowa - ustawienia sesji po 6h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'Dawka fraxaparyny [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'Interwał czasowy podawania fraxaparyny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'Anty-Xa', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (15, 'S', 'TMP [mmhg', 1);
-- Heparyna drobnocząsteczkowa - ustawienia sesji po 24h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'Dawka fraxaparyny [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'Interwał czasowy podawania fraxaparyny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'Anty-Xa', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (16, 'S', 'TMP [mmhg', 1);
-- Heparyna drobnocząsteczkowa - ustawienia sesji po 48h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'Dawka fraxaparyny [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'Interwał czasowy podawania fraxaparyny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'Anty-Xa', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (17, 'S', 'TMP [mmhg', 1);
-- Heparyna drobnocząsteczkowa - ustawienia sesji końcowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'Dawka fraxaparyny [mg]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'Interwał czasowy podawania fraxaparyny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'Anty-Xa', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (18, 'S', 'TMP [mmhg]', 1);

-- Bez antykoagulacji
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'ECMO', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Metoda oczyszczenia pozaustrojowego', 0);
-- Bez antykoagulacji - ustawienia sesji poczatkowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (20, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (20, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (20, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (20, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (20, 'S', 'UF [ml / h]', 1);
-- Bez antykoagulacji - ustawienia sesji po 6h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (21, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (21, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (21, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (21, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (21, 'S', 'TMP [mmhg]', 1);
-- Bez antykoagulacji - ustawienia sesji po 24h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (22, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (22, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (22, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (22, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (22, 'S', 'TMP [mmhg]', 1);
-- Bez antykoagulacji - ustawienia sesji po 48h
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (23, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (23, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (23, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (23, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (23, 'S', 'TMP [mmhg]', 1);
-- Bez antykoagulacji - ustawienia sesji końcowej
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (24, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (24, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (24, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (24, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (24, 'S', 'TMP [mmhg]', 1);

-- Bezpośredenie wskazanie do CKRT
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'ECMO', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Bezmocz / skąpomocz', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Nadciśnienie tętnicze', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Przewodnienie', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Obecność AKI', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Kreatynina', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Mocznik', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Zaburzenia jonowe', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Kwasica metaboliczna', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Zatrucie egzogenne', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Wstrząs septyczny', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Zespół zmiażdżenia', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Antykoagulacja', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Rodzaj dostępu naczyniowego', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Grubość cewnika', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Długość cewnika', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (25, 'C', 'Miejsce założenia dostępu naczyniowego', 0);


END;
