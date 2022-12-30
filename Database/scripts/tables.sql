-- This script was generated by the ERD tool in pgAdmin 4.
-- Please log an issue at https://redmine.postgresql.org/projects/pgadmin4/issues/new if you find any bugs, including reproduction steps.
BEGIN;

DROP SCHEMA IF EXISTS database CASCADE;	-- added after script generation
CREATE SCHEMA database;					-- added after script generation

CREATE TABLE IF NOT EXISTS database."CLINICAL_CENTERS"
(
    "CLINICAL_CENTER_ID" serial,
    "NAME" character varying(100) NOT NULL,
    "STREET" character varying(100) NOT NULL,
    "BUILDING_NUMBER" character varying(5) NOT NULL,
    "LOCALITY" character varying(100) NOT NULL,
    "POSTAL_CODE" character varying(6) NOT NULL,
    "VENUE_NUMBER" character varying(5),
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "CLCEN_PK" PRIMARY KEY ("CLINICAL_CENTER_ID"),
    CONSTRAINT "CLCEN_NAME_UN" UNIQUE ("NAME"),
    CONSTRAINT "CLCEN_ADDRESS_UN" UNIQUE ("STREET", "BUILDING_NUMBER", "LOCALITY", "POSTAL_CODE", "VENUE_NUMBER")
);

COMMENT ON TABLE database."CLINICAL_CENTERS"
    IS 'Short name: CLCEN';

CREATE TABLE IF NOT EXISTS database."CLINICAL_DIAGNOSES"
(
    "DIAGNOSIS_ID" serial,
    "NAME" character varying(200) NOT NULL,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "CLDIAG_PK" PRIMARY KEY ("DIAGNOSIS_ID"),
    CONSTRAINT "CLDIAG_NAME_UN" UNIQUE ("NAME")
);

COMMENT ON TABLE database."CLINICAL_DIAGNOSES"
    IS 'Short name: CLDIAG';

CREATE TABLE IF NOT EXISTS database."PATIENTS"
(
    "PATIENT_ID" serial,
    "INITIALS" character varying(4) NOT NULL,
    "BIRTH_DATE" date NOT NULL,
    "HOSPITALISATION_DATE" date NOT NULL,
    "CKRT_START_DATE" date NOT NULL,
    "LIVER_FAILURE" numeric(1) NOT NULL DEFAULT 0,
    "WEIGHT" numeric(5, 2) NOT NULL,
    "HEIGHT" numeric(3) NOT NULL,
    "CLINICAL_CENTER_ID" integer NOT NULL,
    "DEATH_DATE" date,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PAT_PK" PRIMARY KEY ("PATIENT_ID")
);

COMMENT ON TABLE database."PATIENTS"
    IS 'Short name: PAT';

CREATE TABLE IF NOT EXISTS database."PATIENTS_CLINICAL_DIAGNOSES"
(
    "PATIENT_ID" integer,
    "DIAGNOSIS_ID" integer,
    CONSTRAINT "PATCLDIAG_PK" PRIMARY KEY ("PATIENT_ID", "DIAGNOSIS_ID")
);

COMMENT ON TABLE database."PATIENTS_CLINICAL_DIAGNOSES"
    IS 'Short name: PATCLDIAG';

CREATE TABLE IF NOT EXISTS database."CLINICAL_DATA"
(
    "PATIENT_ID" integer,
    "CLINICAL_DATA_TYPE_CODE" integer,
    "CLINICAL_DATA_TYPE_DISCRIMINATOR" character varying(1),
    "DATA_COLLECTION_DATE" date,
    "DOCTOR_ID" integer NOT NULL,
    "IS_DRAFT_VERSION" numeric(1) NOT NULL DEFAULT 0,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "CLDA_PK" PRIMARY KEY ("PATIENT_ID", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "DATA_COLLECTION_DATE", "CLINICAL_DATA_TYPE_CODE")
);

COMMENT ON TABLE database."CLINICAL_DATA"
    IS 'Short name: CLDA';

CREATE TABLE IF NOT EXISTS database."DOCTORS"
(
    "DOCTOR_ID" serial,
    "FIRST_NAME" character varying(30) NOT NULL,
    "LAST_NAME" character varying(50) NOT NULL,
    "IS_DATA_ADMINISTRATOR" numeric(1) NOT NULL,
    "PASSWORD" character varying(20) NOT NULL,
    "MIDDLE_NAME" character varying(30),
    "EMAIL" character varying(50),
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "DOCT_PK" PRIMARY KEY ("DOCTOR_ID")
);

