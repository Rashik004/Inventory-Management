--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.5
-- Dumped by pg_dump version 9.6.5

-- Started on 2017-11-13 18:50:53

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 186 (class 1259 OID 24688)
-- Name: DeviceInstance; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "DeviceInstance" (
    "DeviceInstanceId" integer NOT NULL,
    "ManufacturingYear" integer,
    "SeriaNo" character varying(100),
    "RFID" character varying(100),
    "DescriptionTitle" character varying(100),
    "Description" character varying(500),
    "DeviceStatusId" integer,
    "DeviceTypeId" integer NOT NULL
);


ALTER TABLE "DeviceInstance" OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 24682)
-- Name: DeviceInstance_DeviceInstanceId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "DeviceInstance_DeviceInstanceId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "DeviceInstance_DeviceInstanceId_seq" OWNER TO postgres;

--
-- TOC entry 2208 (class 0 OID 0)
-- Dependencies: 185
-- Name: DeviceInstance_DeviceInstanceId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "DeviceInstance_DeviceInstanceId_seq" OWNED BY "DeviceInstance"."DeviceInstanceId";


--
-- TOC entry 188 (class 1259 OID 24701)
-- Name: DeviceStatus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "DeviceStatus" (
    "DeviceStatusId" integer NOT NULL,
    "DeviceStatusEnglishName" character varying(100)
);


ALTER TABLE "DeviceStatus" OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 32799)
-- Name: DeviceStatusHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "DeviceStatusHistory" (
    "DeviceStatusHistoryId" integer NOT NULL,
    "DeviceInstanceId" integer NOT NULL,
    "ModificationDate" date,
    "ModifiedByUserId" integer NOT NULL,
    "NewStatusId" integer NOT NULL
);


ALTER TABLE "DeviceStatusHistory" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 32797)
-- Name: DeviceStatusHistory_DeviceStatusHistoryId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "DeviceStatusHistory_DeviceStatusHistoryId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "DeviceStatusHistory_DeviceStatusHistoryId_seq" OWNER TO postgres;

--
-- TOC entry 2209 (class 0 OID 0)
-- Dependencies: 199
-- Name: DeviceStatusHistory_DeviceStatusHistoryId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "DeviceStatusHistory_DeviceStatusHistoryId_seq" OWNED BY "DeviceStatusHistory"."DeviceStatusHistoryId";


--
-- TOC entry 187 (class 1259 OID 24699)
-- Name: DeviceStatus_DeviceStatusId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "DeviceStatus_DeviceStatusId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "DeviceStatus_DeviceStatusId_seq" OWNER TO postgres;

--
-- TOC entry 2210 (class 0 OID 0)
-- Dependencies: 187
-- Name: DeviceStatus_DeviceStatusId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "DeviceStatus_DeviceStatusId_seq" OWNED BY "DeviceStatus"."DeviceStatusId";


--
-- TOC entry 190 (class 1259 OID 24709)
-- Name: DeviceType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "DeviceType" (
    "DeviceTypeId" integer NOT NULL,
    "DevicaeName" character varying(500),
    "DeviceDescription" character varying(25),
    "DeviceModel" character varying(50),
    "DeviceVersion" character varying(50),
    "DeviceVendor" character varying(50)
);


ALTER TABLE "DeviceType" OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 24707)
-- Name: DeviceType_DeviceTypeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "DeviceType_DeviceTypeId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "DeviceType_DeviceTypeId_seq" OWNER TO postgres;

--
-- TOC entry 2211 (class 0 OID 0)
-- Dependencies: 189
-- Name: DeviceType_DeviceTypeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "DeviceType_DeviceTypeId_seq" OWNED BY "DeviceType"."DeviceTypeId";


--
-- TOC entry 194 (class 1259 OID 24724)
-- Name: ReservationList; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "ReservationList" (
    "ReservationId" integer NOT NULL,
    "ReserverUserId" integer NOT NULL,
    "StartDate" date,
    "EndDate" date,
    "DeviceInstanceId" integer NOT NULL,
    "ReservationDate" date
);


ALTER TABLE "ReservationList" OWNER TO postgres;

--
-- TOC entry 193 (class 1259 OID 24722)
-- Name: ReservationList_DeviceTypeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "ReservationList_DeviceTypeId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ReservationList_DeviceTypeId_seq" OWNER TO postgres;

--
-- TOC entry 2212 (class 0 OID 0)
-- Dependencies: 193
-- Name: ReservationList_DeviceTypeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "ReservationList_DeviceTypeId_seq" OWNED BY "ReservationList"."DeviceInstanceId";


