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
    
    public partial class Bouquet_flowers
    {
        public int Id_Bouquet_flowers { get; set; }
        public int Id_flower { get; set; }
        public int Id_bouquet { get; set; }
    
        public virtual Bouquet Bouquet { get; set; }
        public virtual Flowers Flowers { get; set; }
    }
}