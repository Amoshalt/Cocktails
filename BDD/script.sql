#Script de Création

#Création de la table 'Cocktail'

create database IF NOT EXISTS ISI_Projet2_TARDYMartial_REMONDVictor;
use ISI_Projet2_TARDYMartial_REMONDVictor;
CREATE TABLE Cocktail (
  NOM_COCKTAIL char(30),
  NUM_COCKTAIL int(11) UNIQUE AUTO_INCREMENT,
  IMG varchar(100),
  TAILLE int(11) NOT NULL,
  CONSTRAINT pkCo
    PRIMARY KEY (NOM_COCKTAIL)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Cocktail (NUM_COCKTAIL, NOM_COCKTAIL, IMG, TAILLE) VALUES
('1', "Kiss Cool", "", 40),
('2', "TGV", "", 30),
('3', "Bloody Sunday", "", 100),
('4', "Jäger Bomb", "", 290),
('5', "Mojito", "", 230);


#Création de la table 'Soft'

CREATE TABLE Soft (
  NOM_SOFT char(30),
  NUM_SOFT int(11) UNIQUE AUTO_INCREMENT,
  CONSTRAINT pkSo
    PRIMARY KEY (NOM_SOFT)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Soft (NUM_SOFT, NOM_SOFT) VALUES
('1', "Jus d'orange"),
('2', "Multifruit"),
('3', "Sirop Grenadine"),
('4', "RedBull"),
('5', "Jus de pomme"),
('6', "Sirop de sucre de canne"),
('7', "Limonade");


#Création de la table 'Alcool'

CREATE TABLE Alcool (
  NOM_ALCOOL Varchar(30),
  NUM_ALCOOL int(11) UNIQUE AUTO_INCREMENT,
  DEGRE FLOAT,
  CONSTRAINT pkAl
    PRIMARY KEY (NOM_ALCOOL)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Alcool (NUM_ALCOOL, NOM_ALCOOL, DEGRE) VALUES
('1', "Get 27", "21"),
('2', "Get 31", "27"),
('3', "Vodka", "40"),
('4', "Tequila", "40"),
('5', "Gin", "45"),
('6', "Wisky", "42"),
('7', "Jägermeister", "35"),
('8', "Rhum", "40");


#Création de la table 'IngredientSoft'

CREATE TABLE IngredientSoft (
  NUM_COCKTAIL int(11),
  NUM_SOFT int(11),
  QUANTITE int(11) NOT NULL,
  CONSTRAINT pkInSo
    PRIMARY KEY (NUM_COCKTAIL, NUM_SOFT),
  CONSTRAINT fkInSo1
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL),
  CONSTRAINT fkInSo2
    FOREIGN KEY (NUM_SOFT)
    REFERENCES Soft(NUM_SOFT)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO IngredientSoft (NUM_COCKTAIL, NUM_SOFT, QUANTITE) VALUES
('3', '1', '60'),
('3', '3', '10'),
('4', '4', '86'),
('5', '6', '7'),
('5', '7', '66');


#Création de la table 'IngredientAlcool'

CREATE TABLE IngredientAlcool (
  NUM_COCKTAIL int(11),
  NUM_ALCOOL int(11),
  QUANTITE int(11) NOT NULL,
  CONSTRAINT pkInAl 
    PRIMARY KEY (NUM_COCKTAIL, NUM_ALCOOL),
  CONSTRAINT fkInAl1
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL),
  CONSTRAINT fkInAl2
    FOREIGN KEY (NUM_ALCOOL)
    REFERENCES Alcool(NUM_ALCOOL)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO IngredientAlcool (NUM_COCKTAIL, NUM_ALCOOL, QUANTITE) VALUES
('1', '2', '40'),
('1', '3', '60'),
('2', '4', '33'),
('2', '5', '33'),
('2', '3', '33'),
('3', '3', '30'),
('4', '7', '14'),
('5', '8', '27');


#Création de la table 'EtapeRecette'

CREATE TABLE EtapeRecette (
  NUM_COCKTAIL int(11),
  NUM_ETAPE int(11),
  ETAPE varchar(100),
  CONSTRAINT pkEtRe 
    PRIMARY KEY (NUM_COCKTAIL, NUM_ETAPE),
  CONSTRAINT fkEtRe
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO EtapeRecette (NUM_COCKTAIL, NUM_ETAPE, ETAPE) VALUES
(1, 1, "Verser directement la vodka et le Get dans un shooter."),
(2, 1, "Le melange se fait directement dans le verre, ajouter des glacons."),
(3, 1, "Melanger la grenadine, le jus d'orange et la vodka. Ajouter des glacons."),
(4, 1, "Verser le RedBull dans un grand verre."),
(4, 2, "Remplir un shooter de Jagermeister."),
(4, 3, "Laiser tomber le shooter dans le verre de RedBull."),
(5, 1, "Placer des feuilles de menthe dans le verre."),
(5, 2, "Ajouter le sucre et le jus de citron."),
(5, 3, "Ahouter le rhum, remplir le verre a moitie de glacons et completer avec de la limonade."),
(5, 4, "Utiliser de preference du jus de citron vert frais.");