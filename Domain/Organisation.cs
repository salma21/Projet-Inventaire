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
    
    public partial class Organisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisation()
        {
            this.Batiment = new HashSet<Batiment>();
        }
    
        public int idOrganisation { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public byte[] Logo { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string adresse { get; set; }
        public string Matricule_fiscale { get; set; }
        public string Email { get; set; }
        public string Registre_de_commerce { get; set; }
        public string Site_web { get; set; }
        public string ville { get; set; }
        public string pays { get; set; }
        public string gouvernorat { get; set; }
        public string localié { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batiment> Batiment { get; set; }
    }
}
