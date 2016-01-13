//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bien()
        {
            this.Association_30 = new HashSet<Association_30>();
            this.Association_49 = new HashSet<Association_49>();
            this.MouvementB = new HashSet<MouvementB>();
        }
    
        public Nullable<int> idBatiment { get; set; }
        public int Id_etage { get; set; }
        public Nullable<int> Dep_idPays { get; set; }
        public Nullable<int> Dep_idRegion { get; set; }
        public Nullable<int> Dep_idGouvernorat { get; set; }
        public Nullable<int> idDelegation { get; set; }
        public Nullable<int> IdDepot { get; set; }
        public int Id_bien { get; set; }
        public Nullable<int> Id_categorie { get; set; }
        public Nullable<int> Id_achat { get; set; }
        public Nullable<int> Id_contrat_garanti { get; set; }
        public Nullable<int> Id_societe_maintenance { get; set; }
        public Nullable<int> Id_contrat_maintenance { get; set; }
        public Nullable<int> Id_societe_assurance { get; set; }
        public Nullable<int> Id_contrat_assurance { get; set; }
        public string Designation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<int> Num_Serie { get; set; }
        public string Etat { get; set; }
        public string Valeur { get; set; }
        public string Mode { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public Nullable<int> Code_a_barre { get; set; }
        public string Emploi_principal { get; set; }
        public Nullable<System.DateTime> Date_d_installation { get; set; }
    
        public virtual Achat Achat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Association_30> Association_30 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Association_49> Association_49 { get; set; }
        public virtual Categorie_materiel Categorie_materiel { get; set; }
        public virtual Contrat_garanti Contrat_garanti { get; set; }
        public virtual Contrat_assurance Contrat_assurance { get; set; }
        public virtual Depot Depot { get; set; }
        public virtual Etage Etage { get; set; }
        public virtual Contrat_maintenance Contrat_maintenance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MouvementB> MouvementB { get; set; }
    }
}