--
-- TOC entry 191 (class 1259 OID 24718)
-- Name: ReservationList_ReservationId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "ReservationList_ReservationId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ReservationList_ReservationId_seq" OWNER TO postgres;

--
-- TOC entry 2213 (class 0 OID 0)
-- Dependencies: 191
-- Name: ReservationList_ReservationId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "ReservationList_ReservationId_seq" OWNED BY "ReservationList"."ReservationId";


--
-- TOC entry 192 (class 1259 OID 24720)
-- Name: ReservationList_ReserverUserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "ReservationList_ReserverUserId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ReservationList_ReserverUserId_seq" OWNER TO postgres;

--
-- TOC entry 2214 (class 0 OID 0)
-- Dependencies: 192
-- Name: ReservationList_ReserverUserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "ReservationList_ReserverUserId_seq" OWNED BY "ReservationList"."ReserverUserId";


--
-- TOC entry 196 (class 1259 OID 24736)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "User" (
    "UserId" integer NOT NULL,
    "FirstName" character varying(50),
    "LastName" character varying(50),
    "UserName" character varying(100) NOT NULL,
    "Email" character varying(100),
    "Designation" character varying(10),
    "Address" character varying(500),
    "Title" character varying(50),
    "UserTypeId" integer NOT NULL
);


ALTER TABLE "User" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 24748)
-- Name: UserType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "UserType" (
    "UserTypeId" integer NOT NULL,
    "UserTypeEnglishName" character varying(500)
);


ALTER TABLE "UserType" OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 24746)
-- Name: UserType_UserTypeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "UserType_UserTypeId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "UserType_UserTypeId_seq" OWNER TO postgres;

--
-- TOC entry 2215 (class 0 OID 0)
-- Dependencies: 197
-- Name: UserType_UserTypeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "UserType_UserTypeId_seq" OWNED BY "UserType"."UserTypeId";


--
-- TOC entry 195 (class 1259 OID 24732)
-- Name: User_UserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "User_UserId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "User_UserId_seq" OWNER TO postgres;

--
-- TOC entry 2216 (class 0 OID 0)
-- Dependencies: 195
-- Name: User_UserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "User_UserId_seq" OWNED BY "User"."UserId";


--
-- TOC entry 2044 (class 2604 OID 24691)
-- Name: DeviceInstance DeviceInstanceId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceInstance" ALTER COLUMN "DeviceInstanceId" SET DEFAULT nextval('"DeviceInstance_DeviceInstanceId_seq"'::regclass);


--
-- TOC entry 2045 (class 2604 OID 24704)
-- Name: DeviceStatus DeviceStatusId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceStatus" ALTER COLUMN "DeviceStatusId" SET DEFAULT nextval('"DeviceStatus_DeviceStatusId_seq"'::regclass);


--
-- TOC entry 2052 (class 2604 OID 32802)
-- Name: DeviceStatusHistory DeviceStatusHistoryId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceStatusHistory" ALTER COLUMN "DeviceStatusHistoryId" SET DEFAULT nextval('"DeviceStatusHistory_DeviceStatusHistoryId_seq"'::regclass);


--
-- TOC entry 2046 (class 2604 OID 24712)
-- Name: DeviceType DeviceTypeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceType" ALTER COLUMN "DeviceTypeId" SET DEFAULT nextval('"DeviceType_DeviceTypeId_seq"'::regclass);


--
-- TOC entry 2047 (class 2604 OID 24727)
-- Name: ReservationList ReservationId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList" ALTER COLUMN "ReservationId" SET DEFAULT nextval('"ReservationList_ReservationId_seq"'::regclass);


--
-- TOC entry 2048 (class 2604 OID 24728)
-- Name: ReservationList ReserverUserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList" ALTER COLUMN "ReserverUserId" SET DEFAULT nextval('"ReservationList_ReserverUserId_seq"'::regclass);


--
-- TOC entry 2049 (class 2604 OID 24729)
-- Name: ReservationList DeviceInstanceId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList" ALTER COLUMN "DeviceInstanceId" SET DEFAULT nextval('"ReservationList_DeviceTypeId_seq"'::regclass);


--
-- TOC entry 2050 (class 2604 OID 24739)
-- Name: User UserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "User" ALTER COLUMN "UserId" SET DEFAULT nextval('"User_UserId_seq"'::regclass);


--
-- TOC entry 2051 (class 2604 OID 24751)
-- Name: UserType UserTypeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserType" ALTER COLUMN "UserTypeId" SET DEFAULT nextval('"UserType_UserTypeId_seq"'::regclass);


