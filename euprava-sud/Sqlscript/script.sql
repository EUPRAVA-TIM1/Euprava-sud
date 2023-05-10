IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Sud')
CREATE DATABASE Sud;

USE Sud

INSERT INTO Opstine (OpstinaId, PTT, Naziv)
VALUES 
('6a299d90-9df6-4d6b-b0c4-70278783b48f', 12000, 'Beograd'),
('B31EFAEB-9FA9-4904-83E3-08DB4FE55FCB', 21000, 'Novi Sad'),
('CB258BF5-ACD8-4E14-83E2-08DB4FE55FCB', 18000, 'Nis');


INSERT INTO Sudovi (SudId, OpstinaId, Naziv)
VALUES 
('571d74ed-34ee-434c-9d9a-88253eb1efec', '6a299d90-9df6-4d6b-b0c4-70278783b48f', 'Visi sud u Beogradu'),
('4f9a55e1-20cb-4b6e-8a02-d3b22f2a5597', '6a299d90-9df6-4d6b-b0c4-70278783b48f', 'Prvi osnovni sud u Beogradu'),
('77858de2-6cb1-4952-9fd4-82d9a614c3eb', 'B31EFAEB-9FA9-4904-83E3-08DB4FE55FCB', 'Osnovni sud u Novom Sadu'),
('c50c5b8e-ae24-4225-9542-7772354f4991', 'CB258BF5-ACD8-4E14-83E2-08DB4FE55FCB', 'Prekrsajni apelacioni sud u Nisu');


INSERT INTO Gradjani (Jmbg, Ime, Prezime, Mail, Broj, Adresa, OpstinaId, Discriminator, SudId)
VALUES 
('1234567890123', 'Marko', 'Erste', 'marko123@example.com', '123-456-7890', '123 Main St.', '6a299d90-9df6-4d6b-b0c4-70278783b48f', 'Sudija', '571d74ed-34ee-434c-9d9a-88253eb1efec'),
('2343123421421', 'Mirko', 'Petrovic', 'mirko123@example.com', '321-654-7890', 'Tamo daleko 8', '6a299d90-9df6-4d6b-b0c4-70278783b48f', 'Sudija', '571d74ed-34ee-434c-9d9a-88253eb1efec'),
('3123123332112', 'Dragoslav', 'Miric', 'dragi123@example.com', '123-534-74234', 'Jos dalje 9', '6a299d90-9df6-4d6b-b0c4-70278783b48f', 'Sudija', '571d74ed-34ee-434c-9d9a-88253eb1efec'),
('5235324235235', 'Ranko', 'Krivokapic', 'kriva123@example.com', '122-346-7122', 'Marsala Tita 62', 'CB258BF5-ACD8-4E14-83E2-08DB4FE55FCB', 'Sudija', '77858de2-6cb1-4952-9fd4-82d9a614c3eb'),
('2141241242144', 'Nebojsa', 'Popadic', 'popara123@example.com', '555-333-7222', 'Mike Antica 32', 'B31EFAEB-9FA9-4904-83E3-08DB4FE55FCB', 'Sudija', 'c50c5b8e-ae24-4225-9542-7772354f4991');

