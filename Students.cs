//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public int Id { get; set; }
        public int Class_Id { get; set; }
        public string st_last_name { get; set; }
        public string st_first_name { get; set; }
        public string st_middle_name { get; set; }
    
        public virtual Classes Classes { get; set; }
    }
}