--
-- TOC entry 2187 (class 0 OID 24688)
-- Dependencies: 186
-- Data for Name: DeviceInstance; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "DeviceInstance" ("DeviceInstanceId", "ManufacturingYear", "SeriaNo", "RFID", "DescriptionTitle", "Description", "DeviceStatusId", "DeviceTypeId") VALUES (15, 0, '420', '420', 'd 420', 'd 420', 1, 2);
INSERT INTO "DeviceInstance" ("DeviceInstanceId", "ManufacturingYear", "SeriaNo", "RFID", "DescriptionTitle", "Description", "DeviceStatusId", "DeviceTypeId") VALUES (16, 0, '100', '200', '300', '300', 1, 1);
INSERT INTO "DeviceInstance" ("DeviceInstanceId", "ManufacturingYear", "SeriaNo", "RFID", "DescriptionTitle", "Description", "DeviceStatusId", "DeviceTypeId") VALUES (18, 0, '1345', 'aaa', 'checking dashboard', 'checking dashboard', 1, 1);
INSERT INTO "DeviceInstance" ("DeviceInstanceId", "ManufacturingYear", "SeriaNo", "RFID", "DescriptionTitle", "Description", "DeviceStatusId", "DeviceTypeId") VALUES (17, 0, '1', 'r1', 'd1', 'd1', 2, 3);


--
-- TOC entry 2217 (class 0 OID 0)
-- Dependencies: 185
-- Name: DeviceInstance_DeviceInstanceId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"DeviceInstance_DeviceInstanceId_seq"', 18, true);


--
-- TOC entry 2189 (class 0 OID 24701)
-- Dependencies: 188
-- Data for Name: DeviceStatus; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "DeviceStatus" ("DeviceStatusId", "DeviceStatusEnglishName") VALUES (1, 'In Stock');
INSERT INTO "DeviceStatus" ("DeviceStatusId", "DeviceStatusEnglishName") VALUES (2, 'Reserved');
INSERT INTO "DeviceStatus" ("DeviceStatusId", "DeviceStatusEnglishName") VALUES (3, 'Loaned');
INSERT INTO "DeviceStatus" ("DeviceStatusId", "DeviceStatusEnglishName") VALUES (4, 'Maintance');
INSERT INTO "DeviceStatus" ("DeviceStatusId", "DeviceStatusEnglishName") VALUES (5, 'Out Of Order');


--
-- TOC entry 2201 (class 0 OID 32799)
-- Dependencies: 200
-- Data for Name: DeviceStatusHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "DeviceStatusHistory" ("DeviceStatusHistoryId", "DeviceInstanceId", "ModificationDate", "ModifiedByUserId", "NewStatusId") VALUES (1, 17, '2017-10-16', 2, 2);
INSERT INTO "DeviceStatusHistory" ("DeviceStatusHistoryId", "DeviceInstanceId", "ModificationDate", "ModifiedByUserId", "NewStatusId") VALUES (2, 17, '2017-10-16', 2, 2);
INSERT INTO "DeviceStatusHistory" ("DeviceStatusHistoryId", "DeviceInstanceId", "ModificationDate", "ModifiedByUserId", "NewStatusId") VALUES (3, 17, '2017-10-16', 2, 2);
INSERT INTO "DeviceStatusHistory" ("DeviceStatusHistoryId", "DeviceInstanceId", "ModificationDate", "ModifiedByUserId", "NewStatusId") VALUES (4, 17, '2017-10-16', 2, 2);


--
-- TOC entry 2218 (class 0 OID 0)
-- Dependencies: 199
-- Name: DeviceStatusHistory_DeviceStatusHistoryId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"DeviceStatusHistory_DeviceStatusHistoryId_seq"', 4, true);


--
-- TOC entry 2219 (class 0 OID 0)
-- Dependencies: 187
-- Name: DeviceStatus_DeviceStatusId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"DeviceStatus_DeviceStatusId_seq"', 5, true);


