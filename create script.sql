-- Drop tables
DROP TABLE Huurcontract CASCADE CONSTRAINTS;
DROP TABLE Artikelen CASCADE CONSTRAINTS;
DROP TABLE Huurder CASCADE CONSTRAINTS;
DROP TABLE Vaargebied CASCADE CONSTRAINTS;
DROP TABLE Boot CASCADE CONSTRAINTS;
DROP TABLE Spierkrachtaangedreven CASCADE CONSTRAINTS;
DROP TABLE Motor CASCADE CONSTRAINTS;
DROP TABLE GehuurdeArtikelen CASCADE CONSTRAINTS;
DROP TABLE VaargebiedHuurcontract CASCADE CONSTRAINTS;
DROP TABLE Bedrijf CASCADE CONSTRAINTS;
DROP TABLE Account CASCADE CONSTRAINTS;

-- Create tables

CREATE TABLE Bedrijf
(
	id number PRIMARY KEY,
	naam varchar2(100)
);

CREATE TABLE Account
(
	id number PRIMARY KEY,
	emailadres varchar2(100) NOT NULL,
	wachtwoord varchar2(100) NOT NULL,
	bedrijfId number NOT NULL,
	CONSTRAINT account_fk FOREIGN KEY (bedrijfId) REFERENCES Bedrijf(id)
);

CREATE TABLE Boot
(
	naam varchar2(100) PRIMARY KEY,
	type varchar2(100) NOT NULL,
	soort varchar2(100) NOT NULL,
	bedrijfId number NOT NULL,
	CONSTRAINT boot_fk FOREIGN KEY (bedrijfId) REFERENCES Bedrijf(id)
);

CREATE TABLE Motor
(
	bootNaam varchar2(100) PRIMARY KEY,
	tankInhoud number NOT NULL,
	CONSTRAINT motor_fk FOREIGN KEY(bootNaam) REFERENCES Boot(naam)
);

CREATE TABLE Spierkrachtaangedreven
(
	bootNaam varchar2(100) PRIMARY KEY,
	CONSTRAINT spierkrachtaangedreven_fk FOREIGN KEY(bootNaam) REFERENCES Boot(naam)
);

CREATE TABLE Artikelen
(
	id number PRIMARY KEY,
	naam varchar2(100) NOT NULL,
	prijs number NOT NULL,
	bedrijfId number NOT NULL,
	CONSTRAINT artikelen_fk FOREIGN KEY (bedrijfId) REFERENCES Bedrijf(id)
);

CREATE TABLE Vaargebied
(
	id number PRIMARY KEY,
	naam varchar2(100) NOT NULL
);

CREATE TABLE Huurder
(
	id number PRIMARY KEY,
	naam varchar2(100),
	emailadres varchar2(100)
);

CREATE TABLE Huurcontract
(
	id number PRIMARY KEY,
	bootNaam varchar2(100) NOT NULL,
	huurderId number NOT NULL,
	beginDatum date NOT NULL,
	eindDatum date NOT NULL,
	aantalMeren number DEFAULT '0',
	prijs number NOT NULL,
	bedrijfId number NOT NULL,
	CONSTRAINT huurcontract_fk FOREIGN KEY (bedrijfId) REFERENCES Bedrijf(id),
	CONSTRAINT huurder_fk FOREIGN KEY (bootNaam) REFERENCES Boot(Naam),
	CONSTRAINT huurder_fk2 FOREIGN KEY (huurderId) REFERENCES Huurder(Id)
);

CREATE TABLE GehuurdeArtikelen
(
	huurcontractId number NOT NULL,
	artikelId number NOT NULL,
	CONSTRAINT gehuurdeArtikelen_fk FOREIGN KEY (huurcontractId) REFERENCES Huurcontract(id),
	CONSTRAINT gehuurdeArtikelen_fk2 FOREIGN KEY (artikelId) REFERENCES Artikelen(id),
	CONSTRAINT gehuurdeArtikelen_pk PRIMARY KEY (huurcontractId, artikelId)
);

CREATE TABLE VaargebiedHuurcontract
(
	huurcontractId number NOT NULL,
	vaargebiedId number NOT NULL,
	CONSTRAINT vaargebiedHuurcontract_fk FOREIGN KEY (huurcontractId) REFERENCES Huurcontract(id),
	CONSTRAINT vaargebiedHuurcontract_fk2 FOREIGN KEY (vaargebiedId)  REFERENCES Vaargebied(id),
	CONSTRAINT vaargebiedHuurcontract_pk PRIMARY KEY (huurcontractId, vaargebiedId)
);

-- Testdata

INSERT INTO Bedrijf VALUES('0', 't Sloepke');

INSERT INTO Account VALUES ('0', 'admin@gmail.com', 'password', '0');

INSERT INTO Boot VALUES ('Grote Kano', 'Valk', 'Kano', '0');
INSERT INTO Spierkrachtaangedreven VALUES('Grote Kano');
INSERT INTO Boot VALUES ('Lil Sailor', 'Valk', 'Zeilboot', '0');
INSERT INTO Spierkrachtaangedreven VALUES ('Lil Sailor');
INSERT INTO Boot VALUES ('Zeilboot Nederland', 'Laser', 'Zeilboot', '0');
INSERT INTO Spierkrachtaangedreven VALUES ('Zeilboot Nederland');
INSERT INTO Boot VALUES ('MotorSloot', 'Kruiser', 'Motorboot', '0');
INSERT INTO Motor VALUES ('MotorSloot', '25');

INSERT INTO Artikelen VALUES ('0', 'Zwemvest', '1,25', '0');
INSERT INTO Artikelen VALUES ('1', 'Snorkel', '1,25', '0');
INSERT INTO Artikelen VALUES ('2', 'Duikbril', '1,25', '0');

INSERT INTO Vaargebied VALUES ('0', 'Noordzee');
INSERT INTO Vaargebied VALUES ('1', 'IJsselmeer');

INSERT INTO Huurder VALUES ('0', 'Sven Henderickx', 'sven@gmail.com');
INSERT INTO Huurcontract VALUES ('0', 'Grote Kano', '0', TO_DATE('2016/06/23', 'yyyy/mm/dd'), TO_DATE('2016/06/23', 'yyyy/mm/dd'), '4',  '25,00', '0');
INSERT INTO GehuurdeArtikelen VALUES('0', '0');
INSERT INTO GehuurdeArtikelen VALUES('0', '1');

INSERT INTO Huurder VALUES ('1', 'Henk Henksen', 'henk@gmail.com');
INSERT INTO Huurcontract VALUES ('1', 'MotorSloot', '1', TO_DATE('2016/06/23', 'yyyy/mm/dd'), TO_DATE('2016/06/23', 'yyyy/mm/dd'), '5',  '25,00', '0');
INSERT INTO GehuurdeArtikelen VALUES('1', '0');
INSERT INTO GehuurdeArtikelen VALUES('1', '1');
INSERT INTO VaargebiedHuurcontract VALUES ('1', '0');
COMMIT;