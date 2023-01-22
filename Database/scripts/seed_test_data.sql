INSERT INTO database."CLINICAL_CENTERS" ("NAME", "STREET", "BUILDING_NUMBER", "LOCALITY", "POSTAL_CODE")
	VALUES ('Test clinical center', 'Test street', '1a', 'Test locality', '01-234');
	
INSERT INTO database."PATIENTS" ("INITIALS", "BIRTH_DATE", "HOSPITALISATION_DATE", "CKRT_START_DATE", "WEIGHT", "HEIGHT", "CLINICAL_CENTER_ID")
	VALUES ('TT', NOW(), NOW(), NOW(), 10, 30, 1);
	
INSERT INTO database."DOCTORS" ("FIRST_NAME", "LAST_NAME", "IS_DATA_ADMINISTRATOR", "PASSWORD", "EMAIL")
	VALUES ('Johnny', 'Bravo', 0, '0123456789', 'johnny@bravo.com');

INSERT INTO database."CLINICAL_DATA" ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "DATA_COLLECTION_DATE", "DOCTOR_ID")
	VALUES (1, 25, 'C', '2023-01-07', 1);
	
INSERT INTO database."CLINICAL_DATA_VALUES" VALUES (1, 25, 'C', '2023-01-07', 161, 0, NULL, NULL, 'Nadciśnienie tętnicze...');
INSERT INTO database."CLINICAL_DATA_VALUES" VALUES (1, 25, 'C', '2023-01-07', 173, NULL, 4, NULL, 'Grubość cewnika...');
INSERT INTO database."CLINICAL_DATA_VALUES" VALUES (1, 25, 'C', '2023-01-07', 175, NULL, NULL, 'Żyła szyjna wewnętrzna prawa', 'Miejsce założenia dostępu naczyniowego...');