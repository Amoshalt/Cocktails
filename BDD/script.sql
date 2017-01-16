#Script de Création

#Création de la table 'Cocktail'

create database IF NOT EXISTS ISI_Projet2_TARDYMartial_REMONDVictor;
use ISI_Projet2_TARDYMartial_REMONDVictor;
CREATE TABLE Cocktail (
  NOM_COCKTAIL char(30),
  NUM_COCKTAIL int(11) UNIQUE AUTO_INCREMENT,
  IMG char(100),
  TAILLE int(11) NOT NULL,
  CONSTRAINT Prim1
    PRIMARY KEY (NOM_COCKTAIL),
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Cocktail (NOM_COCKTAIL, NUM_COCKTAIL, IMG, TAILLE) VALUES
('1', "Kiss Cool", "", 40),
('2', "TGV", "", 30),
('3', "Bloody Sunday", "", 100),
('4', "Jager Bomb", "", 290),
('5', "Mojito", "", 23);


#Création de la table 'Soft'

CREATE TABLE Soft (
  NOM_SOFT char(30),
  NUM_SOFT int(11) UNIQUE AUTO_INCREMENT,
  CONSTRAINT Prim1
    PRIMARY KEY (NOM_SOFT),
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Soft (NOM_SOFT, NUM_SOFT) VALUES
('1', "Jus d'orange"),
('2', "Multifruit"),
('3', "Sirop Grenadine"),
('4', "RedBull"),
('5', "Jus de pomme"),
('6', "Sirop de sucre de canne"),
('7', "Limonade");


#Création de la table 'Alcool'

CREATE TABLE Alcool (
  NOM_ALCOOL char(30),
  NUM_ALCOOL int(11) UNIQUE AUTO_INCREMENT,
  DEGRE FLOAT,
  CONSTRAINT Prim1
    PRIMARY KEY (NOM_ALCOOL),
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO Alcool (NOM_ALCOOL, NUM_ALCOOL, DEGRE) VALUES
('1', "Get 27", "21"),
('2', "Get 31", "27"),
('3', "Vodka", "40"),
('4', "Tequila", "40"),
('5', "Gin", "45"),
('6', "Wisky", "42"),
('7', "Jager", "35"),
('8', "Rhum", "40");


#Création de la table 'IngredientSoft'

CREATE TABLE IngredientSoft (
  NUM_COCKTAIL int(11),
  NUM_SOFT int(11),
  QUANTITE int(11) NOT NULL,
  CONSTRAINT NumCo
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL),
  CONSTRAINT NumSo
    FOREIGN KEY (NUM_SOFT)
    REFERENCES Soft(NUM_SOFT),
  CONSTRAINT Prim 
    PRIMARY KEY (NUM_COCKTAIL, NUM_SOFT)
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
  CONSTRAINT NumCo
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL),
  CONSTRAINT NumAl
    FOREIGN KEY (NUM_ALCOOL)
    REFERENCES Alcool(NUM_ALCOOL),
  CONSTRAINT Prim 
    PRIMARY KEY (NUM_COCKTAIL, NUM_ALCOOL)
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
  QUANTITE int(11) NOT NULL,
  CONSTRAINT NumCo
    FOREIGN KEY (NUM_COCKTAIL)
    REFERENCES Cocktail(NUM_COCKTAIL),
  CONSTRAINT Prim 
    PRIMARY KEY (NUM_COCKTAIL, NUM_ETAPE)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;