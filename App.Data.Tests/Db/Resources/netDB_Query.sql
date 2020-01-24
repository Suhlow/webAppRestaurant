INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet chinois',0745821654,'beignets de crevette exceptionnels','toufa@neuf.ch',2,2);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet congolais',0745821654,'les serviettes étaient douces','congoa@buffet.uk',1,8);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet portuguais',0745821654,'une sauce tres amer','porto@buffet.uk',2,7);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet arménien',0745821654,'recommandable','arma@buffet.uk',3,6);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet corréen',0745821654,'suculent savon','corree@buffet.uk',4,5);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet hongrois',0745821654,'qui a dit que le riz était démodé?','hongri@buffet.uk',5,4);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet catalan',0745821654,'excellente vodka','catala@buffet.uk',6,3);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet israelien',0745821654,'sans saveur mais beaucoup dentrain','israel@buffet.uk',7,2);
INSERT INTO Restaurants (nom, num_tel, commentaire, mail_proprio, adresseID, noteID) 
VALUES ('Buffet francais',0745821654,'beignets de crevette exceptionnels','franco@buffet.uk',8,1);

INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('11/01/2020',8,'inégalé');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('11/01/2020',8,'service pontané');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('12/06/1978',7,'truculent');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('15/04/2020',6,'excquis');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('06/06/1666',5,'fantasmagorique');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('11/01/2004',4,'dément');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('10/03/1999',10,'incroyable');
INSERT INTO Notes (date_dv, note, commentaire_dv) 
VALUES('10/10/2019',9,'extra');


INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (52, 'rue lakanal', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (15, 'rue barbe', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (5, 'rue ralle', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (2, 'rue matisme', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (12, 'rue stick', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (22, 'rue neuh', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (72, 'rue bixcube', 38100, 'Grenoble');
INSERT INTO Adresses (num_voie, rue, cp, ville) 
VALUES (6, 'rue bis', 38100, 'Grenoble');

SELECT * FROM Restaurants;