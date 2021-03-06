USE [BissInventaire]
GO
/****** Object:  Table [dbo].[Direction]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Categorie_materiel]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorie_materiel](
	[Id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](254) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATEGORIE_MATERIEL] PRIMARY KEY NONCLUSTERED 
(
	[Id_categorie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventaire]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Organisation]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Pays]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Region]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[ServiceD]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceD](
	[Id_direction] [int] NOT NULL,
	[Id_service] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
 CONSTRAINT [PK_SERVICED] PRIMARY KEY NONCLUSTERED 
(
	[Id_direction] ASC,
	[Id_service] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategorieDesignation]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieDesignation](
	[Id_categorie] [int] NOT NULL,
	[id_categorie_Designation] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATEGORIEDESIGNATION] PRIMARY KEY NONCLUSTERED 
(
	[Id_categorie] ASC,
	[id_categorie_Designation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gouvernorat]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Delegation]    Script Date: 12/30/2015 12:53:41 ******/
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
/****** Object:  Table [dbo].[Societe_maintenance]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Societe_maintenance](
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
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
	[idDelegation] ASC,
	[Id_societe_maintenance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Societe_assurance]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Societe_assurance](
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
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
	[idDelegation] ASC,
	[Id_societe_assurance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Batiment]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Batiment](
	[idOrganisation] [int] NULL,
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
	[idDelegation] [int] NOT NULL,
	[idBatiment] [int] IDENTITY(1,1) NOT NULL,
	[code] [int] NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_BATIMENT] PRIMARY KEY NONCLUSTERED 
(
	[idDelegation] ASC,
	[idBatiment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fournisseur]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fournisseur](
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
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
	[idDelegation] ASC,
	[Id_fournisseur] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_maintenance]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_maintenance](
	[idDelegation] [int] NULL,
	[Id_societe_maintenance] [int] NOT NULL,
	[Id_contrat_assurance] [int] IDENTITY(1,1) NOT NULL,
	[Type_maintenance] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_MAINTENANCE] PRIMARY KEY NONCLUSTERED 
(
	[Id_societe_maintenance] ASC,
	[Id_contrat_assurance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_garanti]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_garanti](
	[Id_contrat_garanti] [int] IDENTITY(1,1) NOT NULL,
	[idDelegation] [int] NULL,
	[Id_fournisseur] [int] NOT NULL,
	[Type_garanti] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_GARANTI] PRIMARY KEY NONCLUSTERED 
(
	[Id_contrat_garanti] ASC,
	[Id_fournisseur] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrat_assurance]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrat_assurance](
	[idDelegation] [int] NULL,
	[Id_societe_assurance] [int] NOT NULL,
	[Id_contrat_assurance] [int] IDENTITY(1,1) NOT NULL,
	[Type_assurance] [varchar](254) NULL,
	[Num] [int] NULL,
	[Date_debut] [datetime] NULL,
	[Date_fin] [datetime] NULL,
	[Cout] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CONTRAT_ASSURANCE] PRIMARY KEY NONCLUSTERED 
(
	[Id_societe_assurance] ASC,
	[Id_contrat_assurance] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Etage]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Etage](
	[idDelegation] [int] NULL,
	[idBatiment] [int] NOT NULL,
	[Id_etage] [int] NOT NULL,
	[code] [int] NULL,
	[description] [varchar](254) NULL,
 CONSTRAINT [PK_ETAGE] PRIMARY KEY NONCLUSTERED 
(
	[idBatiment] ASC,
	[Id_etage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personnel](
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
	[idOrganisation] [int] NULL,
	[idDelegation] [int] NULL,
	[idBatiment] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_id] [int] NOT NULL,
	[nom] [varchar](254) NULL,
	[prenom] [varchar](254) NULL,
	[Matricule] [int] NULL,
 CONSTRAINT [PK_PERSONNEL] PRIMARY KEY NONCLUSTERED 
(
	[idBatiment] ASC,
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parc_auto]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parc_auto](
	[idDelegation] [int] NULL,
	[idBatiment] [int] NOT NULL,
	[Id_parc] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [varchar](254) NULL,
 CONSTRAINT [PK_PARC_AUTO] PRIMARY KEY NONCLUSTERED 
(
	[idBatiment] ASC,
	[Id_parc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Achat]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achat](
	[Id_achat] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Vehicule]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehicule](
	[Id_contrat_garanti] [int] NULL,
	[idBatiment] [int] NULL,
	[Id_parc] [int] NOT NULL,
	[Id_Vehicule] [int] IDENTITY(1,1) NOT NULL,
	[Id_fournisseur] [int] NULL,
	[Id_societe_assurance] [int] NULL,
	[Id_contrat_assurance] [int] NULL,
	[Id_societe_maintenance] [int] NULL,
	[Con_Id_contrat_assurance] [int] NULL,
	[Id_achat] [int] NULL,
	[Matricule] [varchar](254) NULL,
	[Modele] [varchar](254) NULL,
	[Etat] [varchar](254) NULL,
	[Num_sachet] [varchar](254) NULL,
	[Prix_d_achat] [numeric](18, 0) NULL,
 CONSTRAINT [PK_VEHICULE] PRIMARY KEY NONCLUSTERED 
(
	[Id_parc] ASC,
	[Id_Vehicule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Bureau]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bureau](
	[idBatiment] [int] NULL,
	[Id_etage] [int] NOT NULL,
	[Id_direction] [int] NOT NULL,
	[Id_bureau] [int] NOT NULL,
	[Code_a_barre] [int] NULL,
	[Description] [varchar](254) NULL,
 CONSTRAINT [PK_BUREAU] PRIMARY KEY NONCLUSTERED 
(
	[Id_etage] ASC,
	[Id_direction] ASC,
	[Id_bureau] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bien]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bien](
	[Id_contrat_garanti] [int] NULL,
	[Id_etage] [int] NULL,
	[Id_direction] [int] NULL,
	[Id_bureau] [int] NOT NULL,
	[Id_bien] [int] IDENTITY(1,1) NOT NULL,
	[Id_categorie] [int] NULL,
	[Id_achat] [int] NULL,
	[Id_societe_maintenance] [int] NULL,
	[Id_contrat_assurance] [int] NULL,
	[Id_fournisseur] [int] NULL,
	[Id_societe_assurance] [int] NULL,
	[Con_Id_contrat_assurance] [int] NULL,
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
	[Id_bureau] ASC,
	[Id_bien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Association_31]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Association_31](
	[Id_inventaire] [int] NOT NULL,
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
	[idOrganisation] [int] NULL,
	[Par_idDelegation] [int] NULL,
	[idBatiment] [int] NULL,
	[Id_parc] [int] NULL,
	[Id_Vehicule] [int] NOT NULL,
 CONSTRAINT [PK_ASSOCIATION_31] PRIMARY KEY NONCLUSTERED 
(
	[Id_inventaire] ASC,
	[Id_Vehicule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mouvement]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mouvement](
	[Id_mouvement] [int] IDENTITY(1,1) NOT NULL,
	[idBatiment] [int] NULL,
	[Id_parc] [int] NULL,
	[Id_Vehicule] [int] NULL,
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
	[idOrganisation] [int] NULL,
	[Bur_idDelegation] [int] NULL,
	[Bie_idBatiment] [int] NULL,
	[Id_etage] [int] NULL,
	[Id_bureau] [int] NULL,
	[Id_bien] [int] NULL,
	[Nom] [varchar](254) NULL,
	[Date_derniere_affectation] [datetime] NULL,
	[Date_prochaine_affectation] [datetime] NULL,
	[Date_renouvellement_prevue] [datetime] NULL,
	[Date_retour_prevue] [datetime] NULL,
	[Date_sortie] [datetime] NULL,
 CONSTRAINT [PK_MOUVEMENT] PRIMARY KEY NONCLUSTERED 
(
	[Id_mouvement] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Association_30]    Script Date: 12/30/2015 12:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Association_30](
	[Id_inventaire] [int] NOT NULL,
	[idPays] [int] NULL,
	[idRegion] [int] NULL,
	[idGouvernorat] [int] NULL,
	[idOrganisation] [int] NULL,
	[Bur_idDelegation] [int] NULL,
	[idBatiment] [int] NULL,
	[Id_etage] [int] NULL,
	[Id_direction] [int] NULL,
	[Id_bureau] [int] NULL,
	[Id_bien] [int] NOT NULL,
 CONSTRAINT [PK_ASSOCIATION_30] PRIMARY KEY CLUSTERED 
(
	[Id_inventaire] ASC,
	[Id_bien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ACHAT_ASSOCIATI_FOURNISS]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Achat]  WITH CHECK ADD  CONSTRAINT [FK_ACHAT_ASSOCIATI_FOURNISS] FOREIGN KEY([idDelegation], [Id_fournisseur])
REFERENCES [dbo].[Fournisseur] ([idDelegation], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Achat] CHECK CONSTRAINT [FK_ACHAT_ASSOCIATI_FOURNISS]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_BIEN]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Association_30]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_BIEN] FOREIGN KEY([Id_bureau], [Id_bien])
REFERENCES [dbo].[Bien] ([Id_bureau], [Id_bien])
GO
ALTER TABLE [dbo].[Association_30] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_BIEN]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_INVENTA]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Association_30]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTA] FOREIGN KEY([Id_inventaire])
REFERENCES [dbo].[Inventaire] ([Id_inventaire])
GO
ALTER TABLE [dbo].[Association_30] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTA]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_INVENTAI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Association_31]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTAI] FOREIGN KEY([Id_inventaire])
REFERENCES [dbo].[Inventaire] ([Id_inventaire])
GO
ALTER TABLE [dbo].[Association_31] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_INVENTAI]
GO
/****** Object:  ForeignKey [FK_ASSOCIAT_ASSOCIATI_VEHICULE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Association_31]  WITH CHECK ADD  CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_VEHICULE] FOREIGN KEY([Id_parc], [Id_Vehicule])
REFERENCES [dbo].[Vehicule] ([Id_parc], [Id_Vehicule])
GO
ALTER TABLE [dbo].[Association_31] CHECK CONSTRAINT [FK_ASSOCIAT_ASSOCIATI_VEHICULE]
GO
/****** Object:  ForeignKey [FK_BATIMENT_ASSOCIATI_DELEGATI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Batiment]  WITH CHECK ADD  CONSTRAINT [FK_BATIMENT_ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Batiment] CHECK CONSTRAINT [FK_BATIMENT_ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_BATIMENT_ASSOCIATI_ORGANISA]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Batiment]  WITH CHECK ADD  CONSTRAINT [FK_BATIMENT_ASSOCIATI_ORGANISA] FOREIGN KEY([idOrganisation])
REFERENCES [dbo].[Organisation] ([idOrganisation])
GO
ALTER TABLE [dbo].[Batiment] CHECK CONSTRAINT [FK_BATIMENT_ASSOCIATI_ORGANISA]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_ACHAT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_ACHAT] FOREIGN KEY([Id_achat])
REFERENCES [dbo].[Achat] ([Id_achat])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_ACHAT]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_BUREAU]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_BUREAU] FOREIGN KEY([Id_etage], [Id_direction], [Id_bureau])
REFERENCES [dbo].[Bureau] ([Id_etage], [Id_direction], [Id_bureau])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_BUREAU]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CATEGORI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CATEGORI] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie_materiel] ([Id_categorie])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CATEGORI]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT] FOREIGN KEY([Id_contrat_garanti], [Id_fournisseur])
REFERENCES [dbo].[Contrat_garanti] ([Id_contrat_garanti], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT_]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_] FOREIGN KEY([Id_societe_maintenance], [Id_contrat_assurance])
REFERENCES [dbo].[Contrat_maintenance] ([Id_societe_maintenance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_]
GO
/****** Object:  ForeignKey [FK_BIEN_ASSOCIATI_CONTRAT_1]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_1] FOREIGN KEY([Id_societe_assurance], [Con_Id_contrat_assurance])
REFERENCES [dbo].[Contrat_assurance] ([Id_societe_assurance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_BIEN_ASSOCIATI_CONTRAT_1]
GO
/****** Object:  ForeignKey [FK_BUREAU_ASSOCIATI_DIRECTIO]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bureau]  WITH CHECK ADD  CONSTRAINT [FK_BUREAU_ASSOCIATI_DIRECTIO] FOREIGN KEY([Id_direction])
REFERENCES [dbo].[Direction] ([Id_direction])
GO
ALTER TABLE [dbo].[Bureau] CHECK CONSTRAINT [FK_BUREAU_ASSOCIATI_DIRECTIO]
GO
/****** Object:  ForeignKey [FK_BUREAU_ASSOCIATI_ETAGE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Bureau]  WITH CHECK ADD  CONSTRAINT [FK_BUREAU_ASSOCIATI_ETAGE] FOREIGN KEY([idBatiment], [Id_etage])
REFERENCES [dbo].[Etage] ([idBatiment], [Id_etage])
GO
ALTER TABLE [dbo].[Bureau] CHECK CONSTRAINT [FK_BUREAU_ASSOCIATI_ETAGE]
GO
/****** Object:  ForeignKey [FK_CATEGORI_ASSOCIATI_CATEGORI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[CategorieDesignation]  WITH CHECK ADD  CONSTRAINT [FK_CATEGORI_ASSOCIATI_CATEGORI] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie_materiel] ([Id_categorie])
GO
ALTER TABLE [dbo].[CategorieDesignation] CHECK CONSTRAINT [FK_CATEGORI_ASSOCIATI_CATEGORI]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_SOCIETE_1]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Contrat_assurance]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE_1] FOREIGN KEY([idDelegation], [Id_societe_assurance])
REFERENCES [dbo].[Societe_assurance] ([idDelegation], [Id_societe_assurance])
GO
ALTER TABLE [dbo].[Contrat_assurance] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE_1]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_FOURNISS]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Contrat_garanti]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_FOURNISS] FOREIGN KEY([idDelegation], [Id_fournisseur])
REFERENCES [dbo].[Fournisseur] ([idDelegation], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Contrat_garanti] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_FOURNISS]
GO
/****** Object:  ForeignKey [FK_CONTRAT__ASSOCIATI_SOCIETE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Contrat_maintenance]  WITH CHECK ADD  CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE] FOREIGN KEY([idDelegation], [Id_societe_maintenance])
REFERENCES [dbo].[Societe_maintenance] ([idDelegation], [Id_societe_maintenance])
GO
ALTER TABLE [dbo].[Contrat_maintenance] CHECK CONSTRAINT [FK_CONTRAT__ASSOCIATI_SOCIETE]
GO
/****** Object:  ForeignKey [FK_DELEGATI_ASSOCIATI_GOUVERNO]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Delegation]  WITH CHECK ADD  CONSTRAINT [FK_DELEGATI_ASSOCIATI_GOUVERNO] FOREIGN KEY([idPays], [idRegion], [idGouvernorat])
REFERENCES [dbo].[Gouvernorat] ([idPays], [idRegion], [idGouvernorat])
GO
ALTER TABLE [dbo].[Delegation] CHECK CONSTRAINT [FK_DELEGATI_ASSOCIATI_GOUVERNO]
GO
/****** Object:  ForeignKey [FK_ETAGE_ASSOCIATI_BATIMENT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Etage]  WITH CHECK ADD  CONSTRAINT [FK_ETAGE_ASSOCIATI_BATIMENT] FOREIGN KEY([idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Etage] CHECK CONSTRAINT [FK_ETAGE_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_FOURNISS_ASSOCIATI_DELEGATI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Fournisseur]  WITH CHECK ADD  CONSTRAINT [FK_FOURNISS_ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Fournisseur] CHECK CONSTRAINT [FK_FOURNISS_ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_GOUVERNO_ASSOCIATI_REGION]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Gouvernorat]  WITH CHECK ADD  CONSTRAINT [FK_GOUVERNO_ASSOCIATI_REGION] FOREIGN KEY([idPays], [idRegion])
REFERENCES [dbo].[Region] ([idPays], [idRegion])
GO
ALTER TABLE [dbo].[Gouvernorat] CHECK CONSTRAINT [FK_GOUVERNO_ASSOCIATI_REGION]
GO
/****** Object:  ForeignKey [FK_MOUVEMEN_ASSOCIATI_BIEN]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Mouvement]  WITH CHECK ADD  CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_BIEN] FOREIGN KEY([Id_bureau], [Id_bien])
REFERENCES [dbo].[Bien] ([Id_bureau], [Id_bien])
GO
ALTER TABLE [dbo].[Mouvement] CHECK CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_BIEN]
GO
/****** Object:  ForeignKey [FK_MOUVEMEN_ASSOCIATI_VEHICULE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Mouvement]  WITH CHECK ADD  CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_VEHICULE] FOREIGN KEY([Id_parc], [Id_Vehicule])
REFERENCES [dbo].[Vehicule] ([Id_parc], [Id_Vehicule])
GO
ALTER TABLE [dbo].[Mouvement] CHECK CONSTRAINT [FK_MOUVEMEN_ASSOCIATI_VEHICULE]
GO
/****** Object:  ForeignKey [FK_PARC_AUT_ASSOCIATI_BATIMENT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Parc_auto]  WITH CHECK ADD  CONSTRAINT [FK_PARC_AUT_ASSOCIATI_BATIMENT] FOREIGN KEY([idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Parc_auto] CHECK CONSTRAINT [FK_PARC_AUT_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_PERSONNE_ASSOCIATI_BATIMENT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_PERSONNE_ASSOCIATI_BATIMENT] FOREIGN KEY([idDelegation], [idBatiment])
REFERENCES [dbo].[Batiment] ([idDelegation], [idBatiment])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [FK_PERSONNE_ASSOCIATI_BATIMENT]
GO
/****** Object:  ForeignKey [FK_PERSONNE_ASSOCIATI_ROLE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_PERSONNE_ASSOCIATI_ROLE] FOREIGN KEY([Rol_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [FK_PERSONNE_ASSOCIATI_ROLE]
GO
/****** Object:  ForeignKey [FK_REGION_ASSOCIATI_PAYS]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_REGION_ASSOCIATI_PAYS] FOREIGN KEY([idPays])
REFERENCES [dbo].[Pays] ([idPays])
GO
ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_REGION_ASSOCIATI_PAYS]
GO
/****** Object:  ForeignKey [FK_SERVICED_ASSOCIATI_DIRECTIO]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[ServiceD]  WITH CHECK ADD  CONSTRAINT [FK_SERVICED_ASSOCIATI_DIRECTIO] FOREIGN KEY([Id_direction])
REFERENCES [dbo].[Direction] ([Id_direction])
GO
ALTER TABLE [dbo].[ServiceD] CHECK CONSTRAINT [FK_SERVICED_ASSOCIATI_DIRECTIO]
GO
/****** Object:  ForeignKey [FK_SOCIETE__ASSOCIATI_DELEGATI]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Societe_assurance]  WITH CHECK ADD  CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATI] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Societe_assurance] CHECK CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATI]
GO
/****** Object:  ForeignKey [FK_SOCIETE__ASSOCIATI_DELEGATION]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Societe_maintenance]  WITH CHECK ADD  CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATION] FOREIGN KEY([idPays], [idRegion], [idGouvernorat], [idDelegation])
REFERENCES [dbo].[Delegation] ([idPays], [idRegion], [idGouvernorat], [idDelegation])
GO
ALTER TABLE [dbo].[Societe_maintenance] CHECK CONSTRAINT [FK_SOCIETE__ASSOCIATI_DELEGATION]
GO
/****** Object:  ForeignKey [FK_UTILISAT_ASSOCIATI_PERSONNE]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Utilisateur]  WITH CHECK ADD  CONSTRAINT [FK_UTILISAT_ASSOCIATI_PERSONNE] FOREIGN KEY([idBatiment], [Per_id])
REFERENCES [dbo].[Personnel] ([idBatiment], [id])
GO
ALTER TABLE [dbo].[Utilisateur] CHECK CONSTRAINT [FK_UTILISAT_ASSOCIATI_PERSONNE]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_ACHAT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_ACHAT] FOREIGN KEY([Id_achat])
REFERENCES [dbo].[Achat] ([Id_achat])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_ACHAT]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_] FOREIGN KEY([Id_societe_maintenance], [Con_Id_contrat_assurance])
REFERENCES [dbo].[Contrat_maintenance] ([Id_societe_maintenance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_2]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_2] FOREIGN KEY([Id_societe_assurance], [Id_contrat_assurance])
REFERENCES [dbo].[Contrat_assurance] ([Id_societe_assurance], [Id_contrat_assurance])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_2]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_CONTRAT_3]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_3] FOREIGN KEY([Id_contrat_garanti], [Id_fournisseur])
REFERENCES [dbo].[Contrat_garanti] ([Id_contrat_garanti], [Id_fournisseur])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_CONTRAT_3]
GO
/****** Object:  ForeignKey [FK_VEHICULE_ASSOCIATI_PARC_AUT]    Script Date: 12/30/2015 12:53:41 ******/
ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_VEHICULE_ASSOCIATI_PARC_AUT] FOREIGN KEY([idBatiment], [Id_parc])
REFERENCES [dbo].[Parc_auto] ([idBatiment], [Id_parc])
GO
ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_VEHICULE_ASSOCIATI_PARC_AUT]
GO