COMMENT ON TABLE database."DOCTORS"
    IS 'Short name: DOCT';

CREATE TABLE IF NOT EXISTS database."TYPES"
(
    "TYPE_CODE" serial,
    "TYPE_DISCRIMINATOR" character varying(1) NOT NULL,
    "NAME" character varying(100) NOT NULL,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "TYP_PK" PRIMARY KEY ("TYPE_CODE", "TYPE_DISCRIMINATOR")
);

COMMENT ON TABLE database."TYPES"
    IS 'Short name: TYP';

CREATE TABLE IF NOT EXISTS database."PARAMETERS"
(
    "TYPE_CODE" integer,
    "TYPE_DISCRIMINATOR" character varying(1),
    "PARAMETER_CODE" serial,
    "NAME" character varying(100) NOT NULL,
    "DATA_TYPE" numeric(1) NOT NULL,
    "IS_PARAMETER_REGISTRATION_SUGGESTED" numeric(1) NOT NULL,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PRMS_PK" PRIMARY KEY ("TYPE_CODE", "TYPE_DISCRIMINATOR", "PARAMETER_CODE")
);

COMMENT ON TABLE database."PARAMETERS"
    IS 'Short name: PRMS';

CREATE TABLE IF NOT EXISTS database."PROCEDURES"
(
    "PATIENT_ID" integer,
    "PROCEDURE_TYPE_CODE" integer,
    "PROCEDURE_TYPE_DISCRIMINATOR" character varying(1),
    "START_DATE" date,
    "CLINICAL_DATA_TYPE_CODE" integer NOT NULL,
    "CLINICAL_DATA_TYPE_DISCRIMINATOR" character varying(1) NOT NULL,
    "CLINICAL_DATA_COLLECTION_DATE" date NOT NULL,
    "DOCTOR_ID" integer NOT NULL,
    "IS_DRAFT_VERSION" numeric NOT NULL DEFAULT 0,
    "COMPLETION_REASON_ID" integer,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PROC_PK" PRIMARY KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "START_DATE")
);

COMMENT ON TABLE database."PROCEDURES"
    IS 'Short name: PROC';

CREATE TABLE IF NOT EXISTS database."CLINICAL_DATA_PARAMETERS_VALUES"
(
    "PATIENT_ID" integer,
    "CLINICAL_DATA_TYPE_CODE" integer,
    "CLINICAL_DATA_TYPE_DISCRIMINATOR" character varying(1),
    "CLINICAL_DATA_COLLECTION_DATE" date,
    "PARAMETER_CODE" serial,
    "NUMERIC_VALUE" numeric(6, 2),
    "TEXT_VALUE" character varying(100),
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "CLDA_PRMVAL_PK" PRIMARY KEY ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "CLINICAL_DATA_COLLECTION_DATE", "PARAMETER_CODE")
);

COMMENT ON TABLE database."CLINICAL_DATA_PARAMETERS_VALUES"
    IS 'CLDA_PRMVAL';

CREATE TABLE IF NOT EXISTS database."PROCEDURES_PARAMETERS_VALUES"
(
    "PATIENT_ID" integer,
    "PROCEDURE_TYPE_CODE" integer,
    "PROCEDURE_TYPE_DISCRIMINATOR" character varying(1),
    "PROCEDURE_DATE" date,
    "PARAMETER_CODE" integer,
    "NUMERIC_VALUE" numeric(6, 2),
    "TEXT_VALUE" character varying(100),
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PROC_PRMVAL_PK" PRIMARY KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_DATE", "PARAMETER_CODE")
);

COMMENT ON TABLE database."PROCEDURES_PARAMETERS_VALUES"
    IS 'Short name: PROC_PRMVAL';

