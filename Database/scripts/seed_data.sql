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
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'ECMO', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (1, 'P', 'Koncentrat cytrynianów', 0);

INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'QB [ml / min]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'QD [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Predylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Postdylucja [ml / h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Stężenie cytrynianów [mmol / l]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'Kompensacja wapnia [%]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (2, 'S', 'UF [ml / h]', 1);

INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Filtr', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'ECMO', 0);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Czas trwania zabiegu [h]', 1);
INSERT INTO database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "NAME", "DATA_TYPE") VALUES (19, 'P', 'Metoda oczyszczenia pozaustrojowego', 0);
--

END;
