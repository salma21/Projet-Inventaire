USE [InventaireBiss2015]
GO
/****** Object:  Table [dbo].[Direction]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Direction](
	[Id_direction] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
 CONSTRAINT [PK_DIRECTION] PRIMARY KEY NONCLUSTERED 
(
	[Id_direction] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorie_materiel]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie_materiel](
	[Id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](254) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATEGORIE_MATERIEL] PRIMARY KEY NONCLUSTERED 
(
	[Id_categorie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventaire]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventaire](
	[Id_inventaire] [int] IDENTITY(1,1) NOT NULL,
	[Nom_] [varchar](254) NULL,
	[Type] [varchar](254) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_INVENTAIRE] PRIMARY KEY NONCLUSTERED 
(
	[Id_inventaire] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organisation](
	[idOrganisation] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_ORGANISATION] PRIMARY KEY NONCLUSTERED 
(
	[idOrganisation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pays]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pays](
	[idPays] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
 CONSTRAINT [PK_PAYS] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service](
	[Id_direction] [int] NOT NULL,
	[Id_service] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
 CONSTRAINT [PK_SERVICE] PRIMARY KEY NONCLUSTERED 
(
	[Id_direction] ASC,
	[Id_service] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategorieDesignation]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieDesignation](
	[Id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[id_categorie_Designation] [int] NOT NULL,
	[libelle] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATEGORIEDESIGNATION] PRIMARY KEY NONCLUSTERED 
(
	[Id_categorie] ASC,
	[id_categorie_Designation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Region](
	[idPays] [int] NOT NULL,
	[idRegion] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
 CONSTRAINT [PK_REGION] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gouvernorat]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Gouvernorat](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
 CONSTRAINT [PK_GOUVERNORAT] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Delegation]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Delegation](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
	[Code_postal] [int] NULL,
 CONSTRAINT [PK_DELEGATION] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Societe_maintenance]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Societe_maintenance](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_societe_maintenance] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
	[Rue] [varchar](254) NULL,
	[Tel] [int] NULL,
	[Fax] [int] NULL,
	[Email] [varchar](254) NULL,
	[Commentaire] [varchar](254) NULL,
 CONSTRAINT [PK_SOCIETE_MAINTENANCE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_societe_maintenance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Societe_assurance]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Societe_assurance](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_societe_assurance] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
	[Rue] [varchar](254) NULL,
	[Tel] [int] NULL,
	[Fax] [int] NULL,
	[Email] [varchar](254) NULL,
	[Commentaire] [varchar](254) NULL,
 CONSTRAINT [PK_SOCIETE_ASSURANCE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_societe_assurance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Batiment]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Batiment](
	[idOrganisation] [int] NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] IDENTITY(1,1) NOT NULL,
	[code] [int] NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_BATIMENT] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[idDelegation] ASC,
	[idBatiment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fournisseur]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fournisseur](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_fournisseur] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](254) NULL,
	[Prenom] [varchar](254) NULL,
	[Rue] [varchar](254) NULL,
	[Tel] [int] NULL,
	[Fax] [int] NULL,
	[Email] [varchar](254) NULL,
	[Commentaire] [varchar](254) NULL,
 CONSTRAINT [PK_FOURNISSEUR] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_fournisseur] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_maintenance]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_maintenance](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_societe_maintenance] [int] NOT NULL,
	[Id_contrat_maintenance] [int] IDENTITY(1,1) NOT NULL,
	[Type_maintenance] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_MAINTENANCE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_societe_maintenance] ASC,
	[Id_contrat_maintenance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_garanti]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_garanti](
	[Id_contrat_garanti] [int] IDENTITY(1,1) NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_fournisseur] [int] NOT NULL,
	[Type_garanti] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_GARANTI] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_fournisseur] ASC,
	[Id_contrat_garanti] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_assurance]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_assurance](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_societe_assurance] [int] NOT NULL,
	[Id_contrat_assurance] [int] IDENTITY(1,1) NOT NULL,
	[Type_assurance] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_ASSURANCE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idDelegation] ASC,
	[Id_societe_assurance] ASC,
	[Id_contrat_assurance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Etage]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Etage](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_etage] [int] NOT NULL,
	[code] [int] NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_ETAGE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[idDelegation] ASC,
	[idBatiment] ASC,
	[Id_etage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personnel](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_id] [int] NOT NULL,
	[nom] [varchar](254) NULL,
	[prenom] [varchar](254) NULL,
	[Matricule] [int] NULL,
 CONSTRAINT [PK_PERSONNEL] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[idDelegation] ASC,
	[idBatiment] ASC,
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parc_auto]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parc_auto](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_parc] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
 CONSTRAINT [PK_PARC_AUTO] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[idDelegation] ASC,
	[idBatiment] ASC,
	[Id_parc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Achat]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achat](
	[Id_achat] [int] IDENTITY(1,1) NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_fournisseur] [int] NOT NULL,
	[Date_livraison] [datetime] NULL,
	[Num_facture] [int] NULL,
	[Num_commande] [int] NULL,
	[Date_d_achat] [datetime] NULL,
	[Prix_d_achat] [numeric](18, 0) NULL,
	[Num_livraison] [int] NULL,
 CONSTRAINT [PK_ACHAT] PRIMARY KEY NONCLUSTERED 
(
	[Id_achat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicule]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehicule](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[Par_idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_parc] [int] NOT NULL,
	[Id_Vehicule] [int] IDENTITY(1,1) NOT NULL,
	[Con_idPays2] [int] NOT NULL,
	[Con_idRegion2] [int] NOT NULL,
	[Con_idGouvernorat2] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_fournisseur] [int] NULL,
	[Id_societe_assurance] [int] NOT NULL,
	[Id_contrat_assurance] [int] NOT NULL,
	[Con_idPays] [int] NOT NULL,
	[Con_idRegion] [int] NOT NULL,
	[Con_idGouvernorat] [int] NOT NULL,
	[Con_idDelegation] [int] NOT NULL,
	[Id_societe_maintenance] [int] NOT NULL,
	[Con_Id_contrat_assurance] [int] NOT NULL,
	[Id_achat] [int] NOT NULL,
	[Id_contrat_garanti] [int] NOT NULL,
	[Matricule] [varchar](254) NULL,
	[Modele] [varchar](254) NULL,
	[Etat] [varchar](254) NULL,
	[Num_sachet] [varchar](254) NULL,
	[Prix_d_achat] [numeric](18, 0) NULL,
 CONSTRAINT [PK_VEHICULE] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[Par_idDelegation] ASC,
	[idBatiment] ASC,
	[Id_parc] ASC,
	[Id_Vehicule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Per_id] [int] NOT NULL,
	[login] [varchar](254) NULL,
	[motDePasse] [varchar](254) NULL,
	[etatUtilisateur] [bit] NULL,
 CONSTRAINT [PK_UTILISATEUR] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bureau]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bureau](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_etage] [int] NOT NULL,
	[Id_direction] [int] NOT NULL,
	[Id_bureau] [int] NOT NULL,
	[Code_a_barre] [int] NULL,
	[Description] [varchar](254) NULL,
 CONSTRAINT [PK_BUREAU] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[idDelegation] ASC,
	[idBatiment] ASC,
	[Id_etage] ASC,
	[Id_direction] ASC,
	[Id_bureau] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bien]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bien](
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[Bur_idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_etage] [int] NOT NULL,
	[Id_direction] [int] NOT NULL,
	[Id_bureau] [int] NOT NULL,
	[Id_inventaire] [int] NOT NULL,
	[Id_bien] [int] IDENTITY(1,1) NOT NULL,
	[Id_categorie] [int] NOT NULL,
	[Id_achat] [int] NOT NULL,
	[Id_contrat_garanti] [int] NOT NULL,
	[Con_idPays] [int] NOT NULL,
	[Con_idRegion] [int] NOT NULL,
	[Con_idGouvernorat] [int] NOT NULL,
	[Con_idDelegation] [int] NOT NULL,
	[Id_societe_maintenance] [int] NOT NULL,
	[Id_contrat_assurance] [int] NOT NULL,
	[Con_idPays2] [int] NOT NULL,
	[Con_idRegion2] [int] NOT NULL,
	[Con_idGouvernorat2] [int] NOT NULL,
	[idDelegation] [int] NOT NULL,
	[Id_fournisseur] [int] NULL,
	[Id_societe_assurance] [int] NOT NULL,
	[Con_Id_contrat_assurance] [int] NOT NULL,
	[Designation] [varchar](254) NULL,
	[Marque] [varchar](254) NULL,
	[Modele] [varchar](254) NULL,
	[Code] [int] NULL,
	[Num_Serie] [int] NULL,
	[Etat] [varchar](254) NULL,
	[Valeur] [varchar](254) NULL,
	[Mode] [varchar](254) NULL,
	[Description] [varchar](254) NULL,
	[Detail] [varchar](254) NULL,
	[Code_a_barre] [int] NULL,
	[Emploi_principal] [varchar](254) NULL,
	[Date_d_installation] [datetime] NULL,
 CONSTRAINT [PK_BIEN] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[Bur_idDelegation] ASC,
	[idBatiment] ASC,
	[Id_etage] ASC,
	[Id_direction] ASC,
	[Id_bureau] ASC,
	[Id_inventaire] ASC,
	[Id_bien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Association_31]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Association_31](
	[Id_inventaire] [int] NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[Par_idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_parc] [int] NOT NULL,
	[Id_Vehicule] [int] NOT NULL,
 CONSTRAINT [PK_ASSOCIATION_31] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[Par_idDelegation] ASC,
	[idBatiment] ASC,
	[Id_parc] ASC,
	[Id_inventaire] ASC,
	[Id_Vehicule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mouvement]    Script Date: 12/29/2015 10:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mouvement](
	[Id_mouvement] [int] IDENTITY(1,1) NOT NULL,
	[Veh_idPays] [int] NOT NULL,
	[Veh_idRegion] [int] NOT NULL,
	[Veh_idGouvernorat] [int] NOT NULL,
	[Veh_idOrganisation] [int] NOT NULL,
	[Par_idDelegation] [int] NOT NULL,
	[idBatiment] [int] NOT NULL,
	[Id_parc] [int] NOT NULL,
	[Id_Vehicule] [int] NOT NULL,
	[idPays] [int] NOT NULL,
	[idRegion] [int] NOT NULL,
	[idGouvernorat] [int] NOT NULL,
	[idOrganisation] [int] NOT NULL,
	[Bur_idDelegation] [int] NOT NULL,
	[Bie_idBatiment] [int] NOT NULL,
	[Id_etage] [int] NOT NULL,
	[Id_direction] [int] NOT NULL,
	[Id_bureau] [int] NOT NULL,
	[Id_inventaire] [int] NOT NULL,
	[Id_bien] [int] NOT NULL,
	[Nom] [varchar](254) NULL,
	[Date_derniere_affectation] [datetime] NULL,
	[Date_prochaine_affectation] [datetime] NULL,
	[Date_renouvellement_prevue] [datetime] NULL,
	[Date_retour_prevue] [datetime] NULL,
	[Date_sortie] [datetime] NULL,
 CONSTRAINT [PK_MOUVEMENT] PRIMARY KEY NONCLUSTERED 
(
	[idPays] ASC,
	[idRegion] ASC,
	[idGouvernorat] ASC,
	[idOrganisation] ASC,
	[Bur_idDelegation] ASC,
	[Bie_idBatiment] ASC,
	[Id_etage] ASC,
	[Id_bureau] ASC,
	[Id_parc] ASC,
	[Id_inventaire] ASC,
	[Id_bien] ASC,
	[Id_Vehicule] ASC,
	[Id_mouvement] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_ACHAT_ASSOCIATI_FOURNISS]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Achat]  WITH CHECK ADD  CONSTRAINT [FK_ACHAT_ASSOCIATI_FOURNISS] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur])
REFERENCES [dbo].[Fournisseur] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Achat] CHECK CONSTRAINT [FK_ACHAT_ASSOCIATI_FOURNISS]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_INVENTAI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Association_31]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTAI] FOREIGN KEY([Id_inventaire])
REFERENCES [dbo].[Inventaire] ([Id_inventaire])
GO
ALTER TABLE [dbo].[Association_31] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTAI]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_VEHICULE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Association_31]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_VEHICULE] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Par_idDelegation], [idBatiment], [Id_parc], [Id_Vehicule])
REFERENCES [dbo].[Vehicule] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Par_idDelegation], [idBatiment], [Id_parc], [Id_Vehicule])
GO
ALTER TABLE [dbo].[Association_31] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_VEHICULE]
GO
/****** Object:  ForeignKey [FK_BATIMENT_ASSOCIATI_DELEGATI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Batiment]  WITH CHECK ADD  CONSTRAINT [FK_BATIMENT_ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Batiment] CHECK CONSTRAINT [FK_BATIMENT_ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_BATIMENT_ASSOCIATI_ORGANISA]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Batiment]  WITH CHECK ADD  CONSTRAINT [FK_BATIMENT_ASSOCIATI_ORGANISA] FOREIGN KEY([idOrganisation])
REFERENCES [dbo].[Organisation] ([idOrganisation])
GO
ALTER TABLE [dbo].[Batiment] CHECK CONSTRAINT [FK_BATIMENT_ASSOCIATI_ORGANISA]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_ACHAT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_ACHAT] FOREIGN KEY([Id_achat])
REFERENCES [dbo].[Achat] ([Id_achat])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_ACHAT]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_BUREAU]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_BUREAU] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Bur_idDelegation], [idBatiment], [Id_etage], [Id_direction], [Id_bureau])
REFERENCES [dbo].[Bureau] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [Id_etage], [Id_direction], [Id_bureau])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_BUREAU]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CATEGORI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CATEGORI] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie_materiel] ([Id_categorie])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CATEGORI]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur], [Id_contrat_garanti])
REFERENCES [dbo].[Contrat_garanti] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur], [Id_contrat_garanti])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT_]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_] FOREIGN KEY([Con_idPays], [Con_idRegion], [Con_idGouvernorat], [Con_idDelegation], [Id_societe_maintenance], [Id_contrat_assurance])
REFERENCES [dbo].[Contrat_maintenance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_maintenance], [Id_contrat_maintenance])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT_1]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_1] FOREIGN KEY([Con_idPays2], [Con_idRegion2], [Con_idGouvernorat2], [idDelegation], [Id_societe_assurance], [Con_Id_contrat_assurance])
REFERENCES [dbo].[Contrat_assurance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_assurance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_1]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_INVENTAI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_INVENTAI] FOREIGN KEY([Id_inventaire])
REFERENCES [dbo].[Inventaire] ([Id_inventaire])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_INVENTAI]
GO
/****** Object:  ForeignKey [FK_BUREAU_ASSOCIATI_DIRECTIO]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bureau]  WITH CHECK ADD  CONSTRAINT [FK_BUREAU_ASSOCIATI_DIRECTIO] FOREIGN KEY([Id_direction])
REFERENCES [dbo].[Direction] ([Id_direction])
GO
ALTER TABLE [dbo].[Bureau] CHECK CONSTRAINT [FK_BUREAU_ASSOCIATI_DIRECTIO]
GO
/****** Object:  ForeignKey [FK_BUREAU_ASSOCIATI_ETAGE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Bureau]  WITH CHECK ADD  CONSTRAINT [FK_BUREAU_ASSOCIATI_ETAGE] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [Id_etage])
REFERENCES [dbo].[Etage] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [Id_etage])
GO
ALTER TABLE [dbo].[Bureau] CHECK CONSTRAINT [FK_BUREAU_ASSOCIATI_ETAGE]
GO
/****** Object:  ForeignKey [FK_CATEGORI_ASSOCIATI_CATEGORI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[CategorieDesignation]  WITH CHECK ADD  CONSTRAINT [FK_CATEGORI_ASSOCIATI_CATEGORI] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie_materiel] ([Id_categorie])
GO
ALTER TABLE [dbo].[CategorieDesignation] CHECK CONSTRAINT [FK_CATEGORI_ASSOCIATI_CATEGORI]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_SOCIETE_1]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Contrat_assurance]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE_1] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_assurance])
REFERENCES [dbo].[Societe_assurance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_assurance])
GO
ALTER TABLE [dbo].[Contrat_assurance] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE_1]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_FOURNISS]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Contrat_garanti]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_FOURNISS] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur])
REFERENCES [dbo].[Fournisseur] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Contrat_garanti] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_FOURNISS]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_SOCIETE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Contrat_maintenance]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_maintenance])
REFERENCES [dbo].[Societe_maintenance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_maintenance])
GO
ALTER TABLE [dbo].[Contrat_maintenance] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE]
GO
/****** Object:  ForeignKey [FK_DELEGATI_ASSOCIATI_GOUVERNO]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Delegation]  WITH CHECK ADD  CONSTRAINT [FK_DELEGATI_ASSOCIATI_GOUVERNO] FOREIGN KEY([idPays], [idRegion], [idGouvernorat])
REFERENCES [dbo].[Gouvernorat] ([idPays], [idRegion], [idGouvernorat])
GO
ALTER TABLE [dbo].[Delegation] CHECK CONSTRAINT [FK_DELEGATI_ASSOCIATI_GOUVERNO]
GO
/****** Object:  ForeignKey [FK_ETAGE_ASSOCIATI_BATIMENT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Etage]  WITH CHECK ADD  CONSTRAINT [FK_ETAGE_ASSOCIATI_BATIMENT] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Etage] CHECK CONSTRAINT [FK_ETAGE_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_FOURNISS_ASSOCIATI_DELEGATI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Fournisseur]  WITH CHECK ADD  CONSTRAINT [FK_FOURNISS_ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Fournisseur] CHECK CONSTRAINT [FK_FOURNISS_ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_GOUVERNO_ASSOCIATI_REGION]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Gouvernorat]  WITH CHECK ADD  CONSTRAINT [FK_GOUVERNO_ASSOCIATI_REGION] FOREIGN KEY([idPays], [idRegion])
REFERENCES [dbo].[Region] ([idPays], [idRegion])
GO
ALTER TABLE [dbo].[Gouvernorat] CHECK CONSTRAINT [FK_GOUVERNO_ASSOCIATI_REGION]
GO
/****** Object:  ForeignKey [FK_MOUVEMEN_ASSOCIATI_BIEN]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Mouvement]  WITH CHECK ADD  CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_BIEN] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Bur_idDelegation], [Bie_idBatiment], [Id_etage], [Id_direction], [Id_bureau], [Id_inventaire], [Id_bien])
REFERENCES [dbo].[Bien] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Bur_idDelegation], [idBatiment], [Id_etage], [Id_direction], [Id_bureau], [Id_inventaire], [Id_bien])
GO
ALTER TABLE [dbo].[Mouvement] CHECK CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_BIEN]
GO
/****** Object:  ForeignKey [FK_MOUVEMEN_ASSOCIATI_VEHICULE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Mouvement]  WITH CHECK ADD  CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_VEHICULE] FOREIGN KEY([Veh_idPays], [Veh_idRegion], [Veh_idGouvernorat], [Veh_idOrganisation], [Par_idDelegation], [idBatiment], [Id_parc], [Id_Vehicule])
REFERENCES [dbo].[Vehicule] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Par_idDelegation], [idBatiment], [Id_parc], [Id_Vehicule])
GO
ALTER TABLE [dbo].[Mouvement] CHECK CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_VEHICULE]
GO
/****** Object:  ForeignKey [FK_PARC_AUT_ASSOCIATI_BATIMENT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Parc_auto]  WITH CHECK ADD  CONSTRAINT [FK_PARC_AUT_ASSOCIATI_BATIMENT] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Parc_auto] CHECK CONSTRAINT [FK_PARC_AUT_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_PERSONNE_ASSOCIATI_BATIMENT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_PERSONNE_ASSOCIATI_BATIMENT] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [FK_PERSONNE_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_PERSONNE_ASSOCIATI_ROLE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_PERSONNE_ASSOCIATI_ROLE] FOREIGN KEY([Rol_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [FK_PERSONNE_ASSOCIATI_ROLE]
GO
/****** Object:  ForeignKey [FK_REGION_ASSOCIATI_PAYS]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_REGION_ASSOCIATI_PAYS] FOREIGN KEY([idPays])
REFERENCES [dbo].[Pays] ([idPays])
GO
ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_REGION_ASSOCIATI_PAYS]
GO
/****** Object:  ForeignKey [FK_SERVICE_ASSOCIATI_DIRECTIO]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_SERVICE_ASSOCIATI_DIRECTIO] FOREIGN KEY([Id_direction])
REFERENCES [dbo].[Direction] ([Id_direction])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_SERVICE_ASSOCIATI_DIRECTIO]
GO
/****** Object:  ForeignKey [FK_SOCIETE__ASSOCIATI_DELEGATI]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Societe_assurance]  WITH CHECK ADD  CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Societe_assurance] CHECK CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_SOCIETE__ASSOCIATI_DELEGATION]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Societe_maintenance]  WITH CHECK ADD  CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATION] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Societe_maintenance] CHECK CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATION]
GO
/****** Object:  ForeignKey [FK_UTILISAT_ASSOCIATI_PERSONNE]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Utilisateur]  WITH CHECK ADD  CONSTRAINT [FK_UTILISAT_ASSOCIATI_PERSONNE] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [Per_id])
REFERENCES [dbo].[Personnel] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [id])
GO
ALTER TABLE [dbo].[Utilisateur] CHECK CONSTRAINT [FK_UTILISAT_ASSOCIATI_PERSONNE]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_ACHAT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_ACHAT] FOREIGN KEY([Id_achat])
REFERENCES [dbo].[Achat] ([Id_achat])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_ACHAT]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_] FOREIGN KEY([Con_idPays], [Con_idRegion], [Con_idGouvernorat], [Con_idDelegation], [Id_societe_maintenance], [Con_Id_contrat_assurance])
REFERENCES [dbo].[Contrat_maintenance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_maintenance], [Id_contrat_maintenance])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_2]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_2] FOREIGN KEY([Con_idPays2], [Con_idRegion2], [Con_idGouvernorat2], [idDelegation], [Id_societe_assurance], [Id_contrat_assurance])
REFERENCES [dbo].[Contrat_assurance] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_societe_assurance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_2]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_3]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_3] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur], [Id_contrat_garanti])
REFERENCES [dbo].[Contrat_garanti] ([idPays], [idRegion], [idGouvernorat], [idDelegation], [Id_fournisseur], [Id_contrat_garanti])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_3]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_PARC_AUT]    Script Date: 12/29/2015 10:47:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_PARC_AUT] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idOrganisation], [Par_idDelegation], [idBatiment], [Id_parc])
REFERENCES [dbo].[Parc_auto] ([idPays], [idRegion], [idGouvernorat], [idOrganisation], [idDelegation], [idBatiment], [Id_parc])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_PARC_AUT]
GO