CREATE TABLE IF NOT EXISTS database."PROCEDURES_SESSIONS"
(
    "PATIENT_ID" integer,
    "PROCEDURE_TYPE_CODE" integer,
    "PROCEDURE_TYPE_DISCRIMINATOR" character varying(1),
    "PROCEDURE_DATE" date,
    "SESSION_TYPE_CODE" integer,
    "SESSION_TYPE_DISCRIMINATOR" character varying(1),
    "ORDINAL_NUMBER" numeric(3),
    "SESSION_START_DATE" date NOT NULL,
    "DOCTOR_ID" integer NOT NULL,
    "IS_DRAFT_VERSION" numeric(1) NOT NULL DEFAULT 0,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PROCSES_PK" PRIMARY KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_DATE", "SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR", "ORDINAL_NUMBER")
);

COMMENT ON TABLE database."PROCEDURES_SESSIONS"
    IS 'Short name: PROCSES';

CREATE TABLE IF NOT EXISTS database."PROCEDURES_SESSIONS_PARAMETERS_VALUES"
(
    "PATIENT_ID" integer,
    "PROCEDURE_TYPE_CODE" integer,
    "PROCEDURE_TYPE_DISCRIMINATOR" character varying(1),
    "PROCEDURE_START_DATE" date,
    "SESSION_TYPE_CODE" integer,
    "SESSION_TYPE_DISCRIMINATOR" character varying(1),
    "SESSION_ORDINAL_NUMBER" numeric(3),
    "PARAMETER_CODE" serial,
    "NUMERIC_VALUE" numeric(6, 2),
    "TEXT_VALUE" character varying(100),
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PROCSES_PRMVAL_PK" PRIMARY KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_START_DATE", "SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR", "SESSION_ORDINAL_NUMBER", "PARAMETER_CODE")
);

COMMENT ON TABLE database."PROCEDURES_SESSIONS_PARAMETERS_VALUES"
    IS 'Short name: PROCSES_PRMVAL';

CREATE TABLE IF NOT EXISTS database."PROCEDURES_COMPLETIONS_REASONS"
(
    "REASON_ID" serial,
    "NAME" character varying(100) NOT NULL,
    "DESCRIPTION" character varying(1000),
    CONSTRAINT "PROCCOMR_PK" PRIMARY KEY ("REASON_ID"),
    CONSTRAINT "PROCCOMR_NAME_UN" UNIQUE ("NAME")
);

COMMENT ON TABLE database."PROCEDURES_COMPLETIONS_REASONS"
    IS 'Short name: PROCCOMR';

CREATE TABLE IF NOT EXISTS database."DOCTORS_PATIENTS"
(
    "DOCTOR_ID" integer,
    "PATIENT_ID" integer,
    CONSTRAINT "DOCTPAT_PK" PRIMARY KEY ("DOCTOR_ID", "PATIENT_ID")
);

COMMENT ON TABLE database."DOCTORS_PATIENTS"
    IS 'Short name: DOCTPAT';

