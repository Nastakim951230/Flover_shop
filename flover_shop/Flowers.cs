//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace flover_shop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flowers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flowers()
        {
            this.Bouquet_flowers = new HashSet<Bouquet_flowers>();
        }
    
        public int Id_Flower { get; set; }
        public string Name_flower { get; set; }
        public int Kolvo { get; set; }
        public int Price { get; set; }
        public byte[] Pfoto_flower { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bouquet_flowers> Bouquet_flowers { get; set; }
    }
}
