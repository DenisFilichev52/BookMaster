//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMaster.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookSubject
    {
        public int BookSubjectId { get; set; }
        public string BookId { get; set; }
        public int SubjectId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
