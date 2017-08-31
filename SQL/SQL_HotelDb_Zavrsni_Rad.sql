CREATE DATABASE HotelDbZavrsniRad
GO

USE HotelDbZavrsniRad
GO


CREATE TABLE Gost(
GostId int IDENTITY(1,1) not null PRIMARY KEY,
Ime nvarchar(20) not null,
Prezime nvarchar(30) not null,
Jmbg char(13) not null CONSTRAINT UQ_Jmbg UNIQUE,
KontaktTelefon nvarchar(30) not null,
Email nvarchar(50)  null 
);


CREATE TABLE DodatnaUsluga(
UslugaId int IDENTITY(1,1) not null PRIMARY KEY,
NazivUsluge nvarchar(50) not null,
CenaPoDanu decimal (9,3) not null
);
CREATE TABLE TipSobe(
TipSobeId int IDENTITY(1,1) not null PRIMARY KEY,
Tip nvarchar(50) not null,
Opis nvarchar(100) null
);

CREATE TABLE Soba(
SobaId int IDENTITY(1,1) not null PRIMARY KEY,
BrojSobe varchar(5) not null,
Sprat int not null,
StatusSobe bit  null CONSTRAINT DF_Soba_Status DEFAULT(1),
TipSobeId int not null FOREIGN KEY REFERENCES TipSobe(TipSobeId),
CenaPoDanu decimal(9,3) not null
);


CREATE TABLE Cekiranje(
CekiranjeId int IDENTITY(1,1) not null PRIMARY KEY,
GostId int not null FOREIGN KEY REFERENCES Gost(GostId),
SobaId int not null FOREIGN KEY REFERENCES Soba(SobaId),
UslugaId int not null FOREIGN KEY REFERENCES DodatnaUsluga(UslugaId),
DatumCekiranja date not null,
DatumOdjave date not null,
UkupnaCenaPoDanu decimal (9,3) not null,
UNIQUE (GostId,SobaId,UslugaId)
)



CREATE TABLE SlikaSobe(
SlikaId int IDENTITY(1,1) not null PRIMARY KEY,
TipSobeId int not null FOREIGN KEY REFERENCES TipSobe(TipSobeId),
SlikaBIn varbinary(max) not null
);

CREATE TABLE Rezervacija(
SobaRezervacijaId int IDENTITY(1,1) not null PRIMARY KEY,
SobaId int not null FOREIGN KEY REFERENCES Soba(SobaId),
DatumCekiranja date not null,
DatumOdjave date not null
);




--Ubacivanje


INSERT INTO TipSobe VALUES('jednokrevetna',NULL);
INSERT INTO TipSobe VALUES('dvokrevetna',NULL);
INSERT INTO TipSobe VALUES('trokrevetna',NULL);
INSERT INTO TipSobe VALUES('apartman',NULL);



INSERT INTO Soba VALUES(11,1,1,1,1200);
INSERT INTO Soba VALUES(12,1,1,1,1200);
INSERT INTO Soba VALUES(13,1,1,1,1200);
INSERT INTO Soba VALUES(14,1,1,1,1200);
INSERT INTO Soba VALUES(15,1,1,1,1200);

INSERT INTO Soba VALUES(21,2,1,2,1870);
INSERT INTO Soba VALUES(22,2,1,2,1870);
INSERT INTO Soba VALUES(23,2,1,2,1870);
INSERT INTO Soba VALUES(24,2,1,2,1870);
INSERT INTO Soba VALUES(25,2,1,2,1870);

INSERT INTO Soba VALUES(31,3,1,3,2450);
INSERT INTO Soba VALUES(32,3,1,3,2450);
INSERT INTO Soba VALUES(33,3,1,3,2450);
INSERT INTO Soba VALUES(34,3,1,3,2450);
INSERT INTO Soba VALUES(35,3,1,3,2450);

INSERT INTO Soba VALUES(41,4,1,4,2500);
INSERT INTO Soba VALUES(42,4,1,4,2500);
INSERT INTO Soba VALUES(43,4,1,4,2500);
INSERT INTO Soba VALUES(44,4,1,4,2500);
INSERT INTO Soba VALUES(45,4,1,4,2500);

INSERT INTO DodatnaUsluga VALUES('dorucak','456.99');
INSERT INTO DodatnaUsluga VALUES('polu pansion','1340.99');
INSERT INTO DodatnaUsluga VALUES('pun pansion','2200.99');


