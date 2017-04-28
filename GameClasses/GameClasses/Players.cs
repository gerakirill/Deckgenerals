namespace GameClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Players
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Players()
        {
            Deck = new HashSet<Deck>();
        }

        [Key]
        [StringLength(30)]
        public string PlayerName { get; set; }

        [Required]
        [StringLength(30)]
        public string PlayerPassword { get; set; }

        [Required]
        [StringLength(40)]
        public string PlayerEmail { get; set; }

        public int PlayerPoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deck> Deck { get; set; }
    }
}