ALTER TABLE IF EXISTS database."PATIENTS"
    ADD CONSTRAINT "PAT_CLCEN_FK" FOREIGN KEY ("CLINICAL_CENTER_ID")
    REFERENCES database."CLINICAL_CENTERS" ("CLINICAL_CENTER_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PATIENTS_CLINICAL_DIAGNOSES"
    ADD CONSTRAINT "PATCLDIAG_PAT_FK" FOREIGN KEY ("PATIENT_ID")
    REFERENCES database."PATIENTS" ("PATIENT_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PATIENTS_CLINICAL_DIAGNOSES"
    ADD CONSTRAINT "PATCLDIAG_CLDIAG_FK" FOREIGN KEY ("DIAGNOSIS_ID")
    REFERENCES database."CLINICAL_DIAGNOSES" ("DIAGNOSIS_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."CLINICAL_DATA"
    ADD CONSTRAINT "CLDA_PAT_FK" FOREIGN KEY ("PATIENT_ID")
    REFERENCES database."PATIENTS" ("PATIENT_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."CLINICAL_DATA"
    ADD CONSTRAINT "CLDA_DOCT_FK" FOREIGN KEY ("DOCTOR_ID")
    REFERENCES database."DOCTORS" ("DOCTOR_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."CLINICAL_DATA"
    ADD CONSTRAINT "CLDA_TYP_FK" FOREIGN KEY ("CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR")
    REFERENCES database."TYPES" ("TYPE_CODE", "TYPE_DISCRIMINATOR") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PARAMETERS"
    ADD CONSTRAINT "PRMS_TYP_FK" FOREIGN KEY ("TYPE_CODE", "TYPE_DISCRIMINATOR")
    REFERENCES database."TYPES" ("TYPE_CODE", "TYPE_DISCRIMINATOR") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES"
    ADD CONSTRAINT "PROC_CLDA_FK" FOREIGN KEY ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "CLINICAL_DATA_COLLECTION_DATE")
    REFERENCES database."CLINICAL_DATA" ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "DATA_COLLECTION_DATE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES"
    ADD CONSTRAINT "PROC_TYP_FK" FOREIGN KEY ("PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR")
    REFERENCES database."TYPES" ("TYPE_CODE", "TYPE_DISCRIMINATOR") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES"
    ADD CONSTRAINT "PROC_PROCCOMR_FK" FOREIGN KEY ("COMPLETION_REASON_ID")
    REFERENCES database."PROCEDURES_COMPLETIONS_REASONS" ("REASON_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES"
    ADD CONSTRAINT "PROC_DOCT_FK" FOREIGN KEY ("DOCTOR_ID")
    REFERENCES database."DOCTORS" ("DOCTOR_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."CLINICAL_DATA_PARAMETERS_VALUES"
    ADD CONSTRAINT "CLDA_PRMVAL_CLDA_FK" FOREIGN KEY ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "CLINICAL_DATA_COLLECTION_DATE")
    REFERENCES database."CLINICAL_DATA" ("PATIENT_ID", "CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "DATA_COLLECTION_DATE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."CLINICAL_DATA_PARAMETERS_VALUES"
    ADD CONSTRAINT "CLDA_PRMVAL_PRMS_FK" FOREIGN KEY ("CLINICAL_DATA_TYPE_CODE", "CLINICAL_DATA_TYPE_DISCRIMINATOR", "PARAMETER_CODE")
    REFERENCES database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "PARAMETER_CODE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_PARAMETERS_VALUES"
    ADD CONSTRAINT "PROC_PRMVAL_PROC_FK" FOREIGN KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_DATE")
    REFERENCES database."PROCEDURES" ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "START_DATE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_PARAMETERS_VALUES"
    ADD CONSTRAINT "PROC_PRMVAL_PRMS_FK" FOREIGN KEY ("PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PARAMETER_CODE")
    REFERENCES database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "PARAMETER_CODE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_SESSIONS"
    ADD CONSTRAINT "PROCSES_PROC_FK" FOREIGN KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_DATE")
    REFERENCES database."PROCEDURES" ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "START_DATE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_SESSIONS"
    ADD CONSTRAINT "PROCSES_DOCT_FK" FOREIGN KEY ("DOCTOR_ID")
    REFERENCES database."DOCTORS" ("DOCTOR_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_SESSIONS"
    ADD CONSTRAINT "PROCSES_TYP_FK" FOREIGN KEY ("SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR")
    REFERENCES database."TYPES" ("TYPE_CODE", "TYPE_DISCRIMINATOR") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_SESSIONS_PARAMETERS_VALUES"
    ADD CONSTRAINT "PROCSES_PRMVAL_PROCSES_FK" FOREIGN KEY ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_START_DATE", "SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR", "SESSION_ORDINAL_NUMBER")
    REFERENCES database."PROCEDURES_SESSIONS" ("PATIENT_ID", "PROCEDURE_TYPE_CODE", "PROCEDURE_TYPE_DISCRIMINATOR", "PROCEDURE_DATE", "SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR", "ORDINAL_NUMBER") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."PROCEDURES_SESSIONS_PARAMETERS_VALUES"
    ADD CONSTRAINT "PROCSES_PRMVAL_PRMS_FK" FOREIGN KEY ("SESSION_TYPE_CODE", "SESSION_TYPE_DISCRIMINATOR", "PARAMETER_CODE")
    REFERENCES database."PARAMETERS" ("TYPE_CODE", "TYPE_DISCRIMINATOR", "PARAMETER_CODE") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."DOCTORS_PATIENTS"
    ADD CONSTRAINT "DOCTPAT_DOCT_FK" FOREIGN KEY ("DOCTOR_ID")
    REFERENCES database."DOCTORS" ("DOCTOR_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS database."DOCTORS_PATIENTS"
    ADD CONSTRAINT "DOCTPAT_PAT_FK" FOREIGN KEY ("PATIENT_ID")
    REFERENCES database."PATIENTS" ("PATIENT_ID") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

END;