--PROCEDURE
GO

CREATE PROC PronadjiSobuPoTipu
(
@TipSobeId int
)
AS
SELECT * FROM Soba WHERE TipSobeId=@TipSobeId;
GO


CREATE PROC DodajGosta
(
@GostId int OUTPUT,
@Ime nvarchar(20),
@Prezime nvarchar(30),
@Jmbg char(13),
@KontaktTelefon nvarchar(30),
@Email nvarchar(50)=null
)
AS
INSERT INTO Gost VALUES(@Ime,@Prezime,@Jmbg,@KontaktTelefon,@Email);
SELECT @GostId=@@IDENTITY;
GO


CREATE PROC DodajCekiranje
(
@GostId int,
@SobaId int,
@UslugaId int,
@DatumCekiranja date,
@DatumOdjave date,
@UkupnaCena decimal(9,3),
@UbacenaSobaId int OUTPUT
)
AS
INSERT INTO Cekiranje VALUES(@GostId,@SobaId,@UslugaId,@DatumCekiranja,@DatumOdjave,@UkupnaCena);
SELECT @UbacenaSobaId=(SELECT SobaId  FROM Cekiranje WHERE CekiranjeId=@@IDENTITY);
GO

CREATE PROC DodajRezervaciju(
@SobaId int,
@DatumCekiranja date,
@DatumOdjave date
)
AS
INSERT INTO Rezervacija VALUES(@SobaId,@DatumCekiranja,@DatumOdjave);

GO
CREATE TRIGGER TR_PromeniStanje
ON
Cekiranje
FOR INSERT
AS
BEGIN
	DECLARE @SobaId int
	 SET @SobaId=(SELECT SobaId FROM inserted);


	  UPDATE Soba SET StatusSobe=0 WHERE SobaId=@SobaId;
	END


GO

CREATE TRIGGER TR_VratiNaStaro
ON
Cekiranje
FOR DELETE
AS
BEGIN
	DECLARE @SobaId int
	 SET @SobaId=(SELECT SobaId FROM deleted);


	  UPDATE Soba SET StatusSobe=1 WHERE SobaId=@SobaId;
	END


GO



GO
CREATE PROC PrikaziRezervisane
AS
select *
from (
   select *,
          row_number() over (partition by SobaId order by DatumCekiranja) as row_number
   from Rezervacija
   ) as rows
where row_number = 1

GO


GO

CREATE PROC PrikaziSlobodne
(
@TipId int=null
)
AS
if(@TipId is not null)
	BEGIN
SELECT * FROM Soba WHERE StatusSobe=1 and TipSobeId=@TipId
	END
ELSE
	BEGIN
	SELECT * FROM Soba WHERE StatusSobe=1 ;
	END
GO

CREATE PROC PromeniGosta
(
@GostId int,
@Ime nvarchar(20) ,
@Prezime nvarchar(30),
@Jmbg char(13),
@KontaktTelefon nvarchar(30),
@Email nvarchar(50)
)
AS
UPDATE Gost SET Ime=@Ime,Prezime=@Prezime,Jmbg=@Jmbg,KontaktTelefon=@KontaktTelefon,Email=@Email
WHERE GostId=@GostId;

GO






GO
CREATE VIEW CekiranjeView
AS
SELECT ck.CekiranjeId,g.Ime +' '+g.Prezime as Gost,t.Tip,ck.DatumCekiranja,ck.DatumOdjave,ck.SobaId,ck.UslugaId
FROM Cekiranje as ck
INNER JOIN Gost as g
ON g.GostId=ck.GostId
INNER JOIN Soba as s
ON s.SobaId=ck.SobaId
INNER JOIN TipSobe as t
ON  s.TipSobeId=t.TipSobeId


GO



CREATE PROC PromeniStanjeSobe
(
@SobaId1 int,
@SobaId2 int
)
AS
UPDATE Soba  SET StatusSobe =1 WHERE SobaId=@SobaId1;
UPDATE Soba SET StatusSobe=0 WHERE   SobaId=@SobaId2;

GO



GO
CREATE PROC Pretraga
(
@Ime nvarchar(50)
)
AS
SELECT * FROM CekiranjeView WHERE Gost like @ime + '%'
GO





