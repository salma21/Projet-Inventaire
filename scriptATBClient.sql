use InventaireBiss2015
create table Biens (
   Code_materiel         int                  not null,
   Num_Serie               nvarchar(max)                  not null,
   Categorie            nvarchar(max)                  not null,
   Modele       nvarchar(max)           not null,
   Marque       nvarchar(max)                  not null,
   Statut      nvarchar(max)                  not null,
   Fin_garantie           nvarchar(max)                  not null,
   Etage             nvarchar(max)                  not null,
   Entite_dernier         nvarchar(max)                  not null,
   dateInventaire            date                  not null,
   dateInstalation              date                  not null,
    localisation              nvarchar(max)                  not null,
     Entite_complet              nvarchar(max)                  not null,
  )
go