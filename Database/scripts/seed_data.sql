BEGIN;

--
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('stan po zabiegu kardiochirurgicznym');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('sepsa');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('uraz wielonarządowy');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('HUS');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('Układowe zapalenie naczyń');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('niewydolność wielonarządowa (o innej przyczynie)');
INSERT INTO database."CLINICAL_DIAGNOSES" ("NAME") VALUES ('zespoł lizy guza');
--

--
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('narastanie TMP');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('wykrzepienie ukladu');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('zapowietrzenie ukladu');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('bład maszyny');
INSERT INTO database."PROCEDURES_COMPLETIONS_REASONS" ("NAME") VALUES ('niesprawny cewnik');
--

--
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
--

END;