--
-- TOC entry 2191 (class 0 OID 24709)
-- Dependencies: 190
-- Data for Name: DeviceType; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (1, 'ProjectorHp', 'Hp 3600 pixel Projector', NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (2, 'Transistor', 'Transistor Board', NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (3, 'TypeName', 'd', NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (4, 'Oct11', 'Testing Purpose', NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (5, 'New Item', NULL, NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (6, 'Name1', 'Description1', NULL, NULL, NULL);
INSERT INTO "DeviceType" ("DeviceTypeId", "DevicaeName", "DeviceDescription", "DeviceModel", "DeviceVersion", "DeviceVendor") VALUES (7, '1', '4', '2', '3', NULL);


--
-- TOC entry 2220 (class 0 OID 0)
-- Dependencies: 189
-- Name: DeviceType_DeviceTypeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"DeviceType_DeviceTypeId_seq"', 7, true);


--
-- TOC entry 2195 (class 0 OID 24724)
-- Dependencies: 194
-- Data for Name: ReservationList; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2221 (class 0 OID 0)
-- Dependencies: 193
-- Name: ReservationList_DeviceTypeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"ReservationList_DeviceTypeId_seq"', 1, false);


--
-- TOC entry 2222 (class 0 OID 0)
-- Dependencies: 191
-- Name: ReservationList_ReservationId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"ReservationList_ReservationId_seq"', 1, false);


--
-- TOC entry 2223 (class 0 OID 0)
-- Dependencies: 192
-- Name: ReservationList_ReserverUserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"ReservationList_ReserverUserId_seq"', 1, false);


--
-- TOC entry 2197 (class 0 OID 24736)
-- Dependencies: 196
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "User" ("UserId", "FirstName", "LastName", "UserName", "Email", "Designation", "Address", "Title", "UserTypeId") VALUES (1, '1', '2', 'uname', '3', '4', '5', '6', 2);
INSERT INTO "User" ("UserId", "FirstName", "LastName", "UserName", "Email", "Designation", "Address", "Title", "UserTypeId") VALUES (2, 'Super', 'Admin', 'admin', 'mail', 'desig', 'Address', 'Title', 0);
INSERT INTO "User" ("UserId", "FirstName", "LastName", "UserName", "Email", "Designation", "Address", "Title", "UserTypeId") VALUES (3, NULL, NULL, 'tester', NULL, NULL, NULL, NULL, 2);


--
-- TOC entry 2199 (class 0 OID 24748)
-- Dependencies: 198
-- Data for Name: UserType; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "UserType" ("UserTypeId", "UserTypeEnglishName") VALUES (0, 'Admin');
INSERT INTO "UserType" ("UserTypeId", "UserTypeEnglishName") VALUES (1, 'User');


--
-- TOC entry 2224 (class 0 OID 0)
-- Dependencies: 197
-- Name: UserType_UserTypeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"UserType_UserTypeId_seq"', 1, true);


--
-- TOC entry 2225 (class 0 OID 0)
-- Dependencies: 195
-- Name: User_UserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"User_UserId_seq"', 3, true);


--
-- TOC entry 2054 (class 2606 OID 24698)
-- Name: DeviceInstance DeviceInstance_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceInstance"
    ADD CONSTRAINT "DeviceInstance_pkey" PRIMARY KEY ("DeviceInstanceId");


--
-- TOC entry 2066 (class 2606 OID 32804)
-- Name: DeviceStatusHistory DeviceStatusHistory_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceStatusHistory"
    ADD CONSTRAINT "DeviceStatusHistory_pkey" PRIMARY KEY ("DeviceStatusHistoryId");


--
-- TOC entry 2056 (class 2606 OID 24706)
-- Name: DeviceStatus DeviceStatus_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceStatus"
    ADD CONSTRAINT "DeviceStatus_pkey" PRIMARY KEY ("DeviceStatusId");


--
-- TOC entry 2058 (class 2606 OID 24717)
-- Name: DeviceType DeviceType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "DeviceType"
    ADD CONSTRAINT "DeviceType_pkey" PRIMARY KEY ("DeviceTypeId");


--
-- TOC entry 2060 (class 2606 OID 24731)
-- Name: ReservationList ReservationList_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList"
    ADD CONSTRAINT "ReservationList_pkey" PRIMARY KEY ("ReservationId");


--
-- TOC entry 2064 (class 2606 OID 24753)
-- Name: UserType UserType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserType"
    ADD CONSTRAINT "UserType_pkey" PRIMARY KEY ("UserTypeId");


--
-- TOC entry 2062 (class 2606 OID 24745)
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");


--
-- TOC entry 2068 (class 2606 OID 24769)
-- Name: ReservationList REL_1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList"
    ADD CONSTRAINT "REL_1" FOREIGN KEY ("ReserverUserId") REFERENCES "User"("UserId");


--
-- TOC entry 2067 (class 2606 OID 24764)
-- Name: ReservationList ReservationList_FK_DeviceType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "ReservationList"
    ADD CONSTRAINT "ReservationList_FK_DeviceType" FOREIGN KEY ("DeviceInstanceId") REFERENCES "DeviceType"("DeviceTypeId");


--
-- TOC entry 2207 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2017-11-13 18:50:53

--
-- PostgreSQL database dump complete
--

